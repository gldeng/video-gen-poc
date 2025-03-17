using System.Text.Json.Serialization;

namespace MiniMax.Client.Models
{
    /// <summary>
    /// Response model for file upload
    /// </summary>
    public class FileUploadResponse
    {
        /// <summary>
        /// ID of the uploaded file
        /// </summary>
        [JsonPropertyName("file_id")]
        public long FileId { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }

    /// <summary>
    /// Response model for file retrieval
    /// </summary>
    public class FileRetrieveResponse
    {
        /// <summary>
        /// Information about the file
        /// </summary>
        [JsonPropertyName("file")]
        public FileInfo File { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }

    /// <summary>
    /// Information about a file
    /// </summary>
    public class FileInfo
    {
        /// <summary>
        /// ID of the file
        /// </summary>
        [JsonPropertyName("file_id")]
        public long FileId { get; set; }

        /// <summary>
        /// Size of the file in bytes
        /// </summary>
        [JsonPropertyName("bytes")]
        public long Bytes { get; set; }

        /// <summary>
        /// Unix timestamp when the file was created
        /// </summary>
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Purpose of the file
        /// </summary>
        [JsonPropertyName("purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// URL to download the file
        /// </summary>
        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; }
    }
} 