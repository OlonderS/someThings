using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1n
{
    enum EnumWydawca { Helion, Miniatura, Marabut, Kwadratura, Rosikon, Prodoks, Springer }
    class Abonent
    {
        string imie;
        string nazwisko;
        string numerTelefonu;
        public string NumerTelefonu
        {
            get => numerTelefonu;
            set
            {
                if (!SprawdzNumer(value))
                {
                    throw new NiepoprawnyNumerException("Numer nie jest poprawny");
                }
                numerTelefonu = value;
            }
        }
        public string Miasto { get; }

        public Abonent(string imie, string nazwisko, string miasto)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            Miasto = miasto;
        }
        bool SprawdzNumer(string numer)
        {
            return new Regex(@"^\d{3}(-\d{3}){2}$").IsMatch(numer);
        }
        public override string ToString()
        {
            return $"{imie} {nazwisko}, {Miasto}: {numerTelefonu}";
        }
    }
    class KsiazkaTest
    {
        static long index;
        string tytul;
        protected string isbn;
        DateTime dataWydania;
        EnumWydawca wydawnictwo;

        static KsiazkaTest()
        {
            index = 1;
        }
        public KsiazkaTest(string tytul, string dataWydania, EnumWydawca wydawnictwo)
        {
            this.tytul = tytul;
            DateTime.TryParseExact(dataWydania, new string[] { "dd-MM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out this.dataWydania);
            this.wydawnictwo = wydawnictwo;
            isbn = $"ISBN-{this.dataWydania:yy-dd}-{this.dataWydania.Month}-{index++}";
        }
        public override string ToString()
        {
            return $"{isbn}: {tytul} ({wydawnictwo})";
        }
    }
    class KsiazkaTelefonicznaTest : KsiazkaTest
    {
        Dictionary<string, Abonent> abonenci;
        public KsiazkaTelefonicznaTest(string tytul, string dataWydania, EnumWydawca wydawnictwo) : base(tytul, dataWydania, wydawnictwo)
        {
            isbn += "-KT";
            abonenci = new Dictionary<string, Abonent>();
        }
        public void DodajAbonenta(Abonent abonent)
        {
            if (abonenci.ContainsKey(abonent.NumerTelefonu))
            {
                throw new BrakAbonentaException("Podany numer istnieje w książce.");
            }
            abonenci.Add(abonent.NumerTelefonu, abonent);
        }
        public void UsunAbonenta(string numer)
        {
            abonenci.Remove(numer);
        }
        public List<Abonent> WyszukajAbonentow(string miasto)
        {
            return abonenci.Values.ToList().FindAll(abonent => abonent.Miasto.Equals(miasto));
        }
        public override string ToString()
        {
            string s = base.ToString(), ss = "";
            foreach (Abonent ab in abonenci.Values)
            {
                ss = $"{ss}\n{ab}";
            }
            return s + ss;
        }
    }
    class BrakAbonentaException : Exception
    {
        public BrakAbonentaException() : base() { }
        public BrakAbonentaException(string msg) : base(msg) { }
    }
    class NiepoprawnyNumerException : Exception
    {
        public NiepoprawnyNumerException() : base() { }
        public NiepoprawnyNumerException(string msg) : base(msg) { }
    }
}
