using APILayer.Entities.BadgeService;
using Newtonsoft.Json;

namespace APILayer.Entities.UsersService
{
    public class UsersItem
    {
        [JsonProperty("badge_counts")]
        public UsersBadgeCount BadgeCounts { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("is_employee")]
        public bool IsEmployee { get; set; }

        [JsonProperty("last_modified_date")]
        public int LastModifiedDate { get; set; }

        [JsonProperty("last_access_date")]
        public int LastAccessDate { get; set; }

        [JsonProperty("reputation_change_year")]
        public int ReputationChangeYear { get; set; }

        [JsonProperty("reputation_change_quarter")]
        public int ReputationChangeQuarter { get; set; }

        [JsonProperty("reputation_change_month")]
        public int ReputationChangeMonth { get; set; }

        [JsonProperty("reputation_change_week")]
        public int ReputationChangeWeek { get; set; }

        [JsonProperty("reputation_change_day")]
        public int ReputationChangeDay { get; set; }

        [JsonProperty("reputation")]
        public int Reputation { get; set; }

        [JsonProperty("creation_date")]
        public int CreationDate { get; set; }

        [JsonProperty("user_type")]
        public string UserType { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}
