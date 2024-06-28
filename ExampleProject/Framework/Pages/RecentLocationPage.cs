using System;
using System.Threading;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ExampleProject.Framework.Pages
{
    internal class RecentLocationPage : Form
    {
        private const string PageName = "Local, National, & Global Daily Weather Forecast | AccuWeather";
        private ITextBox searchInput = ElementFactory.GetTextBox(By.XPath("//*[@class='search-input']"), "Search Input");
        private IButton londonElement = ElementFactory.GetButton(By.XPath("//p[@class='search-bar-result__name' and text()='London']"), "London Element");
        //private ILabel elementOnNewPage = ElementFactory.GetLabel(By.XPath("YourUniqueElementLocator"), "Element on New Page");
        private IButton recentElement = ElementFactory.GetButton(By.XPath("//a[contains(@class, 'recent-location-item') and contains(@data-ga-text, 'London')]"), "first recent Element");
        private readonly IElement headerElement = ElementFactory.GetLabel(By.XPath("//h1[@class='header-loc' and contains(text(),'London')]"), "London Header");
        private IButton adElementCloseButton = ElementFactory.GetButton(By.XPath("//*[@id='dismiss-button']//div"), "Ad Element");
        private const string adIFrameId = "google_ads_iframe_/6581/web/gb/interstitial/news_info/country_home_0";
        
        public RecentLocationPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }
        public void InputText(string text)
        {
            searchInput.Type(text);
        }

        public void ClickLondonElement()
        {
            londonElement.ClickAndWait();
            //Thread.Sleep(2000);
            headerElement.State.WaitForDisplayed();
        }

        public void GoBackToPreviousPage()
        {
            AqualityServices.Browser.GoBack();
        }

        public void ClickTheFirstRecentLocation()
        {            
            recentElement.Click();            
        }

        public void AdHandling()
        {
            AqualityServices.Browser.Driver.SwitchTo().Frame(adIFrameId);
            adElementCloseButton.Click();
            AqualityServices.Browser.Driver.SwitchTo().DefaultContent();
        }

        public string IsLabelDisplayed()
        {
            return headerElement.Text;
        }
    }
}
