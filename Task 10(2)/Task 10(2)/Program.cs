using System;

namespace _2
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
            Console.Write("Введите a1: ");
            double aPrev = Convert.ToDouble(Console.ReadLine());
            double ak, maxDif = 0;
            for (int k = 2; k <= n; k++)
            {
                Console.Write($"Введите a{k}: ");
                ak = Convert.ToDouble(Console.ReadLine());
                double dif = Math.Abs(ak - aPrev); 
                if (dif > maxDif)
                    maxDif = dif;
                aPrev = ak; 
            }
            Console.WriteLine("\nНаибольший модуль разности: " + maxDif);
            Console.WriteLine("\nНажмите Enter для завершения...");
            Console.ReadKey();
        }
    }
}


