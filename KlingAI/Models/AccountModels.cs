using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KlingAI.Models
{
    public class AccountCostsResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public AccountCostsData Data { get; set; }
    }
    
    public class AccountCostsData
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        
        [JsonPropertyName("msg")]
        public string Msg { get; set; }
        
        [JsonPropertyName("resource_pack_subscribe_infos")]
        public List<ResourcePackSubscribeInfo> ResourcePackSubscribeInfos { get; set; }
    }
    
    public class ResourcePackSubscribeInfo
    {
        [JsonPropertyName("resource_pack_name")]
        public string ResourcePackName { get; set; }
        
        [JsonPropertyName("resource_pack_id")]
        public string ResourcePackId { get; set; }
        
        [JsonPropertyName("resource_pack_type")]
        public string ResourcePackType { get; set; }
        
        [JsonPropertyName("total_quantity")]
        public double TotalQuantity { get; set; }
        
        [JsonPropertyName("remaining_quantity")]
        public double RemainingQuantity { get; set; }
        
        [JsonPropertyName("purchase_time")]
        public long PurchaseTime { get; set; }
        
        [JsonPropertyName("effective_time")]
        public long EffectiveTime { get; set; }
        
        [JsonPropertyName("invalid_time")]
        public long InvalidTime { get; set; }
        
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
} 