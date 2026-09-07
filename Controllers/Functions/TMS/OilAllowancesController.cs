using APISmartCity.DI;
using APISmartCity.lib;
using APISmartCity.Models;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static APISmartCity.lib.Function;
using static APISmartCity.Models.TMS.OilAllowances.Request;

namespace APISmartCity.Controllers.TMS
{
    [ApiExplorerSettings(GroupName = "Microservice.nPL.OilAllowances")]
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class OilAllowancesController : ControllerBase
    {
        private readonly UserInfo _UserInfo;
        private readonly string _ConfigurationDB;
        private readonly string _nPLDB;
        private readonly string _ProcedureName = "ExecOilAllowances";

        public OilAllowancesController(UserInfo userInfo)
        {
            this._UserInfo = userInfo;
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _nPLDB = Global.ListDB?.Find(item => item.DBType == "LOG")?.DBString!;
        }

        [HttpPost]
        public async Task<IActionResult> Get()
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
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, null!);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] GetByID request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GET-BYID" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
                };
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                if (dataResponse.Result!.Count > 1)
                {
                    dynamic result = dataResponse.Result[0][0];
                    result.NotOverloadNotContGoodTypes = dataResponse.Result[1];
                    result.NotOverloadContGoodTypes = dataResponse.Result[2];
                    result.OverloadNotContGoodTypes = dataResponse.Result[3];
                    result.OverloadContGoodTypes = dataResponse.Result[4];
                    result.JoinShipOilNotContGoodTypes = dataResponse.Result[5];
                    result.JoinShipOilContGoodTypes = dataResponse.Result[6];
                    result.OilAllowancesRoutes = dataResponse.Result[7];
                    result.OilAllowancesVehicles = dataResponse.Result[8];
                    result.Properties = dataResponse.Result[9];
                    result.Histories = dataResponse.Result[10];
                    result.Progress = dataResponse.Result[11];

                    dataResponse.Result = result;
                }
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
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ADD" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                if (request.OilAllowancesRoutes != null)
                {
                    DataTable OilAllowancesRoutes = request.OilAllowancesRoutes.ToDataTable();
                    OilAllowancesRoutes.SetTypeName("OilAllowancesRoute");
                    parameters.Add("@OilAllowancesRoutes", OilAllowancesRoutes);
                    request.OilAllowancesRoutes = null;
                }
                if (request.OilAllowancesVehicles != null)
                {
                    DataTable OilAllowancesVehicles = request.OilAllowancesVehicles.ToDataTable();
                    OilAllowancesVehicles.SetTypeName("OilAllowancesVehicle");
                    parameters.Add("@OilAllowancesVehicles", OilAllowancesVehicles);
                    request.OilAllowancesVehicles = null;
                }
                List<OilAllowancesGoodTypeTotal> oilAllowancesGoodTypeTotal = new();
                request.NotOverloadNotContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 0,
                    OrderTypeID = 0,
                    IsJoinShip = 0,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant

                }));
                request.NotOverloadContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 0,
                    OrderTypeID = 1,
                    IsJoinShip = 0,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant
                }));
                request.OverloadNotContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 1,
                    OrderTypeID = 0,
                    IsJoinShip = 0,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant
                }));
                request.OverloadContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 1,
                    OrderTypeID = 1,
                    IsJoinShip = 0,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant

                }));

                request.JoinShipOilNotContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 0,
                    OrderTypeID = 0,
                    IsJoinShip = 1,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant

                }));
                request.JoinShipOilContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 0,
                    OrderTypeID = 1,
                    IsJoinShip = 1,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant

                }));



                if (oilAllowancesGoodTypeTotal.Count > 0)
                {
                    DataTable oilAllowancesGoodTypes = oilAllowancesGoodTypeTotal.ToDataTable();
                    oilAllowancesGoodTypes.SetTypeName("OilAllowancesGoodType");
                    parameters.Add("@OilAllowancesGoodTypes", oilAllowancesGoodTypes);
                }
                request.NotOverloadNotContGoodTypes = null;
                request.NotOverloadContGoodTypes = null;
                request.OverloadNotContGoodTypes = null;
                request.OverloadContGoodTypes = null;
                request.JoinShipOilNotContGoodTypes = null;
                request.JoinShipOilContGoodTypes = null;
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
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "EDIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@CmpnID", _UserInfo.CmpnID }
                };
                if (request.OilAllowancesRoutes != null)
                {
                    DataTable OilAllowancesRoutes = request.OilAllowancesRoutes.ToDataTable();
                    OilAllowancesRoutes.SetTypeName("OilAllowancesRoute");
                    parameters.Add("@OilAllowancesRoutes", OilAllowancesRoutes);
                    request.OilAllowancesRoutes = null;
                }
                if (request.OilAllowancesVehicles != null)
                {
                    DataTable OilAllowancesVehicles = request.OilAllowancesVehicles.ToDataTable();
                    OilAllowancesVehicles.SetTypeName("OilAllowancesVehicle");
                    parameters.Add("@OilAllowancesVehicles", OilAllowancesVehicles);
                    request.OilAllowancesVehicles = null;
                }
                List<OilAllowancesGoodTypeTotal> oilAllowancesGoodTypeTotal = new();
                request.NotOverloadNotContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 0,
                    OrderTypeID = 0,
                    IsJoinShip = 0,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant

                }));
                request.NotOverloadContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 0,
                    OrderTypeID = 1,
                    IsJoinShip = 0,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant

                }));
                request.OverloadNotContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 1,
                    OrderTypeID = 0,
                    IsJoinShip = 0,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant

                }));
                request.OverloadContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 1,
                    OrderTypeID = 1,
                    IsJoinShip = 0,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant

                }));
                request.JoinShipOilNotContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 0,
                    OrderTypeID = 0,
                    IsJoinShip = 1,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant

                }));
                request.JoinShipOilContGoodTypes?.ForEach(x => oilAllowancesGoodTypeTotal.Add(new OilAllowancesGoodTypeTotal()
                {
                    IsOverload = 0,
                    OrderTypeID = 1,
                    IsJoinShip = 1,
                    GoodsTypeID = x.GoodsTypeID,
                    NewQuota = x.NewQuota,
                    OldQuota = x.OldQuota,
                    Deviant = x.Deviant

                }));
                if (oilAllowancesGoodTypeTotal.Count > 0)
                {
                    DataTable oilAllowancesGoodTypes = oilAllowancesGoodTypeTotal.ToDataTable();
                    oilAllowancesGoodTypes.SetTypeName("OilAllowancesGoodType");
                    parameters.Add("@OilAllowancesGoodTypes", oilAllowancesGoodTypes);
                }
                request.NotOverloadNotContGoodTypes = null;
                request.NotOverloadContGoodTypes = null;
                request.OverloadNotContGoodTypes = null;
                request.OverloadContGoodTypes = null;
                request.JoinShipOilNotContGoodTypes = null;
                request.JoinShipOilContGoodTypes = null;
                DataResponse dataResponse = await GetDataResponse(parameters, _nPLDB, _ConfigurationDB, _ProcedureName, request);
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Del request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "DEL" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> Copy([FromBody] GetByID request)
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
                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                return Ok(new DataResponse(ex.Message, "", "-1"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GoodTypes([FromBody] GoodTypes request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "GOODTYPES" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> Routes([FromBody] Routes request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "ROUTES" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> Vehicles([FromBody] Vehicles request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "VEHICLES" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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
        public async Task<IActionResult> ChangeStatus([FromBody] EditStatus request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "@type", "SUBMIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID },
                    { "@IsLock", request.IsActive }

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
                    { "@type", "SUBMIT" },
                    { "@language", _UserInfo.Language },
                    { "@UserIDCurent", _UserInfo.UserID }
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