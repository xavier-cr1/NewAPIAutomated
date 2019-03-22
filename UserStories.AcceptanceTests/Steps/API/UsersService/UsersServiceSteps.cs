using APILayer.Client.Contracts;
using APILayer.Entities.PostsService;
using APILayer.Entities.UsersService;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace UserStories.AcceptanceTests.Steps.API.UsersService
{
    [Binding]
    public class UsersServiceSteps : StepsBase
    {
        private readonly IUsersServiceRestApi usersServiceRestApi;
        private UsersRequest usersRequest;
        private RootResponse<UsersItem> usersRootResponse;

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

        [Given(@"The user gets the unread inbox with the following properties")]
        public void GivenTheUserGetsTheUnreadInboxWithTheFollowingProperties(Table table)
        {
        }

        [When(@"The user marks as read the '(.*)' inbox message")]
        public void WhenTheUserMarksAsReadTheInboxMessage(string p0)
        {
        }

        [Then(@"The amount of bronze badges are '(.*)', silver are '(.*)' and gold are '(.*)'")]
        public void ThenTheAmountOfBronzeBadgesAreSilverAreAndGoldAre(int expectedbBronzeCount, int expectedSilverCount, int expectedGoldCount)
        {
            var userBadgeList = this.usersServiceRestApi.GetUserBadgeCount(this.usersRootResponse);

            using (new AssertionScope())
            {
                userBadgeList.Sum(x => x.Bronze).Should().Be(expectedbBronzeCount);

                userBadgeList.Sum(x => x.Silver).Should().Be(expectedSilverCount);

                userBadgeList.Sum(x => x.Gold).Should().Be(expectedGoldCount);
            }
        }

        [Then(@"The users response is empty")]
        public void TheUsersResponseIsEmpty()
        {
            this.usersRootResponse.Item.Count.Should().Be(0);
        }

        [Then(@"The user gets the unread inbox with the following properties")]
        public void ThenTheUserGetsTheUnreadInboxWithTheFollowingProperties(Table table)
        {
        }

        [Then(@"The users checks the '(.*)' inbox message is not in unread's lists")]
        public void ThenTheUsersChecksTheInboxMessageIsNotInUnreadSLists(string p0)
        {
        }
    }
}
