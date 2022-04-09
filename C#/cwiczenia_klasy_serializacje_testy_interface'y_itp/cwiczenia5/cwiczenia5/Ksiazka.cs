using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cwiczenia5
{
    enum ENumWydawcy
    { Helion, Miniatura, Marabut, Kwadratura, Rosikon, Prodoks, Springer }
    class Ksiazka
    {
        static long indeks;
        string tytul;
        DateTime dataWydania;
        ENumWydawcy wydawca;
        protected string isbn;

        public static long Indeks { get => indeks; set => indeks = value; }
        public string Tytul { get => tytul; set => tytul = value; }
        public DateTime DataWydania { get => dataWydania; set => dataWydania = value; }
        internal ENumWydawcy Wydawca { get => wydawca; set => wydawca = value;}



        public Ksiazka(string tytul, string dataWydania, ENumWydawcy wydawca)
        {
            Tytul = tytul;
            DateTime.TryParseExact(dataWydania, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yyyy", "yyyy-M-d" }, null, System.Globalization.DateTimeStyles.None, out this.dataWydania);
            Wydawca = wydawca;
            isbn = $"ISBN-{ DataWydania.ToString("yyyy-MM-dd")}-{indeks++}"; //najpierw wypisze potem zwiekszy wiec indeksy od 1
        }

        public override string ToString()
        {
            return $"{isbn}: \"{Tytul}\", {Wydawca} (data: {DataWydania.ToString("MMM-yyyy")})";
        }
        public static string NaRzymskie(int n)
        {
            Dictionary<int, string> Rzymskie = new Dictionary<int, string>
            {
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
            };
            var Rzymskie2 = new StringBuilder();

            foreach (var i in Rzymskie)
            {
                while (n >= i.Key)
                {
                    Rzymskie2.Append(i.Value);
                    n -= i.Key;
                }
            }
            return Rzymskie2.ToString();
        }

        public string ZmienNaRzymskie(int miesiac)
        {
            int i = 9; //stala pozycja - przed miesiacem
            int x = isbn.Substring(i + 1, 3).IndexOf("-");
            string n = isbn.Substring(i + 1, x);
            isbn = isbn.Substring(0, i + 1) + NaRzymskie(int.Parse(n)) + isbn.Substring(i + 1 + x);
            return isbn;
        }

    }
}
