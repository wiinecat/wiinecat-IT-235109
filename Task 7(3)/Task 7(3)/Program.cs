using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Введите позицию белой фигуры (например, e2): ");
            string whitePosition = Console.ReadLine();
            Console.Write("Введите позицию черной фигуры (например, e4): ");
            string blackPosition = Console.ReadLine();

            // Декодируем позиции
            (int wx, int wy) = DecodePosition(whitePosition);
            (int bx, int by) = DecodePosition(blackPosition);

            // Проверяем корректность данных
            if (wx == bx && wy == by)
            {
                Console.WriteLine("Позиции фигур не должны совпадать.");
                return;
            }

            if (IsUnderAttack(wx, wy, bx, by))
            {
                Console.WriteLine("Белая фигура находится под боем черной фигуры.");
                return;
            }

            Console.Write("Введите позицию предполагаемого хода белой фигуры: ");
            string targetPosition = Console.ReadLine();
            (int tx, int ty) = DecodePosition(targetPosition);

            if (CanMove(wx, wy, bx, by, tx, ty))
            {
                Console.WriteLine("Белая фигура может сделать ход на указанную клетку.");
            }
            else
            {
                Console.WriteLine("Белая фигура не может сделать ход на указанную клетку или попадет под бой.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Некорректная позиция.");
        }
    }

    static (int, int) DecodePosition(string position)
    {
        if (position.Length != 2 || !char.IsLetter(position[0]) || !char.IsDigit(position[1]))
        {
            throw new FormatException();
        }

        int x = position[0] - 'a'; 
        int y = position[1] - '1'; 

        return (x, y);
    }

    static bool IsKingMove(int sx, int sy, int ex, int ey)
    {
        return Math.Max(Math.Abs(sx - ex), Math.Abs(sy - ey)) == 1;
    }

    static bool IsKnightMove(int sx, int sy, int ex, int ey)
    {
        return (Math.Abs(sx - ex), Math.Abs(sy - ey)) == (2, 1) || (Math.Abs(sx - ex), Math.Abs(sy - ey)) == (1, 2);
    }

    static bool IsUnderAttack(int wx, int wy, int bx, int by)
    {
        return IsKingMove(bx, by, wx, wy) || IsKnightMove(bx, by, wx, wy);
    }

    static bool CanMove(int wx, int wy, int bx, int by, int tx, int ty)
    {
        if (IsUnderAttack(wx, wy, bx, by))
        {
            return false;
        }

        
        if (IsKingMove(wx, wy, tx, ty) || IsKnightMove(wx, wy, tx, ty))
        {
            return !IsUnderAttack(tx, ty, bx, by);
        }

        return false;
    }
}
