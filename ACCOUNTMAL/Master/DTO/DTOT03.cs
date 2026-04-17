using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ACCOUNTMAL
{
    /// <summary>
    /// Transaction Master
    /// </summary>
    public class DTOT03
    {
        /// <summary>
        /// Transaction Id 
        /// </summary>
        [Required(ErrorMessage ="Transaction Id Is Required.")]
        [JsonProperty("T03X01")]
        public int T03F01 { get; set; } = 0;

        /// <summary>
        /// Account Id
        /// </summary>
        [Required(ErrorMessage ="Account Id Is Required.")]
        [JsonProperty("T03X02")]
        public int T03F02 { get; set; } = 0;

        /// <summary>
        /// Transaction Number
        /// </summary>
        [StringLength(12 ,MinimumLength = 12,ErrorMessage ="12 Degit Transaction Number Is Mendatory.")]
        [JsonProperty("T03X03")]
        public string T03F03 { get; set; } = string.Empty;

        /// <summary>
        /// Date
        /// </summary>
        [JsonProperty("T03X04")]
        public DateOnly T03F04 { get; set; }

        /// <summary>
        /// Credit/Debit
        /// </summary>
        [JsonProperty("T03X05")]
        public string T03F05 { get; set; } = string.Empty;

        /// <summary>
        /// Amount
        /// </summary>
        [JsonProperty("T03X06")]
        public decimal T03F06 { get; set; } = 0;
    }
}
