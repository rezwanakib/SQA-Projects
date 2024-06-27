using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace JsonSectionReaderUsage
{
    [TestFixture]
    public class Example2Sectioning
    {
        [Test]
        public void Test()
        {
            var name =JSectionReader.Section("Example2Sectioning.json").GetSection("employees", 1, "name").GetObject<string>();
            Assert.AreEqual("richard", name);
        }
    }
}