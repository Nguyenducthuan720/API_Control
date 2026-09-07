using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Categorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Data;
using System.Dynamic;
using static APISmartCity.lib.Function;

namespace DMS.Controllers.Functions.Configs
{
    [ApiExplorerSettings(GroupName = "Microservice.Init.FormPrints")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class FormPrintController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _ProcedureName = "ExecFormPrints";
        private readonly string _ProcedurePrints = "ExecPrints";
        private readonly DBFolder _SettingOther;

        public FormPrintController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "Print");
        }

        /// <summary>
        /// Lấy danh sách Yêu cầu
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Get(FormPrints.Request.Get request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FormPrints.Request.Add request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@FactorID", request.FactorID },
                    { "@EntryID", request.EntryID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] FormPrints.Request.Delete request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@Language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@ID", request.ID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        /// <summary>
        /// Print dữ liệu
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Print(FormPrints.Request.Print request)
        {
            try
            {
                dynamic results = new ExpandoObject();
                string errorCode = ""; string errDescription = "";
                string exportLink = _SettingOther.Link;
                string exportPath = _SettingOther.Path;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "PRINT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, _ProcedurePrints, request);
                if (dataResponse.Result!.Count > 0)
                {
                    errorCode = dataResponse.ErrorCode;
                    errDescription = dataResponse.Message;
                    if (errorCode == "0")
                    {
                        List<dynamic> result = dataResponse.Result!;
                        string factorID = result[0][0].FactorID.ToString();
                        string entryID = result[0][0].EntryID.ToString();
                        string OID = result[0][0].OID.ToString();
                        string printTemplate = result[0][0].PrintTemplate.ToString();

                        DateTime current = DateTime.Now;
                        string outputConfig = Path.Combine(factorID, entryID, OID.Replace("/", "_") + $"_{current:ddMMyyyyHHmm}" + Path.GetExtension(printTemplate));
                        string destinationLink = NextAvailableFilename(Path.Combine(exportLink, outputConfig).Replace("\\", "/"));
                        string destinationFile = NextAvailableFilename(Path.Combine(exportPath, outputConfig).Replace("\\", "/"));
                        if (System.IO.File.Exists(printTemplate))
                        {
                            if (!Directory.Exists(Path.GetDirectoryName(destinationFile)))
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(destinationFile));
                            }
                            System.IO.File.Copy(printTemplate, destinationFile);
                        }

                        ExcelPackage.LicenseContext = LicenseContext.Commercial;
                        ExcelPackage package = new ExcelPackage(new FileInfo(destinationFile));
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                        switch (factorID)
                        {
                            case "ALLOWANCE_ROUTE":
                                switch (entryID)
                                {
                                    case "RQ_FEEOFROUTE":
                                        dynamic master = result[1][0]!;
                                        List<dynamic> details = result[2]!;
                                        // I. KINH DOANH
                                        bool isCont = master.OrderTypesName == "Hàng Container";
                                        worksheet.Cells["L6"].Value = master.GoodsTypesName; // Loại hàng
                                        worksheet.Cells["P8"].Value = isCont ? "" : "☑"; // Hàng Rời
                                        worksheet.Cells["L8"].Value = isCont ? "☑" : ""; // Hàng Container
                                        string routesName = master.RoutesName;
                                        string[] routes = routesName.Split('-');
                                        string[] fromRoutes = routes[0].Split(',');
                                        string[] toRoutes = routes[1].Split(',');
                                        worksheet.Cells["D11"].Value = fromRoutes[2]; // Nơi đi - Phường/Xã
                                        worksheet.Cells["D12"].Value = fromRoutes[1]; // Nơi đi - Quận/Huyện
                                        worksheet.Cells["D13"].Value = fromRoutes[0]; // Nơi đi - TP/Tỉnh
                                        worksheet.Cells["L11"].Value = toRoutes[2]; // Nơi đến - Phường/Xã
                                        worksheet.Cells["L12"].Value = toRoutes[1]; // Nơi đến - Quận/Huyện
                                        worksheet.Cells["L13"].Value = toRoutes[0]; // Nơi đến - TP/Tỉnh
                                        // II. ĐIỀU ĐỘ
                                        worksheet.Cells["D21"].Value = master.RoutesName; // Tuyến
                                        worksheet.Cells["D22"].Value = master.RoutesCode; // Mã tuyến
                                        worksheet.Cells["D23"].Value = master.RouteGroupsName; // Nhóm tuyến
                                        worksheet.Cells["O21"].Value = master.Distance; // Số km
                                        worksheet.Cells["O25"].Value = details.Select(r => (double)r.ChargingCost).Sum(); // Phí cầu đường (ô tổng sẽ tự động cộng chi tiết phí từng trạm liệt kê)
                                        int sourceRow = 26; // Index của row detail đầu tiên, row 27 trên excel là index 26
                                        int targetRow = sourceRow + 1;
                                        if (details.Count > 0)
                                        {
                                            worksheet.InsertRow(targetRow + 1, details.Count);
                                            var sourceRange = worksheet.Cells[targetRow, 1, targetRow, worksheet.Dimension.End.Column];
                                            for (int i = 0; i < details.Count; i++)
                                            {
                                                targetRow++;
                                                var targetRange = worksheet.Cells[targetRow, 1, targetRow, worksheet.Dimension.End.Column];
                                                sourceRange.Copy(targetRange);
                                                targetRange[$"F{targetRow}"].Value = details[i].ChargingStationsName.ToString(); // Use column F => targetRange[$"F{targetRow}"]
                                                targetRange[$"O{targetRow}"].Value = details[i].ChargingCost; // Use column O => targetRange[$"O{targetRow}"]
                                            }
                                            worksheet.DeleteRow(sourceRow + 1, 1); // Delete temp detail row
                                        }
                                        // III. ĐIẾU ĐỘ - DŨNG
                                        int indexPlus = details.Count - 1;
                                        worksheet.Cells[$"D{35 + indexPlus}"].Value = master.NoOverloadTotalCost; // Phí đủ tải
                                        worksheet.Cells[$"N{35 + indexPlus}"].Value = master.NoOverloadSalary; // Lương tài xế đủ tải
                                        worksheet.Cells[$"D{37 + indexPlus}"].Value = master.OverloadTotalCost; // Phí quá tải
                                        worksheet.Cells[$"N{37 + indexPlus}"].Value = master.OverloadSalary; // Lương tài xế quá tải
                                        worksheet.Cells[$"D{39 + indexPlus}"].Value = master.OtherCost; // Phí khác
                                        worksheet.Cells[$"M{39 + indexPlus}"].Value = master.OtherCostDescription; // Ghi chú của phí khác
                                        // TỔNG CHI PHÍ
                                        worksheet.Cells[$"N{45 + indexPlus}"].Value = master.NoOverloadTotalCost; // Tổng phí đủ tải
                                        worksheet.Cells[$"N{46 + indexPlus}"].Value = master.OverloadTotalCost; // Tổng phí quá tải
                                        // Save excel
                                        package.Save();
                                        break;

                                    default:
                                        results = "";
                                        errorCode = dataResponse.ErrorCode;
                                        errDescription = dataResponse.Message;
                                        break;
                                }
                                break;

                            default:
                                results = result;
                                errorCode = dataResponse.ErrorCode;
                                errDescription = dataResponse.Message;
                                break;
                        }

                        results = destinationLink;
                    }
                }
                else
                {
                    errorCode = "0"; errDescription = "Success, Not Found Data";
                }
                return Ok(new DataResponse(errDescription, results, errorCode));
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}