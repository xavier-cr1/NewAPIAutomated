using System;
using APILayer.Client;
using APILayer.Client.Contracts;
using APILayer.Client.Services;
using AppiumLayer.Factory.Android.Contracts;
using AppiumLayer.Factory.Android.Pages;
using BoDi;

namespace CrossLayer.Containers
{
    public class AppContainer : IAppContainer
    {
        public void RegisterAPIs(IObjectContainer objectContainer)
        {
            //Register API's
            objectContainer.RegisterTypeAs<PostsServiceRestApi, IPostsServiceRestApi>();
            objectContainer.RegisterTypeAs<UsersServiceRestApi, IUsersServiceRestApi>();
        }

        public void RegisterAppiumAndroid(IObjectContainer objectContainer)
        {
            //Register Appium contracts
            objectContainer.RegisterTypeAs<SearchPage, ISearchPage>();
        }
    }
}
