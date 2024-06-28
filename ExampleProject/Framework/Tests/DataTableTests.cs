using System.Text.RegularExpressions;
using System;
using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;
using Allure.NUnit.Attributes;

namespace ExampleProject.Framework.Tests
{
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Data Table tests")]

    internal class DataTableTests : BaseTest
    {
        private DataTablesPage dataTablesPage = new();
        private static readonly string currencyRegex = "[^\\d.]";

        [Test]
        public void DataTablesTest()
        {
            MainPageMethod();
            var actualSum = 0.00;
            foreach (string due in dataTablesPage.GetFirstDueList())
            {
                actualSum += Convert.ToDouble(Regex.Replace(due, currencyRegex, ""));
            }
            //Assert.AreEqual(testdata.GetValue<double>("dataTable.expectedSum"), actualSum, "Sum is not correct");
        }

        [AllureStep("Mainpage")]
        private void MainPageMethod()
        {
            mainPage.ClickNavigationLink("Sortable Data Tables");
        }
    }
}
