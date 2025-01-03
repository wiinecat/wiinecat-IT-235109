using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            while (n <= 0)
            {
                Console.Write("\nНекорректное значение! Введите n (n > 0): ");
                n = Convert.ToInt32(Console.ReadLine());
            }
            double h = Math.PI / (double)n; 
            Console.WriteLine("|  x  |  f(x)  |");
            for (double x = 0; x <= 2 * Math.PI; x += h) 
            {
                double fx = Math.Sin(x); 
                Console.WriteLine($" {x:0.00} | {fx:0.00}");
            }

            Console.WriteLine("Нажмите Enter для завершения...");
            Console.ReadKey();
        }
    }
}
