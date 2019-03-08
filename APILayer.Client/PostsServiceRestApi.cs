using APILayer.Client.Base;
using APILayer.Client.Contracts;
using APILayer.Entities.PostsService;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace APILayer.Client
{
    public class PostsServiceRestApi : ServiceRestApiClientBase, IPostsServiceRestApi
    {
        private string postsService => this.configurationRoot.GetSection("AppConfiguration")["PostsAPIService"];

        public PostsServiceRestApi(IConfigurationRoot configurationRoot) 
            : base (configurationRoot)
        {
        }

        public Task<PostsRootResponse> PostsServiceGetAsync(PostsRequest postsRequest)
        {
            throw new NotImplementedException();
        }
    }
}
