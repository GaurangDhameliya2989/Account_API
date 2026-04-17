using ACCOUNTDAL;
using ACCOUNTMAL;
using ACCOUNTMAL.Master.POCO;
using EMPDAL;
using Microsoft.AspNetCore.Http;
using ServiceStack.OrmLite;
using System.Data;

namespace ACCOUNTBAL
{
    /// <summary>
    /// This Handler is Handle All Transaction And Summary.
    /// </summary>
    public class ACT03Handler
    {
        ACT03 objT03 = null;

        public void PreSave(DTOT03 objDTOT03)
        {
            objT03 = new ACT03();
            objT03.T03F01 = objDTOT03.T03F01;
            objT03.T03F02 = objDTOT03.T03F02;
            objT03.T03F03 = objDTOT03.T03F03;
            objT03.T03F04 = objDTOT03.T03F04;
            objT03.T03F05 = objDTOT03.T03F05;
            objT03.T03F06 = objDTOT03.T03F06;
        }

        /// <summary>
        /// Add New Transaction 
        /// </summary>
        public Response Insert()
        {
            Response objResponse = new Response();
            int transId = 0;
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT03.T03F01 == 0)
                    {
                        transId = (int) db.Insert(objT03 ,selectIdentity: true);
                        objResponse.Message = "Transaction Sucessfully.";
                    }
                    else
                    {
                        objResponse.Message = "Transaction Failed.";
                    }
                    Trans.Commit();
                }
            }
            objResponse.Status = StatusCodes.Status200OK;
            objResponse.Result = transId;
            return objResponse;
        }
        
        /// <summary>
        /// Update Transaction Detail
        /// </summary>
        public Response Update()
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT03.T03F01 != 0)
                    {
                        db.Update(objT03);
                        objResponse.Message = "Your Transaction Update Sucessfully.";
                        objResponse.Status = StatusCodes.Status200OK;
                        objResponse.Result = objT03;
                    }
                    else
                    {
                        objResponse.Message = "Transaction Doesn't Exist.";
                        objResponse.Status = StatusCodes.Status404NotFound;
                    }
                    Trans.Commit();
                }
            }
            return objResponse;
        }

        /// <summary>
        /// Delate Transaction
        /// </summary>
        public Response Delete(int transactionId)
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (transactionId != 0)
                    {
                        db.DeleteById<ACT03>(transactionId);
                        objResponse.Message = "Transaction Delete Sucessfully.";
                        objResponse.Status= StatusCodes.Status200OK;
                        objResponse.Result = transactionId;
                    }
                    else
                    {
                        objResponse.Message = "Transaction Doesn't Exist.";
                        objResponse.Status = StatusCodes.Status404NotFound;
                    }
                    Trans.Commit();
                }
            }
            return objResponse;
        }

        /// <summary>
        /// This Method is Used to Get Summary.
        /// </summary>
        public Response Get(int id)
        {
            Response objResponse = new Response();
            List<DTOT04> lstT04 = new List<DTOT04>();
            DTOT04 objT04 = new DTOT04();
            DBACT03Context objT03Context = new DBACT03Context();
            lstT04 = objT03Context.Get(id);
            if (lstT04 != null)
            {
                foreach (var T04 in lstT04)
                {
                    if (T04.T03F05 == "CR")
                    {
                        objT04.T03F98 = objT04.T03F98 + T04.T03F06;
                    }
                    else
                    {
                        objT04.T03F97 = objT04.T03F97 + T04.T03F06;
                    }
                    objT04.T01F01 = T04.T01F01;
                    objT04.T01F06 = T04.T01F06;
                }
                objT04.T03F99 = objT04.T01F06 + objT04.T03F98 - objT04.T03F97;
            }
            if (objT04 != null)
            {
                objResponse.Result = objT04;
                objResponse.Status = StatusCodes.Status200OK;
                objResponse.Message = "Transaction Summary Fatched.";
            }
            else
            {
                objResponse.Status = StatusCodes.Status404NotFound;
                objResponse.Message = "No Recored Found.";
            }
          
            return objResponse;
        }
    }
}
