using AppiumLayer.Driver.Android.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumLayer.Factory.Android
{
    public class AndroidBasePage
    {
        protected readonly AppiumDriver<AndroidElement> androidDriver;

        public AndroidBasePage(AppDriver appDriver)
        {
            this.androidDriver = appDriver.AppiumAndroidDriver;
        }

        protected IWebElement WaitUntilFindElement(AppiumDriver<AndroidElement> androidDriver, By by, double waitSeconds = 3)
        {
            androidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitSeconds);
            var webDriverWait = new WebDriverWait(androidDriver, TimeSpan.FromSeconds(waitSeconds));
            var findElement = webDriverWait.Until(x => x.FindElement(by));

            return findElement;
        }
    }
}
