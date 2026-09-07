using Microsoft.AspNetCore.Routing;

namespace APISmartCity.Models.Categorys
{
    public static class PlanForUsers
    {
        public static class Request
        {
            public class Add
            {
                /// <summary>
                /// Note
                /// </summary>
                /// <example>Note</example>
                public string? Note { get; set; }

                /// <summary>
                /// Extention1
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example></example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example></example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example></example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example></example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example></example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example></example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example></example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string? Extention10 { get; set; }
                public string? Extention11 { get; set; }
                public string? Extention12 { get; set; }
                public string? Extention13 { get; set; }
                public string? Extention14 { get; set; }
                public string? Extention15 { get; set; }
                public string? Extention16 { get; set; }
                public string? Extention17 { get; set; }
                public string? Extention18 { get; set; }
                public string? Extention19 { get; set; }
                public string? Extention20 { get; set; }

                /// <summary>
                /// UserID
                /// </summary>
                /// <example></example>
                public int? UserID { get; set; }

                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public string? OID { get; set; }
            }
            public class AddVisitPlan : Add
            {
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>1</example>
                public DateTime ODate { get; set; }
                /// <summary>
                /// FactorID
                /// </summary>
                /// <example>1</example>
                public string? FactorID { get; set; }

                /// <summary>
                /// EntryID
                /// </summary>
                /// <example>1</example>
                public string? EntryID { get; set; }

                /// <summary>
                /// SAPID
                /// </summary>
                /// <example></example>
                public string? SAPID { get; set; }

                /// <summary>
                /// LemonID
                /// </summary>
                /// <example></example>
                public string? LemonID { get; set; }

                /// <summary>
                /// TypeUse
                /// </summary>
                /// <example></example>
                public string? FromDate { get; set; }

                /// <summary>
                /// StationID
                /// </summary>
                /// <example></example>
                public string? ToDate { get; set; }

                /// <summary>
                /// ProcessID
                /// </summary>
                /// <example></example>
                public int? ApprovalProcessID { get; set; }

                /// <summary>
                /// Step
                /// </summary>
                /// <example>1</example>
                public int? ApprovalStep { get; set; }

                /// <summary>
                /// Status
                /// </summary>
                /// <example>1</example>
                public int? ApprovalStatusID { get; set; }

                /// <summary>
                /// Date
                /// </summary>
                /// <example></example>
                public string? ApprovalDate { get; set; }

                /// <summary>
                /// Approval Note
                /// </summary>
                /// <example></example>
                public string? ApprovalNote { get; set; }

                /// <summary>
                /// IsLock
                /// </summary>
                /// <example>0</example>
                public int? IsLock { get; set; }

                /// <summary>
                /// IsDeleted
                /// </summary>
                /// <example>0</example>
                public int? IsDeleted { get; set; }

                /// <summary>
                /// Active
                /// </summary>
                /// <example>1</example>
                public int? IsActive { get; set; }

                /// <summary>
                /// CustomerSupportLineID
                /// </summary>
                /// <example></example>
                public int? CustomerSupportLineID { get; set; }

                /// <summary>
                /// PlanCode
                /// </summary>
                /// <example></example>
                public string? PlanCode { get; set; }

                /// <summary>
                /// PlanName
                /// </summary>
                /// <example></example>
                public string? PlanName { get; set; }

                /// <summary>
                /// PlanName
                /// </summary>
                /// <example></example>
                public string? PlanName1 { get; set; }

                /// <summary>
                /// PlanName
                /// </summary>
                /// <example></example>
                public string? PlanName2 { get; set; }

                /// <summary>
                /// PlanName
                /// </summary>
                /// <example></example>
                public string? PlanName3 { get; set; }

                /// <summary>
                /// PlanName
                /// </summary>
                /// <example></example>
                public string? PlanName4 { get; set; }

                /// <summary>
                /// PlanName
                /// </summary>
                /// <example></example>
                public string? PlanName5 { get; set; }

                /// <summary>
                /// PlanName
                /// </summary>
                /// <example></example>
                public string? PlanName6 { get; set; }


                /// <summary>
                /// PlanName
                /// </summary>
                /// <example></example>
                public string? PlanName7 { get; set; }

                /// <summary>
                /// PlanName
                /// </summary>
                /// <example></example>
                public string? PlanName8 { get; set; }

                /// <summary>
                /// PlanName
                /// </summary>
                /// <example></example>
                public string? PlanName9 { get; set; }
                /// <summary>
                /// Link
                /// </summary>
                /// <example></example>
                public string? Link { get; set; }

            }
            public class AddSchedule : Add
            {
                /// <summary>
                /// ID
                /// </summary>
                /// <example></example>
                public int? ID { get; set; }

                /// <summary>
                /// PlanDate
                /// </summary>
                /// <example>2022/03/10</example>
                public string? PlanDate { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? ScheduleName { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? ScheduleName1 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? ScheduleName2 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? ScheduleName3 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? ScheduleName4 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? ScheduleName5 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? ScheduleName6 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? ScheduleName7 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? ScheduleName8 { get; set; }

                /// <summary>
                /// Name
                /// </summary>
                /// <example></example>
                public string? ScheduleName9 { get; set; }

            }
            public class ContentArray
            {
                /// <summary>
                /// PlanScheduleID
                /// </summary>
                /// <example>1</example>
                public int? PlanScheduleID { get; set; }
                /// <summary>
                /// CustomerID
                /// </summary>
                /// <example></example>
                public int? CustomerID { get; set; }
                /// <summary>
                /// IsOffRouteVisit
                /// </summary>
                /// <example></example>
                public string? VisitTypeCode { get; set; }

                /// <summary>
                /// IsOffRouteVisit
                /// </summary>
                /// <example></example>
                public string? Link { get; set; }


                /// <summary>
                /// Check In Lat
                /// </summary>
                /// <example>1</example>
                public decimal CheckIn_Lat { get; set; }

                /// <summary>
                /// Check In Long
                /// </summary>
                /// <example>1</example>
                public decimal CheckIn_Long { get; set; }

                /// <summary>
                /// CheckInTime
                /// </summary>
                /// <example></example>
                public string? CheckInTime { get; set; }

                /// <summary>
                /// Check In Lat
                /// </summary>
                /// <example>1</example>
                public decimal CheckOut_Lat { get; set; }

                /// <summary>
                /// Check In Long
                /// </summary>
                /// <example>1</example>
                public decimal CheckOut_Long { get; set; }

                /// <summary>
                /// CheckInTime
                /// </summary>
                /// <example></example>
                public string? CheckOutTime { get; set; }

                /// <summary>
                /// TotalTime
                /// </summary>
                /// <example></example>
                public decimal TotalTime { get; set; }

                /// <summary>
                /// FeedBack
                /// </summary>
                /// <example></example>
                public string? FeedBack { get; set; }

                /// <summary>
                /// Rival
                /// </summary>
                /// <example>1</example>
                public string? Rival { get; set; }

                /// <summary>
                /// Status
                /// </summary>
                /// <example>1</example>
                public string? Status { get; set; }


                /// <summary>
                /// StationNote
                /// </summary>
                /// <example></example>
                public string? StationNote { get; set; }

                /// <summary>
                /// StatisticReason
                /// </summary>
                /// <example></example>
                public string? StatisticReason { get; set; }

                /// <summary>
                /// Note
                /// </summary>
                /// <example></example>
                public string? Note { get; set; }
                
                /// <summary>
                /// Extention1
                /// </summary>
                /// <example></example>
                public string? Extention1 { get; set; }

                /// <summary>
                /// Extention2
                /// </summary>
                /// <example></example>
                public string? Extention2 { get; set; }

                /// <summary>
                /// Extention3
                /// </summary>
                /// <example></example>
                public string? Extention3 { get; set; }

                /// <summary>
                /// Extention4
                /// </summary>
                /// <example></example>
                public string? Extention4 { get; set; }

                /// <summary>
                /// Extention5
                /// </summary>
                /// <example></example>
                public string? Extention5 { get; set; }

                /// <summary>
                /// Extention6
                /// </summary>
                /// <example></example>
                public string? Extention6 { get; set; }

                /// <summary>
                /// Extention7
                /// </summary>
                /// <example></example>
                public string? Extention7 { get; set; }

                /// <summary>
                /// Extention8
                /// </summary>
                /// <example></example>
                public string? Extention8 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string? Extention9 { get; set; }

                /// <summary>
                /// Extention9
                /// </summary>
                /// <example></example>
                public string? Extention10 { get; set; }

                /// <summary>
                /// ID
                /// </summary>
                /// <example>1</example>
                public string? ID { get; set; }
            }
            public class AddOrEditArray
            {
                public List<ContentArray> dataJson { get; set; }
            }

            public class GetByID
            {
                /// <summary>
                /// OID
                /// </summary>
                /// <example>0</example>
                public string? OID { get; set; }
            }
            public class Submit : GetByID
            {
                public int? IsLock { get; set; }
                public string? Note { get; set; }
            }

            public class DelPlan : GetByID
            {
            }

            public class DelSchedule
            {
                public int? VisitScheduleID { get; set; }
            }

            public class CalendarCheck
            {
                public int? UserID { get; set; }

                public string? FromDate { get; set; }

                public string? ToDate { get; set; }

                public string? OID { get; set; }
            }
            public class Process : GetByID
            {
                public string? FactorID { get; set; }
                public string? EntryID { get; set; }
                public int? ApprovalProcessID { get; set; }
                public int? ApprovalStatusID { get; set; }
                public string? ApprovalNote { get; set; }
            }
            public class ProcessArray 
            {
                public List<Process> dataJson { get; set; }
            }

        }
    }
}