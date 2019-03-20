using APILayer.Entities;
using APILayer.Entities.PostsService;
using System.Threading.Tasks;

namespace APILayer.Client.Contracts
{
    public interface IPostsServiceRestApi
    {
        RootResponse<PostsItem> PostsServiceGetFromGzip(PostsRequest postsRequest);
    }
}
