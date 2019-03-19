using APILayer.Entities.Commom;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace APILayer.Entities.PostsService
{
    public class RootResponse<T> where T : class
    {
        [JsonProperty("items")]
        public ObservableCollection<T> Item { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("quota_max")]
        public int QuotaMax { get; set; }

        [JsonProperty("quota_remaining")]
        public int QuotaRemaining { get; set; }

        public string StatusCode { get; set; }
    }
}
