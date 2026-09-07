using APISmartCity.lib;
using APISmartCity.Models;
using APISmartCity.Models.Systems;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace APISmartCity.TransferDataPostgreSQLServices
{
    public class TransferDataPostgreSQLService
    {
        private readonly string _ConfigurationDB;
        private readonly string _SecondaryDB;
        private readonly string _ProcedurePostgreName = "ExecGeoemtryLocation";

        public TransferDataPostgreSQLService()
        {
            _ConfigurationDB = Global.ListDB?.Find(item => item.DBType == "CON")?.DBString!;
            _SecondaryDB = Global.ListDB?.Find(item => item.DBType == "FUN")?.DBString!;

        }
        public async Task GetStationDataForPostgreSQL(Default.Request.ID_ByString request)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                };

                DataResponse dataResponse = await Function.GetDataResponse(parameters, _SecondaryDB, _ConfigurationDB, _ProcedurePostgreName, request);

                if (dataResponse.Result != null && dataResponse.Result.Count > 0)
                {
                    var filteredResult = ((IEnumerable<dynamic>)dataResponse.Result).Where(s => s.statusid == 1).ToList();
                    if (filteredResult.Count > 0)
                    {
                        CheckStationDataToPostgreSQL(filteredResult);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async void CheckStationDataToPostgreSQL(dynamic data)
        {
            try
            {
                using (var connection = new NpgsqlConnection(Global.connectStringPostgreSQL))
                {
                    await connection.OpenAsync(); //  

                    foreach (var d in data)
                    {
                        bool HasRows = false;
                        string query = $"SELECT fid FROM public.\"StationData\" where processtreeid  = '{d.processtreeid}' and statusid = 1 ";

                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                HasRows = reader.HasRows;
                            }
                        }
                        if (HasRows)
                        {
                            string string_geom = d.the_geom;
                            string sql = "UPDATE \"StationData\" SET " +
                                "the_geom = " + string_geom +
                                ", serverid = '" + d.serverid +
                                "', cmpnid = '" + d.cmpnid +
                                "', geocode = '" + d.geocode +
                                "', stationid = '" + d.stationid +
                                "', stationcode = '" + d.stationcode +
                                "', stationno = '" + d.stationno +
                                "', stationlink = '" + d.stationlink +
                                "', stationname = '" + d.stationname +
                                "', stationaddress = '" + d.stationaddress +
                                "', statusid = '" + d.statusid +
                                "', statusicon = '" + d.statusicon +
                                "', statusname = '" + d.statusname +
                                "', updatetime = '" + d.updatetime.ToString("yyyy-MM-dd HH:mm:ss") +
                                "', regionid01 = '" + d.regionid01 +
                                "', regionid02 = '" + d.regionid02 +
                                "', regionid03 = '" + d.regionid03 +
                                "', regionid04 = '" + d.regionid04 +
                                "', regionid05 = '" + d.regionid05 +
                                "', referenceid = '" + d.referenceid +
                                "', createuser = '" + d.createuser +
                                "', createdate = '" + d.createdate.ToString("yyyy-MM-dd HH:mm:ss") +
                                "', changedate = '" + d.changedate.ToString("yyyy-MM-dd HH:mm:ss") +
                                "', changeuser = '" + d.changeuser +
                                "', lat = '" + d.lat +
                                "', \"long\" = '" + d.Long +
                                "', regionid06 = '" + d.regionid06 +
                                "', type = '" + d.type +
                                "', stationstatus = '" + d.stationstatus +
                                "', stationtypeid = '" + d.stationtypeid +
                                "', stationtypename = '" + d.stationtypename +
                                "', managementunitid = '" + d.managementunitid +
                                "', managementunitname = '" + d.managementunitname +
                                "', stationstatuscolor = '" + d.stationstatuscolor +
                                "', stationstatusname = '" + d.stationstatusname +
                                "', stationheight = '" + d.stationheight +
                                "', stationheightname = '" + d.stationheightname +
                                "', treediameter = '" + d.stationdiameter +
                                "', treediametername = '" + d.stationdiametername +
                                "', foliagediameter = '" + d.foliagediameter +
                                "', foliagediametername = '" + d.foliagediametername +
                                "', stationage = '" + d.stationage +
                                "', stationagename = '" + d.stationagename +
                                "', regionname1 = '" + d.regionname01 +
                                "', regionname2 = '" + d.regionname02 +
                                "', regionname3 = '" + d.regionname03 +
                                "', regionname4 = '" + d.regionname04 +
                                "', regionname5 = '" + d.regionname05 +
                                "', regionname6 = '" + d.regionname06 +
                                "', stationcategoryid = '" + d.stationcategoryid +
                                "', stationcategoryname = '" + d.stationcategoryname +
                                "', stationgroupid = '" + d.stationgroupid +
                                "', stationgroupname = '" + d.stationgroupname +
                                "' WHERE processtreeid = '" + d.processtreeid + "';";

                            // Execute the UPDATE query
                            using (var commandUpdate = new NpgsqlCommand(sql, connection))
                            {
                              await  commandUpdate.ExecuteNonQueryAsync();
                            }
                        }
                        else
                        {
                            string string_geom = d.the_geom;
                            string sql = "INSERT INTO \"StationData\" " +
                                "(the_geom, serverid, cmpnid, geocode, stationid, stationcode, stationno, stationlink, stationname, stationaddress, statusid, statusicon, statusname, updatetime," +
                                " regionid01, regionid02, regionid03, regionid04, regionid05, referenceid, createuser, createdate, changedate, changeuser, processtreeid, lat, \"long\", regionid06, type, stationstatus, stationtypeid, stationtypename, managementunitid," +
                                " managementunitname, stationstatuscolor, stationstatusname, stationheight, stationheightname, treediameter, treediametername, foliagediameter, foliagediametername, stationage, stationagename, regionname1, " +
                                "regionname2, regionname3, regionname4, regionname5, regionname6,stationcategoryid,stationcategoryname,stationgroupid,stationgroupname) " +

                                "SELECT " + string_geom + ", '" + d.serverid + "', '" + d.cmpnid + "', '" + d.geocode + "', '" + d.stationid + "', '" + d.stationcode + "', '" + d.stationno + "', '" + d.stationlink + "','" + d.stationname + "', '" + d.stationaddress + "', '" + d.statusid + "', '"
                                + d.statusicon + "', '" + d.statusname + "', '" + d.updatetime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + d.regionid01 + "', '" + d.regionid02 + "', '" + d.regionid03 + "', '" + "" + d.regionid04 + "', '" + d.regionid05 + "', '" + d.referenceid + "', '" + d.createuser + "', '" + d.createdate.ToString("yyyy-MM-dd HH:mm:ss")
                                + "', '" + d.changedate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + d.changeuser + "', '" + d.processtreeid + "', '" + d.lat + "', '" + d.Long + "', '" + d.regionid06 + "', '" + d.type + "', '" + d.stationstatus + "', '" + d.stationtypeid + "', '" + d.stationtypename + "','" + d.managementunitid
                                + "', '" + d.managementunitname + "', '" + d.stationstatuscolor + "', '" + d.stationstatusname + "', '" + d.stationheight + "', '" + d.stationheightname + "', '" + d.stationdiameter + "', '" + d.stationdiametername + "', '" + d.foliagediameter + "', '" + d.foliagediametername +
                                "', '" + d.stationage + "', '" + d.stationagename + "', '" + d.regionname01 + "', '" + d.regionname02 + "', '" + d.regionname03 + "', '" + d.regionname04 + "', '" + d.regionname05 + "','" + d.regionname06 + "','" + d.stationcategoryid + "','" + d.stationcategoryname + "','" + d.stationgroupid + "','" + d.stationgroupname + "';";

                            // Execute the INSERT query
                            using (var commandInsert = new NpgsqlCommand(sql, connection))
                            {
                                await commandInsert.ExecuteNonQueryAsync();
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}