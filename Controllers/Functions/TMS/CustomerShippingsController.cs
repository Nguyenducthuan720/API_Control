using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.TMS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static APISmartCity.lib.Function;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.CustomerShippings")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class CustomerShippingsController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _CategoryDB;
        private readonly DBFolder _SettingOther;
        private readonly string _ProcedureName = "ExecShippings";

        public CustomerShippingsController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _CategoryDB = Global.ListDB?.Find(item => item.DBType == "CTL")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
            _SettingOther = Global.ListFolder?.Find(item => item.Type == "AttachFiles")!;
        }

        [HttpPost]
        public async Task<IActionResult> GetTotalContractByReferenceID([FromBody] Shippings.Request.GetByReferenceID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-TotalByReferenceID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    if (dataResponse.Result[0].Count > 0)
                    {
                        dynamic result = dataResponse.Result[0][0];
                        result.ListShippings = dataResponse.Result[1];
                        dataResponse.Result = result;
                    }
                }

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetDetailByOIDAndReferenceID([FromBody] Shippings.Request.GetByDetails request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "Get-DetailsByOIDAndReferenceID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result;
                    var results = (IEnumerable<dynamic>)result[0]!;
                    foreach (var item in results)
                    {
                        item.Contracts = ((IEnumerable<dynamic>)result[1]!).Where(r => r.ReferenceID == item.OID);
                        item.DetailsByIncurreds = ((IEnumerable<dynamic>)result[6]!);
                        item.DetailsAttachFiles = ((IEnumerable<dynamic>)result[7]!);
                        foreach (var ct in item.Contracts)
                        {
                            //ct.ShipPoints = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ct.ReferenceID);
                            //foreach (var sp in ct.ShipPoints)
                            //{
                            //    sp.ShippingDetails = ((IEnumerable<dynamic>)result[4]!).Where(r => r.OID == sp.OID && r.ShipPoint == sp.ShipPoint);
                            //    sp.ListConts = ((IEnumerable<dynamic>)result[11]!).Where(r => r.OID == sp.OID && r.ShipPoint == sp.ShipPoint);
                            //}

                            ct.ShipPoints = ((IEnumerable<dynamic>)result[2]!).Where(r => r.OID == ct.ReferenceID && r.ReferenceID == ct.OID);
                            foreach (var sp in ct.ShipPoints)
                            {
                                sp.ShippingDetails = ((IEnumerable<dynamic>)result[4]!).Where(r => r.OID == sp.OID && r.ReferenceID == sp.ReferenceID && r.ShipPoint == sp.ShipPoint);
                                sp.ListConts = ((IEnumerable<dynamic>)result[11]!).Where(r => r.OID == sp.OID && r.ReferenceID == sp.ReferenceID && r.ShipPoint == sp.ShipPoint);
                            }
                        }
                        item.Lines = ((IEnumerable<dynamic>)result[5]!);
                    }

                    dataResponse.Result = results;
                }
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}