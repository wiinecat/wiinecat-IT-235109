using NUnit.Framework;
using Task16;

namespace FoodStructTests
{
    [TestFixture]
    public class FoodTests
    {
        [Test]
        public void Constructor_ValidValues_Success()
        {
            Food food = new Food(250, 280.5f);
            Assert.That(food.Weight, Is.EqualTo(250));
            Assert.That(food.Calorie, Is.EqualTo(280.5f));
            Assert.That(food.Value, Is.EqualTo(701.25f));
        }

        [Test]
        public void Weight_NegativeValue_ThrowsArgumentException()
        {
            Food food = new Food();
            Assert.That(() => food.Weight = -100, Throws.ArgumentException);
        }

        [Test]
        public void Calorie_NegativeValue_ThrowsArgumentException()
        {
            Food food = new Food();
            Assert.That(() => food.Calorie = -50.0f, Throws.ArgumentException);
        }

        [Test]
        public void ToString_ValidFood_CorrectString()
        {
            Food food = new Food(250, 280.5f);
            Assert.That(food.ToString(), Is.EqualTo("250 г калорийности 280,5  кал/100 г"));
        }

        [Test]
        public void Equals_SameFood_True()
        {
            Food food1 = new Food(250, 280.5f);
            Food food2 = new Food(250, 280.5f);
            Assert.That(food1.Equals(food2), Is.True);
            Assert.That(food1 == food2, Is.True);
        }

        [Test]
        public void Equals_DifferentFood_False()
        {
            Food food1 = new Food(250, 280.5f);
            Food food2 = new Food(300, 280.5f);
            Assert.That(food1.Equals(food2), Is.False);
            Assert.That(food1 == food2, Is.False);
        }

        [Test]
        public void GetHashCode_SameFood_SameHashCode()
        {
            Food food1 = new Food(250, 280.5f);
            Food food2 = new Food(250, 280.5f);
            Assert.That(food1.GetHashCode(), Is.EqualTo(food2.GetHashCode()));
        }

        [Test]
        public void Addition_SameCalorie_Success()
        {
            Food food1 = new Food(250, 280.5f);
            Food food2 = new Food(300, 280.5f);
            Food result = food1 + food2;
            Assert.That(result.Weight, Is.EqualTo(550));
            Assert.That(result.Calorie, Is.EqualTo(280.5f));
        }

        [Test]
        public void Addition_DifferentCalorie_ThrowsArgumentException()
        {
            Food food1 = new Food(250, 280.5f);
            Food food2 = new Food(300, 300.0f);
            Assert.That(() => food1 + food2, Throws.ArgumentException);
        }

        [Test]
        public void Subtraction_SameCalorie_Success()
        {
            Food food1 = new Food(500, 280.5f);
            Food food2 = new Food(300, 280.5f);
            Food result = food1 - food2;
            Assert.That(result.Weight, Is.EqualTo(200));
            Assert.That(result.Calorie, Is.EqualTo(280.5f));
        }

        [Test]
        public void Subtraction_DifferentCalorie_ThrowsArgumentException()
        {
            Food food1 = new Food(500, 280.5f);
            Food food2 = new Food(300, 300.0f);
            Assert.That(() => food1 - food2, Throws.ArgumentException);
        }

        [Test]
        public void Subtraction_LargerWeight_ThrowsArgumentException()
        {
            Food food1 = new Food(250, 280.5f);
            Food food2 = new Food(300, 280.5f);
            Assert.That(() => food1 - food2, Throws.ArgumentException);
        }

        [Test]
        public void Multiplication_Success()
        {
            Food food = new Food(250, 280.5f);
            Food result = food * 2.5f;
            Assert.That(result.Weight, Is.EqualTo(625));
            Assert.That(result.Calorie, Is.EqualTo(280.5f));
        }
    }
}
