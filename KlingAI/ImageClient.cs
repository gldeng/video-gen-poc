using System.Net.Http;
using System.Threading.Tasks;
using KlingAI.Models;

namespace KlingAI
{
    public class ImageClient
    {
        private readonly KlingAIClient _client;
        
        internal ImageClient(KlingAIClient client)
        {
            _client = client;
        }
        
        // Image generation endpoints
        public Task<TaskResponse> CreateImageGenerationTaskAsync(ImageGenerationRequest request)
        {
            return _client.SendRequestAsync<TaskResponse>(HttpMethod.Post, "/v1/images/generations", request);
        }
        
        public Task<TaskListResponse> GetImageGenerationTasksAsync(int pageNum = 1, int pageSize = 30)
        {
            var endpoint = $"/v1/images/generations?pageNum={pageNum}&pageSize={pageSize}";
            return _client.SendRequestAsync<TaskListResponse>(HttpMethod.Get, endpoint);
        }
        
        public Task<TaskDetailResponse> GetImageGenerationTaskAsync(string id)
        {
            return _client.SendRequestAsync<TaskDetailResponse>(HttpMethod.Get, $"/v1/images/generations/{id}");
        }
        
        // Virtual try-on endpoints
        public Task<TaskResponse> CreateVirtualTryOnTaskAsync(VirtualTryOnRequest request)
        {
            return _client.SendRequestAsync<TaskResponse>(HttpMethod.Post, "/v1/images/kolors-virtual-try-on", request);
        }
        
        public Task<TaskListResponse> GetVirtualTryOnTasksAsync(int pageNum = 1, int pageSize = 30)
        {
            var endpoint = $"/v1/images/kolors-virtual-try-on?pageNum={pageNum}&pageSize={pageSize}";
            return _client.SendRequestAsync<TaskListResponse>(HttpMethod.Get, endpoint);
        }
        
        public Task<TaskDetailResponse> GetVirtualTryOnTaskAsync(string id)
        {
            return _client.SendRequestAsync<TaskDetailResponse>(HttpMethod.Get, $"/v1/images/kolors-virtual-try-on/{id}");
        }
    }
} 