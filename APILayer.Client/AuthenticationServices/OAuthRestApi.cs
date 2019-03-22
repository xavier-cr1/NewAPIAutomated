using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using APILayer.Client.Base;
using CrossLayer.Models;
using CrossLayer.Models.API;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace APILayer.Client.Authentication
{
    public class OAuthRestApi : ServiceRestApiClientBase, IOAuthRestApi
    {
        private string oauthService => this.ConfigurationRoot.GetSection("AppConfiguration")["OauthAPIService"];

        private readonly string oauthCredentialsFile = @"TestData\OAuthCredentials.json";

        private IEnumerable<OAuth> oauth;

        private readonly string clientId = "client_id=";

        private readonly string key = "key=";

        private readonly string redirect_uri = "redirect_uri=";

        public OAuthRestApi(IConfigurationRoot configurationRoot)
            : base(configurationRoot)
        {
        }

        public Token RequestOAuthToken()
        {
            //TODO - The user registers oauth -> Create a step for this
            string usersRootResponse = "";
            string url = $"{this.oauthService}/dialog?{this.clientId}";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        usersRootResponse = reader.ReadToEnd();
                    }
                    return new Token();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

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
