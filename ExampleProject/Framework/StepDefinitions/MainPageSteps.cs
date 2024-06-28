using ExampleProject.Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ExampleProject.Framework.StepDefinitions
{
    [Binding]
    internal class MainPageSteps
    {
        MainPage mainPage = new();

        [Given(@"I want to consent data usage policy on the main page")]
        public void GoToMainPage()
        {
            Assert.AreEqual(mainPage.IsPageTitleCorrect(), mainPage.PageName, "MainPage is not displayed");
            mainPage.ClickNavigationLink();
        }
    }
}