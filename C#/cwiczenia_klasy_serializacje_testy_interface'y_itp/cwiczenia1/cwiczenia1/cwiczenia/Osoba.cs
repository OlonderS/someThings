using System;
using System.Globalization;

namespace cwiczenia
{
    public enum Plcie { K, M }
    [Serializable]
    public abstract class Osoba : IEquatable<Osoba>
    {
        string imie;
        string nazwisko;
        string ulica;
        string miasto;
        int kodPocztowy;
        DateTime dataUrodzenia;
        string pesel;
        Plcie plec;
        string nrTel;

        public string Nazwisko { get; set; }
        public string Imie { get { return imie; } set { imie = value; } }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public string Pesel
        {
            get => pesel;
            set
            {
                if (value.Length != 11)
                {
                    throw new FormatException("Pesel niepoprawny");
                }
                pesel = value;
            }
        }
        public string NrTel //d4
        {
            get => nrTel;
            set
            {
                if (value.Length != 9 || !int.TryParse(value, out int _))
                {
                    throw new FormatException("Numer niepoprawny");
                }
                nrTel = value;
            }
        }
        public Osoba()
        {
            pesel = "00000000000";
        }
        public Osoba(string imie, string nazwisko)
        {
            this.imie = imie;
            this.Nazwisko = nazwisko;
        }
        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec) : this(imie, nazwisko) // uzywa poprzedniego konstrukotra z tej samej klasy
        {
            DateTime.TryParseExact(dataUrodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out this.dataUrodzenia);
            this.pesel = pesel;
            this.plec = plec;
        }
        public Osoba(string imie, string nazwisko, string ulica, string miasto, int kodPocztowy, string dataUrodzenia, string pesel, Plcie plec) : this(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            this.ulica = ulica;
            this.miasto = miasto;
            this.kodPocztowy = kodPocztowy;
        }
        public Osoba(string imie, string nazwisko, string ulica, string miasto, int kodPocztowy, string dataUrodzenia, string pesel, Plcie plec, string nrTel) : this(imie, nazwisko, ulica, miasto, kodPocztowy, dataUrodzenia, pesel, plec) //d5
        {
            this.nrTel = nrTel;
        }
        public int Wiek()
        {
            return DateTime.Now.Year - dataUrodzenia.Year;
        }
        public void Litery() //d1
        {
            imie = char.ToUpper(imie[0]) + imie.Substring(1).ToLower();
            Nazwisko = char.ToUpper(Nazwisko[0]) + Nazwisko.Substring(1).ToLower();
        }
        public void Godziny(string godzina) //d2
        {
            DateTime dt = DateTime.Parse(godzina);
            TimeSpan span = DateTime.Now.AddHours(dt.Hour).Subtract(dataUrodzenia);
            Console.WriteLine($"Godzin zycia: {(int)span.TotalHours}");
        }
        public bool CzyPesel(string pesel) //d3
        {
            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            bool wynik = false;
            if (pesel.Length == 11)
            {
                int suma = 0;
                for (int i = 0; i < pesel.Length - 1; i++)
                {
                    suma += wagi[i] * int.Parse(pesel[i].ToString());
                }
                int numer = suma % 10;
                numer = 10 - numer;
                if (numer == 10)
                {
                    numer = 0;
                }
                int cyfra = int.Parse(pesel[pesel.Length - 1].ToString());
                if (numer == cyfra)
                {
                    wynik = true;
                    Console.WriteLine("Pesel poprawny");
                }
                else
                {
                    Console.WriteLine("Pesel niepoprawny");
                }
            }
            return wynik;
        }
        public override string ToString() //d6
        {

            return $"Pesel: {pesel} Imie: {imie} Naziwsko: {Nazwisko} ({Wiek()} lat) Plec: {plec}";//Miasto: {miasto}\nKod pocztowy: {kodPocztowy.ToString().Insert(2, "-")}\nNumer telefonu: {nrTel}";
        }
        public bool Equals(Osoba other)
        {
            return Pesel.Equals(other.Pesel);
        }
    }

}

