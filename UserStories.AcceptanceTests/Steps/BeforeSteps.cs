using BoDi;
using CrossLayer.Containers;
using Microsoft.Extensions.Configuration;
using System.IO;
using TechTalk.SpecFlow;

namespace UserStories.AcceptanceTests.Steps
{
    [Binding]
    public class BeforeSteps
    {
        private readonly IObjectContainer objectContainer;
        private readonly IAppContainer appContainers;

        public BeforeSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;

            // Inject app containers.
            this.RegisterAppContainerToObjectContainer();
            this.appContainers = this.objectContainer.Resolve<IAppContainer>();

            // Inject configuration to object container
            this.RegisterConfigurationToObjectContainer();
        }

        /// <summary>
        /// Sets up API scenarios. Triggers appcontainers
        /// </summary>
        [BeforeScenario]
        [Scope(Tag = "Type:API")]
        public void SetUpAPIScenarios()
        {
            this.appContainers.RegisterAPIs(this.objectContainer);
        }

        /// <summary>
        /// Sets up Appium Android scenarios. Triggers appcontainers
        /// </summary>
        [BeforeScenario]
        [Scope(Tag = "Type:AppiumAndroid")]
        public void SetUpAppiumAndroidScenarios()
        {

        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var dataOutputFolder = "TestOutput";

            if (!Directory.Exists(dataOutputFolder))
            {
                Directory.CreateDirectory(dataOutputFolder);
            }
        }

        private void RegisterConfigurationToObjectContainer()
        {
            var configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var environment = configurationRoot.GetSection("AppConfiguration")["Environment"];

            var configurationEnvironment = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .Build();

            this.objectContainer.RegisterInstanceAs(configurationEnvironment);
        }

        private void RegisterAppContainerToObjectContainer()
        {
            this.objectContainer.RegisterTypeAs<AppContainer, IAppContainer>();
        }
    }
}
