using Newtonsoft.Json;
using System;

namespace CrossLayer.Models
{
    public class OAuth
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }
    }
}
