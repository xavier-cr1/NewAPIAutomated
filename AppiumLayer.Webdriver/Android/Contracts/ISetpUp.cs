using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumLayer.Driver.Android
{
    public interface ISetpUp
    {
        AppiumDriver<AndroidElement> SetUpAppiumDriver();

        void CloseAppiumDriver(AppiumDriver<AndroidElement> appiumDriver);
    }
}
