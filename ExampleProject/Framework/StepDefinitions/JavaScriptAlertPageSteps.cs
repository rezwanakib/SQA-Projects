using ExampleProject.Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ExampleProject.Framework.StepDefinitions
{
    [Binding]
    internal class JavaScriptAlertPageSteps
    {
        private JavaScriptAlertPage jsAlertPage = new();

        [When(@"I generate JS alert on the Javascript Alert Page")]
        public void GenerateJSAlertOnTheJavaScriptAlertPage()
        {
            jsAlertPage.ClickJSAlertBtn();
        }

        [Then(@"Success message is displayed on JavaScript Alert Page")]
        public void CheckThatSuccessMessageIsDisplayedOnTheJavaScriptAlertPage()
        {
            Assert.IsTrue(jsAlertPage.IsSuccessMessageDisplayed(),"Not Displayed");
        }        
    }
}