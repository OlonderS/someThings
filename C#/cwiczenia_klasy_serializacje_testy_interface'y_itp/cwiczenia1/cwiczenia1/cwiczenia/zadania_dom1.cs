using System;
using System.Linq;
using System.Threading;

namespace cwiczenia

{
    class Program
    {
        static void Trojkat()
        {
            Console.Write("Podaj rozmiar trojkata: ");
            if (!int.TryParse(Console.ReadLine(), out int r) || r < 2)
            {
                Console.WriteLine("Niepoprawny rozmiar");
                return;
            }
            int[,] tab = new int[r, r];
            tab[0, 0] = tab[1, 0] = tab[1, 1] = 1;
            for (int i = 2; i < r; i++)
            {
                tab[i, 0] = 1;
                for (int j = 1; j <= i; j++)
                {
                    tab[i, j] = tab[i - 1, j - 1] + tab[i - 1, j];
                }
            }
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j <= i; j++)
                    Console.Write(tab[i, j] + " ");
                Console.Write("\n");
            }
        }

        static void Figura()
        {
            Console.Write("Podaj rozmiar figury: ");
            if (!int.TryParse(Console.ReadLine(), out int r) || r < 3 || r % 2 != 1)
            {
                Console.WriteLine("Niepoprawny rozmiar");
                return;
            }
            ///      int[,] tab = new int[r, r];
            for (int j = 1; j <= r; j++)
                Console.Write(" * ");
            Console.Write("\n");
            for (int i = 2; i < r; i++)
            {
                for (int j = 1; j <= r; j++)
                    if (j == 1 || j == i || j == r - i + 1 || j == r)
                        Console.Write(" * ");
                    else
                        Console.Write("   ");
                Console.Write("\n");
            }
            for (int j = 1; j <= r; j++)
                Console.Write(" * ");
            Console.Write("\n");
        }

        static void Kalkulator()
        {

            string[] znaki = { "*", "+", "-", "/" };
            string znak;
            Console.WriteLine("Podaj pierwsza liczbe: ");
            if (!double.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out double x))
            {
                Console.WriteLine("Niepoprawna wartosc");
                return;
            }

            Console.WriteLine("Podaj znak dzialania (+ - * /): ");
            if (!znaki.Contains(znak = Console.ReadLine()))
            {
                Console.WriteLine("Niepoprawny znak");
                return;
            }
            Console.WriteLine("Podaj druga liczbe: ");
            if (!double.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out double y))
            {
                Console.WriteLine("Niepoprawna wartosc");
                return;
            }
            switch (znak)
            {
                case "+":
                    Console.WriteLine("{0, 10}\n{1, 10}\n{2, 10}\n{3, 10}\n{4, 10}", x, '+', y, '=', x + y);
                    break;
                case "-":
                    Console.WriteLine("{0, 10}\n{1, 10}\n{2, 10}\n{3, 10}\n{4, 10}", x, '-', y, '=', x - y);
                    break;
                case "*":
                    Console.WriteLine("{0, 10}\n{1, 10}\n{2, 10}\n{3, 10}\n{4, 10:F6}", x, '*', y, '=', x * y);
                    break;
                case "/":
                    if (y != 0)
                        Console.WriteLine("{0, 10}\n{1, 10}\n{2, 10}\n{3, 10}\n{4, 10:F6}", x, '/', y, '=', x / y);
                    else
                        Console.WriteLine("Dzielenie przez 0");
                    break;
            }
        }

        static void Tablica()
        {
            int min = -100;
            int max = 100;
            int parzyste, nieparzyste, dodatnie, ujemne;
            parzyste = nieparzyste = dodatnie = ujemne = 0;

            Console.WriteLine("Podaj liczbe elementow: ");
            if (!int.TryParse(Console.ReadLine(), out int x) || x < 1)
            {
                Console.WriteLine("Niepoprawne dane");
                return;
            }
            int[] tab = new int[x];
            Random randNum = new Random();
            for (int i = 0; i < x; i++)
            {
                tab[i] = randNum.Next(min, max);
                Console.Write(tab[i] + " ");
                if (tab[i] % 2 == 0)
                    parzyste++;
                else
                    nieparzyste++;
                if (tab[i] > 0)
                    dodatnie++;
                else if (tab[i] < 0)
                    ujemne++;
            }
            Console.WriteLine("\nparzystych: {0}\nnieparzystych: {1}\ndodatnich: {2}\nujemnych: {3}", parzyste, nieparzyste, dodatnie, ujemne);
        }

        static void TablicaZnakow()
        {
            int i = 0;
            string ciag = "";
            string wynik = "";
            Console.WriteLine("Podaj tekst (max 30 znakow): ");

            while (i <= 29)
            {
                char c = Console.ReadKey().KeyChar;
                ciag += c;
                if (c == '\r')
                    break;

                if (char.IsLetter(c))
                    wynik += c;
                ++i;
            }
            if (i == 30)
            {
                Console.WriteLine("\n---MAX 30 ZNAKOW---");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Podany tekst: " + ciag + "\nSame litery: " + wynik);
        }

        static int CyfraRek(int x)
        {
            if (x % 10 == 3)
            {
                Console.WriteLine("Liczba ma cyfre 3");
                return 0;
            }
            else if (x == 0)
            {
                Console.WriteLine("Liczba nie ma cyfry 3");
                return 0;
            }
            else
                return CyfraRek(x / 10);
        }

        static void Main()
        {
            //Trojkat();
            //Figura();
            //Kalkulator();
            //Tablica();
            //TablicaZnakow();
            //CyfraRek(12345);
        }
    }
}