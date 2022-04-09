using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SysLinq = System.Linq;

namespace cw1n
{
    class Program
    {
        static void TestZespolu()
        {
            CzlonekZespolu cz1 =
                new CzlonekZespolu("Adam", "Nowak", "09-07-1993",
                "93070902837", Plcie.M, "programista");
            CzlonekZespolu cz2 =
                new CzlonekZespolu("Witold", "Adamski", "24-12-1999",
                "99122422072", Plcie.M, "projektant");
            KierownikZespolu kier =
                new KierownikZespolu("Zuzanna", "Muzyk", "13-03-2003",
                "03231348567", Plcie.K, 10);
            Zespol z = new Zespol("ULTRAVOX", kier);
            z.DodajCzlonkaZespolu(cz1);
            z.DodajCzlonkaZespolu(cz2);
            z.DodajCzlonkaZespolu(
                new CzlonekZespolu("Beata", "Nowak", "29-09-1988",
                "88092973866", Plcie.K, "projektant"));
            Console.WriteLine(z);
            z.UsunCzlonkaZespolu("92102266731");
            Console.WriteLine(z);
            List<CzlonekZespolu> fz = z.WyszukajFunkcje("projektant");
            fz.ForEach(cz => Console.WriteLine(cz));
            z.SortujCzlonkowZespolu();
            Console.WriteLine("------------------------------");
            Console.WriteLine(z);
            CzlonekZespolu cz1kopia = cz1.Clone() as CzlonekZespolu;
            z.SortujPoPESEL();
            Console.WriteLine(z);
            z.DodajCzlonkaZespolu(new CzlonekZespolu("Ewa", "Misiak", "27-12-2002", "02122789053", Plcie.K, "sekretarz"));
            z.DodajCzlonkaZespolu(new CzlonekZespolu("Katarzyna", "Słowik", "19-08-1999", "99081911098", Plcie.K, "programista"));
            z.DodajCzlonkaZespolu(new CzlonekZespolu("Ludwik", "Mielcarz", "01-12-1983", "83120123318", Plcie.M, "technik"));
            z.ZapiszBIN("test_zapisu.bin");
            //Zespol zz = Zespol.OdczytBIN("test_zapisu.bin");
            //Console.WriteLine("Po odczycie");
            Console.WriteLine(z);
            //z.ZapiszJson("zespoj.json");
            //Zespol zzz = z.KopiaGleboka();
            //Console.WriteLine("Kopia głęboka");
            //Console.WriteLine(zzz);
            z.ZapiszXML("zespol.xml");
        }
        
        static void Main()
        {
            TestZespolu();
        }
    }
}
