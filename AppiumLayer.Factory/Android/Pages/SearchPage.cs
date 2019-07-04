using AppiumLayer.Driver.Android.Entities;
using AppiumLayer.Factory.Android.Contracts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumLayer.Factory.Android.Pages
{
    public class SearchPage : AndroidBasePage, ISearchPage
    {
        private IWebElement searchTextBox => WaitUntilFindElement(this.androidDriver, By.Id("com.stackexchange.stackoverflow:id/search_src_text"));

        public SearchPage(AppDriver appDriver)
            :base(appDriver)
        {
        }

        public void UseSearch(string text)
        {
            this.searchTextBox.SendKeys(text + "\n");

            var test = 0;
        }
    }
}
