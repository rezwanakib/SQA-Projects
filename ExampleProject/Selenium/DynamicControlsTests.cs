using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace ExampleProject.Selenium
{
    internal class DynamicControlsTests : BaseTest
    {
        private static readonly By dynamicControl = By.XPath(string.Format(preciseTextXpath, "Dynamic Controls"));
        private static readonly By enableBtn = By.XPath(string.Format(preciseTextXpath, "Enable"));
        
        private static readonly By inputField = By.XPath("//*[@id='input-example']//input");
        private static readonly string randomValue=Guid.NewGuid().ToString();

        [Test]
        public void DynamicControlsTest()
        {
            driver.FindElement(dynamicControl).Click();
            driver.FindElement(enableBtn).Click();
            
            //assert input is enabled
            var inputFieldElement= driver.FindElement(inputField);
            Assert.That(IsEnabled(inputFieldElement),"Input is not enabled");

            //input randomly generated text
            inputFieldElement.SendKeys(randomValue);

            //assert input text
            ClassicAssert.AreEqual(driver.FindElement(inputField).GetAttribute("value"), randomValue,
                "Text is not displayed");
        }

        private bool IsEnabled(IWebElement element)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
