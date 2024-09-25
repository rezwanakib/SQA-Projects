using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using NLog.Filters;
using OpenQA.Selenium;
namespace ExampleProject.Framework.Pages
{
    internal class SignupPage : Form
    {
        private IButton accountButton = ElementFactory.GetButton(By.XPath("//*[@title='SignUp/Login']"), "Account Button");
        private IButton signupButton = ElementFactory.GetButton(By.XPath("//*[@href='https://bssoln-001-site3.atempurl.com/register?returnUrl=%2F']"), "Sign up Button");
        private ITextBox firstNameTextBox = ElementFactory.GetTextBox(By.XPath("//*[@id='FirstName']"), "First Name Text Box");
        private ITextBox lastNameTextBox = ElementFactory.GetTextBox(By.XPath("//*[@id='LastName']"), "Last Name Text Box");
        private ITextBox emailTextBox = ElementFactory.GetTextBox(By.XPath("//*[@id='Email']"), "Email Text Box");
        private ITextBox phoneTextBox = ElementFactory.GetTextBox(By.XPath("//*[@id='Phone']"), "Phone Text Box");
        private ITextBox passwordTextBox = ElementFactory.GetTextBox(By.XPath("//*[@id='registration-password-field']"), "Password Text Box");
        private ITextBox confirmPasswordTextBox = ElementFactory.GetTextBox(By.XPath("//*[@id='registration-confirm-password-field']"), "Confirm Password Text Box");
        private IButton registerButton = ElementFactory.GetButton(By.XPath("//*[@id='register-button']"), "Register Button");
        private ILabel welcomeText = ElementFactory.GetLabel(By.XPath("//*[@class='page-title']"), "Welcome Text");

        public SignupPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "")), "")
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

        public void ClickSignupButton() 
        {
            signupButton.Click();
        }

        public void FillFirstName(string firstName)
        {
            firstNameTextBox.Type(firstName);
        }

        public void FillLastName(string lastName) 
        {
            lastNameTextBox.Type(lastName);
        }

        public void FillEmail(string email) 
        {
            emailTextBox.Type(email);
        }

        public void FillPhone(string phone)
        {
            phoneTextBox.Type(phone);
        }

        public void FillPassword(string password) 
        {
            passwordTextBox.Type(password);
        }

        public void FillConfirmPassword(string password)
        {
            confirmPasswordTextBox.Type(password);
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)AqualityServices.Browser.Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ClickRegisterButton()
        {
            ScrollToElement(registerButton.GetElement());
            registerButton.Click();
        }

        public string GetWelcomeText()
        {
            return welcomeText.GetText();
        }
    }
}
