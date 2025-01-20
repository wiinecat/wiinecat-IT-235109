using System;
using System.Linq; 

class Program
{
    static void Main()
    {
        string originalWord = "пирамида";

        
        string dima = new string(originalWord.Substring(5, 2).Reverse().ToArray()) +
                      new string(originalWord.Substring(3, 2).Reverse().ToArray());

        string iraida = originalWord.Substring(1, 3) + originalWord.Substring(5, 3);

        Console.WriteLine($"Полученные имена: {dima}, {iraida}");
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}


