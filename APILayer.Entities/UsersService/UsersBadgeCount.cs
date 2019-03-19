using Newtonsoft.Json;

namespace APILayer.Entities.BadgeService
{
    public class UsersBadgeCount
    {
        [JsonProperty("bronze")]
        public int Bronze { get; set; }

        [JsonProperty("silver")]
        public int Silver { get; set; }

        [JsonProperty("gold")]
        public int Gold { get; set; }
    }
}
