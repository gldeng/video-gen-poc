using System.Text.Json.Serialization;

namespace MiniMax.Client.Models
{
    /// <summary>
    /// Request model for voice cloning
    /// </summary>
    public class VoiceCloneRequest
    {
        /// <summary>
        /// ID of the file to clone voice from
        /// </summary>
        [JsonPropertyName("file_id")]
        public long FileId { get; set; }

        /// <summary>
        /// Custom ID for the cloned voice
        /// </summary>
        [JsonPropertyName("voice_id")]
        public string VoiceId { get; set; }

        /// <summary>
        /// Whether to apply noise reduction
        /// </summary>
        [JsonPropertyName("noise_reduction")]
        public bool? NoiseReduction { get; set; }

        /// <summary>
        /// Text to preview with cloned voice
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// Model to use for preview
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Text validation accuracy threshold
        /// </summary>
        [JsonPropertyName("accuracy")]
        public float? Accuracy { get; set; }

        /// <summary>
        /// Whether to enable volume normalization
        /// </summary>
        [JsonPropertyName("need_volume_normalization")]
        public bool? NeedVolumeNormalization { get; set; }
    }

    /// <summary>
    /// Response model for voice cloning
    /// </summary>
    public class VoiceCloneResponse
    {
        /// <summary>
        /// Whether the input audio has triggered any errors
        /// </summary>
        [JsonPropertyName("input_sensitive")]
        public bool InputSensitive { get; set; }

        /// <summary>
        /// Type of sensitivity issue
        /// </summary>
        [JsonPropertyName("input_sensitive_type")]
        public int InputSensitiveType { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }
} 