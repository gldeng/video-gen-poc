using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MiniMax.Client.Models
{
    /// <summary>
    /// Request model for image generation
    /// </summary>
    public class ImageGenerationRequest
    {
        /// <summary>
        /// ID of the model to use
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Description for the image to generate
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// Controls the aspect ratio of the generated image
        /// </summary>
        [JsonPropertyName("aspect_ratio")]
        public string AspectRatio { get; set; }

        /// <summary>
        /// Controls the output format (url or base64)
        /// </summary>
        [JsonPropertyName("response_format")]
        public string ResponseFormat { get; set; }

        /// <summary>
        /// Random seed for image generation
        /// </summary>
        [JsonPropertyName("seed")]
        public int? Seed { get; set; }

        /// <summary>
        /// Number of images to generate
        /// </summary>
        [JsonPropertyName("n")]
        public int? N { get; set; }

        /// <summary>
        /// Whether to enable automatic prompt optimization
        /// </summary>
        [JsonPropertyName("prompt_optimizer")]
        public bool? PromptOptimizer { get; set; }
    }

    /// <summary>
    /// Response model for image generation
    /// </summary>
    public class ImageGenerationResponse
    {
        /// <summary>
        /// Unique ID of the request
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Data for the generated images
        /// </summary>
        [JsonPropertyName("data")]
        public ImageData Data { get; set; }

        /// <summary>
        /// Additional metadata about the generation
        /// </summary>
        [JsonPropertyName("metadata")]
        public ImageMetadata Metadata { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }

    /// <summary>
    /// Data containing the generated images
    /// </summary>
    public class ImageData
    {
        /// <summary>
        /// URLs of the generated images
        /// </summary>
        [JsonPropertyName("image_urls")]
        public List<string> ImageUrls { get; set; }
    }

    /// <summary>
    /// Metadata about the image generation
    /// </summary>
    public class ImageMetadata
    {
        /// <summary>
        /// Number of image generations that failed
        /// </summary>
        [JsonPropertyName("failed_count")]
        public string FailedCount { get; set; }

        /// <summary>
        /// Number of successful image generations
        /// </summary>
        [JsonPropertyName("success_count")]
        public string SuccessCount { get; set; }
    }
} 