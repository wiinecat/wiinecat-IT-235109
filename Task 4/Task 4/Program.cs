using System;

namespace Task_4
{
    internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите значение х");
        var x = double.Parse(Console.ReadLine());

        var y = MyFunction(x);
        Console.WriteLine("f(x) = " + y);

        Console.ReadKey();
    }
    static double MyFunction(double x)

    {
            //throw new NotImplementedException();
            double numerator = Math.Abs(x + 1) - Math.Abs(x - 1);
            double denominator = Math.Abs(x);

            return numerator / denominator;





        }
    }
}


