using System.Runtime.InteropServices;
using ExampleProject.Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ExampleProject.Framework.StepDefinitions
{
    [Binding]
    internal class CurrentLocationLabelSteps
    {
        private CurrentLocationLabelPage currentLocationLabelPage = new();

        [When(@"I want to click the Search field")]
        public void ClickTheSearchField()
        {
            currentLocationLabelPage.ClickTheSearchBar();
        }

        [Then(@"Check if the current location label is displayed")]
        public void CheckThatHeaderNameContainsTheSearchedCity()
        {
            Assert.AreEqual(currentLocationLabelPage.label, currentLocationLabelPage.IsLabelDisplayed(), "Current Location Label is not displayed");
        }
    }
}