using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public  class Szafa : Produkt
    {
        Kategorie kategoria;
        int liczbaDrzwi;
        bool rozsuwana;
        public int LiczbaDrzwi { get => liczbaDrzwi; set => liczbaDrzwi = value; }
        public bool Rozsuwana { get => rozsuwana; set => rozsuwana = value; }
        public Kategorie Kategoria { get => kategoria; set => kategoria = value; }

        public Szafa()
        {
            Kategoria = Kategorie.Szafa;
        }

        public Szafa(Producenci producent, string model, int cena, float wysokosc, float szerokosc, float glebokosc, Materialy material,  int liczbaDrzwi, bool rozsuwana) : base(producent, model, cena, wysokosc, szerokosc, glebokosc, material )
        {
            LiczbaDrzwi = liczbaDrzwi;
            Rozsuwana = rozsuwana;
            Kategoria = Kategorie.Szafa;
        }
        public override string ToString()
        {
            return $"Kategoria: {Kategoria}, " + base.ToString() + $", Liczba drzwi: {LiczbaDrzwi}, Rozsuwana: {Rozsuwana}";
        }
    }
    public class Lozko : Produkt
    {
        bool materac;
        Kategorie kategoria;
        public Kategorie Kategoria { get => kategoria; set => kategoria = value; }
        public bool Materac { get => materac; set => materac = value; }
        public Lozko()
        {
            Kategoria = Kategorie.Łóżko;
        }

        public Lozko(Producenci producent, string model, int cena, float wysokosc, float szerokosc, float glebokosc, Materialy material,  bool materac) : base(producent, model, cena, wysokosc, szerokosc, glebokosc, material)
        {
            Materac = materac;
            Kategoria = Kategorie.Łóżko;
        }

        public override string ToString()
        {
            return $"Kategoria: {Kategoria}, " + base.ToString() + $", Materac: {Materac}";
        }
    }
    public enum Ksztalty { prostokątny, okrągły }

    public class Stolik : Produkt
    {
        Ksztalty ksztalt;
        Kategorie kategoria;
        public Kategorie Kategoria { get => kategoria; set => kategoria = value; }
        public Ksztalty Ksztalt { get => ksztalt; set => ksztalt = value; }

        public Stolik()
        {
            Kategoria = Kategorie.Stolik;
        }

        public Stolik(Producenci producent, string model, int cena, float wysokosc, float szerokosc, float glebokosc, Materialy material, Ksztalty ksztalt) : base(producent, model, cena, wysokosc, szerokosc, glebokosc, material)
        {
            Ksztalt = ksztalt;
            Kategoria = Kategorie.Stolik;
        }
        public override string ToString()
        {
            return $"Kategoria: {Kategoria}, " + base.ToString() + $", Kształt: {Ksztalt}";
        }
    }

    public enum TypKanapy { Rogowa, Standardowa }

    public class Kanapa : Produkt
    {
        bool rozkladana;
        TypKanapy typKanapy;
        Kategorie kategoria;
        public Kategorie Kategoria { get => kategoria; set => kategoria = value; }
        public bool Rozkladana { get => rozkladana; set => rozkladana = value; }
        public TypKanapy TypKanapy { get => typKanapy; set => typKanapy = value; }
        public Kanapa()
        {
            Kategoria = Kategorie.Kanapa;
        }

        public Kanapa(Producenci producent, string model, int cena, float wysokosc, float szerokosc, float glebokosc, Materialy material, bool rozkladana, TypKanapy typKanapy) : base(producent, model, cena, wysokosc, szerokosc, glebokosc, material)
        {
            this.Rozkladana = rozkladana;
            this.TypKanapy = typKanapy;
            Kategoria = Kategorie.Kanapa;
        }

        public override string ToString()
        {
            return $"Kategoria: {Kategoria}, " + base.ToString() + $", Typ: {TypKanapy}, Rozkładana: {Rozkladana}";
        }

    }

}
