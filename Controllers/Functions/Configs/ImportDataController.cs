using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;

namespace APISmartCity.Controllers.ProcessExcels
{
    [ApiExplorerSettings(GroupName = "Microservice.Config.ImportDatas")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ImportDataController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        //private readonly DBFolder _SettingOther;

        public ImportDataController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            //_SettingOther = Global.ListFolder?.Find(item => item.Type == "PathExcel")!;
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcel([FromForm] Excels.Request.ImportExcel import)
        {
            try
            {
                DataTable DataImport = import.File.ExcelCopyToDataTable();
                DataImport.SetTypeName("TableImport");
                if (DataImport.Rows.Count > 0)
                {
                    string colName = "";
                    string ListCol = "";
                    bool Flagcheck = false;
                    for (int i = 0; i < DataImport.Columns.Count; i++)
                    {
                        if (DataImport.Columns[i].DataType.Name == "Object")
                        {
                            Flagcheck = true;
                        }
                        DataColumn dataColumn = DataImport.Columns[i];
                        colName = $"{DataImport.Columns[i].ColumnName}";
                        colName += dataColumn.DataType.Name.ToUpper() switch
                        {
                            "STRING" => " [NVARCHAR](500) NULL,",
                            "DATE" => " [DATE] NULL,",
                            "DATETIME" => " [DATETIME] NULL,",
                            "DECIMAL" or "DOUBLE" => " [DECIMAL](18,3) NULL,",
                            "INT16" or "INT32" or "INT64" => " [INT] NULL,",
                            _ => " [NVARCHAR](500) NULL,",
                        };
                        ListCol += colName;
                    }
                    ListCol = ListCol[0..^1];

                    DataImport.Rows.RemoveAt(0);

                    if (Flagcheck)
                    {
                        DataTable dtCloned = DataImport.Clone();
                        //for (int fix = 0; fix < dtCloned.Columns.Count - 1; fix++)
                        //{
                        //    dtCloned.Columns[fix].DataType = typeof(string);
                        //}
                        foreach (DataColumn dc in dtCloned.Columns)
                        {
                            dc.DataType = typeof(string);
                        }
                        foreach (DataRow row in DataImport.Rows)
                        {
                            dtCloned.ImportRow(row);
                        }
                        DataImport = dtCloned;
                    }

                    using IDbConnection conn = new SqlConnection(_ConfigurationDB);
                    string typeName = "TableImport";
                    var p = new DynamicParameters();
                    p.Add("@TypeName", typeName);
                    p.Add("@ListCol", ListCol);
                    var aaa = conn.Query("ImportData_Begin", param: p, commandType: CommandType.StoredProcedure);

                    Dictionary<string, object> parameters = new()
                    {
                        { "@OID", import.OID },
                        { "@FactorID", import.FactorID },
                        { "@EntryID", import.EntryID },
                        { "@DataImport", DataImport },
                        { "@language", _UserInfo.Language },
                        { "@UserIDCurent", _UserInfo.UserID },
                        { "@CmpnID", _UserInfo.CmpnID }
                    };

                    DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "ImportData_End", null!);

                    if (dataResponse.Result!.Count > 1 && dataResponse.ErrorCode == "0")
                    {
                        dynamic result = new ExpandoObject();
                        result.Result = dataResponse.Result[0];
                        result.DataErrorFile = dataResponse.Result[1];
                        result.DataDupFile = dataResponse.Result[2];
                        result.DataDupDB = dataResponse.Result[3];
                        result.DataInsert = dataResponse.Result[4];
                        dataResponse.Result = result;
                    }
                    else
                    {
                        dataResponse.Result = null;
                    }
                    return Ok(dataResponse);
                }
                else
                {
                    return Ok(new DataResponse("Data empty", "", "-1"));
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> NLImportExcel([FromForm] Excels.Request.ImportExcel import)
        {
            try
            {
                DataTable DataImport = import.File.ExcelCopyToDataTable();
                DataImport.SetTypeName("NLTableImport");
                if (DataImport.Rows.Count > 0)
                {
                    string colName = "";
                    string ListCol = "";
                    bool Flagcheck = false;
                    for (int i = 0; i < DataImport.Columns.Count; i++)
                    {
                        if (DataImport.Columns[i].DataType.Name == "Object")
                        {
                            Flagcheck = true;
                        }
                        DataColumn dataColumn = DataImport.Columns[i];
                        colName = $"{DataImport.Columns[i].ColumnName}";
                        colName += dataColumn.DataType.Name.ToUpper() switch
                        {
                            "STRING" => " [NVARCHAR](500) NULL,",
                            "DATE" => " [DATE] NULL,",
                            "DATETIME" => " [DATETIME] NULL,",
                            "DECIMAL" or "DOUBLE" => " [DECIMAL](18,3) NULL,",
                            "INT16" or "INT32" or "INT64" => " [INT] NULL,",
                            _ => " [NVARCHAR](500) NULL,",
                        };
                        ListCol += colName;
                    }
                    ListCol = ListCol[0..^1];

                    DataImport.Rows.RemoveAt(0);

                    if (Flagcheck)
                    {
                        DataTable dtCloned = DataImport.Clone();
                        for (int fix = 0; fix < dtCloned.Columns.Count - 1; fix++)
                        {
                            dtCloned.Columns[fix].DataType = typeof(string);
                        }
                        foreach (DataRow row in DataImport.Rows)
                        {
                            dtCloned.ImportRow(row);
                        }
                        DataImport = dtCloned;
                    }

                    using IDbConnection conn = new SqlConnection(_ConfigurationDB);
                    string typeName = "NLTableImport";
                    var p = new DynamicParameters();
                    p.Add("@TypeName", typeName);
                    p.Add("@ListCol", ListCol);
                    var aaa = conn.Query("NLImportData_Begin", param: p, commandType: CommandType.StoredProcedure);

                    Dictionary<string, object> parameters = new()
                    {
                        { "@FactorID", import.FactorID },
                        { "@EntryID", import.EntryID },
                        { "@DataImport", DataImport },
                        { "@language", _UserInfo.Language },
                        { "@UserIDCurent", _UserInfo.UserID }
                    };

                    DataResponse dataResponse = await Function.GetDataResponse(parameters, _ConfigurationDB, _ConfigurationDB, "NLImportData_End", null!);

                    if (dataResponse.Result!.Count > 1 && dataResponse.ErrorCode == "0")
                    {
                        dynamic result = new ExpandoObject();
                        result.Result = dataResponse.Result[0];
                        result.DataErrorFile = dataResponse.Result[1];
                        result.DataDupFile = dataResponse.Result[2];
                        result.DataDupDB = dataResponse.Result[3];
                        result.DataInsert = dataResponse.Result[4];
                        dataResponse.Result = result;
                    }
                    else
                    {
                        dataResponse.Result = null;
                    }
                    return Ok(dataResponse);
                }
                else
                {
                    return Ok(new DataResponse("Data empty", "", "-1"));
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}