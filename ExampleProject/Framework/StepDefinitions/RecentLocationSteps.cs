using System.Runtime.InteropServices;
using ExampleProject.Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ExampleProject.Framework.StepDefinitions
{
    [Binding]
    internal class RecentLocationSteps
    {
        private RecentLocationPage recentLocationPage = new();

        [When(@"I Input '(.*)' in the Search field")]
        public void InputInTheSearchField(string searchString)
        {
            recentLocationPage.InputText(searchString);
        }

        [When(@"I Click on the first Search result")]
        public void ClickingTheFirstSearchResult()
        {
            recentLocationPage.ClickLondonElement();
        }

        [When(@"Go back to the Main page")]
        public void GoToMainPage()
        {
            recentLocationPage.GoBackToPreviousPage();
        }

        [When(@"Choose the first city in Recent locations")]
        public void ClickingTheFirstRecentLocationElement()
        {
            recentLocationPage.ClickTheFirstRecentLocation();
        }

        [When(@"Handle the Ad frame")]
        public void WantToCloseTheAd()
        {
            recentLocationPage.AdHandling();
        }

        [Then(@"Check if the City weather page header contains '(.*)' from the Search")]
        public void CheckThatHeaderNameContainsTheSearchedCity(string searchString)
        {            
            Assert.That(recentLocationPage.IsLabelDisplayed(), Does.StartWith(searchString), "London page is not displayed");
        }
    }
}