using System.Runtime.InteropServices;
using ExampleProject.Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ExampleProject.Framework.StepDefinitions
{
    [Binding]
    internal class SearchCitySteps
    {
        private SearchCityPage searchCityPage = new();

        [When(@"I Input '(.*)' in the search field")]
        public void InputInTheSearchField(string searchString)
        {
            searchCityPage.InputText(searchString);
        }

        [When(@"I Click on the first search result")]
        public void ClickingTheFirstSearchResult()
        {
            searchCityPage.ClickFirstResultElement();
        }

        [Then(@"Check if the City weather page header contains '(.*)' from the search")]
        public void CheckThatHeaderNameContainsTheSearchedCity(string searchString)
        {
            Assert.That(searchCityPage.IsLabelDisplayed(searchString), Does.StartWith(searchString), "Searched city page is not displayed");
        }
    }
}