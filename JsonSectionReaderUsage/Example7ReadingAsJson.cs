using System;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace JsonSectionReaderUsage
{
    [TestFixture]
    public class Example7ReadingAsJson
    {
        [Test]
        public void Test()
        {
            var expectedJson = "{\"name\":\"Nash\",\"id\":31433}";
            var data = new JSectionReader().Read("Example7ReadingAsJson.json").GetSection("employees" , 1).GetJson();
            Assert.AreEqual(expectedJson, data);
        }
    }
}