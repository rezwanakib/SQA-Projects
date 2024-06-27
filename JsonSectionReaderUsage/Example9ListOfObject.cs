using System;
using System.Collections.Generic;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace JsonSectionReaderUsage
{
    [TestFixture]
    public class Example9ListOfObject
    {
        [Test]
        public void Test()
        {
            var employees = new JSectionReader().Read("Example9ListOfObject.json").GetSection("data")
                .GetTableAsObjectList<Employee, int, string, int>(
                    (id, name, age) => new Employee()
                    {
                        Id = id,
                        Name = name,
                        Age = age,
                    });
            var expectedEmployees = new List<Employee>()
            {
                new Employee(){Id =2432,Name ="John", Age = 32},
                new Employee(){Id =2222,Name ="Nash", Age = 33},
                new Employee(){Id =3421,Name ="Peter", Age = 33},
            };

            for (int i = 0; i < expectedEmployees.Count; i++)
            {
                Assert.AreEqual(expectedEmployees[i].Id, employees[i].Id);
                Assert.AreEqual(expectedEmployees[i].Name, employees[i].Name);
                Assert.AreEqual(expectedEmployees[i].Age, employees[i].Age);
            }
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}