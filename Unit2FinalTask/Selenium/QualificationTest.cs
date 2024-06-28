using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.IO;

namespace Unit2FinalTask.Selenium
{
    internal class QualificationTest : BaseTest
    {       
        private static readonly By jsAlertBtn = By.XPath(string.Format(preciseTextXpath, "JavaScript Alerts"));
        private static readonly By jsConfirmBtn = By.XPath(string.Format(preciseTextXpath, "Click for JS Prompt"));
        private static readonly string randomText=Guid.NewGuid().ToString();
        private static readonly By result = By.XPath(string.Format(partialTextXpath, $"{randomText}"));


        [Test]
        public void QualifyingTest()
        {
            driver.FindElement(jsAlertBtn).Click();
            
            Assert.That(driver.FindElements(jsAlertBtn), Is.Not.Empty, "Page is not opened.");
            driver.FindElement(jsConfirmBtn).Click();

            driver.SwitchTo().Alert().SendKeys(randomText);
            driver.SwitchTo().Alert().Accept();
            Assert.That(driver.FindElement(result).Text.Contains(randomText),"The text is not shown.");

        }        
    }
}
