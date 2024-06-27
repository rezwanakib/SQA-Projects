using System.Collections.Generic;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace JsonSectionReaderUsage
{
    [TestFixture]
    public class Example6ReadingList
    {
        [Test]
        public void Test()
        {
            var numbers = JSectionReader.Section("Example6ReadingList.json").GetSection("numbers").GetObject<List<int>>();
            CollectionAssert.AreEqual(new List<int>(){5,4,3,2,1}, numbers);
        }
    }
}