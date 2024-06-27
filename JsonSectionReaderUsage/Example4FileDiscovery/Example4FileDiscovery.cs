using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WonderTools.JsonSectionReader;

namespace JsonSectionReaderUsage.Example4FileDiscovery
{
    [TestFixture]
    class Example4FileDiscovery
    {
        [Test]
        public void Test1()
        {
            var actualWord = JSectionReader
                .Section("JsonSectionReaderUsage.Example4FileDiscovery.Boo.Example4FileDiscovery.json")
                .GetSection("animal").GetObject<string>();
            Assert.AreEqual("elephant", actualWord);
        }

        [Test]
        public void Test2()
        {
            var actualWord = JSectionReader
                .Section("Example4FileDiscovery.Boo.Example4FileDiscovery.json")
                .GetSection("animal").GetObject<string>();
            Assert.AreEqual("elephant", actualWord);
        }

        [Test]
        public void Test3()
        {
            var actualWord = JSectionReader
                .Section("Boo.Example4FileDiscovery.json")
                .GetSection("animal").GetObject<string>();
            Assert.AreEqual("elephant", actualWord);
        }
    }
}
