using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia4
{
    class MagazynFIFO : IMagazynuje
    {
        string nazwa;
        int iloscPaczek;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }
        public Queue<Paczka> ListaPaczek;

        public MagazynFIFO()
        {
            iloscPaczek = 0;
            ListaPaczek = new Queue<Paczka>();
        }
        public MagazynFIFO(string nazwa) : this()
        {
            this.nazwa = nazwa;
        }

        public void Umiesc(Paczka t)
        {
            ListaPaczek.Enqueue(t);
            ++IloscPaczek;
        }
        public Paczka Pobierz()
        {
            Paczka p = null;
            if (ListaPaczek != null && ListaPaczek.Count() > 0)
            {
                p = ListaPaczek.Dequeue();
                IloscPaczek--;
            }
            return p;
        }
        public void Wyczysc()
        {
            ListaPaczek.Clear();
            IloscPaczek = 0;
        }
        public int PodajIlosc()
        {
            if (ListaPaczek.Count() != IloscPaczek)
            {
                Console.WriteLine("\nLiczba paczek sie nie zgadza");
                return IloscPaczek;
            }
            return ListaPaczek.Count();
        }
        public Paczka PodajBiezacy()
        {
            Paczka p = null;
            if (ListaPaczek != null && ListaPaczek.Count() > 0)
            {
                p = ListaPaczek.Peek();
            }
            return p;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"nazwa: \"{nazwa}\" liczba paczek: {iloscPaczek}");
            foreach (Paczka p in ListaPaczek)
                sb.AppendLine(p.ToString());
            return sb.ToString();
        }
    }
}