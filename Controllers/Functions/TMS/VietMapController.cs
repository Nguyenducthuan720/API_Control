using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.VietmapGeocodeServices;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.Logistics.VietMap.Request;

namespace APISmartCity.Controllers.Logistics
{
    [ApiExplorerSettings(GroupName = "Microservice.VietMap")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class VietMapController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecGeoCodeVietMap";
        private readonly VietmapGeocodeService _services;

        public VietMapController(UserInfo userInfo, VietmapGeocodeService service)
        {
            _services = service;
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> AutoComplete([FromBody] GeoCode request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                if (dataResponse?.ErrorCode == "0")
                {
                    return Ok(dataResponse);
                }
                else
                {
                    List<RefID> addrequest = await _services.GeoCode(request.Address);
                    if (addrequest?.Count == 0)
                    {
                        return Ok(new DataResponse("Api not found address", "", "-1"));
                    }
                    else
                    {
                        Dictionary<string, object> addparameters = new()
                        {
                            { "@type", "AddRefID" },
                            { "@language", _UserInfo.Language },
                            { "@UserIDCurent", _UserInfo.UserID }
                        };
                        DataTable RefID = addrequest.ToDataTable();
                        RefID.SetTypeName("RefID");
                        addparameters.Add("@REFID", RefID);
                        DataResponse adddataResponse = await GetDataResponse(addparameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                        return Ok(adddataResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> VietMapRoute([FromBody] GetRoute request)
        {
            try
            {
                request.StringPoint = request.StringPoint.Replace(" ", "");
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetRoute" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                if (dataResponse?.ErrorCode == "0")
                {
                    return Ok(dataResponse);
                }
                else
                {
                    string json = await _services.Route(request.StringPoint);
                    if (json is null)
                    {
                        return Ok(new DataResponse("Api not found", "", "-1"));
                    }
                    else
                    {
                        Dictionary<string, object> addparameters = new()
                        {
                            { "@type", "AddRoute" },
                            { "@language", _UserInfo.Language },
                            { "@json", json },
                            { "@StringPoint", request.StringPoint },
                            { "@UserIDCurent", _UserInfo.UserID }
                        };
                        DataResponse adddataResponse = await GetDataResponse(addparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                        return Ok(adddataResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> VietMapRouteAddPoint([FromBody] GetRouteAddPoint request)
        {
            try
            {
                request.StringPoint = request.StringPoint.Replace(" ", "");
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetPositionRoute" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                if (dataResponse?.ErrorCode != "0" || dataResponse?.Message == "Success, Not Found Data")
                {
                    return Ok(new DataResponse("No result", "", "-1"));
                }
                else
                {
                    string StringPoint = dataResponse?.Result[0].StringPoint;
                    string json = await _services.Route(StringPoint);
                    if (json is null)
                    {
                        return Ok(new DataResponse("Api not found", "", "-1"));
                    }
                    else
                    {
                        Dictionary<string, object> addparameters = new()
                        {
                            { "@type", "AddRoute" },
                            { "@language", _UserInfo.Language },
                            { "@json", json },
                            { "@StringPoint", StringPoint },
                            { "@UserIDCurent", _UserInfo.UserID }
                        };
                        DataResponse adddataResponse = await GetDataResponse(addparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                        return Ok(adddataResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> VietMapTSP([FromBody] GetRoute request)
        {
            try
            {
                request.StringPoint = request.StringPoint.Replace(" ", "");
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GetRoute" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request!);
                if (dataResponse?.ErrorCode == "0")
                {
                    return Ok(dataResponse);
                }
                else
                {
                    string json = await _services.TSP(request.StringPoint);
                    if (json is null)
                    {
                        return Ok(new DataResponse("Api not found", "", "-1"));
                    }
                    else
                    {
                        Dictionary<string, object> addparameters = new()
                        {
                            { "@type", "AddRoute" },
                            { "@language", _UserInfo.Language },
                            { "@json", json },
                            { "@StringPoint", request.StringPoint },
                            { "@UserIDCurent", _UserInfo.UserID }
                        };
                        DataResponse adddataResponse = await GetDataResponse(addparameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                        return Ok(adddataResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Place([FromBody] GetLatLong request)
        {
            try
            {
                var result = await _services.Place(request.RefId);
                if (result is null)
                {
                    return Ok(new DataResponse("Api not found lat long", "", "-1"));
                }
                else
                {
                    Dictionary<string, object> parameters = new()
                    {
                        { "@type", "Add" },
                        { "@language", _UserInfo.Language },
                        { "@UserIDCurent", _UserInfo.UserID },
                        { "@Lat", result.Lat },
                        { "@Long", result.Long },
                        { "@ReferenceID", request.RefId }
                    };
                    DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null);
                    return Ok(dataResponse);
                }
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }
    }
}