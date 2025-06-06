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
    public class EditionTests
    {
        [Test]
        public void CompareToTest()
        {
            var edition1 = new Edition("Book A", new List<string> { "Author B" }, 2020, "Publisher A", "001");
            var edition2 = new Edition("Book B", new List<string> { "Author A" }, 2021, "Publisher B", "002");

            Assert.IsTrue(edition1.CompareTo(edition2) > 0);
            Assert.IsTrue(edition2.CompareTo(edition1) < 0);
        }
    }
}
