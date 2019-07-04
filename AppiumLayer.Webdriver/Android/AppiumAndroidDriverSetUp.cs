using BoDi;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using AppiumLayer.Driver.Android.Entities;

namespace AppiumLayer.Driver.Android
{
    public class AppiumAndroidDriverSetUp : ISetpUp
    {
        private const string AndroidApplicationPath = @"\netcoreapp2.1\Android\binaries\com.stackexchange.stackoverflow.apk";
        private readonly IObjectContainer objectContainer;

        public AppiumAndroidDriverSetUp(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        public AppiumDriver<AndroidElement> SetUpAppiumDriver()
        {
            AndroidDriver<AndroidElement> androidDriver = null;

            try
            {
                var appFullPath = Directory.GetParent(Directory.GetCurrentDirectory()) + AndroidApplicationPath;

                // See Appium Capabilities wiki.
                var appOptions = new AppiumOptions();
                appOptions.AddAdditionalCapability("platformName", "Android");
                appOptions.AddAdditionalCapability("platformVersion", "7.1.1");
                appOptions.AddAdditionalCapability("fastReset", "True");
                appOptions.AddAdditionalCapability("app", appFullPath);

                // To see the device name with the cmd console check adb devices -l
                appOptions.AddAdditionalCapability("deviceName", "emulator-5554");

                androidDriver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appOptions, TimeSpan.FromSeconds(600));

                this.objectContainer.RegisterInstanceAs(new AppDriver { AppiumAndroidDriver = androidDriver });

                return androidDriver;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
                if (androidDriver != null)
                {
                    this.CloseAppiumDriver(androidDriver);
                }

                throw;
            }
        }

        public void CloseAppiumDriver(AppiumDriver<AndroidElement> appiumDriver)
        {
            appiumDriver?.Close();
            appiumDriver?.Quit();
        }
    }
}
