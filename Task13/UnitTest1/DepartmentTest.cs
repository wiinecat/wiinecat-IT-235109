using Library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest1
{
    [TestFixture]
    public class DepartmentTests
    {
        private Department department;

        [SetUp] 
        public void Setup()
        {
            var editions = new List<Edition>
            {
                new Edition("Book A", new List<string> { "Author A" }, 2020, "Publisher A", "001"),
                new Edition("Book B", new List<string> { "Author B" }, 2021, "Publisher B", "002")
            };
            department = new Department("Fiction", editions);
        }

        [Test]
        public void CountTest()
        {
            Assert.That(department.Count, Is.EqualTo(2));
        }

        [Test]
        public void IEnumerableTest()
        {
            int count = 0;
            var bookTitles = new List<string>();

            foreach (var edition in department)
            {
                count++;
                bookTitles.Add(edition.Name);
            }

            Assert.That(count, Is.EqualTo(2));
            Assert.That(bookTitles, Does.Contain("Book A"));
            Assert.That(bookTitles, Does.Contain("Book B"));
        }

        [Test]
        public void EmptyDepartment_ShouldHaveZeroCount()
        {
            var emptyDepartment = new Department("Empty", new List<Edition>());
            Assert.That(emptyDepartment.Count, Is.EqualTo(0));
        }

        [Test]
        public void NullEditions_ShouldThrowException()
        {
            Assert.That(() => new Department("Test", null), Throws.ArgumentNullException);
        }
    }
}
