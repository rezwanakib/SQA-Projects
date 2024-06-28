using Allure.NUnit;
using Allure.NUnit.Attributes;
using Aquality.Selenium.Browsers;
using ExampleProject.Framework.Pages;
//using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Basic Auth tests")]

    internal class BasicAuthTest : BaseTest
    {
        private BasicAuthPage basicAuthPage = new();

        [SetUp]
        public void BasicAuthorisation()
        {
            //todo: add basic auth
            browser.RegisterBasicAuthenticationAndStartMonitoring("herokuapp.com",
                testdata.GetValue<string>("basicAuth.login"), 
                testdata.GetValue<string>("basicAuth.password"));
        }

        [Test]
        public void BasicAuthSuccessfulTest()
        {
            ClickNavigationLink();
            ValidateSuccessMessage();            
        }

        [AllureStep("Click Navigation Link")]
        private void ClickNavigationLink()
        {
            mainPage.ClickNavigationLink("Basic Auth");
        }

        [AllureStep("Validate Success Message")]
        private void ValidateSuccessMessage()
        {
            Assert.That(basicAuthPage.IsSuccessMessageDisplayed(), "Success message is not displayed");
        }
    }
}
