using ExampleProject.Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using ExampleProject.Framework.Utils;

namespace ExampleProject.Framework.StepDefinitions
{
    [Binding]
    internal class DataTablesSteps
    {
        private DataTablesPage dataTablesPage = new();

        [Then(@"Sum of the Due columns is (.*)")]
        public void CheckThatSumOfTheDueColumnsIs(double sum)
        {
            var actualSum = 0.00;
            foreach(string due in dataTablesPage.GetFirstDueList())
            {
                actualSum += StringUtils.GetDoubleFromString(due);
            }
            Assert.AreEqual(sum, actualSum, "Sum is not correct");
        }
    }
}