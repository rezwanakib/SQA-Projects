using System;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ExampleProject.Framework.Pages
{
    internal class CurrentLocationLabelPage : Form
    {
        public string label = "Use your current location";
        private const string PageName = "Local, National, & Global Daily Weather Forecast | AccuWeather";
        private ITextBox searchInput = ElementFactory.GetTextBox(By.XPath("//*[@class='search-input']"), "Search Input");
        
        private readonly ILabel currentLocationElement = ElementFactory.GetLabel(By.XPath("//*[@class='current-location-text' and contains(text(),'Use your current location')]"), "current location label");

        public CurrentLocationLabelPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public void ClickTheSearchBar()
        {
            searchInput.Click();
        }

        public string IsLabelDisplayed()
        {
            return currentLocationElement.Text;
        }
    }
}
