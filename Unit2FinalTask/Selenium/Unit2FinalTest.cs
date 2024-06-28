using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System.IO;

namespace Unit2FinalTask.Selenium
{
    internal class Unit2FinalTest : BaseTest
    {
        private static readonly string searchValue = "Albert Einstein";
        private static readonly string pageTitle = "Wikipedia";

        private static readonly By searchField = By.XPath("//*[@id='searchInput']");
        private static readonly By submitBtn = By.XPath("//*[@class='pure-button pure-button-primary-progressive']");
        private static readonly By toolBtn = By.XPath("//*[@id='vector-page-tools-dropdown-checkbox']");
        //private static readonly By downloadAsPDF = By.XPath("//*[@id='coll-download-as-rl']/a");
        private static readonly By downloadAsPDF = By.XPath("//*[@id='coll-download-as-rl']//a[contains(@href,'download')]");
        private static readonly By fileDownloadBtn = By.XPath(string.Format(preciseTextXpath, "Download"));
        
        private FileInfo downloadedFile;

        [Test]
        public void FinalTest()
        {
            ClassicAssert.AreEqual(pageTitle, driver.Title, "Main page is not displayed.");

            var searchFieldElement = driver.FindElement(searchField);
            searchFieldElement.SendKeys(searchValue);

            driver.FindElement(submitBtn).Click();
            driver.FindElement(toolBtn).Click();
            driver.FindElement(downloadAsPDF).Click();

            By classname = By.ClassName("mw-electronpdfservice-selection-label-desc");
            string fileName = driver.FindElement(classname).Text;

            driver.FindElement(fileDownloadBtn).Click();

            By fileNameField = By.XPath(string.Format(preciseTextXpath, fileName));

            driver.FindElement(fileNameField).Click();

            string filePath = relativePathFolder + fileName;
            downloadedFile = new FileInfo(Path.GetFullPath(filePath));

            wait.Until(condition => IsFileDownloaded(filePath));
            Assert.That(IsFileDownloaded(filePath), "File not downloaded");
        }

        private bool IsFileDownloaded(string filePath)
        {
            var newFile = new FileInfo(Path.GetFullPath(filePath));
            return newFile.Exists;
        }

        [TearDown]
        public void DeleteFile()
        {
            if (downloadedFile.Exists)
                downloadedFile.Delete();
        }
    }
}
