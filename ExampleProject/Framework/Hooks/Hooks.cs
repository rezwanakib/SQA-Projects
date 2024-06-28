using System.Runtime.ConstrainedExecution;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using TechTalk.SpecFlow;
using static HarmonyLib.Code;

namespace ExampleProject.Framework.Hooks
{
    [Binding]
    internal class Hooks
    {
        private readonly Browser browser = AqualityServices.Browser;
        private static readonly JsonSettingsFile settings = new("config.json");        
            
        [BeforeScenario]
        public void Setup()
        {
            browser.Maximize();
            browser.GoTo(settings.GetValue<string>("url"));
        }
        
        [AfterScenario]
        public void Teardown()
        {
            browser.Quit();
        }        
    }
}