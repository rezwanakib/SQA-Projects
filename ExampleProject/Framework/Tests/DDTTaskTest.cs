using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using ExampleProject.Framework.Pages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace ExampleProject.Framework.Tests
{
    internal class DDTTaskTest : BaseTest
    {
        private DDTTaskPage dDTTaskPage = new();

        public static List<TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();
                var section = JSectionReader.Section("testdata.json");

                for (int i = 0; i < 3; i++)
                {
                    string fullName = section.GetSection("DDT", i, "fullName").GetObject<string>();
                    string email = section.GetSection("DDT", i, "email").GetObject<string>();

                    var testCase = new TestCaseData(fullName, email);
                    testCases.Add(testCase);
                }
                return testCases;
            }
        }

        [TestCaseSource(nameof(TestCases))]
        public void DDTTaskTests(string fullName, string email)
        {
            //DDTPage.InputFullName(testdata.GetValue<string>("DDT.fullName"));
            //DDTPage.InputEmail(testdata.GetValue<string>("DDT.email"));

            dDTTaskPage.InputFullName(fullName);
            dDTTaskPage.InputEmail(email);

            dDTTaskPage.ClickSubmit();

            //Assert.AreEqual(testdata.GetValue<string>("DDT.fullName"), DDTPage.IsNameInputDisplayed());
            //Assert.Contains(DDTPage.IsNameInputDisplayed(),testdata.GetValue<string>("DDT.fullName"));

            StringAssert.Contains(fullName, dDTTaskPage.IsNameInputDisplayed());
            StringAssert.Contains(email, dDTTaskPage.IsEmailInputDisplayed());
        }
    }
}
