using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia4
{
    class Program
    {
        static void Main()
        {
            //paczki
            Paczka nadawcaA = new Paczka("Jan Kowalski", 3);
            Paczka nadawcaB = new Paczka("Adam Kowalski", 4);
            Paczka nadawcaC = new Paczka("Janina Kowalska", 5);
            PaczkaPolecona nadawcaD = new PaczkaPolecona("Kamila Kowal", 2);
            PaczkaSpecjalna nadawcaE = new PaczkaSpecjalna("Michal Kichal", 6, "21-11-2021");
            //stos
            MagazynLIFO mStos = new MagazynLIFO("mStos");
            mStos.Umiesc(nadawcaA);
            mStos.Umiesc(nadawcaB);
            mStos.Umiesc(nadawcaC);
            mStos.Umiesc(nadawcaD);
            mStos.Umiesc(nadawcaE);
            Console.WriteLine(mStos);
            Console.WriteLine($"Suma oplat za przesylki: {mStos.SumaOplat():c}\n");
            Console.WriteLine($"Liczba przesylek powyzej ustalonej kwoty: {mStos.WysylkaPowyzejKwoty(20)}\n");
            Console.WriteLine(mStos.PodajBiezacy() + "\n");
            mStos.Pobierz();
            Console.WriteLine(mStos.PodajIlosc() + "\n");
            Console.WriteLine(mStos);
            mStos.Wyczysc();
            Console.WriteLine(mStos.PodajIlosc() + "\n");
            //kolejka
            MagazynFIFO mKolejka = new MagazynFIFO("mKolejka");
            mKolejka.Umiesc(nadawcaA);
            mKolejka.Umiesc(nadawcaB);
            mKolejka.Umiesc(nadawcaC);
            mKolejka.Umiesc(nadawcaD);
            mKolejka.Umiesc(nadawcaE);
            Console.WriteLine(mKolejka);
            Console.WriteLine(mKolejka.PodajBiezacy() + "\n");
            mKolejka.Pobierz();
            Console.WriteLine(mKolejka.PodajIlosc() + "\n");
            Console.WriteLine(mKolejka);
            mKolejka.Wyczysc();
            Console.WriteLine(mKolejka.PodajIlosc() + "\n");
            //lista wiazana
            MagazynList mWiazana = new MagazynList("mWiazana");
            mWiazana.Umiesc(nadawcaA);
            mWiazana.Umiesc(nadawcaB);
            mWiazana.Umiesc(nadawcaC);
            mWiazana.Umiesc(nadawcaD);
            mWiazana.Umiesc(nadawcaE);
            Console.WriteLine(mWiazana);
            Console.WriteLine(mWiazana.PodajBiezacy() + "\n");
            mWiazana.Pobierz();
            Console.WriteLine(mWiazana.PodajIlosc() + "\n");
            Console.WriteLine(mWiazana);
            mWiazana.Wyczysc();
            Console.WriteLine(mWiazana.PodajIlosc() + "\n");
            //lista tablicowa
            MagazynList mTablicowa = new MagazynList("mTablicowa");
            mTablicowa.Umiesc(nadawcaA);
            mTablicowa.Umiesc(nadawcaB);
            mTablicowa.Umiesc(nadawcaC);
            mTablicowa.Umiesc(nadawcaD);
            mTablicowa.Umiesc(nadawcaE);
            Console.WriteLine(mTablicowa);
            Console.WriteLine(mTablicowa.PodajBiezacy() + "\n");
            mTablicowa.Pobierz();
            Console.WriteLine(mTablicowa.PodajIlosc() + "\n");
            Console.WriteLine(mTablicowa);
            mTablicowa.Wyczysc();
            Console.WriteLine(mTablicowa.PodajIlosc() + "\n");

            ArrayList ar = new ArrayList();
            ar.Add(10);
            ar.Add(3.4);
            ar.Add("b");
            ar.Add(3);
            foreach (object i in ar)
            {
                Console.WriteLine("liczba int");
            }
        }
    }
}
