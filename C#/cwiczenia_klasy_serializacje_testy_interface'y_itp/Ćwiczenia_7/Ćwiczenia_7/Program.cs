//Magdalena Raczkiewicz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ćwiczenia_7
{
    [Serializable]
    public enum Plcie { K, M } // enum: K=0, M=1
    class Program
    {
        static void Main(string[] args)
        {
            //tworzenie
            CzlonekZespolu os3 = new CzlonekZespolu("Beata", "Nowak", "1992-10-22", "92102201346", Plcie.K, "projektant");
            CzlonekZespolu os4 = new CzlonekZespolu("Jan", "Kowalski", "1992-03-15", "92031507771", Plcie.M, "programista");
            CzlonekZespolu os5 = new CzlonekZespolu("Arnold", "Kowalski", "1992-03-15", "92031507771", Plcie.M, "programista");
            KierownikZespolu kr1 = new KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90070100210", Plcie.M, 5);

            //klonowanie
            os5 = (CzlonekZespolu)os4.Clone();
            os5.Imie = "Humbert Humbert";
            KierownikZespolu kr2 = (KierownikZespolu)kr1.Clone();
            kr2.Imie = "Marek";

            ZespolLista grupa = new ZespolLista("Grupa IT", kr1);
            grupa.DodajCzlonka(os3);
            grupa.DodajCzlonka(os4);
            grupa.DodajCzlonka(os5);

            Console.WriteLine("Czy Beata Nowak jest czlonkiem? " + grupa.JestCzlonkiem("Beata", "Nowak"));

            //kopiowanie
            ZespolLista nowaGrupa = (ZespolLista)grupa.DeepCopy();
            nowaGrupa.Nazwa = "NowaGrupa";
            nowaGrupa.Kierownik.Imie = "Rafał";
            nowaGrupa.Kierownik.Nazwisko = "Marzec";
            nowaGrupa.Kierownik.DataUrodzenia = new DateTime(1988, 03, 21);
            nowaGrupa.Kierownik.PESEL = "88032112353";  //88032112357 - niepoprawna suma kontrolna

            //kopiaZesp1.Czlonkowie.ElementAt(0).Imie = "Kasia";
            Console.WriteLine(grupa);
            Console.WriteLine(nowaGrupa);

            //sortowanie
            grupa.Sortuj();
            Console.WriteLine(grupa);
            grupa.SortujPoPESEL();
            Console.WriteLine(grupa);

            //porownanie
            Console.WriteLine("Porownanie dwoch osob: " + os4.Equals(os5));
            Console.WriteLine("Jest czlonkiem? " + grupa.JestCzlonkiem(os4));
            Console.WriteLine("Zespol Equals(): " + grupa.Equals(nowaGrupa));
            Console.WriteLine();

            //-----------Cwiczenia 7------------

            //zapis i odczyt BIN
            Console.WriteLine("Zapis do pliku BIN...");
            grupa.ZapiszBIN("grupaBIN.txt");
            Console.WriteLine("Odczyt...");
            ZespolLista odczytanaBIN = (ZespolLista)grupa.OdczytajBIN("grupaBIN.txt");
            Console.WriteLine(odczytanaBIN);
            
            //zapis i odczyt XML
            Console.WriteLine("Zapis do pliku XML...");
            ZespolLista.ZapiszXML("grupaXML", grupa);
            Console.WriteLine("Odczyt...");
            ZespolLista.OdczytajXML("grupaXML");
            

            //zapis i odczyt JSON
            Console.WriteLine("Zapis do pliku JSON...");
            ZespolLista.ZapiszJSON("grupaJSON", grupa);
            Console.WriteLine("Odczyt...");
            ZespolLista odczytanaJSON = ZespolLista.OdczytajJSON("grupaJSON");
            Console.WriteLine(odczytanaJSON);

            Console.ReadKey();
        }
    }
}
