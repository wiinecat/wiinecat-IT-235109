using System;

namespace ForCSharp
{
    class Program
    {
        static bool CheckCondition(int k, int m, int n)
        {
            return (k > 0) && (m > 0) && (n > 0) &&
                (k % 2 == 0 || m % 2 == 0 || n % 2 == 0);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите три числа: ");
            Console.Write(" k = ");
            int k = int.Parse(Console.ReadLine());
            Console.Write(" m = ");
            int m = int.Parse(Console.ReadLine());
            Console.Write(" n = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Результат проверки");
            Console.WriteLine("Все три числа положительные и есть чётное: " + CheckCondition(k, m, n));
        }
    }
}

