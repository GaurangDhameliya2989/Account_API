using System.Text.Json.Serialization;

namespace ACCOUNTMAL
{
    public class BaseResponse
    {
        /// <summary>
        /// Error Status
        /// </summary>
        [JsonIgnore]
        public bool IsError { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}
