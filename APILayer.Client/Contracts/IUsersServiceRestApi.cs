using APILayer.Entities.BadgeService;
using APILayer.Entities.PostsService;
using APILayer.Entities.UsersService;
using System.Collections.Generic;

namespace APILayer.Client.Contracts
{
    public interface IUsersServiceRestApi
    {
        RootResponse<UsersItem> UsersServiceGetFromGzip(UsersRequest postsRequest);

        List<UsersBadgeCount> GetUserBadgeCount(RootResponse<UsersItem> usersRootResponse);
    }
}
