using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KlingAI.Models
{
    public class BaseResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        
        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }
    }
    
    public class TaskResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public TaskResponseData Data { get; set; }
    }
    
    public class TaskResponseData
    {
        [JsonPropertyName("task_id")]
        public string TaskId { get; set; }
        
        [JsonPropertyName("task_status")]
        public string TaskStatus { get; set; }
        
        [JsonPropertyName("task_info")]
        public TaskInfo TaskInfo { get; set; }
        
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
        
        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }
    }
    
    public class TaskInfo
    {
        [JsonPropertyName("external_task_id")]
        public string ExternalTaskId { get; set; }
    }
    
    public enum TaskStatus
    {
        Submitted,
        Processing,
        Succeed,
        Failed
    }
    
    public class TaskDetail
    {
        [JsonPropertyName("task_id")]
        public string TaskId { get; set; }
        
        [JsonPropertyName("task_status")]
        public string TaskStatus { get; set; }
        
        [JsonPropertyName("task_status_msg")]
        public string TaskStatusMsg { get; set; }
        
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
        
        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }
        
        [JsonPropertyName("task_result")]
        public TaskResult TaskResult { get; set; }
    }
    
    public class TaskResult
    {
        [JsonPropertyName("images")]
        public List<ImageResult> Images { get; set; }
    }
    
    public class ImageResult
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }
        
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
} 