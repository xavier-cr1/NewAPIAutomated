using AppiumLayer.Factory.Android.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace UserStories.AcceptanceTests.Steps.Appium.Android_StackOverflow
{
    [Binding]
    public class Android_StackOverflowSteps : StepsBase
    {
        private readonly ISearchPage searchPage;

        public Android_StackOverflowSteps(ISearchPage searchPage)
        {
            this.searchPage = searchPage;
        }

        [Given(@"The user types the text value '(.*)' into search input")]
        public void GivenTheUserTypesTheTextValueIntoSearchInput(string text)
        {
            this.searchPage.UseSearch(text);
        }

        [Then(@"All presented entrances have the tag '(.*)'")]
        public void ThenAllPresentedEntracesHaveTheTag(string tag)
        {
            this.searchPage.AllEntrancesContainsTheCorrectTag(tag);
        }

    }
}
