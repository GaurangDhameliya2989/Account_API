using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ACCOUNTMAL
{
    /// <summary>
    /// Account Master
    /// </summary>
    public class DTOT01
    {
        /// <summary>
        /// Account Holder Unique Id
        /// </summary>
        [Required(ErrorMessage = "Account Holder Id Is Mendatory")]
        [JsonProperty("T01X01")]
        public int T01F01 { get; set; } = 0;

        /// <summary>
        /// Account Holder Name
        /// </summary>
        [StringLength(60 ,ErrorMessage = "The Account  Holder Name Is Must Be At Most 60 Characters")]
        [JsonProperty("T01X02")]
        public string T01F02 { get; set; } = string.Empty;

        /// <summary>
        /// City Id
        /// </summary>
        [JsonProperty("T01X03")]
        public int T01F03 { get; set; } = 0;

        /// <summary>
        /// Mobile
        /// </summary>
        [StringLength(10 ,MinimumLength = 10, ErrorMessage = "10 Degit Mobile No. is Mendatory")]
        [JsonProperty("T01X04")]
        public string T01F04 { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(60 ,ErrorMessage ="Email Is Required.")]
        [EmailAddress(ErrorMessage ="Invalid Email Format.")]
        [JsonProperty("T01X05")]
        public string T01F05 { get; set; } = string.Empty;

        /// <summary>
        /// Opning Amount
        /// </summary>
        [JsonProperty("T01X06")]
        public decimal T01F06 { get; set; } = 0;
    }
}
