using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.UnitTests
{
    [TestFixture]
    public class KnigaTests
    {
        // тест конструктора для edition
        [Test]
        public void TestKonstruktor()
        {
            var kniga = CreateTestKniga();
            Assert.That(kniga.Name, Is.EqualTo("C# за 5 минут"));
            Assert.That(kniga.Avtors, Is.EquivalentTo(new List<string> { "Иванов", "Сидоров" }));
            Assert.That(kniga.Year, Is.EqualTo(2022));
            Assert.That(kniga.Izdatel, Is.EqualTo("Питер"));
            Assert.That(kniga.Nomer, Is.EqualTo("кн456"));
            Assert.That(kniga.Cena, Is.EqualTo(0));
            Assert.That(kniga.Status, Is.EqualTo(Status.NaSklade));
        }

        [Test]
        public void TestGetInfo()
        {
            var kniga = CreateTestKniga();
            var info = kniga.GetInfo();
            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("C# за 5 минут (авторы: Иванов, Сидоров)"));
            Assert.That(info[1], Is.EqualTo("год: 2022, издательство: Питер, номер: кн456, статус: на складе, цена: 0 руб."));
        }

        [Test]
        public void TestKonstruktorNaukaKniga()
        {
            var nauka = CreateTestNaukaKniga();
            Assert.That(nauka.Name, Is.EqualTo("Физика для всех"));
            Assert.That(nauka.Avtors, Is.EquivalentTo(new List<string> { "Фейнман" }));
            Assert.That(nauka.OblastNauki, Is.EqualTo("физика"));
            Assert.That(nauka.Annotaciya, Is.EqualTo("основы физики"));
        }

        [Test]
        public void TestGetInfoNaukaKniga()
        {
            var nauka = CreateTestNaukaKniga();
            var info = nauka.GetInfo();
            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("Физика для всех (авторы: Фейнман)"));
            Assert.That(info[1], Is.EqualTo("год: 1963, издательство: Мир, номер: нк123, статус: на складе, цена: 0 руб."));
            Assert.That(info[2], Is.EqualTo("научная книга. область: физика, аннотация: основы физики"));
        }

        [Test]
        public void TestKonstruktorHudozhKniga()
        {
            var hudozh = CreateTestHudozhKniga();
            Assert.That(hudozh.Name, Is.EqualTo("Война и мир"));
            Assert.That(hudozh.Avtors, Is.EquivalentTo(new List<string> { "Толстой" }));
            Assert.That(hudozh.Zhanr, Is.EqualTo("роман"));
            Assert.That(hudozh.Yazyk, Is.EqualTo("русский"));
            Assert.That(hudozh.Vid, Is.EqualTo(VidProizvedeniya.Proza));
        }

        [Test]
        public void TestGetInfoHudozhKniga()
        {
            var hudozh = CreateTestHudozhKniga();
            var info = hudozh.GetInfo();
            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("Война и мир (авторы: Толстой)"));
            Assert.That(info[1], Is.EqualTo("год: 1869, издательство: Русский вестник, номер: хк789, статус: на складе, цена: 0 руб."));
            Assert.That(info[2], Is.EqualTo("художественная книга. жанр: роман, язык: русский, вид: Proza"));
        }

        [Test]
        public void TestKonstruktorPeriodKniga()
        {
            var period = CreateTestPeriodKniga();
            Assert.That(period.Name, Is.EqualTo("Наука и жизнь"));
            Assert.That(period.Avtors, Is.EquivalentTo(new List<string> { "Редакция" }));
            Assert.That(period.PeriodVyhoda, Is.EqualTo("ежемесячно"));
            Assert.That(period.VidPeriodiki, Is.EqualTo(PeriodType.Journal));
        }

        [Test]
        public void TestGetInfoPeriodKniga()
        {
            var period = CreateTestPeriodKniga();
            var info = period.GetInfo();
            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("Наука и жизнь (авторы: Редакция)"));
            Assert.That(info[1], Is.EqualTo("год: 2023, издательство: Наука, номер: пк321, статус: на складе, цена: 0 руб."));
            Assert.That(info[2], Is.EqualTo("периодическая литература. период выхода: ежемесячно, вид: Journal"));
        }

        private Edition CreateTestKniga()
        {
            return new Edition(
                name: "C# за 5 минут",
                avtors: new List<string> { "Иванов", "Сидоров" },
                year: 2022,
                izdatel: "Питер",
                nomer: "кн456"
            );
        }

        private NaukaKniga CreateTestNaukaKniga()
        {
            return new NaukaKniga(
                name: "Физика для всех",
                avtors: new List<string> { "Фейнман" },
                year: 1963,
                izdatel: "Мир",
                nomer: "нк123",
                oblastNauki: "физика",
                annotaciya: "основы физики"
            );
        }
        private HudozhKniga CreateTestHudozhKniga()
        {
            return new HudozhKniga(
                name: "Война и мир",
                avtors: new List<string> { "Толстой" },
                year: 1869,
                izdatel: "Русский вестник",
                nomer: "хк789",
                zhanr: "роман",
                yazyk: "русский",
                vid: VidProizvedeniya.Proza
            );
        }

        private PeriodKniga CreateTestPeriodKniga()
        {
            return new PeriodKniga(
                name: "Наука и жизнь",
                avtors: new List<string> { "Редакция" },
                year: 2023,
                izdatel: "Наука",
                nomer: "пк321",
                periodVyhoda: "ежемесячно",
                vidPeriodiki: PeriodType.Journal
            );
        }
    }
}