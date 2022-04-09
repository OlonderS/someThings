using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw1n
{
    class Cwiczenia1N
    {
static Func<dynamic> ZwrocJeden = () => 1;
        static Func<dynamic, dynamic> DodajJeden = (a) => a + 1;
        static double Kwadrat(double x) => x * x;

        private delegate int Obliczenia(int a, int b);
        static int Dodaj(int a, int b) { return a + b; }
        static int Wymnoz(int a, int b) { return a * b; }
        static void Oblicz()
        {
            Obliczenia dodawacz = Dodaj;
            Console.WriteLine("Wynik: " + dodawacz(2, 4)); // Wynik: 6
            Obliczenia mnoz = Wymnoz;
            Console.WriteLine("Wynik: " + mnoz(2, 4)); // Wynik: 6
        }
        static void ObliczI()
        {
            Obliczenia dodawacz = delegate (int a, int b) {
                return a + b;
            };
            Console.WriteLine("Wynik: " + dodawacz(2, 4)); // Wynik: 6 
        }
        static void TestFinally()
        {
            int i = 123;
            string s = "Jakiś napis"; object obj = s;

            try
            {
                // Próba konwersji napisu na typ int.
                i = (int)obj;
            }
            finally
            {
                Console.WriteLine("\nWykonanie bloku finally po nieobsłużonym wyjątku");
                Console.WriteLine("i = {0}", i);
            }

        }
        private delegate float Funkcja(float x);
        static float Calka(Funkcja f, int n)
        {
            float a = 2.0f, b = 4.0f;
            float h = (b - a) / n, w = 0, x0 = a;
            for(int i = 0; i < n; ++i)
            {
                w += f(h * x0); x0 += h;
            }
            return w;
        }

        //static float fun1(float x) => (x * x);
        static void ObliczCalke()
        {
            Funkcja fun1 = delegate (float x) { return x * x; };
            Console.WriteLine($"{Calka(fun1, 100)}");
        }
        public static void Zad1Figura(int n)
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
        public static void TestZada1Figura()
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
        public static void Zad2Liczby()
        {
            Console.Write("Podaj n:");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Niepoprawne dane.");
                return;
            }
            int s = 0, amax = 0, amin = 0;
            for (int i = 0; i < n; ++i)
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
    }
}
