using ACCOUNTMAL;
using ACCOUNTMAL.Master.POCO;
using EMPDAL;
using ServiceStack.OrmLite;

namespace ACCOUNTDAL
{
    /// <summary>
    /// This Context Class is Handle All Retrive aboute Summary.
    /// </summary>
    public class DBACT03Context
    {
        public List<DTOT04> Get(int id)
        {
            using (var db = new MySqlOrmLite().Open())
            {
                return db.Select<DTOT04>(@"
                    Select
                        T01.T01F01,
                        T01.T01F06,
                        T03.T03F05,
                        T03.T03F06
                    From
                        ACT01 T01
                    JOIN ACT03 T03 ON T01.T01F01=T03.T03F02
                    WHERE T01.T01F01 = @AccountId;", new {AccountId = id}
                );
            }
        }
    }
}
