using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите n ( > 1000): ");
            int n = Convert.ToInt32(Console.ReadLine());
            int razr = 0, result = 0;
            while (n > 0) 
            {
                int digit = n % 10; 
                if (digit % 2 != 0) 
                {
                    
                    result = result + (int)(digit * Math.Pow(10, razr));
                    razr++;
                }
                n = n / 10; 
            }
            Console.WriteLine(result);
            Console.WriteLine("\nНажмите Enter для завершения...");
            Console.ReadKey();
        }
    }
}

