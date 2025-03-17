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
            
            var responseContent = await response.Content.ReadAsStringAsync();
            
            // Check for API errors even if HTTP status is 200
            var apiError = CheckForApiError(responseContent);
            if (apiError != null)
            {
                throw apiError;
            }
            
            if (!response.IsSuccessStatusCode)
            {
                throw CreateApiException(response.StatusCode, responseContent);
            }
            
            return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private async Task<T> GetRequestAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            
            // Check for API errors even if HTTP status is 200
            var apiError = CheckForApiError(responseContent);
            if (apiError != null)
            {
                throw apiError;
            }
            
            if (!response.IsSuccessStatusCode)
            {
                throw CreateApiException(response.StatusCode, responseContent);
            }
            
            return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private MiniMaxApiException CheckForApiError(string responseContent)
        {
            try
            {
                // Try to parse the base_resp error from the response
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseObj = JsonSerializer.Deserialize<JsonElement>(responseContent, options);
                
                if (responseObj.TryGetProperty("base_resp", out var baseResp))
                {
                    if (baseResp.TryGetProperty("status_code", out var statusCode) && 
                        statusCode.GetInt32() != 0)
                    {
                        var errorCode = statusCode.GetInt32();
                        var errorMessage = baseResp.TryGetProperty("status_msg", out var statusMsg) 
                            ? statusMsg.GetString() 
                            : "Unknown error";
                        
                        return new MiniMaxApiException(
                            errorCode,
                            errorMessage,
                            GetSolutionForErrorCode(errorCode),
                            System.Net.HttpStatusCode.OK, // The HTTP status was actually 200
                            responseContent
                        );
                    }
                }
                
                return null; // No error found
            }
            catch (JsonException)
            {
                return null; // If we can't parse the JSON, assume no error
            }
        }

        private MiniMaxApiException CreateApiException(System.Net.HttpStatusCode statusCode, string errorContent)
        {
            try
            {
                // First check for base_resp error format
                var apiError = CheckForApiError(errorContent);
                if (apiError != null)
                {
                    return apiError;
                }
                
                // Try other error format as fallback
                var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(errorContent);
                if (errorResponse?.Error != null)
                {
                    return new MiniMaxApiException(
                        errorResponse.Error.Code,
                        errorResponse.Error.Message,
                        GetSolutionForErrorCode(errorResponse.Error.Code),
                        statusCode,
                        errorContent
                    );
                }
            }
            catch (JsonException)
            {
                // If we can't parse the error, just continue to fallback
            }
            
            // Fallback for unparseable responses
            return new MiniMaxApiException(
                0, // Unknown code
                $"API error: {statusCode}",
                "Please retry your requests later.",
                statusCode,
                errorContent
            );
        }

        private string GetSolutionForErrorCode(int code)
        {
            return code switch
            {
                1000 => "Please retry your requests later.",
                1001 => "Please retry your requests later.",
                1002 => "Please retry your requests later.",
                1004 => "Please check your api key and make sure it is correct and active.",
                1008 => "Please check your account balance.",
                1024 => "Please retry your requests later.",
                1026 => "Please change your input content.",
                1027 => "Please change your input content.",
                1033 => "Please retry your requests later.",
                1039 => "Please retry your requests later.",
                1041 => "Please contact us if the issue persists.",
                1042 => "Please check your input content for invisible or illegal characters.",
                1043 => "Please check file_id and text_validation.",
                1044 => "Please check clone prompt audio and prompt words.",
                2013 => "Please check the request parameters.",
                20132 => "Please check your file_id (in Voice Cloning API), voice_id (in T2A v2 API, T2A Large v2 API) and contact us if the issue persists.",
                2037 => "Please adjust the duration of your file_id for voice clone.",
                2039 => "Please check the voice_id to ensure no duplication with the existing ones.",
                2042 => "Please check whether you are the creator of this voice_id and contact us if the issue persists.",
                2045 => "Please avoid sudden increases and decreases in requests.",
                2048 => "Please adjust the duration of the prompt_audio file (<8s).",
                2049 => "Please check your api key and make sure it is correct and active.",
                _ => "Please retry your requests later or contact MiniMax support if the issue persists."
            };
        }
    }

    public class MiniMaxApiException : Exception
    {
        /// <summary>
        /// The MiniMax API error code
        /// </summary>
        public int ErrorCode { get; }
        
        /// <summary>
        /// The HTTP status code returned by the API
        /// </summary>
        public System.Net.HttpStatusCode StatusCode { get; }
        
        /// <summary>
        /// The raw error content returned by the API
        /// </summary>
        public string ErrorContent { get; }
        
        /// <summary>
        /// Suggested solution for this error code
        /// </summary>
        public string Solution { get; }

        public MiniMaxApiException(int errorCode, string message, string solution, System.Net.HttpStatusCode statusCode, string errorContent) 
            : base(message)
        {
            ErrorCode = errorCode;
            Solution = solution;
            StatusCode = statusCode;
            ErrorContent = errorContent;
        }
        
        public MiniMaxApiException(string message) : base(message)
        {
            Solution = "Please retry your requests later or contact MiniMax support if the issue persists.";
        }
    }

    // Models for error response parsing
    public class ErrorResponse
    {
        public ErrorDetails Error { get; set; }
    }

    public class ErrorDetails
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
} 