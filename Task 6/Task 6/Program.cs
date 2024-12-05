using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    
    private static readonly Dictionary<char, string> translitMap = new Dictionary<char, string>
    {
        {'А', "A"}, {'Б', "B"}, {'В', "V"}, {'Г', "G"}, {'Д', "D"},
        {'Е', "E"}, {'Ё', "E"}, {'Ж', "Zh"}, {'З', "Z"}, {'И', "I"},
        {'Й', "I"}, {'К', "K"}, {'Л', "L"}, {'М', "M"}, {'Н', "N"},
        {'О', "O"}, {'П', "P"}, {'Р', "R"}, {'С', "S"}, {'Т', "T"},
        {'У', "U"}, {'Ф', "F"}, {'Х', "Kh"}, {'Ц', "Ts"}, {'Ч', "Ch"},
        {'Ш', "Sh"}, {'Щ', "Shch"}, {'Ъ', "Ie"}, {'Ы', "Y"}, {'Ь', ""},
        {'Э', "E"}, {'Ю', "Iu"}, {'Я', "Ya"},
        {'а', "a"}, {'б', "b"}, {'в', "v"}, {'г', "g"}, {'д', "d"},
        {'е', "e"}, {'ё', "e"}, {'ж', "zh"}, {'з', "z"}, {'и', "i"},
        {'й', "i"}, {'к', "k"}, {'л', "l"}, {'м', "m"}, {'н', "n"},
        {'о', "o"}, {'п', "p"}, {'р', "r"}, {'с', "s"}, {'т', "t"},
        {'у', "u"}, {'ф', "f"}, {'х', "kh"}, {'ц', "ts"}, {'ч', "ch"},
        {'ш', "sh"}, {'щ', "shch"}, {'ъ', "ie"}, {'ы', "y"}, {'ь', ""},
        {'э', "e"}, {'ю', "iu"}, {'я', "ya"}
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст на русском языке:");
        string input = Console.ReadLine();

        string transliteratedText = Transliterate(input);

        Console.WriteLine("Транслитерация:");
        Console.WriteLine(transliteratedText);
    }

    
    static string Transliterate(string text)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in text)
        {
            if (translitMap.TryGetValue(c, out string transliteratedChar))
            {
                result.Append(transliteratedChar);
            }
            else
            {
                
                result.Append(c);
            }
        }

        return result.ToString();
    }
}
