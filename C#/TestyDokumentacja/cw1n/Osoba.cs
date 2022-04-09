using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cw1n
{
    public class BlednyPeselException : Exception
    {
        public BlednyPeselException() : base() { }
        public BlednyPeselException(string msg) : base(msg) { }
    }
    public enum Plcie { K, M }
    [Serializable]
    public abstract class Osoba : IEquatable<Osoba>
    {
        string imie;
        string nazwisko;
        DateTime dataUrodzenia;
        string pESEL;
        Plcie plec;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public Plcie Plec { get => plec; set => plec = value; }

        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        [XmlAttribute]
        public string PESEL { get => pESEL;
            set
            {
                if (!SprawdzPesel(value))
                {
                    throw new BlednyPeselException("Niepoprawny numer PESEL");
                }
                pESEL = value;
            }
        }

        public Osoba()
        {
            pESEL = new string('0', 11);
        }
        public Osoba(string imie, string nazwisko) : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }
        protected Osoba(string imie, string nazwisko, string dataUrodzenia, string pESEL, Plcie plec) : this(imie, nazwisko)
        {
            DateTime.TryParseExact(dataUrodzenia,
                new string[] { "dd-MM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out this.dataUrodzenia);
            this.Plec = plec;
            PESEL = pESEL;
        }
        public int Wiek()
        {
            int w = (int)((DateTime.Now - DataUrodzenia).TotalDays / 365.0);
            return Math.Max(w, 0);
        }
        public bool SprawdzPesel(string s)
        {
            return Regex.IsMatch(pESEL, @"\d{11}");
        }
        public override string ToString()
        {
            return $"{imie} {nazwisko} (ur. {DataUrodzenia:dd/MM/yyyy}, w: {Wiek()}), PESEL: {PESEL}";
        }

        public bool Equals(Osoba other)
        {
            return PESEL.Equals(other.PESEL);
        }
    }
}
