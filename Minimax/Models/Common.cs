using System.Text.Json.Serialization;

namespace MiniMax.Client.Models
{
    /// <summary>
    /// Base response information included in most API responses
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Status code (0 for success)
        /// </summary>
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }

        /// <summary>
        /// Status message
        /// </summary>
        [JsonPropertyName("status_msg")]
        public string StatusMsg { get; set; }
    }
} 