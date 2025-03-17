using System.Text.Json.Serialization;

namespace MiniMax.Client.Models
{
    /// <summary>
    /// Request model for music file upload
    /// </summary>
    public class MusicUploadRequest
    {
        /// <summary>
        /// Purpose of the uploaded file (song, voice, instrumental)
        /// </summary>
        [JsonPropertyName("purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// Path to the audio file
        /// </summary>
        [JsonPropertyName("file")]
        public string File { get; set; }
    }

    /// <summary>
    /// Response model for music file upload
    /// </summary>
    public class MusicUploadResponse
    {
        /// <summary>
        /// Voice ID for the acapella reference
        /// </summary>
        [JsonPropertyName("voice_id")]
        public string VoiceId { get; set; }

        /// <summary>
        /// Instrumental ID for the accompaniment reference
        /// </summary>
        [JsonPropertyName("instrumental_id")]
        public string InstrumentalId { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }

    /// <summary>
    /// Request model for music generation
    /// </summary>
    public class MusicGenerationRequest
    {
        /// <summary>
        /// Voice ID for reference
        /// </summary>
        [JsonPropertyName("refer_voice")]
        public string ReferVoice { get; set; }

        /// <summary>
        /// Instrumental ID for reference
        /// </summary>
        [JsonPropertyName("refer_instrumental")]
        public string ReferInstrumental { get; set; }

        /// <summary>
        /// Lyrics for the generated music
        /// </summary>
        [JsonPropertyName("lyrics")]
        public string Lyrics { get; set; }

        /// <summary>
        /// ID of the model to use
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Audio output settings
        /// </summary>
        [JsonPropertyName("audio_setting")]
        public AudioSetting AudioSetting { get; set; }
    }

    /// <summary>
    /// Response model for music generation
    /// </summary>
    public class MusicGenerationResponse
    {
        /// <summary>
        /// Data containing the generated music
        /// </summary>
        [JsonPropertyName("data")]
        public AudioData Data { get; set; }

        /// <summary>
        /// Trace ID for the request
        /// </summary>
        [JsonPropertyName("trace_id")]
        public string TraceId { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }
} 