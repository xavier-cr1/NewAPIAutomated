using APILayer.Client.Base;
using APILayer.Client.Contracts;
using APILayer.Entities.BadgeService;
using APILayer.Entities.PostsService;
using APILayer.Entities.UsersService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace APILayer.Client.Services
{
    public class UsersServiceRestApi : ServiceRestApiClientBase, IUsersServiceRestApi
    {
        private readonly string inNameAttr = "&inname=";

        private string usersService => this.ConfigurationRoot.GetSection("AppConfiguration")["UsersAPIService"];

        public UsersServiceRestApi(IConfigurationRoot configurationRoot)
            : base(configurationRoot)
        {
        }

        public RootResponse<UsersItem> UsersServiceGetFromGzip(UsersRequest usersRequest)
        {
            string usersRootResponse = "";
            string url = "";

            if(!string.IsNullOrEmpty(usersRequest.InName))
            {
                var inNameUrl = System.Web.HttpUtility.UrlEncode(usersRequest.InName);
                url = $"{GetBaseUrlRequest(this.usersService, usersRequest)}{inNameAttr}{inNameUrl}";
            }
            else
            {
                url = GetBaseUrlRequest(this.usersService, usersRequest);
            }
            
            try
            {
                var uri = new Uri(url, UriKind.Absolute);
                var request = (HttpWebRequest)WebRequest.Create(uri);

                //KEY to decompress /!\
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        usersRootResponse = reader.ReadToEnd();
                    }

                    var jsonPostsRoot = JsonConvert.DeserializeObject<RootResponse<UsersItem>>(usersRootResponse);
                    jsonPostsRoot.StatusCode = response.StatusCode.ToString();
                    return jsonPostsRoot;
                }
            }

            catch (WebException webEx)
            {
                var responseErr = (HttpWebResponse)webEx.Response;
                return new RootResponse<UsersItem> { StatusCode = responseErr.StatusDescription };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UsersBadgeCount> GetUserBadgeCount(RootResponse<UsersItem> usersRootResponse)
        {
            var userItems = (IEnumerable<UsersItem>)usersRootResponse.Item;

            return userItems.Select(x => x.BadgeCounts).ToList();
        }
    }
}
