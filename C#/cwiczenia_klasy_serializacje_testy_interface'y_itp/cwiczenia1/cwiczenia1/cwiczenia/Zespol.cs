using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace cwiczenia
{
    public interface Izapisywalna
    {
        void ZapiszBin(string fname);
        void ZapiszXml(string fname);

        void ZapiszJson(string fname);

    }
    [Serializable]
    public class Zespol : ICloneable
    {
        int liczbaCzlonkow;
        string nazwa;
        KierownikZespolu kierownik;
        List<CzlonekZespolu> czlonkowie;
        public Zespol()
        {
            liczbaCzlonkow = 0;
            czlonkowie = new List<CzlonekZespolu>();
        }
        public Zespol(string nazwa, KierownikZespolu kierownik) : this()
        {
            this.nazwa = nazwa;
            this.kierownik = kierownik;
        }
        public int LiczbaCzlonkow { get => liczbaCzlonkow; set => liczbaCzlonkow = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        internal KierownikZespolu Kierownik { get => kierownik; set => kierownik = value; }
        public List<CzlonekZespolu> Czlonkowie { get => czlonkowie; set => czlonkowie = value; }

        public void DodajCzlonkaZepsolu(CzlonekZespolu cz)
        {
            ++liczbaCzlonkow;
            czlonkowie.Add(cz);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(nazwa);
            czlonkowie.ForEach(cz => sb.AppendLine(cz.ToString()));
            return sb.ToString();
        }
        public bool JestCzlonkiem(string PESEL)
        {
            for (int i = 0; i < czlonkowie.Count; i++)
            {
                if (czlonkowie[i].Pesel == PESEL)
                    return true;
            }
            return false;
        }
        public bool JestCzlonkiem(string imie, string nazwisko)
        {
            for (int i = 0; i < czlonkowie.Count; i++)
            {
                if (czlonkowie[i].Imie == imie && czlonkowie[i].Nazwisko == nazwisko)
                    return true;
            }
            return false;
        }
        public void Aktualizacja()
        {
            for (int i = 0; i < LiczbaCzlonkow; i++)
            {
                if (czlonkowie[i] == null)
                {
                    for (int j = i; j < LiczbaCzlonkow; j++)
                        czlonkowie[j] = czlonkowie[j + 1];
                }
            }
        }
        public void UsunCzlonka(string PESEL)
        {
            var el = czlonkowie.SingleOrDefault(cz => cz.Pesel == PESEL);
            if (el != null)
            {
                czlonkowie.Remove(el);
                --liczbaCzlonkow;
                Aktualizacja();
            }
            else
                Console.WriteLine("Nie ma czlonka o takim peselu");
        }
        public void UsunCzlonka(string imie, string nazwisko)
        {
            var el = czlonkowie.SingleOrDefault(cz => cz.Imie == imie && cz.Nazwisko == nazwisko);
            if (el != null)
            {
                czlonkowie.Remove(el);
                --liczbaCzlonkow;
                Aktualizacja();
            }
            else
                Console.WriteLine("Nie ma takiego czlonka");
        }
        public void UsunWszystkich()
        {
            czlonkowie.Clear();
            liczbaCzlonkow=0;  
        }
        public List<CzlonekZespolu> WyszukajCzlonkow(string funkcja)
        {
            List<CzlonekZespolu> lista = new List<CzlonekZespolu>();
            foreach (CzlonekZespolu cz in czlonkowie)
            {
                if (cz.Funkcja == funkcja)
                {
                    lista.Add(cz);
                }   
            }
            return lista;
        }
        public List<CzlonekZespolu> WyszukajCzlonkow(int miesiac)
        {
            List<CzlonekZespolu> lista = new List<CzlonekZespolu>();
            foreach (CzlonekZespolu cz in czlonkowie)
            {
                if (cz.DataZapisu.Month == miesiac)
                    lista.Add(cz);
            }
            return lista;
        }

        public object Clone()
        {
            // return MemberwiseClone(); nie zadzaila bo sa obiekty wiec kopiuje ich referenceje
            Zespol z = (Zespol)MemberwiseClone();
            z.Kierownik = Kierownik.Clone() as KierownikZespolu;
            List<CzlonekZespolu> list = new List<CzlonekZespolu>();
            Czlonkowie.ForEach(cz => list.Add(cz.Clone() as CzlonekZespolu));
            z.Czlonkowie = new List<CzlonekZespolu>(list);
            return z;
        }

        public void Sortuj()
        {
            Czlonkowie.Sort();
        }

        public void SortujPoPeselu()
        {

        }

        public void ZapiszBin(string fname)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream FileShare = new FileStream(fname, FileMode.Create))
            {
                bf.Serialize(FileShare, this);
            }
        }

        public void ZapiszXml(string fname) //klasy musza byc public i domyslne konstruktory i pola publiczne/miec metody dostepowe
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
            File.WriteAllText(fname, js.Serialize(this));
        }

        public Zespol DeepClone()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                return bf.Deserialize(ms) as Zespol;
            }
        }

        public static Zespol OdczytajBin(string fname)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (!File.Exists(fname))
                return null;
            using (FileStream fs = new FileStream(fname, FileMode.Open))
            {
                return bf.Deserialize(fs) as Zespol;
            }
        }

        public static Zespol OdcztytajJson(string fname)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (!File.Exists(fname))
                return null;
            return js.Deserialize(File.ReadAllText(fname), typeof(Zespol)) as Zespol;
        }
    }
}