using APILayer.Client.Base;
using APILayer.Client.Contracts;
using APILayer.Entities.PostsService;
using BoDi;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace UserStories.AcceptanceTests.Steps.API.PostsService
{
    [Binding]
    public class PostsServiceSteps : StepsBase
    {
        private readonly IPostsServiceRestApi postsServiceRestApi;
        
        private PostsRequest postsRequest;
        private PostsRootResponse postsRootResponse;

        public PostsServiceSteps(IPostsServiceRestApi postsServiceRestApi) 
        {
            this.postsServiceRestApi = postsServiceRestApi;
        }

        [Given(@"The user gets a list of posts with the following properties")]
        public void GivenTheUserGetsAListOfPostsWithTheFollowingProperties(Table table)
        {
            this.postsRequest = table.CreateInstance<PostsRequest>();
            this.postsRootResponse = this.postsServiceRestApi.PostsServiceGetAsyncFromGzip(postsRequest);
        }
        
        [Given(@"The status code of the posts service is '(.*)'")]
        public void GivenTheResponseCodeOfThePostsServiceIs(string statusCode)
        {
            var realCode = this.postsRootResponse.StatusCode;
            realCode.Should().Be(statusCode, $"Real code {realCode} --- Expected code {statusCode}");
        }
        
        [Then(@"The first post given has the id '(.*)' and the owner '(.*)'")]
        public void ThenTheFirstPostGivenHasTheIdAndTheOwner(string post_id, string user_id)
        {
        }
    }
}
