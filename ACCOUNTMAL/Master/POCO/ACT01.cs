namespace ACCOUNTMAL.Master.POCO
{
    /// <summary>
    /// Account Master
    /// </summary>
    public class ACT01
    {
        /// <summary>
        /// Account Holder Unique Id
        /// </summary>
        [ServiceStack.DataAnnotations.PrimaryKey]
        public int T01F01 { get; set; }

        /// <summary>
        /// Account Holder Name
        /// </summary>
        public string T01F02 { get; set; } 

        /// <summary>
        /// City Id
        /// </summary>
        public  int T01F03 { get; set; }

        /// <summary>
        /// Mobile
        /// </summary>
        public string T01F04 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string T01F05 { get; set; }

        /// <summary>
        /// Opening Amount
        /// </summary>
        public decimal T01F06 { get; set; }
    }
}
