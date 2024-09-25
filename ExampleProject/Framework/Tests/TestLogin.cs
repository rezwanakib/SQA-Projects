using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class TestLogin : BaseTest
    {
        private LoginPage loginPage = new();

        string expectedTitle = "Ladily. Home page title";
        private static readonly string password = testdata.GetValue<string>("signup.password");
        private static readonly string email = testdata.GetValue<string>("signup.email");

        [Test]
        public void LoginTest()
        {
            Assert.AreEqual(loginPage.GetMainPageTitle(),expectedTitle, "Main page is not loaded");
            loginPage.ClickAccountButton();
            loginPage.FillUsername(email);
            loginPage.FillPassword(password);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetMainPageTitle(), expectedTitle, "Login Failed");
        }

       
    }
}
