using ACCOUNTMAL;
using ACCOUNTMAL.Master.POCO;
using EMPDAL;
using Microsoft.AspNetCore.Http;
using ServiceStack.OrmLite;
using System.Data;

namespace ACCOUNTBAL
{
    /// <summary>
    /// This Handler Manage All Task Related To Account Holder (Insert,Update,Delete)
    /// </summary>
    public class ACT01Handler
    {
        ACT01 objT01 = null;
        public void PerSave(DTOT01 objDTOT01)
        {
            objT01 = new ACT01();
            objT01.T01F01 = objDTOT01.T01F01;
            objT01.T01F02 = objDTOT01.T01F02;
            objT01.T01F03 = objDTOT01.T01F03;
            objT01.T01F04 = objDTOT01.T01F04;
            objT01.T01F05 = objDTOT01.T01F05;
            objT01.T01F06 = objDTOT01.T01F06;
        }

        /// <summary>
        /// Insert New Account Holder
        /// </summary>
        public Response Insert()
        {
            Response objResponse = new Response();
            int acHolderId = 0;
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT01.T01F01 == 0)
                    {
                        acHolderId = (int) db.Insert(objT01 ,selectIdentity:true);
                        objResponse.Message = "Recored Insert Sucessfully";
                    }
                    else
                    {
                        objResponse.Message = "Recored AllReady Exist.";
                    }
                    Trans.Commit();
                }
            }
            objResponse.Status = StatusCodes.Status200OK;
            objResponse.Result = acHolderId;
            return objResponse ;
        }

        /// <summary>
        /// Update Account Holder Detail
        /// </summary>
        public Response Update()
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT01.T01F01 != 0)
                    {
                        db.Update(objT01);
                        objResponse.Message = "Account Holder's Detail Update Sucessfully.";
                        objResponse.Status = StatusCodes.Status200OK;
                        objResponse.Result = objT01;
                    }
                    else
                    {
                        objResponse.Message = "Account Holder Not Exist.";
                        objResponse.Status = StatusCodes.Status404NotFound;
                    }
                    Trans.Commit();
                }
            }
            return objResponse;
        }

        /// <summary>
        /// Delete Account Holder
        /// </summary>
        public Response Delete(int acHolderId)
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (acHolderId != 0)
                    {
                        db.DeleteById<ACT01>(acHolderId);
                        objResponse.Message = "Account Holder Delete Sucessfully.";
                        objResponse.Status = StatusCodes.Status200OK;
                        objResponse.Result = acHolderId;
                    }
                    else
                    {
                        objResponse.Message = "Account Holder Doesn't Exist";
                        objResponse.Status = StatusCodes.Status404NotFound;
                    }
                    Trans.Commit();
                }
            }
            return objResponse;
        }
    }
}
