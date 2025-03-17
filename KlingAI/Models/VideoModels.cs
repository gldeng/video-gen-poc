using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KlingAI.Models
{
    // Camera control for videos
    public class CameraControl
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("config")]
        public CameraConfig Config { get; set; }
    }
    
    public class CameraConfig
    {
        [JsonPropertyName("horizontal")]
        public double? Horizontal { get; set; }
        
        [JsonPropertyName("vertical")]
        public double? Vertical { get; set; }
        
        [JsonPropertyName("pan")]
        public double? Pan { get; set; }
        
        [JsonPropertyName("tilt")]
        public double? Tilt { get; set; }
        
        [JsonPropertyName("roll")]
        public double? Roll { get; set; }
        
        [JsonPropertyName("zoom")]
        public double? Zoom { get; set; }
    }
    
    // Text to video request
    public class TextToVideoRequest
    {
        [JsonPropertyName("model_name")]
        public string ModelName { get; set; } = "kling-v1";
        
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        
        [JsonPropertyName("negative_prompt")]
        public string NegativePrompt { get; set; }
        
        [JsonPropertyName("cfg_scale")]
        public double? CfgScale { get; set; }
        
        [JsonPropertyName("mode")]
        public string Mode { get; set; }
        
        [JsonPropertyName("camera_control")]
        public CameraControl CameraControl { get; set; }
        
        [JsonPropertyName("aspect_ratio")]
        public string AspectRatio { get; set; }
        
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
        
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        
        [JsonPropertyName("external_task_id")]
        public string ExternalTaskId { get; set; }
    }
    
    // Image to video request
    public class ImageToVideoRequest
    {
        [JsonPropertyName("model_name")]
        public string ModelName { get; set; } = "kling-v1";
        
        [JsonPropertyName("image")]
        public string Image { get; set; }
        
        [JsonPropertyName("image_tail")]
        public string ImageTail { get; set; }
        
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        
        [JsonPropertyName("negative_prompt")]
        public string NegativePrompt { get; set; }
        
        [JsonPropertyName("cfg_scale")]
        public double? CfgScale { get; set; }
        
        [JsonPropertyName("mode")]
        public string Mode { get; set; }
        
        [JsonPropertyName("static_mask")]
        public string StaticMask { get; set; }
        
        [JsonPropertyName("dynamic_masks")]
        public List<DynamicMask> DynamicMasks { get; set; }
        
        [JsonPropertyName("camera_control")]
        public CameraControl CameraControl { get; set; }
        
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
        
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        
        [JsonPropertyName("external_task_id")]
        public string ExternalTaskId { get; set; }
    }
    
    public class DynamicMask
    {
        [JsonPropertyName("mask")]
        public string Mask { get; set; }
        
        [JsonPropertyName("trajectories")]
        public List<Trajectory> Trajectories { get; set; }
    }
    
    public class Trajectory
    {
        [JsonPropertyName("x")]
        public int X { get; set; }
        
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
    
    // Video extend request
    public class VideoExtendRequest
    {
        [JsonPropertyName("video_id")]
        public string VideoId { get; set; }
        
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
    }
    
    // Lip sync request
    public class LipSyncRequest
    {
        [JsonPropertyName("input")]
        public LipSyncInput Input { get; set; }
        
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
    }
    
    public class LipSyncInput
    {
        [JsonPropertyName("video_id")]
        public string VideoId { get; set; }
        
        [JsonPropertyName("mode")]
        public string Mode { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("voice_id")]
        public string VoiceId { get; set; }
        
        [JsonPropertyName("voice_language")]
        public string VoiceLanguage { get; set; }
        
        [JsonPropertyName("voice_speed")]
        public double? VoiceSpeed { get; set; }
        
        [JsonPropertyName("audio_type")]
        public string AudioType { get; set; }
        
        [JsonPropertyName("audio_file")]
        public string AudioFile { get; set; }
        
        [JsonPropertyName("audio_url")]
        public string AudioUrl { get; set; }
    }
    
    // Video effects request
    public class VideoEffectsRequest
    {
        [JsonPropertyName("effect_scene")]
        public string EffectScene { get; set; }
        
        [JsonPropertyName("input")]
        public object Input { get; set; } // Can be SingleImageEffectInput or DualCharacterEffectInput
        
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        
        [JsonPropertyName("external_task_id")]
        public string ExternalTaskId { get; set; }
    }
    
    public class SingleImageEffectInput
    {
        [JsonPropertyName("model_name")]
        public string ModelName { get; set; }
        
        [JsonPropertyName("image")]
        public string Image { get; set; }
        
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
    }
    
    public class DualCharacterEffectInput
    {
        [JsonPropertyName("model_name")]
        public string ModelName { get; set; } = "kling-v1";
        
        [JsonPropertyName("mode")]
        public string Mode { get; set; } = "std";
        
        [JsonPropertyName("images")]
        public List<string> Images { get; set; }
        
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
    }
    
    // Video task responses
    public class VideoTaskListResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public List<VideoTaskDetail> Data { get; set; }
    }
    
    public class VideoTaskDetailResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public VideoTaskDetail Data { get; set; }
    }
    
    public class VideoTaskDetail
    {
        [JsonPropertyName("task_id")]
        public string TaskId { get; set; }
        
        [JsonPropertyName("task_status")]
        public string TaskStatus { get; set; }
        
        [JsonPropertyName("task_status_msg")]
        public string TaskStatusMsg { get; set; }
        
        [JsonPropertyName("task_info")]
        public TaskInfo TaskInfo { get; set; }
        
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
        
        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }
        
        [JsonPropertyName("task_result")]
        public VideoTaskResult TaskResult { get; set; }
    }
    
    public class VideoTaskResult
    {
        [JsonPropertyName("videos")]
        public List<VideoResult> Videos { get; set; }
    }
    
    public class VideoResult
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("url")]
        public string Url { get; set; }
        
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
    }
    
    // Video extend responses
    public class VideoExtendTaskListResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public List<VideoExtendTaskDetail> Data { get; set; }
    }
    
    public class VideoExtendTaskDetailResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public VideoExtendTaskDetail Data { get; set; }
    }
    
    public class VideoExtendTaskDetail
    {
        [JsonPropertyName("task_id")]
        public string TaskId { get; set; }
        
        [JsonPropertyName("task_status")]
        public string TaskStatus { get; set; }
        
        [JsonPropertyName("task_status_msg")]
        public string TaskStatusMsg { get; set; }
        
        [JsonPropertyName("task_info")]
        public VideoExtendTaskInfo TaskInfo { get; set; }
        
        [JsonPropertyName("task_result")]
        public VideoTaskResult TaskResult { get; set; }
        
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
        
        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }
    }
    
    public class VideoExtendTaskInfo
    {
        [JsonPropertyName("parent_video")]
        public VideoResult ParentVideo { get; set; }
    }
} 