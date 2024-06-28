using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Linq;

namespace Unit2FinalTask.Selenium
{
    internal class Unit2SurveyTest : BaseTest
    {
        private static readonly string pageTitle = "DEMOQA";
        private static readonly By cards = By.XPath("//*[@class='card mt-4 top-card']");
        private static readonly By alertCard = By.XPath(string.Format(preciseTextXpath, "Alerts, Frame & Windows"));
        private static readonly By browserWindowsBtn = By.XPath(string.Format(preciseTextXpath, "Browser Windows"));
        private static readonly By newTabBtn = By.XPath("//*[@id='tabButton']");
        private static readonly By newTabPage = By.XPath("//*[@id='sampleHeading']");
        private static readonly By widgetBtn = By.XPath(string.Format(preciseTextXpath, "Widgets"));
        private static readonly By pragressBarBtn = By.XPath(string.Format(preciseTextXpath, "Progress Bar"));
        private static readonly By startBtn = By.XPath("//*[@id='startStopButton']");
        private static readonly By resetBtn = By.XPath("//*[@id='resetButton']");

        [Test]
        public void Test1()
        {
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> cardFreq = driver.FindElements(cards);
            int cardNumber = cardFreq.Count;
            Assert.That(cardNumber, Is.GreaterThan(5));
        }

        [Test]
        public void Test2()
        {
            var elem = driver.FindElement(alertCard);
            driver.ExecuteScript("arguments[0].scrollIntoView(true);", elem);

            driver.FindElement(alertCard).Click();
            driver.FindElement(browserWindowsBtn).Click();
            driver.FindElement(newTabBtn).Click();

            var lastTab= driver.WindowHandles.Last();
            driver.SwitchTo().Window(lastTab);

            string expectedText = driver.FindElement(newTabPage).Text;
            Assert.That(expectedText, Is.EqualTo("This is a sample page"),"Texts are not matching");

        }

        [Test]
        public void Test3()
        {
            Assert.That(pageTitle, Is.EqualTo(driver.Title), "Main page is not displayed.");

            var element = driver.FindElement(widgetBtn);
            driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            driver.FindElement(widgetBtn).Click();
            driver.FindElement(pragressBarBtn).Click();
            driver.FindElement(startBtn).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(resetBtn));
            Assert.That(driver.FindElement(resetBtn).Displayed);
        }
    }
}
