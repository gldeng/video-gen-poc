using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using KlingAI.Authentication;
using KlingAI.Models;

namespace KlingAI
{
    public class KlingAIClient
    {
        private readonly HttpClient _httpClient;
        private readonly JwtTokenGenerator _tokenGenerator;
        private readonly TimeSpan _tokenLifetime;
        
        /// <summary>
        /// Creates a new KlingAI client using access key and secret key authentication with default token lifetime (1 hour)
        /// </summary>
        public KlingAIClient(string accessKey, string secretKey, string baseUrl = "https://api.klingai.com")
            : this(accessKey, secretKey, TimeSpan.FromHours(1), baseUrl)
        {
        }
        
        /// <summary>
        /// Creates a new KlingAI client using access key and secret key authentication with custom token lifetime
        /// </summary>
        public KlingAIClient(string accessKey, string secretKey, TimeSpan tokenLifetime, string baseUrl = "https://api.klingai.com")
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            
            _tokenGenerator = new JwtTokenGenerator(accessKey, secretKey);
            _tokenLifetime = tokenLifetime;
            
            Images = new ImageClient(this);
            Videos = new VideoClient(this);
            Account = new AccountClient(this);
        }
        
        public ImageClient Images { get; }
        public VideoClient Videos { get; }
        public AccountClient Account { get; }
        
        internal async Task<T> SendRequestAsync<T>(HttpMethod method, string endpoint, object requestBody = null)
        {
            var request = new HttpRequestMessage(method, endpoint);
            
            // Generate a fresh JWT token for each request with specified lifetime
            string token = _tokenGenerator.GenerateToken(_tokenLifetime);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            if (requestBody != null)
            {
                var json = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
            {
                throw new KlingAIException($"API request failed with status code {response.StatusCode}: {content}");
            }
            
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
    
    public class KlingAIException : Exception
    {
        public KlingAIException(string message) : base(message) { }
    }
} 