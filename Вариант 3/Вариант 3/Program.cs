using System;
using System.Collections.Generic;

class Program
{
   
    static List<int> Eratosthenes(int n)
    {
        bool[] sieve = new bool[n + 1];
        List<int> primes = new List<int>();

       
        for (int i = 2; i <= n; i++)
            sieve[i] = true;

        
        for (int i = 2; i * i <= n; i++)
        {
            if (sieve[i])
            {
                for (int j = i * i; j <= n; j += i)
                {
                    sieve[j] = false;
                }
            }
        }

        
        for (int i = 2; i <= n; i++)
        {
            if (sieve[i])
            {
                primes.Add(i);
            }
        }

        return primes;
    }

    
    static int FindMinimalNumber(int limit)
    {
        List<int> primes = Eratosthenes(limit);

        
        for (int n = 9; n <= limit; n += 2)
        {
            bool found = false;

            
            if (primes.Contains(n))
                continue;

           
            foreach (int p in primes)
            {
                if (p >= n) break;

                
                int remainder = n - p;
                if (remainder % 2 == 0)
                {
                    int squareCandidate = remainder / 2;
                    int sqrt = (int)Math.Sqrt(squareCandidate);
                    if (sqrt * sqrt == squareCandidate)
                    {
                        found = true;
                        break;
                    }
                }
            }

            
            if (!found)
                return n;
        }

        return -1; 
    }

    static void Main()
    {
        int limit = 10000; 
        int result = FindMinimalNumber(limit);

        if (result != -1)
            Console.WriteLine($"Минимальное число, которое не представимо как сумма простого числа и удвоенного квадрата: {result}");
        else
            Console.WriteLine("Такого числа не найдено в заданном диапазоне.");

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    
}
