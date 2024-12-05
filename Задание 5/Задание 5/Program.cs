using System;

class Program
{
    static void Main(string[] args)
    {
       
        double x = CalculateX(4);

        
        Console.WriteLine($"Значение x: {x:F3}");
    }

   
    static double CalculateX(int n)
    {
        
        double result = n;

        
        for (int i = n - 1; i >= 1; i--)
        {
            result = Math.Sin(i + result);
        }

        return result;
    }
}
