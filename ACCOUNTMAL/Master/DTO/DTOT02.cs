using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ACCOUNTMAL
{
    /// <summary>
    /// City Master
    /// </summary>
    public class DTOT02
    {
        /// <summary>
        /// City Id
        /// </summary>
        [Required(ErrorMessage ="City Id Is Required.")]
        [JsonProperty("T02X01")]
        public int T02F01 { get; set; } = 0;

        /// <summary>
        /// City Name 
        /// </summary>
        [StringLength(60 , ErrorMessage = "City Name is Must Be At most 60 Characters.")]
        [JsonProperty("T02X02")]
        public string T02F02 { get; set; } = string.Empty;
    }
}
