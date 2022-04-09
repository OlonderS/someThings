using System;
using System.Collections.Generic;


namespace cwiczenia
{
    class Program
    {
        static void Main()
        {
            /* Osoba os = new Osoba("Jan", "Kowalkski");
             try
             {
                 os.Pesel = "11111111111";
             }
             catch (FormatException)
             {
                 Console.WriteLine("Pesel niepoprawny");
             }
             
            Osoba os1 = new Osoba("Beata", "Nowak", "ul. Szeroka 21", "Kraków", 30345, "1992-10-22", "92102201347", (Plcie)0);
            Osoba os1 = new Osoba("BeAta", "nowAk", "ul. Szeroka 21", "Kraków", 30345, "1992-10-22", "92102285245", (Plcie)0, "111222333");
            os1.Litery();
            Console.WriteLine(os1.ToString());
            os1.CzyPesel(os1.Pesel);
            os1.Godziny("01:00:00");*/
            //CzlonekZespolu cz = new CzlonekZespolu("Jan", "Kowalski");
            KierownikZespolu kierownik = new KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90090142412", (Plcie)0, 5);
            Zespol zespol = new Zespol("Zespol", kierownik);
            CzlonekZespolu cz1 = new CzlonekZespolu("witold", "Adamski", "1990-22-10", "92102266738", (Plcie)1, "01-sty-20", "sekretarz");
            CzlonekZespolu cz2 = new CzlonekZespolu("Jan", "Janowski", "1992-03-15", "92031532652", (Plcie)1, "01-sty-20", "programista");
            CzlonekZespolu cz3 = new CzlonekZespolu("Jan", "But", "1992-05-16", "92051613915", (Plcie)1, "01-cze-19", "programista");
            CzlonekZespolu cz4 = new CzlonekZespolu("Beata", "Nowak", "1993-11-22", "93112225923", (Plcie)0, "01-sty-20", "projektant");
            CzlonekZespolu cz5 = new CzlonekZespolu("Anna", "Mysza", "1991-07-22", "91072235964", (Plcie)0, "31-lip-19", "projektant");
            zespol.DodajCzlonkaZepsolu(cz1);
            zespol.DodajCzlonkaZepsolu(cz2);
            zespol.DodajCzlonkaZepsolu(cz3);
            zespol.DodajCzlonkaZepsolu(cz4);
            zespol.DodajCzlonkaZepsolu(cz5);
            Console.WriteLine(kierownik.ToString());
            Console.WriteLine(cz1.ToString());
            Console.WriteLine(cz2.ToString());
            Console.WriteLine(cz3.ToString());
            Console.WriteLine(cz4.ToString());
            Console.WriteLine(cz5.ToString());
            //Console.WriteLine(zespol.JestCzlonkiem("92102266738"));
            //Console.WriteLine(zespol.JestCzlonkiem("Jan", "Jan"));
            //Console.WriteLine(zespol.LiczbaCzlonkow);
            //Console.WriteLine(zespol);
            //zespol.UsunCzlonka("92102266738");
            //zespol.UsunCzlonka("Jan", "Jan");
            //Console.WriteLine(zespol.LiczbaCzlonkow);
            //zespol.WyszukajCzlonkow("programista").ForEach(os => Console.WriteLine(os));
            //zespol.WyszukajCzlonkow(1).ForEach(os => Console.WriteLine(os));
            //zespol.UsunWszystkich();
            //Console.WriteLine(zespol.LiczbaCzlonkow);

            // dalsze zadania 
            KierownikZespolu kkopia = (KierownikZespolu)kierownik.Clone();
            kkopia.Imie = "Jan";
            Console.WriteLine(kkopia);

            Zespol zkopia = zespol.Clone() as Zespol; /// to samo co (Zespol)zespol.Clone();
            zkopia.Kierownik.Imie = "Roman";
            Console.WriteLine("Po kopii zespolu");
            Console.WriteLine(zkopia);

            zespol.ZapiszBin("tobin.bin");
            Console.WriteLine("po deserializacji");
            Zespol zkopiabin = Zespol.OdczytajBin("tobin.bin");
            if (zkopiabin is object)
            {
                Console.WriteLine(zkopiabin.ToString());
            }
            zespol.ZapiszXml("toxml.xml");
            zespol.ZapiszJson("tojson");

        }
    }
}