using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MiniMax.Client.Models
{
    /// <summary>
    /// Request model for chat completion
    /// </summary>
    public class ChatCompletionRequest
    {
        /// <summary>
        /// ID of the model to use
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// A list of messages comprising the conversation
        /// </summary>
        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; }

        /// <summary>
        /// Controls randomness: 0 means deterministic, higher values mean more random
        /// </summary>
        [JsonPropertyName("temperature")]
        public float? Temperature { get; set; }

        /// <summary>
        /// Nucleus sampling: only consider tokens with the top-p cumulative probability
        /// </summary>
        [JsonPropertyName("top_p")]
        public float? TopP { get; set; }

        /// <summary>
        /// How many chat completion choices to generate for each input message
        /// </summary>
        [JsonPropertyName("n")]
        public int? N { get; set; }

        /// <summary>
        /// Whether to stream back partial progress
        /// </summary>
        [JsonPropertyName("stream")]
        public bool? Stream { get; set; }

        /// <summary>
        /// Up to how many completions to generate
        /// </summary>
        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; }

        /// <summary>
        /// Penalize repeating tokens
        /// </summary>
        [JsonPropertyName("presence_penalty")]
        public float? PresencePenalty { get; set; }

        /// <summary>
        /// Penalize tokens based on their frequency
        /// </summary>
        [JsonPropertyName("frequency_penalty")]
        public float? FrequencyPenalty { get; set; }

        /// <summary>
        /// Mask sensitive information in the output
        /// </summary>
        [JsonPropertyName("mask_sensitive_info")]
        public bool? MaskSensitiveInfo { get; set; }

        /// <summary>
        /// List of tools the model may call
        /// </summary>
        [JsonPropertyName("tools")]
        public List<Tool> Tools { get; set; }

        /// <summary>
        /// Specifies the format for the model output
        /// </summary>
        [JsonPropertyName("response_format")]
        public ResponseFormat ResponseFormat { get; set; }
    }

    /// <summary>
    /// Message in a conversation
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Role of the message sender
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// Optional name of the sender
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Content of the message
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    /// <summary>
    /// Tool that the model can use
    /// </summary>
    public class Tool
    {
        /// <summary>
        /// Type of the tool
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Function that can be called by the model
        /// </summary>
        [JsonPropertyName("function")]
        public Function Function { get; set; }
    }

    /// <summary>
    /// Function that can be called by the model
    /// </summary>
    public class Function
    {
        /// <summary>
        /// Name of the function
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the function
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Parameters accepted by the function
        /// </summary>
        [JsonPropertyName("parameters")]
        public object Parameters { get; set; }
    }

    /// <summary>
    /// Format for the model output
    /// </summary>
    public class ResponseFormat
    {
        /// <summary>
        /// Type of the response format
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// JSON schema for structured output
        /// </summary>
        [JsonPropertyName("json_schema")]
        public object JsonSchema { get; set; }
    }

    /// <summary>
    /// Response model for chat completion
    /// </summary>
    public class ChatCompletionResponse
    {
        /// <summary>
        /// Unique identifier for the chat completion
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The list of completion choices
        /// </summary>
        [JsonPropertyName("choices")]
        public List<Choice> Choices { get; set; }

        /// <summary>
        /// Unix timestamp when the completion was created
        /// </summary>
        [JsonPropertyName("created")]
        public long Created { get; set; }

        /// <summary>
        /// The model used for completion
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// The object type
        /// </summary>
        [JsonPropertyName("object")]
        public string Object { get; set; }

        /// <summary>
        /// Usage statistics for the completion
        /// </summary>
        [JsonPropertyName("usage")]
        public Usage Usage { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }

    /// <summary>
    /// A completion choice
    /// </summary>
    public class Choice
    {
        /// <summary>
        /// The reason why the completion finished
        /// </summary>
        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; }

        /// <summary>
        /// The index of this choice
        /// </summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>
        /// The message generated by the model
        /// </summary>
        [JsonPropertyName("message")]
        public Message Message { get; set; }
    }

    /// <summary>
    /// Token usage information
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// Total number of tokens used
        /// </summary>
        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
} 