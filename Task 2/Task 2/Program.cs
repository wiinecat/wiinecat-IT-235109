using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("Введите координаты центра квадрата (x, y):");
        Console.Write("x: ");
        double centerX = Convert.ToDouble(Console.ReadLine());
        Console.Write("y: ");
        double centerY = Convert.ToDouble(Console.ReadLine());


        Console.WriteLine("Введите координаты одной из вершин квадрата (x, y):");
        Console.Write("x: ");
        double vertexX = Convert.ToDouble(Console.ReadLine());
        Console.Write("y: ");
        double vertexY = Convert.ToDouble(Console.ReadLine());


        double sideLength = Math.Abs(vertexX - centerX) * Math.Sqrt(2);


        double area = sideLength * sideLength;
        double perimeter = 4 * sideLength;


        Console.WriteLine($"\nПлощадь квадрата: {area}");
        Console.WriteLine($"Периметр квадрата: {perimeter}");


        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
