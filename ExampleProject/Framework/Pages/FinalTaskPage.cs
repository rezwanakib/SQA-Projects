using System;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ExampleProject.Framework.Pages
{
    internal class FinalTaskPage : Form
    {
        private const string PageName = "Local, National, & Global Daily Weather Forecast | AccuWeather";
        private IButton acceptBtn = ElementFactory.GetButton(By.XPath("//*[@class='banner-button policy-accept']"), "Policy Accept");        
        private ITextBox searchInput = ElementFactory.GetTextBox(By.XPath("//*[@class='search-input']"), "Search Input");
        private IButton newYorkElement = ElementFactory.GetButton(By.XPath("//p[@class='search-bar-result__name' and text()='New York']"), "New York Element");
        private readonly IElement headerElement = ElementFactory.GetLabel(By.XPath("//h1[@class='header-loc' and contains(text(),'New York')]"), "New York Header");

        public FinalTaskPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public bool IsPageTitleCorrect()
        {
            string actualTitle = AqualityServices.Browser.Driver.Title;
            return actualTitle.Equals(PageName);
        }

        public void ClickAcceptBtn()
        {
            acceptBtn.Click();
        }

        public void InputText(string text)
        {
            searchInput.Type(text);
        }

        public void ClickNewYorkElement()
        {
            newYorkElement.Click();
        }

        public string IsLabelDisplayed()
        {
            return headerElement.Text;
        }
    }
}
