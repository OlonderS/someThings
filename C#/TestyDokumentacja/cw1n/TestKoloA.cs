using System;
using System.Linq;

namespace TestKoloA
{
    class Pojemnik
    {
        string nazwa;
        int[] elementy;

        public string Nazwa { get => nazwa; }
        public int[] Elementy { get => elementy; set => elementy = value; }

        public Pojemnik(string nazwa, int n)
        {
            this.nazwa = nazwa;
            elementy = new int[n];
        }
        public void Losuj(DateTime dur)
        {
            Random r = new Random();
            int M = dur.Day * dur.Month;
            for (int i = 1, n = elementy.Length; i < n; ++i)
            {
                elementy[i] = r.Next(-M, M + 1);
            }
        }
        public int Max()
        {
            return elementy.Max();
        }

        public override string ToString()
        {
            string s = $"{nazwa} [Max={Max()}]";
            Array.ForEach(elementy, el => s += $" {el}");
            return s;
        }
        public static void Test()
        { 
            DateTime dur = new DateTime(1966, 02, 27);
            Pojemnik pojemnik = new Pojemnik("Pudełko", 10);
            pojemnik.Losuj(dur);
            Console.WriteLine(pojemnik);
        }
    }
}
