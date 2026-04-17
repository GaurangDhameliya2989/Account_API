using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ACCOUNTMAL
{
    /// <summary>
    /// Account Summary
    /// </summary>
    public class DTOT04
    {
        /// <summary>
        /// Account 
        /// </summary>
        [Required(ErrorMessage = "Account Id is Required.")]
        [JsonProperty("T01X01")]
        public int T01F01 { get; set; } = 0;

        /// <summary>
        /// Opning Amount
        /// </summary>
        [JsonProperty("T01X06")]
        public decimal T01F06 { get; set; } = 0;

        /// <summary>
        /// Status (CR/DB)
        /// </summary>
        [JsonProperty("T03X05")]
        public string T03F05 { get; set; } = string.Empty;

        /// <summary>
        /// Debit/credit Amount
        /// </summary>
        [JsonProperty("T03X06")]
        public decimal T03F06 { get; set; } = 0;

        ///Below Entity is Used To Final Calculation purpose

        /// <summary>
        /// Closing Amount
        /// </summary>
        [JsonProperty("T03X99")]
        public decimal T03F99 { get; set;} = 0;

        /// <summary>
        /// Total Credit Amount
        /// </summary>
        [JsonProperty("T03X98")]
        public decimal T03F98 { get; set; } = 0;

        /// <summary>
        /// Total Debit Amount
        /// </summary>
        [JsonProperty("T03X97")]
        public decimal T03F97 { get; set; } = 0;
    }
}
