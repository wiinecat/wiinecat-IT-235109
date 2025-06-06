namespace Task16
{
    public struct Food
    {
        private int weight;
        private float calorie;

        public int Weight
        {
            get { return weight; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Вес продукта должен быть положительным числом.");
                weight = value;
            }
        }

        public float Calorie
        {
            get { return calorie; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Калорийность продукта должна быть положительным числом.");
                calorie = (float)Math.Round(value, 1);
            }
        }

        public float Value
        {
            get { return (Weight * Calorie) / 100f; }
        }

        public Food(int weight, float calorie)
        {
            this.weight = weight;
            this.calorie = (float)Math.Round(calorie, 1);
        }

        public override string ToString()
        {
            return $"{Weight} г калорийности {Calorie} Ккал/100 г";
        }

        public override bool Equals(object obj)
        {
            if (obj is Food)
            {
                Food other = (Food)obj;
                return Weight == other.Weight && Calorie == other.Calorie;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                const int p = 23;
                hash = hash * p + Weight.GetHashCode();
                hash = hash * p + Calorie.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Food x, Food y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Food x, Food y)
        {
            return !x.Equals(y);
        }

        public static Food operator +(Food x, Food y)
        {
            if (x.Calorie != y.Calorie)
                throw new ArgumentException("Нельзя складывать продукты с разной калорийностью.");
            return new Food(x.Weight + y.Weight, x.Calorie);
        }

        public static Food operator -(Food x, Food y)
        {
            if (x.Calorie != y.Calorie)
                throw new ArgumentException("Нельзя вычитать продукты с разной калорийностью.");
            if (x.Weight < y.Weight)
                throw new ArgumentException("Нельзя вычитать продукт с большим весом.");
            return new Food(x.Weight - y.Weight, x.Calorie);
        }

        public static Food operator *(Food food, double k)
        {
            return new Food((int)Math.Round(food.Weight * k), food.Calorie);
        }

        public static Food operator *(double k, Food food)
        {
            return food * k;
        }
    }
}
