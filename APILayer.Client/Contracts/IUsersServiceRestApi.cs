using APILayer.Entities.BadgeService;
using APILayer.Entities.PostsService;
using APILayer.Entities.UsersService;
using System;
using System.Collections.Generic;
using System.Text;

namespace APILayer.Client.Contracts
{
    public interface IUsersServiceRestApi
    {
        RootResponse UsersServiceGetFromGzip(UsersRequest postsRequest);

        List<UsersBadgeCount> GetUserBadgeCount();
    }
}
