using ACCOUNTMAL;
using ACCOUNTMAL.Master.POCO;
using EMPDAL;
using Microsoft.AspNetCore.Http;
using ServiceStack.OrmLite;
using System.Data;

namespace ACCOUNTBAL
{
    /// <summary>
    /// This Handler Is Manage All Task Related To City (Insert,Update,Delete)
    /// </summary>
    public class ACT02Handler
    {
        ACT02 objT02 = null;

        public void PreSave(DTOT02 objDTOT02)
        {
            objT02 = new ACT02();
            objT02.T02F01 = objDTOT02.T02F01;
            objT02.T02F02 = objDTOT02.T02F02;
        }

        /// <summary>
        /// Add New City
        /// </summary>
        public Response Insert()
        {
            Response objResponse = new Response();
            int cityId = 0;
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT02.T02F01 == 0)
                    {
                        cityId = (int) db.Insert(objT02 ,selectIdentity: true);
                        objResponse.Message = "City Insert Sucessfully.";
                    }
                    else
                    {
                        objResponse.Message = "Recored AllReady Exist.";
                    }
                    Trans.Commit();
                }
            }
            objResponse.Status = StatusCodes.Status200OK;
            objResponse.Result = cityId;
            return objResponse;
        }

        /// <summary>
        /// Update City Name 
        /// </summary>
        public Response Update()
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT02.T02F01 != 0)
                    {
                        db.Update(objT02);
                        objResponse.Message = "City Update Sucessfully.";
                        objResponse.Status = StatusCodes.Status200OK;
                        objResponse.Result = objT02;
                    }
                    else
                    {
                        objResponse.Message = "City Is Not Exist.";
                        objResponse.Status = StatusCodes.Status404NotFound;
                    }
                    Trans.Commit();
                }
            }
            return objResponse;
        }

        /// <summary>
        /// Delete City
        /// </summary>
        public Response Delete(int cityId)
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (cityId != 0)
                    {
                        db.DeleteById<ACT02>(cityId);
                        objResponse.Message = "City Dlete Sucessfully.";
                        objResponse.Status = StatusCodes.Status200OK;
                        objResponse.Result = cityId;
                    }
                    else
                    {
                        objResponse.Message = "City Doesn't Exist.";
                        objResponse.Status = StatusCodes.Status404NotFound;
                    }
                    Trans.Commit();
                }
            }
            return objResponse;
        }
    }
}
