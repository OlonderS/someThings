using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace WpfApp2
{
    public class CenaComparator : Comparer<Zakup>
    {
        public override int Compare(Zakup x, Zakup y)
        {
            return x.ObliczCene().CompareTo(y.ObliczCene());
        }
    }

    public static class Klient
    {
        public static List<Zakup> listaZakupow = new List<Zakup>(); 
        public static float kwota = 0;

        static void DodajDoListy(Produkt produkt, int liczba = 1) 
        {
            listaZakupow.Add(new Zakup(produkt, liczba));
            kwota += produkt.Cena * liczba;
        }

        public static void UsunZListy(Zakup zakup)
        {
            listaZakupow.Remove(zakup);
        }

        public static void ZmienIlosc(Zakup z, int liczba)
        {
            z.ilosc = liczba;
        }

        public static float WartoscZakupow() 
        {
            int suma = 0;
            listaZakupow.ForEach(x => suma += (x.ilosc) * x.produkt.Cena);
            return suma;
        }

        public static void SortujPoCenie()
        {
            listaZakupow.Sort(new CenaComparator());
        }

        public static string WyswietlListe()
        {
            StringBuilder sb = new StringBuilder();
            listaZakupow.ForEach(x => sb.Append(x.ToString()));
            return sb.ToString();
        }
    }
}





