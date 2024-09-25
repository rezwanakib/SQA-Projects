using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using NLog.Filters;
using OpenQA.Selenium;
namespace ExampleProject.Framework.Pages
{
    internal class LoginPage : Form
    {
        private IButton accountButton = ElementFactory.GetButton(By.XPath("//*[@title='SignUp/Login']"), "Account Button");
        private ITextBox usernameTextBox = ElementFactory.GetTextBox(By.XPath("//*[@id='Username']"), "Username Text Box");
        private ITextBox passwordTextBox = ElementFactory.GetTextBox(By.XPath("//*[@id='login-password-field']"), "Password Text Box");
        private IButton loginButton = ElementFactory.GetButton(By.XPath("//*[@class='auth__details__form__submit']"), "Login Button");
        private ILabel welcomeText = ElementFactory.GetLabel(By.XPath("//*[@class='page-title']"), "Welcome Text");

        public LoginPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "")), "")
        {
        }

        public string GetMainPageTitle()
        {
            return AqualityServices.Browser.Driver.Title;
        }

        public void ClickAccountButton()
        {
            accountButton.Click();
        }

        public void FillUsername(string username)
        {
            usernameTextBox.Type(username);
        }

        public void FillPassword(string password) 
        {
            passwordTextBox.Type(password);
        }

        public void ClickLoginButton()
        {
            loginButton.Click();
        }
    }
}
