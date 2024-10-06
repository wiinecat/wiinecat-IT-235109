using System;

class Program
{
    static void Main()
    {

        ConsoleColor originalColor = Console.ForegroundColor;


        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("И скучно и грустно…");


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("И скучно и грустно, и некому руку подать\n" +
                          "В минуту душевной невзгоды…\n" +
                          "Желанья!.. Что пользы напрасно и вечно желать?..\n" +
                          "А годы проходят — все лучшие годы!\n" +
                          "Любить… Но кого же?.. На время — не стоит труда,\n" +
                          "А вечно любить невозможно.\n" +
                          "В себя ли заглянешь? — там прошлого нет и следа:\n" +
                          "И радость, и муки, и всё там ничтожно…\n" +
                          "Что страсти? — ведь рано иль поздно их сладкий недуг\n" +
                          "Исчезнет при слове рассудка;\n" +
                          "И жизнь, как посмотришь с холодным вниманьем вокруг, –\n" +
                          "Такая пустая и глупая шутка…");


        Console.ForegroundColor = originalColor;


        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();


    }
}

