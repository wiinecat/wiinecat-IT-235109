using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("Введите трехзначное число:");
        int number = Convert.ToInt32(Console.ReadLine());


        if (number < 100 || number > 999)
        {
            Console.WriteLine("Ошибка: Введите трехзначное число.");
            return;
        }


        int hundreds = number / 100;
        int tens = (number / 10) % 10;
        int units = number % 10;


        int newNumber = tens * 100 + hundreds * 10 + units;


        Console.WriteLine($"Полученное число после перестановки первой и второй цифр: {newNumber}");


        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}