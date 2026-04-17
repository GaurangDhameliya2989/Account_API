namespace ACCOUNTMAL.Master.POCO
{
    /// <summary>
    /// Transaction Master
    /// </summary>
    public class ACT03
    {
        /// <summary>
        /// Transaction Id
        /// </summary>
        [ServiceStack.DataAnnotations.PrimaryKey]
        public int T03F01 { get; set; }

        /// <summary>
        /// Account Id 
        /// </summary>
        public int T03F02 { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        public string T03F03 { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateOnly T03F04 { get; set; }

        /// <summary>
        /// Credit/Debit
        /// </summary>
        public string T03F05 { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal T03F06 { get; set; }
    }
}
