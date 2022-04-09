using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace cw1n
{
    interface IZapisywalna
    {
        void ZapiszBIN(string filename);
    }
    public class PESELCOmparator : IComparer<CzlonekZespolu>
    {
        public int Compare(CzlonekZespolu x, CzlonekZespolu y)
        {
            return x.PESEL.CompareTo(y.PESEL);
        }
    }
    #region CzlonekZespolu
    [Serializable]
    public class CzlonekZespolu : Osoba, IComparable<CzlonekZespolu>,
        ICloneable
    {
        string funkcja;
        public string Funkcja { get => funkcja; set => funkcja = value; }
        public CzlonekZespolu() : base() { }
        public CzlonekZespolu(string imie, string nazwisko, string funkcja) 
            : base(imie, nazwisko)
        {
            Funkcja = funkcja;
        }
        public CzlonekZespolu(string imie, string nazwisko, string dataUrodzenia,
            string pESEL, Plcie plec, string funkcja)
            : base(imie, nazwisko, dataUrodzenia, pESEL, plec)
        {
            Funkcja = funkcja;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {funkcja}";
        }

        public int CompareTo(CzlonekZespolu other)
        {
            if (other is null) { return 1; }
            int w = Nazwisko.CompareTo(other.Nazwisko);
            if (w!= 0) { return  w; }
            return Imie.CompareTo(other.Imie);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    #endregion

    #region KierownikZespolu
    [Serializable]
    public class KierownikZespolu : Osoba, ICloneable
    {
        int doswiadczenie;
        public int Doswiadczenie { get => doswiadczenie; set => doswiadczenie = value; }

        public KierownikZespolu() : base() { }
        public KierownikZespolu(string imie, string nazwisko, int doswiadczenie)
            : base(imie, nazwisko)
        {
            this.Doswiadczenie = doswiadczenie;
        }
        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia,
            string pESEL, Plcie plec, int doswiadczenie)
            : base(imie, nazwisko, dataUrodzenia, pESEL, plec)
        {
            this.Doswiadczenie = doswiadczenie;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {Doswiadczenie}";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    #endregion

    #region Zespol
    [Serializable]
    public class Zespol : ICloneable, IZapisywalna
    {
        string nazwa;
        KierownikZespolu kierownik;
        List<CzlonekZespolu> czlonkowie;

        public KierownikZespolu Kierownik { get => kierownik; set => kierownik = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        public List<CzlonekZespolu> Czlonkowie { get => czlonkowie; set => czlonkowie = value; }
        public Zespol()
        {
            czlonkowie = new List<CzlonekZespolu>();
        }

        public Zespol(string nazwa, KierownikZespolu kierownik)
            : this()
        {
            this.nazwa = nazwa;
            this.kierownik = kierownik;
        }

        public Zespol KopiaGleboka()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using(MemoryStream ms  = new MemoryStream())
            {
                bf.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                return (Zespol)bf.Deserialize(ms);
            }
        }

        public void DodajCzlonkaZespolu(CzlonekZespolu cz)
        {
            if (cz is null) { return; }
            Czlonkowie.Add(cz);
        }
        public bool JestCzlonkiemZespolu(string pesel)
        {
            return Czlonkowie.Where(cz => cz.PESEL.Equals(pesel)).Any();
        }
        public bool JestCzlonkiemZespolu(string imie, string nazwisko)
        {
            return Czlonkowie.Where(cz => cz.Imie.Equals(imie) &&
                cz.Nazwisko.Equals(nazwisko)).Any();
        }
        public bool JestCzlonkiemZespolu(CzlonekZespolu cz)
        {
            return czlonkowie.Where(c => c.Equals(cz)).Any();
        }
        public void UsunCzlonkaZespolu(string pesel)
        {
            CzlonekZespolu cz = Czlonkowie.FirstOrDefault(czl => czl.PESEL.Equals(pesel));
            Czlonkowie.Remove(cz);
        } 
        public void UsunWszystkich()
        {
            Czlonkowie.Clear();
        }
        public List<CzlonekZespolu> WyszukajFunkcje(string funkcja)
        {
            return Czlonkowie.FindAll(cz => (!string.IsNullOrEmpty(cz.Funkcja)) &&  cz.Funkcja.Equals(funkcja));
        }
        public void SortujCzlonkowZespolu()
        {
            Czlonkowie.Sort();
            //czlonkowie.Sort((x, y) => x.Nazwisko.CompareTo(y.Nazwisko));
        }
        public void SortujPoPESEL()
        {
            Czlonkowie.Sort(new PESELCOmparator());
            //czlonkowie.Sort((x, y) => x.PESEL.CompareTo(y.PESEL));
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Zespół: {nazwa}");
            sb.AppendLine($"Kierownik: {kierownik}");
            sb.AppendLine("Członkowie zespołu:");
            czlonkowie.ForEach(cz => sb.AppendLine(cz.ToString()));
            return sb.ToString();
        }

        public object Clone()
        {
            Zespol kopia = MemberwiseClone() as Zespol;
            kopia.kierownik = kierownik.Clone() as KierownikZespolu;
            kopia.Czlonkowie = new List<CzlonekZespolu>();
            Czlonkowie.ForEach(cz => kopia.DodajCzlonkaZespolu(cz.Clone() as CzlonekZespolu));
            return kopia;
        }
        public static Zespol OdczytBIN(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (!File.Exists(filename)) { return null; }
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                return bf.Deserialize(fs) as Zespol;
            }
        }
        public void ZapiszBIN(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using(FileStream fs = new FileStream(filename,FileMode.Create))
            {
                bf.Serialize(fs, this);
            }
        }
        public void ZapiszXML(string fname)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Zespol));
            using (StreamWriter sw = new StreamWriter(fname))
            {
                xs.Serialize(sw, this);
            }
        }
        public void ZapiszJson(string fname)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jss = js.Serialize(this);
            File.WriteAllText(fname, jss);
        }
    }
    #endregion
}
