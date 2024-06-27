using System;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ExampleProject.Framework.Pages
{
    internal class DDTTaskPage : Form
    {
        private ITextBox fullName = ElementFactory.GetTextBox(By.XPath("//*[@id='userName']"), "Full Name Input");
        private ITextBox email = ElementFactory.GetTextBox(By.XPath("//*[@id='userEmail']"), "Email Input");
        private IButton submitBtn = ElementFactory.GetButton(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "Submit")), "Submit Button");
        private ILabel fullNameLabel => ElementFactory.GetLabel(By.XPath("//*[@id='name']"), "Full Name Label");
        private ILabel emailLabel => ElementFactory.GetLabel(By.XPath("//*[@id='email']"), "Email Label");

        public DDTTaskPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "")), "")
        {
        }

        public void InputFullName(string name)
        {
            fullName.Type(name);
        }

        public void InputEmail(string email)
        {
            this.email.Type(email);
        }

        public void ClickSubmit()
        {
            //submitBtn.GetJsActions().ScrollIntoView();
            ((IJavaScriptExecutor)AqualityServices.Browser.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitBtn.GetElement());
            submitBtn.Click();
        }

        public string IsNameInputDisplayed()
        {
            return fullNameLabel.Text;
        }
        public string IsEmailInputDisplayed()
        {
            return emailLabel.Text;
        }
    }
}
