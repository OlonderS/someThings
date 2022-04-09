using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia4
{
    class MagazynLIFO : IMagazynuje
    {
        string nazwa;
        int iloscPaczek;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }
        public Stack<Paczka> StosPaczek { get; set; }

        public MagazynLIFO()
        {
            StosPaczek = new Stack<Paczka>();
            iloscPaczek = 0;
        }
        public MagazynLIFO(String nazwa) : this()
        {
            this.nazwa = nazwa;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"nazwa: \"{nazwa}\" liczba paczek: {iloscPaczek}");
            foreach (Paczka p in StosPaczek)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }
        public void Umiesc(Paczka paczka)
        {
            StosPaczek.Push(paczka);
            ++iloscPaczek;
        }
        public Paczka Pobierz()
        {
            Paczka paczka = null;
            if (StosPaczek.Count()!=0)
            {
                paczka = StosPaczek.Pop();
                iloscPaczek--;
            }
            return paczka;
        }
        public void Wyczysc()
        {
            StosPaczek.Clear();
            iloscPaczek = 0;
        }
        public int PodajIlosc()
        {
            if (StosPaczek.Count() != iloscPaczek)
            {
                Console.WriteLine("\nNieprawidłowa liczba paczek\n");
                return 0;
            }
            return StosPaczek.Count();
        }
        public Paczka PodajBiezacy()
        {
            if (StosPaczek.Count()==0)
                return null;
            return StosPaczek.Peek();
        }
        public float SumaOplat()
        {
            float suma = 0;
            foreach (Paczka p in StosPaczek)
            {
                suma += p.KosztWysylki();
            }
            return suma;
        }
        public int WysylkaPowyzejKwoty(float kwota)
        {
            int licz = 0;
            foreach (Paczka p in StosPaczek)
            {
                if (p.KosztWysylki() > kwota)
                    ++licz;
            }
            return licz;
        }
    }
}

