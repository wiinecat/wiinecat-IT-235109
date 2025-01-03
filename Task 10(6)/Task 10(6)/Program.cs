using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= a; y++)
                {
                    for (int z = 1; z <= a; z++)
                    {
                        if (x * x + y * y == z * z)
                        {
                            Console.WriteLine($"\nx = {x}, y = {y}, z = {z}");
                            Console.WriteLine($"{x * x} + {y * y} = {z * z}");
                        }

                    }
                }
            }
            Console.WriteLine("\nНажмите Enter для завершения...");
            Console.ReadKey();
        }
    }
}