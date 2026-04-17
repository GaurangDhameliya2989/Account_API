namespace ACCOUNTMAL.Master.POCO
{
    /// <summary>
    /// City Master
    /// </summary>
    public class ACT02
    {
        /// <summary>
        /// City Id
        /// </summary>
        [ServiceStack.DataAnnotations.PrimaryKey]
        public int T02F01 { get; set; }

        /// <summary>
        /// City Name
        /// </summary>
        public string T02F02 { get; set; }
    }
}
