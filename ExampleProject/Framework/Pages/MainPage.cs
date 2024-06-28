using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
namespace ExampleProject.Framework.Pages
{
    internal class MainPage : Form
    {
        public string PageName = "Local, National, & Global Daily Weather Forecast | AccuWeather";

        private IButton acceptBtn = ElementFactory.GetButton(By.XPath("//*[@class='banner-button policy-accept']"), "Policy Accept");

        public MainPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "")), "")
        {
        }

        public string IsPageTitleCorrect()
        {
            string actualTitle = AqualityServices.Browser.Driver.Title;
            return actualTitle;
        }

        public void ClickNavigationLink()
        {
            ClickAcceptBtn();
        }
        
        public void ClickAcceptBtn()
        {
            acceptBtn.Click();
        }        
    }
}