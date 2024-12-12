using System;

namespace ForCSharp
{
    class Program
    {
        static bool CheckCondition(double x, double y)
        {
            return (x >= 2) || (y >= 0.5 && y <= 1.5);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты точки: ");
            Console.Write(" x = ");
            double x = double.Parse(Console.ReadLine());
            Console.Write(" y = ");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Результат проверки");
            if (CheckCondition(x, y))
            {
                Console.WriteLine("Точка принадлежит области");
            }
            else
            {
                Console.WriteLine("Точка не принадлежит области");
            }
        }
    }
}

