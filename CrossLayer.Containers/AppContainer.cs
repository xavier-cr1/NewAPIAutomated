using System;
using APILayer.Client;
using APILayer.Client.Contracts;
using BoDi;

namespace CrossLayer.Containers
{
    public class AppContainer : IAppContainer
    {
        public void RegisterAPIs(IObjectContainer objectContainer)
        {
            //Register API's
            objectContainer.RegisterTypeAs<PostsServiceRestApi, IPostsServiceRestApi>();
        }
    }
}
