using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace Unit2FinalTask
{
    internal class BaseTest
    {
        protected WebDriver driver;
        protected static readonly string url = "https://demoqa.com/";
        protected static readonly string preciseTextXpath = "//*[text()='{0}']";
        protected static readonly string relativePathFolder = @"Resources\"; 
        protected WebDriverWait wait = null;
        protected static readonly int maxWait = 10;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", Path.GetFullPath(relativePathFolder));

            driver = new ChromeDriver(chromeOptions);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
