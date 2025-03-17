using System.Text.Json.Serialization;

namespace MiniMax.Client.Models
{
    /// <summary>
    /// Request model for text-to-audio conversion
    /// </summary>
    public class T2ARequest
    {
        /// <summary>
        /// ID of the model to use
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Text to convert to audio
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// Voice settings for the audio
        /// </summary>
        [JsonPropertyName("voice_setting")]
        public VoiceSetting VoiceSetting { get; set; }

        /// <summary>
        /// Audio output settings
        /// </summary>
        [JsonPropertyName("audio_setting")]
        public AudioSetting AudioSetting { get; set; }

        /// <summary>
        /// Whether to stream the audio
        /// </summary>
        [JsonPropertyName("stream")]
        public bool? Stream { get; set; }

        /// <summary>
        /// Language boost for improved recognition
        /// </summary>
        [JsonPropertyName("language_boost")]
        public string LanguageBoost { get; set; }

        /// <summary>
        /// Whether to enable subtitles
        /// </summary>
        [JsonPropertyName("subtitle_enable")]
        public bool? SubtitleEnable { get; set; }
    }

    /// <summary>
    /// Voice settings for audio generation
    /// </summary>
    public class VoiceSetting
    {
        /// <summary>
        /// ID of the voice to use
        /// </summary>
        [JsonPropertyName("voice_id")]
        public string VoiceId { get; set; }

        /// <summary>
        /// Speed of the speech (0.5 to 2.0)
        /// </summary>
        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        /// <summary>
        /// Volume of the speech (0.5 to 2.0)
        /// </summary>
        [JsonPropertyName("vol")]
        public float Vol { get; set; }

        /// <summary>
        /// Pitch adjustment (-12 to 12)
        /// </summary>
        [JsonPropertyName("pitch")]
        public int Pitch { get; set; }
    }

    /// <summary>
    /// Audio output settings
    /// </summary>
    public class AudioSetting
    {
        /// <summary>
        /// Sample rate of the audio
        /// </summary>
        [JsonPropertyName("sample_rate")]
        public int SampleRate { get; set; }

        /// <summary>
        /// Bitrate of the audio
        /// </summary>
        [JsonPropertyName("bitrate")]
        public int Bitrate { get; set; }

        /// <summary>
        /// Format of the audio (mp3, wav, etc.)
        /// </summary>
        [JsonPropertyName("format")]
        public string Format { get; set; }

        /// <summary>
        /// Number of audio channels
        /// </summary>
        [JsonPropertyName("channel")]
        public int Channel { get; set; }
    }

    /// <summary>
    /// Response model for text-to-audio conversion
    /// </summary>
    public class T2AResponse
    {
        /// <summary>
        /// Data containing the generated audio
        /// </summary>
        [JsonPropertyName("data")]
        public AudioData Data { get; set; }

        /// <summary>
        /// Subtitle file URL
        /// </summary>
        [JsonPropertyName("subtitle_file")]
        public string SubtitleFile { get; set; }

        /// <summary>
        /// Extra information about the generated audio
        /// </summary>
        [JsonPropertyName("extra_info")]
        public AudioExtraInfo ExtraInfo { get; set; }

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

    /// <summary>
    /// Audio data
    /// </summary>
    public class AudioData
    {
        /// <summary>
        /// Hex-encoded audio data
        /// </summary>
        [JsonPropertyName("audio")]
        public string Audio { get; set; }

        /// <summary>
        /// Status code
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }
    }

    /// <summary>
    /// Extra information about the generated audio
    /// </summary>
    public class AudioExtraInfo
    {
        /// <summary>
        /// Length of the audio in milliseconds
        /// </summary>
        [JsonPropertyName("audio_length")]
        public int AudioLength { get; set; }

        /// <summary>
        /// Sample rate of the audio
        /// </summary>
        [JsonPropertyName("audio_sample_rate")]
        public int AudioSampleRate { get; set; }

        /// <summary>
        /// Size of the audio in bytes
        /// </summary>
        [JsonPropertyName("audio_size")]
        public int AudioSize { get; set; }

        /// <summary>
        /// Bitrate of the audio
        /// </summary>
        [JsonPropertyName("audio_bitrate")]
        public int AudioBitrate { get; set; }

        /// <summary>
        /// Word count in the input text
        /// </summary>
        [JsonPropertyName("word_count")]
        public int WordCount { get; set; }

        /// <summary>
        /// Format of the audio
        /// </summary>
        [JsonPropertyName("audio_format")]
        public string AudioFormat { get; set; }

        /// <summary>
        /// Number of characters used for billing
        /// </summary>
        [JsonPropertyName("usage_characters")]
        public int UsageCharacters { get; set; }
    }

    /// <summary>
    /// Request model for asynchronous text-to-audio conversion
    /// </summary>
    public class T2AAsyncRequest
    {
        /// <summary>
        /// ID of the model to use
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Text to convert to audio
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// File ID containing text to convert
        /// </summary>
        [JsonPropertyName("file_id")]
        public string FileId { get; set; }

        /// <summary>
        /// Voice settings for the audio
        /// </summary>
        [JsonPropertyName("voice_setting")]
        public VoiceSetting VoiceSetting { get; set; }

        /// <summary>
        /// Audio output settings
        /// </summary>
        [JsonPropertyName("audio_setting")]
        public AudioSetting AudioSetting { get; set; }

        /// <summary>
        /// Whether to enable timestamps
        /// </summary>
        [JsonPropertyName("timestamp_enable")]
        public bool? TimestampEnable { get; set; }
    }

    /// <summary>
    /// Response model for asynchronous text-to-audio task creation
    /// </summary>
    public class T2AAsyncResponse
    {
        /// <summary>
        /// ID of the created task
        /// </summary>
        [JsonPropertyName("task_id")]
        public long TaskId { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }

    /// <summary>
    /// Response model for asynchronous text-to-audio status query
    /// </summary>
    public class T2AAsyncStatusResponse
    {
        /// <summary>
        /// ID of the task
        /// </summary>
        [JsonPropertyName("task_id")]
        public long TaskId { get; set; }

        /// <summary>
        /// Status of the task (Processing, Success, Failed, Expired)
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// File ID of the generated audio (when status is Success)
        /// </summary>
        [JsonPropertyName("file_id")]
        public long? FileId { get; set; }

        /// <summary>
        /// Base response information
        /// </summary>
        [JsonPropertyName("base_resp")]
        public BaseResponse BaseResp { get; set; }
    }
} 