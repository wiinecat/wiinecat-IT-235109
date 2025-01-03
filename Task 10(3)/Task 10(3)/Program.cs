using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            double eps;
            Console.Write("Введите eps: ");
            eps = Convert.ToDouble(Console.ReadLine());
            double aPrev = 1; 
            double a = 2; 
			double chislA = 1, chislB = 2, znamA = 1, znamB = 1; 
            while (Math.Abs(a - aPrev) <= eps) 
            {
                double chislT = chislB;
                chislB = chislA + chislB;
                chislA = chislT;
                double znamT = znamB;
                znamB = znamA + znamB;
                znamA = znamT;
                aPrev = a;
                a = (chislB) / (znamB);
            }
            Console.WriteLine("\nПервый член последовательности, нарушающий правило: " + a);
            Console.WriteLine("\nНажмите Enter для завершения...");
            Console.ReadKey();
        }

    }
}
