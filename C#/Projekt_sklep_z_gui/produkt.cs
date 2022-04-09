using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp2
{
    public enum Kategorie { Szafa, Łóżko, Stolik, Kanapa }
    public enum Producenci { Alfa, Beta, Gamma }
    public enum Materialy { skóra, dąb, ekoskóra, sosna, olcha }

    [Serializable]
    [XmlInclude(typeof(Szafa))]
    [XmlInclude(typeof(Lozko))]
    [XmlInclude(typeof(Stolik))]
    [XmlInclude(typeof(Kanapa))]
    public abstract class Produkt : IEquatable<Produkt>, ICloneable
    {
        static int numer;
        string produktID;
        Producenci producent;
        string model;
        int cena;
        float wysokosc;
        float szerokosc;
        float glebokosc;
        Materialy material;
      

        public Producenci Producent { get => producent; set => producent = value; }
        public string Model { get => model; set => model = value; }
        public int Cena { get => cena; set => cena = value; }
        public float Wysokosc 
        { 
            get => wysokosc;
            set
            {
                if (value <= 0)
                    throw new ZlyWymiarException("Podaj poprawną wysokość");
                else
                    wysokosc=value;
            } 
        }
        public float Szerokosc 
        {
            get => szerokosc;
            set
            {
                if (value <= 0)
                    throw new ZlyWymiarException("Podaj poprawną szerokość");
                else
                    szerokosc = value;
            }
        }
        public float Glebokosc
        {
            get => glebokosc;
            set
            {
                if (value <= 0)
                    throw new ZlyWymiarException("Podaj poprawną szerokość");
                else
                    glebokosc = value;
            }
        }
        public Materialy Material { get => material; set => material = value; }
    
        public static int Numer { get => numer; set => numer = value; }
        public string ProduktID { get => produktID; set => produktID = value; }

        static Produkt()
        {
            Numer = 100;
        }
        public Produkt()
        {
            ProduktID = $"P{Numer++}";
        }

        public Produkt(Producenci producent, string model, int cena, float wysokosc, float szerokosc, float glebokosc, Materialy material) : this()
        {
            Producent = producent;
            Model = model;
            Cena = cena;
            Wysokosc = wysokosc;
            Szerokosc = szerokosc;
            Glebokosc = glebokosc;
            Material = material;
        }
        public override string ToString()
        {
            return $"Producent: {Producent}, model: {Model}, cena: {Cena}, wymiary(cm): {Wysokosc}Wx{Szerokosc}SZx{Glebokosc}G, materiał: {material}, liczba na stanie";
        }

        public bool Equals(Produkt other)
        {
            return ProduktID.Equals(other.ProduktID);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        public int CompareTo(Produkt other) 
        {
            if (other is null)
                return 1;
            return Cena.CompareTo(other.Cena);
        }
    }
}
