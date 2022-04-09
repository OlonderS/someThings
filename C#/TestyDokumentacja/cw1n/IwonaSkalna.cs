using System;
using System.Linq;

namespace cw1n
{
    class Program
    {
        static void Zad1Figura(int n)
        {
            string s = string.Concat(Enumerable.Repeat("* ", n));
            Console.WriteLine(s);
            for (int i = 1; i < n - 1; ++i)
            {
                for (int j = 0; j < n; 
                    Console.Write((j == 0 || j == i || j == n - i - 1 || j == n - 1) ? "* " : "  "), ++j) ;
                Console.WriteLine();
            }
            Console.WriteLine(s);
        }
        static void TestZada1Figura()
        {
            //int n = 7;
            Console.Write("Podaj wielkość figury (n>=3, nieparzyste): ");
            if (int.TryParse(Console.ReadLine(), out int n) && n % 2 != 0
                && n >= 3)
            {
                Zad1Figura(n);
            }
            else
            {
                Console.WriteLine("Niepoprawne dane.");
            }
        }
        static void Zad2Liczby()
        {
            Console.Write("Podaj n:");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Niepoprawne dane.");
                return;
            }
            int s = 0, amax = 0, amin = 0;
            for(int i = 0; i < n; ++i)
            {
                Console.Write($"Podaj liczbę [{i + 1}]: ");
                if (int.TryParse(Console.ReadLine(), out int a))
                {
                    if (i == 0)
                    {
                        amin = a; amax = a;
                    }
                    else
                    {
                        if (a < amin) { amin = a; }
                        if (a > amax) { amax = a; }
                    }
                    s += a;
                }
                else
                {
                    --i;
                }
            }
            Console.WriteLine($"suma = {s}\nmax = {amax}\nmin = {amin}");
        }
        static void Main(string[] args)
        {
            //Console.WriteLine($"Dziś jest {DateTime.Now:MMM-yyyy}");
            TestZada1Figura();
            //Zad2Liczby();
            Console.ReadKey();
        }
    }
}
