using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите первое число: ");
            double t = Convert.ToDouble(Console.ReadLine()); 
            double sum = 0;
            while (t != 0)
            {
                if (t > a)
                    sum += t; 
                Console.Write("Введите новое число или 0 для завершения: ");
                t = Convert.ToDouble(Console.ReadLine()); 
            }
            Console.WriteLine($"\nСумма чисел > {a}: {sum}");
            Console.WriteLine("\nНажмите Enter для завершения...");
            Console.ReadKey();
        }
    }
}
