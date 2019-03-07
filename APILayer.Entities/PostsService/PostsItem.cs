using APILayer.Entities.PostsService;
using Newtonsoft.Json;

namespace APILayer.Entities
{
    public class PostsItem
    {
        [JsonProperty("owner")]
        public PostOwner Owner { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("last_activity_date")]
        public int LastActivityDate { get; set; }

        [JsonProperty("creation_date")]
        public int CreationDate { get; set; }

        [JsonProperty("post_type")]
        public string PostType { get; set; }

        [JsonProperty("post_id")]
        public int PostId { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("last_edit_date")]
        public int? LastEditDate { get; set; }
    }
}
