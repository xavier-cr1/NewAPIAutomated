using CrossLayer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace UserStories.AcceptanceTests.Steps
{
    [Binding]
    public class StepsBase : TechTalk.SpecFlow.Steps
    {
        private readonly string oauthCredentialsFile = @"TestData\OAuthCredentials.json";

        private IEnumerable<OAuth> oauth;

        protected OAuth GetOAuthByClientId(string clientId)
        {
            this.oauth = GetOauthListInJson();

            return this.oauth.FirstOrDefault(i => i.ClientId == clientId);
        }

        private IEnumerable<OAuth> GetOauthListInJson()
        {
            var fileLines = File.ReadAllLines(oauthCredentialsFile);
            var result = JsonConvert.DeserializeObject<List<OAuth>>(string.Join(System.Environment.NewLine, fileLines));

            return result;
        }
    }
}
