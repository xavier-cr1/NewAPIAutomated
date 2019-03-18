using APILayer.Client.Contracts;
using BoDi;
using CrossLayer.Containers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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
