using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class FinalTaskTest : BaseTest
    {
        private FinalTaskPage finalTaskPage = new();
        private static readonly string searchString = "New York";

        [Test]
        public void FinalTaskTests()
        {
            Assert.IsTrue(finalTaskPage.IsPageTitleCorrect(), "Mainpage is not loaded");
            finalTaskPage.ClickAcceptBtn();
            finalTaskPage.InputText(searchString);
            finalTaskPage.ClickNewYorkElement();
            StringAssert.StartsWith(searchString, finalTaskPage.IsLabelDisplayed(), "New York page is not displayed");
        }
    }
}
