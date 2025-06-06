using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.UnitTests
{
    [TestFixture]
    public class EditionUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var kniga = CreateTestEdition();

            Assert.That(kniga.Name, Is.EqualTo("C# за 5 минут"));
            Assert.That(kniga.Avtors, Is.EquivalentTo(new List<string> { "Иванов", "Сидоров" }));
            Assert.That(kniga.Year, Is.EqualTo(2022));
            Assert.That(kniga.Izdatel, Is.EqualTo("Питер"));
            Assert.That(kniga.Nomer, Is.EqualTo("кн456"));
            Assert.That(kniga.Cena, Is.EqualTo(0));
            Assert.That(kniga.Status, Is.EqualTo(Status.NaSklade));
        }

        [Test]
        public void GetInfoTest()
        {
            var kniga = CreateTestEdition();
            var info = kniga.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("C# за 5 минут (авторы: Иванов, Сидоров)"));
            Assert.That(info[1], Is.EqualTo("год: 2022, издательство: Питер, номер: кн456, статус: на складе, цена: 0 руб."));
        }

        private Edition CreateTestEdition()
        {
            return new Edition(
                name: "C# за 5 минут",
                avtors: new List<string> { "Иванов", "Сидоров" },
                year: 2022,
                izdatel: "Питер",
                nomer: "кн456"
            );
        }
    }
}