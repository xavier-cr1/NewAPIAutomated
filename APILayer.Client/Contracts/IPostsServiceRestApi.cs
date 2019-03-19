using APILayer.Entities;
using APILayer.Entities.PostsService;
using System.Threading.Tasks;

namespace APILayer.Client.Contracts
{
    public interface IPostsServiceRestApi
    {
        //Task<RootResponse<T>> PostsServiceGetAsyncGeneric<T>(PostsRequest postsRequest);

        Task<string> PostsServiceGetAsync(PostsRequest postsRequest);

        RootResponse<PostsItem> PostsServiceGetFromGzip(PostsRequest postsRequest);
    }
}
