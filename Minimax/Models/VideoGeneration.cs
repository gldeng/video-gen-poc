using System.Text.Json.Serialization;

namespace MiniMax.Client.Models
{
    /// <summary>
    /// Request model for video generation
    /// </summary>
    public class VideoGenerationRequest
    {
        /// <summary>
        /// Description for the video to generate
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// ID of the model to use
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Input image data (for image-to-video)
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>
        /// Duration of the generated video in seconds
        /// </summary>
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// Quality setting for video generation
        /// </summary>
        [JsonPropertyName("quality")]
        public string Quality { get; set; }
    }

    /// <summary>
    /// Response model for video generation task creation
    /// </summary>
    public class VideoGenerationTaskResponse
    {
        /// <summary>
        /// ID of the created task
        /// </summary>
        [JsonPropertyName("task_id")]
        public string TaskId { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }

    /// <summary>
    /// Response model for video generation status query
    /// </summary>
    public class VideoGenerationStatusResponse
    {
        /// <summary>
        /// ID of the task
        /// </summary>
        [JsonPropertyName("task_id")]
        public string TaskId { get; set; }

        /// <summary>
        /// Status of the task (Preparing, Queueing, Processing, Success, Fail)
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// File ID of the generated video (when status is Success)
        /// </summary>
        [JsonPropertyName("file_id")]
        public string FileId { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }
} 