using System.Net.Http;
using System.Threading.Tasks;
using KlingAI.Models;

namespace KlingAI
{
    public class AccountClient
    {
        private readonly KlingAIClient _client;
        
        internal AccountClient(KlingAIClient client)
        {
            _client = client;
        }
        
        public Task<AccountCostsResponse> GetCostsAsync(long startTime, long endTime, string resourcePackName = null)
        {
            var endpoint = $"/account/costs?start_time={startTime}&end_time={endTime}";
            
            if (!string.IsNullOrEmpty(resourcePackName))
            {
                endpoint += $"&resource_pack_name={resourcePackName}";
            }
            
            return _client.SendRequestAsync<AccountCostsResponse>(HttpMethod.Get, endpoint);
        }
    }
} 