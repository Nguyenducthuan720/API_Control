namespace APISmartCity.Models.TMS
{
    public class ShippingDriverSalarys
    {
        public static class Request
        {
            public class Content
            {
                /// <summary>
                /// Odate
                /// </summary>
                /// <example>2023-05-12</example>
                public string? Odate { get; set; }

                /// <summary>
                /// FromDate
                /// </summary>
                /// <example>2023-04-01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// ToDate
                /// </summary>
                /// <example>2023-04-30</example>
                public string? ToDate { get; set; }

                /// <summary>
                /// Period
                /// </summary>
                /// <example>T04/2023</example>
                public string? Period { get; set; }

                /// <summary>
                /// VehicleTeamID
                /// </summary>
                /// <example>21</example>
                public string? VehicleTeamID { get; set; }

                /// <summary>
                /// TotalShip
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalShip { get; set; }

                /// <summary>
                /// TotalDriver
                /// </summary>
                /// <example>0</example>
                public int? TotalDriver { get; set; }

                /// <summary>
                /// SalaryDriver
                /// </summary>
                /// <example>0.00</example>
                public decimal SalaryDriver { get; set; }

                /// <summary>
                /// AllowanceCrane
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceCrane { get; set; }

                /// <summary>
                /// AllowanceMeal
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceMeal { get; set; }

                /// <summary>
                /// AllowanceMeal
                /// </summary>
                /// <example>0.00</example>
                public decimal BasicSalaryDriver { get; set; }


                public decimal AllowanceVehicle2015 { get; set; }



                public decimal BasicSalarySunday { get; set; }

                /// <summary>
                /// AllowanceTarpaulin
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceTarpaulin { get; set; }

                /// <summary>
                /// AllowanceDriverHelper
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceDriverHelper { get; set; }

                /// <summary>
                /// AllowanceRetail
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceRetail { get; set; }

                /// <summary>
                /// AllowanceOther
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceOther { get; set; }

                /// <summary>
                /// TotalAdjustUp
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalAdjustUp { get; set; }

                /// <summary>
                /// TotalAdjustDown
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalAdjustDown { get; set; }

                /// <summary>
                /// TotalSalaryDriver
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalSalaryDriver { get; set; }

                /// <summary>
                /// FeePackage
                /// </summary>
                /// <example>0.00</example>
                public decimal FeePackage { get; set; }

                /// <summary>
                /// FeeOther
                /// </summary>
                /// <example>0.00</example>
                public decimal FeeOther { get; set; }

                /// <summary>
                /// AllowanceOverLoad
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceOverLoad { get; set; }

                /// <summary>
                /// AllowanceTire
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceTire { get; set; }

                /// <summary>
                /// TotalTemp
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalTiket { get; set; }

                /// <summary>
                /// TotalTemp
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalFee { get; set; }

                /// <summary>
                /// TotalTemp
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalTemp { get; set; }

                /// <summary>
                /// TotalTemp
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalFeeDebit { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }

                public List<SalaryDetails> ShippingDriverSalaryDetails { get; set; }
            }

            public class Add : Content
            {
            }

            public class Edit : Content
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>LTX/23/05/007</example>
                public string? OID { get; set; }
            }

            public class GetByOID
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>LTX/23/05/008</example>
                public string? OID { get; set; }
            }

            public class GetByTeamID
            {
                /// <summary>
                /// ID đội xe
                /// </summary>
                /// <example>21</example>
                public string? VehicleTeamID { get; set; }
            }

            public class GetByOdate
            {
                /// <summary>
                /// Ngày CT
                /// </summary>
                /// <example>2023/05/01</example>
                public string? Odate { get; set; }
            }

            public class GetByDriverID
            {
                /// <summary>
                /// GetByDriverID
                /// </summary>
                /// <example>172</example>
                public string? DriverID { get; set; }
            }

            public class GetSalary
            {
                /// <summary>
                /// ID đội xe
                /// </summary>
                /// <example>21</example>
                public string? VehicleTeamID { get; set; }

                /// <summary>
                /// Danh sách các tài xế đã chọn tính lương
                /// </summary>
                /// <example>220,50,175,1036</example>
                public string? ListDriver { get; set; }

                /// <summary>
                /// Tính lương từ ngày
                /// </summary>
                /// <example>2023-04-01</example>
                public string? FromDate { get; set; }

                /// <summary>
                /// Tính lương đến ngày
                /// </summary>
                /// <example>2023-04-30</example>
                public string? ToDate { get; set; }
            }

            public class EditStatus
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>LTX/23/05/008</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }
            }


            public class Submit
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>LTX/23/05/008</example>
                public string? OID { get; set; }

                /// <summary>
                /// IsActive
                /// </summary>
                /// <example>1</example>
                public int? IsLock { get; set; }
            }

            public class Del
            {
                /// <summary>
                /// Mã chứng từ
                /// </summary>
                /// <example>LTX/23/05/008</example>
                public string? OID { get; set; }
            }

            public class SalaryDetails
            {
                /// <summary>
                /// DriverID
                /// </summary>
                /// <example>172</example>
                public int? DriverID { get; set; }

                /// <summary>
                /// DriverName
                /// </summary>
                /// <example>Trương Bình</example>
                public string? DriverName { get; set; }

                /// <summary>
                /// LicensePlates
                /// </summary>
                /// <example>03609-50H</example>
                public string? LicensePlates { get; set; }

                /// <summary>
                /// TotalShip
                /// </summary>
                /// <example>5.00</example>
                public decimal TotalShip { get; set; }

                /// <summary>
                /// SalaryDriver
                /// </summary>
                /// <example>0.00</example>
                public decimal SalaryDriver { get; set; }

                /// <summary>
                /// AllowanceCrane
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceCrane { get; set; }

                public decimal BasicSalary { get; set; }

                /// <summary>
                /// AllowanceMeal
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceMeal { get; set; }

                /// <summary>
                /// BasicSalaryDriver
                /// </summary>
                /// <example>0.00</example>
                

                /// <summary>
                /// AllowanceTarpaulin
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceTarpaulin { get; set; }

                /// <summary>
                /// AllowanceDriverHelper
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceDriverHelper { get; set; }

                /// <summary>
                /// AllowanceRetail
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceRetail { get; set; }

                /// <summary>
                /// AllowanceOther
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceOther { get; set; }

                /// <summary>
                /// TotalAdjustUp
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalAdjustUp { get; set; }

                /// <summary>
                /// TotalAdjustDown
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalAdjustDown { get; set; }

                /// <summary>
                /// TotalSalaryDriver
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalSalaryDriver { get; set; }

                /// <summary>
                /// FeePackage
                /// </summary>
                /// <example>0.00</example>
                public decimal FeePackage { get; set; }

                /// <summary>
                /// FeeOther
                /// </summary>
                /// <example>0.00</example>
                public decimal FeeOther { get; set; }

                /// <summary>
                /// AllowanceOverLoad
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceOverLoad { get; set; }

                /// <summary>
                /// AllowanceTire
                /// </summary>
                /// <example>0.00</example>
                public decimal AllowanceTire { get; set; }

                /// <summary>
                /// tổng tiền vé tay tài xế mua
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalTiket { get; set; }

                /// <summary>
                /// TotalFee
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalFee { get; set; }

                /// <summary>
                /// TotalTemp
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalTemp { get; set; }

                /// <summary>
                /// TotalFeeDebit
                /// </summary>
                /// <example>0.00</example>
                public decimal TotalFeeDebit { get; set; }


                public decimal BasicSalaryDriver { get; set; }



                public decimal AllowanceVehicle2015 { get; set; }



                public decimal BasicSalarySunday { get; set; }
            }
        }
    }
}