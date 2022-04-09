using System;
using System.Globalization;

namespace cwiczenia
{
    [Serializable]
    public class KierownikZespolu : Osoba, ICloneable
    {
        int doswiadczenie;
        public KierownikZespolu()
        { }
        public KierownikZespolu(string imie, string nazwisko) : base(imie, nazwisko) { }
        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec, int doswiadczenie)
            : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            this.doswiadczenie = doswiadczenie;
        }
        public override string ToString()
        {

            return $"{base.ToString()}\nDoświadczenie: {doswiadczenie}lat";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    [Serializable]
    public class CzlonekZespolu : Osoba, ICloneable, IComparable<CzlonekZespolu>
    {
        DateTime dataZapisu;
        string funkcja;

        public CzlonekZespolu() { }
        public CzlonekZespolu(string imie, string nazwisko) : base(imie, nazwisko) { }
        public CzlonekZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec, string dataZapisu, string funkcja)
            : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            DateTime.TryParseExact(dataZapisu, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out this.dataZapisu);
            this.funkcja = funkcja;
        }
        public string Funkcja { get => funkcja; set => funkcja = value; }
        public DateTime DataZapisu { get => dataZapisu; set => dataZapisu = value; }
        public override string ToString()
        {
            return $"{base.ToString()}\nData zapisu: {dataZapisu.ToString("dd-MMM-yyyy")} funckja: {funkcja}";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public int CompareTo(CzlonekZespolu other)
        {
            int p = Nazwisko.CompareTo(other.Nazwisko);
            if (p != 0)
                return p;
            return Imie.CompareTo(other.Imie);
        }
    }
}
