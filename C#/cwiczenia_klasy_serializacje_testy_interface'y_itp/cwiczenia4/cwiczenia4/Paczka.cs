using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia4
{
    public class Paczka
    {
        string nadawca;
        int rozmiar;
        string numerPaczki;
        static int aktualnyNumer;
        static float oplataZaKg;

        public string Nadawca { get => nadawca; set => nadawca = value; }
        public int Rozmiar { get => rozmiar; set => rozmiar = value; }
        public string NumerPaczki { get => numerPaczki; set => numerPaczki = value; }
        public static float OplataZaKg { get => Paczka.oplataZaKg; set => Paczka.oplataZaKg = value; }
        public static int AktualnyNumer { get => aktualnyNumer; set => aktualnyNumer = value; }

        static Paczka()
        {
            aktualnyNumer = 100;
            oplataZaKg = 5.0f;
        }
        public Paczka()
        {
            numerPaczki = $"P/{aktualnyNumer++}/{DateTime.Now.Year}";
        }
        public Paczka(string nadawca, int rozmiar):this()
        {
            this.nadawca = nadawca;
            this.rozmiar = rozmiar;

        }
        public virtual float KosztWysylki()
        {
            return OplataZaKg * Rozmiar;
        }
        public override string ToString()
        {
            return $"Nadawca: {nadawca} rozmiar: {rozmiar} numer: {NumerPaczki} koszt wysylki: {KosztWysylki():c}";
        }
    }
}