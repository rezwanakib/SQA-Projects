using System.Collections.Generic;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace JsonSectionReaderUsage
{
    [TestFixture]
    public class Example8ListOfList
    {
        [Test]
        public void Test()
        { 
            var data = new JSectionReader().Read("Example8ListOfList.json").GetSection("data")
                .GetTable(typeof(int), typeof(string), typeof(string));

            var expectedData = new List<List<object>>()
            {
                new List<object>() {1, "Monday", "Morning"},
                new List<object>() {2, "Monday", "Afternoon"},
                new List<object>() {3, "Tuesday", "Morning"},
                new List<object>() {4, "Tuesday", "Afternoon"},
            };

            for (int i = 0; i < expectedData.Count; i++)
            {
                for (int j = 0; j < expectedData[i].Count; j++)
                {
                    Assert.AreEqual(data[i][j],expectedData[i][j]);
                }
            }
        }
    }
}