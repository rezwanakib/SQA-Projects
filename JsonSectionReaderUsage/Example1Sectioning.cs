using System.Text;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace JsonSectionReaderUsage
{
    [TestFixture]
    public class Example1Sectioning
    {
        [Test]
        public void Test1()
        {
            var name = JSectionReader.Section("Example1Sectioning.json").GetSection("name").GetObject<string>();
            Assert.AreEqual("john", name);
        }

        [Test]
        public void Test2()
        {
            var name = JSectionReader.Section("Example1Sectioning.json", Encoding.Default, "name").GetObject<string>();
            Assert.AreEqual("john", name);
        }

        [Test]
        public void Test3()
        {
            var name = new JSectionReader().Read("Example1Sectioning.json", Encoding.Default, "name").GetObject<string>();
            Assert.AreEqual("john", name);
        }
    }
}