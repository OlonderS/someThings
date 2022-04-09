using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
//JSON
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

namespace Ćwiczenia_7
{
    [DataContract]
    [Serializable]
    class ZespolLista : ICloneable, IEquatable<ZespolLista>, IZapisywalna
    {
        public class PESELComparator : IComparer<CzlonekZespolu>
        {
            public int Compare(CzlonekZespolu a, CzlonekZespolu b)
            {
                return (new CaseInsensitiveComparer()).Compare(a, b);
            }
        }
        [DataMember]
        private int liczbaCzlonkow;
        [DataMember]
        private string nazwa;
        [DataMember]
        KierownikZespolu kierownik;
        [DataMember]
        List<CzlonekZespolu> czlonkowie;

        public int LiczbaCzlonkow
        {
            get
            {
                return liczbaCzlonkow;
            }

            set
            {
                liczbaCzlonkow = value;
            }
        }
        public string Nazwa
        {
            get
            {
                return nazwa;
            }

            set
            {
                nazwa = value;
            }
        }
        internal KierownikZespolu Kierownik
        {
            get
            {
                return kierownik;
            }

            set
            {
                kierownik = value;
            }
        }
        internal List<CzlonekZespolu> Czlonkowie
        {
            get
            {
                return czlonkowie;
            }

            set
            {
                czlonkowie = value;
            }
        }

        public ZespolLista()
        {
            Nazwa = null;
            Kierownik = null;
            LiczbaCzlonkow = 0;
            this.Czlonkowie = new List<CzlonekZespolu>();
        }
        public ZespolLista(string n, KierownikZespolu k) : this()
        {
            Nazwa = n;
            Kierownik = k;
        }

        public void DodajCzlonka(CzlonekZespolu c)
        {
            Czlonkowie.Add(c);
            LiczbaCzlonkow++;
        }

        public bool JestCzlonkiem(string PESEL)
        {
            for (int i = 0; i < LiczbaCzlonkow; i++)
            {
                if (Czlonkowie[i].PESEL == PESEL)
                {
                    return true;
                }
            }
            return false;
        }
        public bool JestCzlonkiem(string imie, string nazwisko)
        {
            for (int i = 0; i < LiczbaCzlonkow; i++)
            {
                if (Czlonkowie[i].Imie == imie && Czlonkowie[i].Nazwisko == nazwisko)
                {
                    return true;
                }
            }
            return false;
        }
        public void UsunCzlonka(string PESEL)
        {
            for (int i = 0; i < LiczbaCzlonkow; i++)
            {
                if (Czlonkowie[i].PESEL == PESEL)
                {
                    Czlonkowie[i] = null;
                    LiczbaCzlonkow--;
                    CzyscTablice();
                }
            }
        }
        public void UsunCzlonka(string imie, string nazwisko)
        {
            for (int i = 0; i < LiczbaCzlonkow; i++)
            {
                if (Czlonkowie[i].Imie == imie && Czlonkowie[i].Nazwisko == nazwisko)
                {
                    Czlonkowie[i] = null;
                    LiczbaCzlonkow--;
                    CzyscTablice();
                }
            }
        }
        public void UsunWszystkich()
        {
            for (int i = 0; i < LiczbaCzlonkow; i++)
            {
                Czlonkowie[i] = null;
            }
            LiczbaCzlonkow = 0;
        }
        public CzlonekZespolu[] WyszukajFunkcje(string funkcja)
        {
            CzlonekZespolu[] tmp = new CzlonekZespolu[liczbaCzlonkow];

            for (int i = 0, j = 0; i < LiczbaCzlonkow; i++)
            {
                if (Czlonkowie[i].Funkcja == funkcja)
                {
                    tmp[j] = Czlonkowie[i];
                    j++;
                }
            }
            return tmp;
        }
        public void CzyscTablice()
        {
            for (int i = 0; i < LiczbaCzlonkow; i++)
            {
                if (Czlonkowie[i] == null)
                {
                    for (int j = i; j < LiczbaCzlonkow; j++)
                    {
                        Czlonkowie[j] = Czlonkowie[j + 1];
                    }
                }
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nZespol : " + Nazwa);
            sb.AppendLine("Kierownik : " + kierownik.ToString());

            for (int i = 0; i < LiczbaCzlonkow; i++) //zamienic na foreach
            {
                if (Czlonkowie.ElementAt(i) != null)
                {
                    sb.AppendLine(Czlonkowie.ElementAt(i).ToString());
                }
            }
            return sb.ToString();
        }

        //-------------------------------------
        public object Clone()
        {
            return (ZespolLista)this.MemberwiseClone();
        }
        public ZespolLista DeepCopy()
        {
            ZespolLista kopia = (ZespolLista)this.Clone();
            kopia.Kierownik = (KierownikZespolu)Kierownik.Clone();
            //kopia.czlonkowie = new List<CzlonekZespolu>(this.czlonkowie.Select(x => (CzlonekZespolu)x.Clone())); // predykatem

            kopia.czlonkowie = new List<CzlonekZespolu>(); //foreachem
            kopia.LiczbaCzlonkow = 0;

            foreach (CzlonekZespolu c in this.czlonkowie)
            {
                CzlonekZespolu cz = (CzlonekZespolu)c.Clone();
                kopia.DodajCzlonka(cz);
            }
            return kopia;
        }
        public void Sortuj()
        {
            czlonkowie.Sort();
        }
        public void SortujPoPESEL()
        {
            PESELComparator mComp = new PESELComparator();
            czlonkowie.Sort(mComp);
        }
        public bool JestCzlonkiem(CzlonekZespolu c)
        {
            foreach (CzlonekZespolu o in this.czlonkowie)
            {
                if (o.Equals(c))
                {
                    return true;
                }
            }
            return false;
        }
        public bool Equals(ZespolLista z)
        {
            if (this.nazwa == z.nazwa && this.kierownik.PESEL == z.kierownik.PESEL && this.liczbaCzlonkow == z.liczbaCzlonkow)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //-------------------------------------
        public static ZespolLista DeepCopy(ZespolLista z)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, z);
                stream.Position = 0;
                ZespolLista z1 = (ZespolLista)formatter.Deserialize(stream);
                stream.Close();
                return z1;
            }
        }

        //BIN
        public void ZapiszBIN(string nazwa)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nazwa, FileMode.Create);
            formatter.Serialize(stream, this); //odwoluje sie do obiektu po 
            stream.Close();
        }
        public Object OdczytajBIN(string nazwa)
        {
            try
            {
                FileStream fstream = new FileStream(nazwa, FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();
                ZespolLista z = (ZespolLista)bformatter.Deserialize(fstream);
                fstream.Close();
                return z;
            }
            catch(FileNotFoundException)
            {
                //SystemSounds.Excamation.Play();
                Console.WriteLine("Plik nie istnieje!");
                //return 0;
            }
            return null;
        }

        //XML
        public static void ZapiszXML(string nazwa, ZespolLista z)
        {
            DataContractSerializer s = new DataContractSerializer(typeof(ZespolLista));
            using (FileStream fs = File.Open("test" + typeof(ZespolLista).Name + ".xml", FileMode.Create))
            {
                Console.WriteLine("Testing for type: {0}", typeof(ZespolLista));
                s.WriteObject(fs, nazwa);
            }
        }
        public static ZespolLista OdczytajXML(string nazwa)
        {
            try
            {
                XmlTextReader textReader = new XmlTextReader(nazwa);
                ZespolLista nowyZespol = new ZespolLista();

                using (StringReader stringReader = new StringReader(nazwa))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(ZespolLista));
                    return null;//(ZespolLista)serializer.Deserialize(stringReader);
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Plik nie istnieje!");
            }
            return null;
        }

        //JSON
        public static void ZapiszJSON(string nazwa, ZespolLista z)
        {
            DataContractSerializer jsonSerialize = new DataContractSerializer(typeof(ZespolLista));
            using (var fstream = File.Create(nazwa))
            {
                jsonSerialize.WriteObject(fstream, z);
            }
        }
        public static ZespolLista OdczytajJSON(string nazwa)
        {
            try
            {
                FileStream fstream = new FileStream(nazwa, FileMode.Open);
                DataContractSerializer jsonSerialize = new DataContractSerializer(typeof(ZespolLista));
                fstream.Position = 0;
                ZespolLista z = (ZespolLista)jsonSerialize.ReadObject(fstream);
                fstream.Close();
                return z;
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Plik nie istnieje!");
            }
            return null;
        }
    }
}

