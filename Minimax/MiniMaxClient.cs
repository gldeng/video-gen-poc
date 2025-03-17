using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MiniMax.Client.Models;

namespace MiniMax.Client
{
    /// <summary>
    /// Client for interacting with the MiniMax API
    /// </summary>
    public class MiniMaxClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _groupId;

        /// <summary>
        /// Initializes a new instance of the MiniMaxClient
        /// </summary>
        /// <param name="apiKey">Your MiniMax API key</param>
        /// <param name="groupId">Your MiniMax Group ID</param>
        public MiniMaxClient(string apiKey, string groupId = null)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _groupId = groupId;
            
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.minimaxi.chat/v1/")
            };
            
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Generate text chat completions
        /// </summary>
        /// <param name="request">Chat completion request parameters</param>
        /// <returns>Chat completion response</returns>
        public async Task<ChatCompletionResponse> CreateChatCompletionAsync(ChatCompletionRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            var response = await SendRequestAsync<ChatCompletionResponse>("text/chatcompletion_v2", request);
            return response;
        }

        /// <summary>
        /// Generate images based on a text prompt
        /// </summary>
        /// <param name="request">Image generation request parameters</param>
        /// <returns>Image generation response</returns>
        public async Task<ImageGenerationResponse> CreateImageAsync(ImageGenerationRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            var response = await SendRequestAsync<ImageGenerationResponse>("image_generation", request);
            return response;
        }

        /// <summary>
        /// Create a video generation task
        /// </summary>
        /// <param name="request">Video generation request parameters</param>
        /// <returns>Video generation task response</returns>
        public async Task<VideoGenerationTaskResponse> CreateVideoGenerationTaskAsync(VideoGenerationRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            var response = await SendRequestAsync<VideoGenerationTaskResponse>("video_generation", request);
            return response;
        }

        /// <summary>
        /// Query the status of a video generation task
        /// </summary>
        /// <param name="taskId">ID of the video generation task</param>
        /// <returns>Video generation status response</returns>
        public async Task<VideoGenerationStatusResponse> GetVideoGenerationStatusAsync(string taskId)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentNullException(nameof(taskId));
            
            var response = await GetRequestAsync<VideoGenerationStatusResponse>($"query/video_generation?task_id={taskId}");
            return response;
        }

        /// <summary>
        /// Convert text to speech (synchronous)
        /// </summary>
        /// <param name="request">Text-to-audio request parameters</param>
        /// <returns>Text-to-audio response</returns>
        public async Task<T2AResponse> TextToAudioAsync(T2ARequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrEmpty(_groupId)) throw new InvalidOperationException("GroupId is required for T2A operations");
            
            var url = $"t2a_v2?GroupId={_groupId}";
            var response = await SendRequestAsync<T2AResponse>(url, request);
            return response;
        }

        /// <summary>
        /// Start an asynchronous text-to-speech task
        /// </summary>
        /// <param name="request">Text-to-audio async request parameters</param>
        /// <returns>Text-to-audio async response</returns>
        public async Task<T2AAsyncResponse> TextToAudioAsyncTaskAsync(T2AAsyncRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrEmpty(_groupId)) throw new InvalidOperationException("GroupId is required for T2A operations");
            
            var url = $"t2a_async_v2?GroupId={_groupId}";
            var response = await SendRequestAsync<T2AAsyncResponse>(url, request);
            return response;
        }

        /// <summary>
        /// Query the status of an asynchronous text-to-audio task
        /// </summary>
        /// <param name="taskId">ID of the T2A task</param>
        /// <returns>T2A async status response</returns>
        public async Task<T2AAsyncStatusResponse> GetTextToAudioStatusAsync(long taskId)
        {
            if (string.IsNullOrEmpty(_groupId)) throw new InvalidOperationException("GroupId is required for T2A operations");
            
            var url = $"query/t2a_async_query_v2?GroupId={_groupId}&task_id={taskId}";
            var response = await GetRequestAsync<T2AAsyncStatusResponse>(url);
            return response;
        }

        /// <summary>
        /// Upload a file for voice cloning or other purposes
        /// </summary>
        /// <param name="filePath">Path to the file to upload</param>
        /// <param name="purpose">Purpose of the file (e.g., "voice_clone")</param>
        /// <returns>File upload response</returns>
        public async Task<FileUploadResponse> UploadFileAsync(string filePath, string purpose)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));
            if (string.IsNullOrEmpty(purpose)) throw new ArgumentNullException(nameof(purpose));
            if (string.IsNullOrEmpty(_groupId)) throw new InvalidOperationException("GroupId is required for file operations");
            
            // Implementation would involve multipart/form-data uploading
            // This is a placeholder for the actual implementation
            throw new NotImplementedException("File upload functionality requires multipart form implementation");
        }

        /// <summary>
        /// Retrieve a file by ID
        /// </summary>
        /// <param name="fileId">ID of the file to retrieve</param>
        /// <returns>File retrieve response</returns>
        public async Task<FileRetrieveResponse> RetrieveFileAsync(string fileId)
        {
            if (string.IsNullOrEmpty(fileId)) throw new ArgumentNullException(nameof(fileId));
            if (string.IsNullOrEmpty(_groupId)) throw new InvalidOperationException("GroupId is required for file operations");
            
            var url = $"files/retrieve?GroupId={_groupId}&file_id={fileId}";
            var response = await GetRequestAsync<FileRetrieveResponse>(url);
            return response;
        }

        /// <summary>
        /// Clone a voice from an audio file
        /// </summary>
        /// <param name="request">Voice cloning request parameters</param>
        /// <returns>Voice cloning response</returns>
        public async Task<VoiceCloneResponse> CloneVoiceAsync(VoiceCloneRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrEmpty(_groupId)) throw new InvalidOperationException("GroupId is required for voice cloning operations");
            
            var url = $"voice_clone?GroupId={_groupId}";
            var response = await SendRequestAsync<VoiceCloneResponse>(url, request);
            return response;
        }

        /// <summary>
        /// Upload audio for music generation
        /// </summary>
        /// <param name="request">Music upload request parameters</param>
        /// <returns>Music upload response</returns>
        public async Task<MusicUploadResponse> UploadMusicAsync(MusicUploadRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            var response = await SendRequestAsync<MusicUploadResponse>("music_upload", request);
            return response;
        }

        /// <summary>
        /// Generate music based on voice and instrumental references
        /// </summary>
        /// <param name="request">Music generation request parameters</param>
        /// <returns>Music generation response</returns>
        public async Task<MusicGenerationResponse> GenerateMusicAsync(MusicGenerationRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            var response = await SendRequestAsync<MusicGenerationResponse>("music_generation", request);
            return response;
        }

        private async Task<T> SendRequestAsync<T>(string endpoint, object data)
        {
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new MiniMaxApiException($"API error: {response.StatusCode} - {errorContent}");
            }
            
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private async Task<T> GetRequestAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new MiniMaxApiException($"API error: {response.StatusCode} - {errorContent}");
            }
            
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }

    public class MiniMaxApiException : Exception
    {
        public MiniMaxApiException(string message) : base(message) { }
    }
} 