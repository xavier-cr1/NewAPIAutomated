using APILayer.Client.Contracts;
using APILayer.Entities.PostsService;
using System;
using System.Threading.Tasks;

namespace APILayer.Client
{
    public class PostsServiceRestApi : IPostsServiceRestApi
    {
        public Task<PostsRootResponse> PostsServiceGetAsync(PostsRequest postsRequest)
        {
            throw new NotImplementedException();
        }
    }
}
