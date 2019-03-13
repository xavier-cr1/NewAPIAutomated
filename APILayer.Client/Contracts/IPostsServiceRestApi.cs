using APILayer.Entities.PostsService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APILayer.Client.Contracts
{
    public interface IPostsServiceRestApi
    {
        Task<PostsRootResponse> PostsServiceGetAsyncGeneric(PostsRequest postsRequest);

        Task<string> PostsServiceGetAsync(PostsRequest postsRequest);

        PostsRootResponse PostsServiceGetAsyncFromGzip(PostsRequest postsRequest);
    }
}
