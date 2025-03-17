using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KlingAI.Models
{
    // Image generation request
    public class ImageGenerationRequest
    {
        [JsonPropertyName("model_name")]
        public string ModelName { get; set; } = "kling-v1";
        
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        
        [JsonPropertyName("negative_prompt")]
        public string NegativePrompt { get; set; }
        
        [JsonPropertyName("image")]
        public string Image { get; set; }
        
        [JsonPropertyName("image_fidelity")]
        public double? ImageFidelity { get; set; }
        
        [JsonPropertyName("n")]
        public int? N { get; set; }
        
        [JsonPropertyName("aspect_ratio")]
        public string AspectRatio { get; set; }
        
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
    }
    
    // Virtual try-on request
    public class VirtualTryOnRequest
    {
        [JsonPropertyName("model_name")]
        public string ModelName { get; set; } = "kolors-virtual-try-on-v1";
        
        [JsonPropertyName("human_image")]
        public string HumanImage { get; set; }
        
        [JsonPropertyName("cloth_image")]
        public string ClothImage { get; set; }
        
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
    }
    
    // Task list response
    public class TaskListResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public List<TaskDetail> Data { get; set; }
    }
    
    // Task detail response
    public class TaskDetailResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public TaskDetail Data { get; set; }
    }
} 