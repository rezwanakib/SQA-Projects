using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class SignupTest : BaseTest
    {
        private SignupPage signupPage = new();

        string expectedTitle = "Ladily. Home page title";
        private static readonly string firstName = GenerateRandomName();
        private static readonly string lastName = GenerateRandomName();
        private static readonly string password = testdata.GetValue<string>("signup.password");
        private static readonly string email = $"{firstName}@domain.com";
        private static readonly string phone = GenerateRandom11DigitNumber();
        private static readonly string welcomeText = $"Welcome! {firstName}";

        [Test]
        public void TestSignup()
        {
            Assert.AreEqual(signupPage.GetMainPageTitle(), expectedTitle, "Main page is not loaded");
            signupPage.ClickAccountButton();
            signupPage.ClickSignupButton();
            signupPage.FillFirstName(firstName);
            signupPage.FillLastName(lastName);
            signupPage.FillEmail(email);
            signupPage.FillPhone(phone);
            signupPage.FillPassword(password);
            signupPage.FillConfirmPassword(password);
            signupPage.ClickRegisterButton();
            Assert.AreEqual(welcomeText, signupPage.GetWelcomeText(), "Account creation failed");
        }

        private static string GenerateRandomName()
        {
            const string upperChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            StringBuilder result = new StringBuilder(5);

            result.Append(upperChars[random.Next(upperChars.Length)]);

            for (int i = 1; i < 5; i++)
            {
                result.Append(lowerChars[random.Next(lowerChars.Length)]);
            }

            return result.ToString();
        }

        private static string GenerateRandom11DigitNumber()
        {
            Random random = new Random();
            long number = (long)(random.NextDouble() * 1_000_000_00L); 
            return $"01{number:D9}"; 
        }
    }
}
