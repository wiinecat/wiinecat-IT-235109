using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите значение x:");
        if (double.TryParse(Console.ReadLine(), out double x))
        {
            double result = CalculateFunction(x);
            Console.WriteLine($"f({x}) = {result}");
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
        }
    }

    
    static double CalculateFunction(double x)
    {
        if (x > 0)
        {
            return Math.Exp(-x); 
        }
        else if (x > -1)
        {
            return 1; 
        }
        else
        {
            return Math.Exp(x) + 1; 
        }
    }
}
