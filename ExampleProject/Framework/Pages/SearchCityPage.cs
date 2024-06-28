using System;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ExampleProject.Framework.Pages
{
    internal class SearchCityPage : Form
    {
        private const string PageName = "Local, National, & Global Daily Weather Forecast | AccuWeather";
        private ITextBox searchInput = ElementFactory.GetTextBox(By.XPath("//*[@class='search-input']"), "Search Input");
        private IButton firstResultCity = ElementFactory.GetButton(By.XPath("(//*[@class='results-container']//*[contains(@class,'search-bar-result')])[1]"), "First Element");
        private IElement headerElement(string cityName) => ElementFactory.GetLabel(By.XPath($"//*[@class='header-loc' and contains(text(),'{cityName}')]"), "New York Header");
        //private IElement headerElement => ElementFactory.GetLabel(By.XPath("//*[@class='header-loc' and contains(text)]"), "Searched City Header");
        //private readonly IElement headerElement = ElementFactory.GetLabel(By.XPath("//h1[@class='header-loc' and contains(text(),'New York')]"), "New York Header");


        public SearchCityPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }
        public void InputText(string text)
        {
            searchInput.Type(text);
        }

        public void ClickFirstResultElement()
        {
            firstResultCity.Click();
        }
        public string IsLabelDisplayed(string cityName)
        {
            return headerElement(cityName).Text;
        }
    }
}
