using APILayer.Client.Contracts;
using APILayer.Entities;
using APILayer.Entities.PostsService;
using APILayer.Entities.UsersService;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit.Abstractions;


namespace UserStories.AcceptanceTests.Steps.API.UsersService
{
    [Binding]
    public class UsersServiceSteps : StepsBase
    {
        private readonly IUsersServiceRestApi usersServiceRestApi;
        private UsersRequest usersRequest;
        private RootResponse usersRootResponse;

        public UsersServiceSteps(IUsersServiceRestApi usersServiceRestApi)
        {
            this.usersServiceRestApi = usersServiceRestApi;
        }

        [Given(@"The user gets a list of users with the following properties")]
        public void GivenTheUserGetsAListOfUsersWithTheFollowingProperties(Table table)
        {
            this.usersRequest = table.CreateInstance<UsersRequest>();
            this.usersRootResponse = this.usersServiceRestApi.UsersServiceGetFromGzip(usersRequest);
        }

        [Given(@"The status code of the users service is '(.*)'")]
        public void GivenTheResponseCodeOfThePostsServiceIs(string statusCode)
        {
            var realCode = this.usersRootResponse.StatusCode;
            realCode.Should().Be(statusCode, $"Real code {realCode} --- Expected code {statusCode}");
        }

        [Then(@"The amount of bronze badges are '(.*)', silver are '(.*)' and gold are '(.*)'")]
        public void ThenTheAmountOfBronzeBadgesAreSilverAreAndGoldAre(int expectedbBronzeCount, int expectedSilverCount, int expectedGoldCount)
        {
        }
    }
}
