﻿using ExampleProject.Framework.Pages;
using NUnit.Framework;
using System;

namespace ExampleProject.Framework.Tests
{
    internal class DynamicControlsTests : BaseTest
    {
        private DynamicControlsPage dynamicControlsPage = new();
        private static readonly string randomString = Guid.NewGuid().ToString();
    
        [Test]
        public void DynamicControlsTest()
        {
            //todo: implement a test

            mainPage.ClickNavigationLink("Dynamic Controls");
            dynamicControlsPage.ClickEnableBtn();
            Assert.IsTrue(dynamicControlsPage.IsInputEnabled(),"Input is not enabled");
            dynamicControlsPage.InputText (randomString) ;
            Assert.AreEqual(randomString, dynamicControlsPage.GetInputTextvatue(),
                "Text is not displayed");
        }
    }
}
