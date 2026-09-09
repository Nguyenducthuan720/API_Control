# Kế hoạch HTML làm nguồn chuẩn cho export

## Mục tiêu

Chuyển phần dựng biểu mẫu sang một luồng có nguồn HTML chuẩn để cùng một dữ
liệu nghiệp vụ tạo được các file:

```text
Procedure legacy
  -> JSON + TableJson + thông tin chữ ký
  -> template HTML/HBS
  -> HTML đã điền dữ liệu
       -> HTML
       -> PDF
       -> XLSX
       -> DOCX
```

HTML phải giữ được form cố định, logo, bảng, ô gộp và vị trí chữ ký của mẫu.
Các trường không có dữ liệu tiếp tục giữ nguyên placeholder `@...`, không tự
điền dữ liệu giả và không tự chèn chữ ký.

Khi xuất XLSX từ HTML đã chỉnh sửa, HTML chỉ là nguồn dữ liệu. Layout XLSX
vẫn lấy từ template OpenXML gốc; không dựng một workbook mới từ các thẻ HTML.

## Phạm vi dữ liệu và nghiệp vụ

- Tiếp tục lấy `JsonData`, `JsonTableData`, `SignType`, `CurrentStep`,
  `UserFullName` và các giá trị liên quan từ luồng `ExecExportPDF` hiện tại.
- Không viết lại procedure, không thay đổi điều kiện nghiệp vụ, approval,
  history, transaction hoặc cập nhật database trong phạm vi chuyển đổi format.
- Tái sử dụng cách thay placeholder, table JSON và xử lý SVG hiện có của
  `FileExcelAPI`/`FileSVG`.
- Chữ ký chỉ được render khi procedure trả về dữ liệu `@SignLink_C1` đến
  `@SignLink_C99` cho đúng vị trí. Nếu không có dữ liệu thì giữ cả
  `@SignLink_C*` và `@SignNote_C*` trong HTML.
- `@UserName` và `@NgayKy` trong SVG được thay theo cùng quy tắc của luồng
  Excel/PDF/Word trước khi SVG được chuyển thành PNG và nhúng dạng base64.

## Tương thích luồng cũ

- Nhánh chọn template `.xlsx/.xls`, `.doc/.docx` và `.pdf` hiện tại giữ
  nguyên; không chuyển chúng qua HTML âm thầm.
- Nhánh HTML mới chỉ chạy khi template có đuôi `.html`, `.htm`, `.hbs`,
  `.handlebars` hoặc khi request chọn rõ output HTML.
- Không dùng `FormPrints` làm runtime source cho nhánh mới vì môi trường local
  không bảo đảm truy cập được file trong DB. Template HTML phải là file được
  cấu hình/đóng gói trong source hoặc storage đã được cấu hình.
- Việc lưu file và cập nhật link dùng lại folder/link hiện có. Nếu storage
  remote không phục vụ file, API phải báo rõ lỗi thay vì ghi link 404.

## Hợp đồng template HTML

Để HTML có thể chuyển ngược sang các định dạng khác một cách ổn định, template
mới phải dùng layout cố định và có kiểm soát:

- Bảng HTML là cấu trúc chính cho biểu mẫu; dùng `rowspan`/`colspan` cho ô
  gộp.
- Kích thước, font, border, màu, căn lề và padding dùng CSS inline hoặc class
  đã quy ước.
- Ảnh/logo/chữ ký dùng đường dẫn an toàn hoặc `data:image/...;base64,...`.
- Giá trị cần giữ kiểu khi xuất Excel/Word có thể khai báo bằng `data-*`, ví dụ
  `data-excel-type="number"`, `data-excel-format`, `data-formula`.
- Không cam kết chuyển đổi pixel-perfect cho HTML tùy ý. Adapter chỉ hỗ trợ
  contract trên và phải báo phần tử không hỗ trợ, không âm thầm làm mất dữ
  liệu.

## Các thành phần sẽ triển khai

1. `FileHTML`: render template HTML/HBS từ JSON, TableJson và chữ ký; giữ
   placeholder khi thiếu dữ liệu. Đây là entry point của nguồn HTML chuẩn.
2. `FileHTMLToPdf`: dùng converter HTML hiện có để tạo PDF từ HTML đã render,
   không tạo PDF bằng cách mở lại XLSX.
3. `FileHTMLToExcelTemplate`: đọc các binding `data-excel-field` trong HTML,
   tạo lại JSON/TableJson rồi gọi `FileExcelAPI.ExportTemplateToExcel` trên
   template XLSX gốc. Cách này giữ merge cell, logo, công thức, style, ảnh và
   print settings của mẫu. `FileHTMLToExcel` chỉ còn là tiện ích chuyển HTML
   tổng quát, không dùng cho form canonical cần giữ layout.
4. `FileHTMLToWord`: đọc cùng contract table HTML, dựng DOCX bằng OpenXML,
   giữ cấu trúc bảng, text, merge cơ bản và ảnh.
5. `ExportPDFController`: chỉ điều phối theo extension/output format. Controller
   không chứa logic parse HTML hay mapping dữ liệu.
6. Request/response: bổ sung lựa chọn output theo hướng tương thích ngược;
   request cũ vẫn tạo đúng output cũ. Link của từng file phải được trả về rõ
   ràng; việc ghi nhiều link vào DB chỉ thực hiện khi procedure/field hiện có
   được xác định rõ, không tự ghi đè link legacy.

## Hợp đồng đã triển khai ở branch này

- `Extention1=HTML` chọn nhánh HTML nhưng controller vẫn gửi `Extention1` rỗng
  khi lấy result set thông tin, để không làm đổi branch dữ liệu của procedure
  legacy.
- `Extention2` là danh sách output bổ sung, phân cách bằng dấu phẩy:
  `PDF`, `XLSX`, `DOCX` hoặc `ALL`. HTML luôn được tạo; chọn `XLSX` hoặc
  `DOCX` tự tạo thêm PDF để giữ cặp file tương ứng.
- Template chuẩn hiện tại là
  `Templates/Export/SALE_SHIPPINGPRICE/ShippingAndCreditnPL.hbs`, được dựng
  từ form Excel hiện hữu. `FileHTML.ResolveCanonicalTemplate` ưu tiên template
  HTML/HBS này cho `SALE_SHIPPINGPRICE`; form chưa migrate vẫn fallback về
  đường Excel cũ.
- HTML là nguồn dữ liệu chung của các adapter mới. PDF/DOCX đọc HTML theo
  contract hiện tại; XLSX đọc dữ liệu HTML nhưng áp vào template XLSX gốc qua
  `FileExcelAPI`, không dựng form mới. Link HTML vẫn là cặp link chính được gửi
  vào `Update-LinkExport` của procedure hiện có. Các output bổ
  sung được trả về trong response bằng `PDFLocalFile`/`PDFLinkFile`,
  `XLSXLocalFile`/`XLSXLinkFile`, `DOCXLocalFile`/`DOCXLinkFile`; chưa ghi đè
  thêm field DB khi procedure chưa có hợp đồng cho nhiều link.
- `PreviewLinkFile` và `HTMLLocalFile` tiếp tục được trả về để kiểm tra trên
  máy local trong Development. Link remote chỉ có ý nghĩa khi storage/IIS
  thực sự phục vụ cùng path.

## Trình tự thực hiện

### Giai đoạn 1: nền HTML

- Chọn và đóng gói template HTML/HBS chuẩn của từng form.
- Render dữ liệu bằng logic replacement hiện có.
- Kiểm tra chữ ký, placeholder, logo và table với ít nhất một OID đã có dữ
  liệu và một OID thiếu chữ ký.

### Giai đoạn 2: các adapter

- Tạo HTML trước.
- Tạo PDF từ HTML.
- Tạo XLSX bằng cách đọc dữ liệu HTML và áp vào template XLSX gốc.
- Tạo DOCX từ bảng HTML.
- Không thay đổi nhánh legacy trong giai đoạn này.

### Giai đoạn 3: API và lưu trữ

- Thêm output mode rõ ràng, không dùng chung một field theo cách khó đoán.
- Trả về local path/preview link và remote link nếu storage remote xác nhận
  file đã tồn tại.
- Chỉ cập nhật link DB sau khi file được ghi thành công và storage đã phục vụ
  đúng file.

### Giai đoạn 4: kiểm thử

- Build solution.
- Smoke test từng output HTML, PDF, XLSX, DOCX.
- So sánh form HTML/PDF với mẫu: logo, bảng, merge, chữ ký và placeholder.
- Test thiếu dữ liệu, dữ liệu số/ngày, nhiều dòng TableJson, chữ ký C1/C2/C99
  và file storage không tồn tại.
- Kiểm tra diff để chắc chắn không sửa procedure, không sửa nhánh legacy và
  không đưa file sinh ra từ `D:/` vào repository.

Đã kiểm tra smoke bằng template chuẩn với dữ liệu header/table giả lập:
HTML và DOCX được tạo hợp lệ; thiếu chữ ký giữ placeholder, còn có
`SignLink_C1` thì chỉ C1 được chuyển SVG → PNG → base64. XLSX đã được nhập
qua `FileHTMLToExcelTemplate` và giữ nguyên workbook gốc (worksheet,
merge/layout và logo; số merge tăng tương ứng với số dòng bảng được chèn).
PDF đã build qua adapter nhưng không thể chạy native `wkhtmltopdf` trên macOS
hiện tại do thiếu thư viện nền; cần xác nhận thêm trên Windows/IIS.

## Ngoài phạm vi đợt đầu

- Cho phép sửa HTML trên trình duyệt và ghi ngược dữ liệu nghiệp vụ vào DB.
  Việc đó cần API cập nhật, quyền, version và audit riêng.
- Chuyển đổi tổng quát mọi HTML/CSS thành Excel/Word không theo contract.
- Thay thế hoặc chỉnh sửa các procedure legacy.

## Tiêu chí hoàn thành

- Template HTML được render từ đúng JSON/TableJson của procedure hiện tại.
- Thiếu trường vẫn giữ placeholder; chữ ký chỉ xuất hiện khi có `SignLink`
  hợp lệ từ dữ liệu nghiệp vụ.
- HTML, PDF, XLSX và DOCX dùng cùng một bản HTML đã render.
- Luồng `.xlsx/.docx/.pdf` cũ vẫn build và chạy theo cách cũ.
- Có log/test chỉ rõ output nào đã tạo, link nào đã lưu và lỗi storage nào còn
  chưa xử lý được.
