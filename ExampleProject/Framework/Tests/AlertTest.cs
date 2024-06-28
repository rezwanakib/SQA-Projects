using Allure.NUnit;
using Allure.NUnit.Attributes;
using ExampleProject.Framework.Pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Alert tests")]

    internal class AlertTest : BaseTest
    {
        private JavaScriptAlertPage jsAlertPage = new();

        [Test]
        public void AlertsTest()
        {
            ClickNavigationLink();
            ClickJSAlertBtn();
            AcceptAlert();
            ValidateSuccessMessage();
        }

        [Allure.NUnit.Attributes.AllureStep("Click Navigation Link")]
        private void ClickNavigationLink()
        {
            mainPage.ClickNavigationLink("JavaScript Alerts");
        }

        [Allure.NUnit.Attributes.AllureStep("Click JS Alert Button")]
        private void ClickJSAlertBtn()
        {
            jsAlertPage.ClickJSAlertBtn();
        }

        [Allure.NUnit.Attributes.AllureStep("Accepting Alert")]
        private void AcceptAlert()
        {
            browser.HandleAlert(Aquality.Selenium.Browsers.AlertAction.Accept);
        }

        [Allure.NUnit.Attributes.AllureStep("Validate Success Message")]
        private void ValidateSuccessMessage()
        {
            Assert.That(jsAlertPage.IsSuccessMessageDisplayed(), "Success message is not displayed");
        }
    }
}
