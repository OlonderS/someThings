using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia5
{
    class Program
    {
        static void TestKsiazkaTelefoniczna()
        {
            try
            {
                Abonent ab = new Abonent("Jan", "Kowalski", "512-734-126", "Warszawa");
                Console.WriteLine(ab);
                Abonent ab2 = new Abonent("Marcin", "Nowak", "624-634-711", "Krakow");
                Console.WriteLine(ab2);
                Ksiazka ks  = new Ksiazka("173 Azory", "2020-12-04", ENumWydawcy.Miniatura);
                ks.ZmienNaRzymskie(11);
                Console.WriteLine(ks);
                Ksiazka ks2 = new Ksiazka("Jas i malgosia", "2010-3-4", ENumWydawcy.Helion);
                Console.WriteLine(ks2);
                KsiazkaTelefoniczna ksTel = new KsiazkaTelefoniczna("teleksiazka", "2021-11-26", ENumWydawcy.Helion);
                Console.WriteLine(ksTel);
                ksTel.DodajAbonenta(ab);
                ksTel.DodajAbonenta(ab2);
                List<Abonent> szukaj = ksTel.WyszukajAbonentow("Warszawa");
                Console.WriteLine("Abonenci z Warszawy:");
                szukaj.ForEach(a => Console.WriteLine(a));
                Console.WriteLine(ksTel);
            }
            catch (BlednyNumerException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            TestKsiazkaTelefoniczna();
        }
    }
}
