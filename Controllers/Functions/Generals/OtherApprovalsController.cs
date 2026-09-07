using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;
using static APISmartCity.lib.Function;
using static DMS.Models.Generals.Configs.OtherApprovals.Request;

namespace DMS.Controllers.Functions.Generals
{
    [ApiExplorerSettings(GroupName = "Functions.OtherApprovals")]
    [Route("api/v2/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class OtherApprovalsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecOtherProposals";
        public OtherApprovalsController(UserInfo userInfo)
        {
            _UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "FUN")?.DBString!;
        }
   
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] GetFilter request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetByID([FromBody] GetById request)
        {
            try
            {
                
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    dynamic results = dataResponse.Result[0][0];
                    results.Details = dataResponse.Result[1];
                    results.Progress = dataResponse.Result[2];
                    results.Customize = dataResponse.Result[3];
                    results.Histories = dataResponse.Result[4];
                    dataResponse.Result = results;
                }
                else
                {
                    dataResponse.Result = null;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetReferenceID()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-REFERENCEID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Add request)
        {
            try
            {
                var contentDetails = JsonConvert.SerializeObject(request.Details);
                request.Details = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@dataJson", contentDetails }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Copy([FromBody] GetById request)
        {
            try
            {

                Dictionary<string, object> parameters = new()
                {
                    { "@type", "COPY" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1 && dataResponse.Result[0].Count > 0)
                {
                    dynamic results = dataResponse.Result[0][0];
                    results.Details = dataResponse.Result[1];
                    results.Progress = dataResponse.Result[2];
                    results.Customize = dataResponse.Result[3];
                    results.Histories = dataResponse.Result[4];
                    dataResponse.Result = results;
                }
                else
                {
                    dataResponse.Result = null;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Cancel([FromBody] Delete request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "CANCEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Edit request)
        {
            try
            {
                var contentDetails = JsonConvert.SerializeObject(request.Details);
                request.Details = null;
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID },
                    { "@dataJson", contentDetails }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
       
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Delete request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] Submit request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Submit" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Annul([FromBody] Annul request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Annul" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    } 
    
}
