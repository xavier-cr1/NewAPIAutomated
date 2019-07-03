using APILayer.Client.Base;
using APILayer.Client.Contracts;
using APILayer.Entities;
using APILayer.Entities.PostsService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace APILayer.Client
{
    public class PostsServiceRestApi : ServiceRestApiClientBase, IPostsServiceRestApi
    {
        private string postsService => this.ConfigurationRoot.GetSection("AppConfiguration")["PostsAPIService"];

        public PostsServiceRestApi(IConfigurationRoot configurationRoot) 
            : base (configurationRoot)
        {
        }

        //webresponse object -> Api Content, revelated a gzip encryption
        public RootResponse<PostsItem> PostsServiceGetFromGzip(PostsRequest postsRequest)
        {
            string postsRootResponse = "";
            var url = GetBaseUrlRequest(this.postsService, postsRequest);

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                //KEY to decompress /!\
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        postsRootResponse = reader.ReadToEnd();
                    }

                    var jsonPostsRoot = JsonConvert.DeserializeObject<RootResponse<PostsItem>>(postsRootResponse);
                    jsonPostsRoot.StatusCode = response.StatusCode.ToString();
                    return jsonPostsRoot;
                }

            }
            catch(WebException webEx)
            {
                var responseErr = (HttpWebResponse)webEx.Response;
                return new RootResponse<PostsItem> { StatusCode = responseErr.StatusDescription };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
