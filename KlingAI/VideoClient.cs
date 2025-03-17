using System.Net.Http;
using System.Threading.Tasks;
using KlingAI.Models;

namespace KlingAI
{
    public class VideoClient
    {
        private readonly KlingAIClient _client;
        
        internal VideoClient(KlingAIClient client)
        {
            _client = client;
        }
        
        // Text to video endpoints
        public Task<TaskResponse> CreateTextToVideoTaskAsync(TextToVideoRequest request)
        {
            return _client.SendRequestAsync<TaskResponse>(HttpMethod.Post, "/v1/videos/text2video", request);
        }
        
        public Task<VideoTaskListResponse> GetTextToVideoTasksAsync(int pageNum = 1, int pageSize = 30)
        {
            var endpoint = $"/v1/videos/text2video?pageNum={pageNum}&pageSize={pageSize}";
            return _client.SendRequestAsync<VideoTaskListResponse>(HttpMethod.Get, endpoint);
        }
        
        public Task<VideoTaskDetailResponse> GetTextToVideoTaskAsync(string id)
        {
            return _client.SendRequestAsync<VideoTaskDetailResponse>(HttpMethod.Get, $"/v1/videos/text2video/{id}");
        }
        
        // Image to video endpoints
        public Task<TaskResponse> CreateImageToVideoTaskAsync(ImageToVideoRequest request)
        {
            return _client.SendRequestAsync<TaskResponse>(HttpMethod.Post, "/v1/videos/image2video", request);
        }
        
        public Task<VideoTaskListResponse> GetImageToVideoTasksAsync(int pageNum = 1, int pageSize = 30)
        {
            var endpoint = $"/v1/videos/image2video?pageNum={pageNum}&pageSize={pageSize}";
            return _client.SendRequestAsync<VideoTaskListResponse>(HttpMethod.Get, endpoint);
        }
        
        public Task<VideoTaskDetailResponse> GetImageToVideoTaskAsync(string id)
        {
            return _client.SendRequestAsync<VideoTaskDetailResponse>(HttpMethod.Get, $"/v1/videos/image2video/{id}");
        }
        
        // Video extend endpoints
        public Task<TaskResponse> CreateVideoExtendTaskAsync(VideoExtendRequest request)
        {
            return _client.SendRequestAsync<TaskResponse>(HttpMethod.Post, "/v1/videos/video-extend", request);
        }
        
        public Task<VideoExtendTaskListResponse> GetVideoExtendTasksAsync(int pageNum = 1, int pageSize = 30)
        {
            var endpoint = $"/v1/videos/video-extend?pageNum={pageNum}&pageSize={pageSize}";
            return _client.SendRequestAsync<VideoExtendTaskListResponse>(HttpMethod.Get, endpoint);
        }
        
        public Task<VideoExtendTaskDetailResponse> GetVideoExtendTaskAsync(string id)
        {
            return _client.SendRequestAsync<VideoExtendTaskDetailResponse>(HttpMethod.Get, $"/v1/videos/video-extend/{id}");
        }
        
        // Lip sync endpoints
        public Task<TaskResponse> CreateLipSyncTaskAsync(LipSyncRequest request)
        {
            return _client.SendRequestAsync<TaskResponse>(HttpMethod.Post, "/v1/videos/lip-sync", request);
        }
        
        public Task<VideoExtendTaskListResponse> GetLipSyncTasksAsync(int pageNum = 1, int pageSize = 30)
        {
            var endpoint = $"/v1/videos/lip-sync?pageNum={pageNum}&pageSize={pageSize}";
            return _client.SendRequestAsync<VideoExtendTaskListResponse>(HttpMethod.Get, endpoint);
        }
        
        public Task<VideoExtendTaskDetailResponse> GetLipSyncTaskAsync(string id)
        {
            return _client.SendRequestAsync<VideoExtendTaskDetailResponse>(HttpMethod.Get, $"/v1/videos/lip-sync/{id}");
        }
        
        // Video effects endpoints
        public Task<TaskResponse> CreateVideoEffectsTaskAsync(VideoEffectsRequest request)
        {
            return _client.SendRequestAsync<TaskResponse>(HttpMethod.Post, "/v1/videos/effects", request);
        }
        
        public Task<VideoTaskListResponse> GetVideoEffectsTasksAsync(int pageNum = 1, int pageSize = 30)
        {
            var endpoint = $"/v1/videos/effects?pageNum={pageNum}&pageSize={pageSize}";
            return _client.SendRequestAsync<VideoTaskListResponse>(HttpMethod.Get, endpoint);
        }
        
        public Task<VideoTaskDetailResponse> GetVideoEffectsTaskAsync(string id)
        {
            return _client.SendRequestAsync<VideoTaskDetailResponse>(HttpMethod.Get, $"/v1/videos/effects/{id}");
        }
    }
} 