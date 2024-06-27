using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace JsonSectionReaderUsage
{
    [TestFixture]
    public class Example5ReadingObject
    {
        [Test]
        public void Test()
        {
            var person = JSectionReader.Section("Example5ReadingObject.json").GetSection("person").GetObject<Person>();
            Assert.AreEqual("richard", person.Name);
            Assert.AreEqual(22, person.Age);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}