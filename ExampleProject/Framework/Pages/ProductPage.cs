using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Forms;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class ProductPage : Form
    {
        private IButton signupButton = ElementFactory.GetButton(By.XPath("//*[@href='https://bssoln-001-site3.atempurl.com/register?returnUrl=%2F']"), "Sign up Button");
        private IButton productButton = ElementFactory.GetButton(By.XPath("//*[@href='/original-loose-powder-foundation-spf-15']"), "Product Button");
        private IButton addToWishList = ElementFactory.GetButton(By.XPath("//*[@id='add-to-wishlist-button-3']"), "Add to Wishlist Button");
        private ILabel wishlistAddedText = ElementFactory.GetLabel(By.XPath("//*[@class='modal-title paris-font']"), "Wishlist Added Text");

        public ProductPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "")), "")
        {
        }

        public string GetMainPageTitle()
        {
            return AqualityServices.Browser.Driver.Title;
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)AqualityServices.Browser.Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ClickProductButton()
        {
            ScrollToElement(productButton.GetElement());
            productButton.Click();
        }

        public void ClickAddToWishlistButton()
        {
            addToWishList.Click();
        }

        public string GetWishlistAddedText()
        {
            return wishlistAddedText.Text;
        }
    }
}
