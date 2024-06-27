//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text.Json;
//using ExampleProject.Framework.Pages;
//using Microsoft.VisualStudio.TestPlatform.ObjectModel;
//using NUnit.Framework;

//namespace ExampleProject.Framework.Tests
//{
//    internal class DDTTest : BaseTest
//    {
//        private DDTPage DDTPage = new();

//        //[Ignore("it has bugs")]

//        [Test]
//        public void DDTTaskTest(string fullName, string email)
//        {
//            DDTPage.InputFullName(testdata.GetValue<string>("DDT.fullName"));
//            DDTPage.InputEmail(testdata.GetValue<string>("DDT.email"));

//            DDTPage.ClickSubmit();

//            //Assert.AreEqual(testdata.GetValue<string>("DDT.fullName"), DDTPage.IsNameInputDisplayed());
//            //Assert.Contains(DDTPage.IsNameInputDisplayed(),testdata.GetValue<string>("DDT.fullName"));

//            StringAssert.Contains(fullName, DDTPage.IsNameInputDisplayed());
//            StringAssert.Contains(email, DDTPage.IsEmailInputDisplayed());
//        }
//    }
//}
