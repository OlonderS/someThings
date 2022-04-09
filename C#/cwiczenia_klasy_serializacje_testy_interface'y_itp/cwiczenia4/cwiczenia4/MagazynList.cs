using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cwiczenia4
{
    class MagazynList : IMagazynuje
    { 
        string nazwa;
        int iloscPaczek;
        public LinkedList<Paczka> listaWiazana;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }

        public MagazynList()
        {
            nazwa = null;
            iloscPaczek = 0;
            listaWiazana = new LinkedList<Paczka>();
        }
        public MagazynList(string nazwa) : this()
        {
            this.nazwa = nazwa;
        }
        public void Umiesc(Paczka t)
        {
            listaWiazana.AddFirst(t);
            ++IloscPaczek;
        }
        public Paczka Pobierz()
        {
            Paczka p = null;
            if (listaWiazana != null && listaWiazana.Count() > 0)
            {
                p = listaWiazana.First();
                listaWiazana.RemoveFirst();
                IloscPaczek--;
            }
            return p;
        }
        public void Wyczysc()
        {
            listaWiazana.Clear();
            IloscPaczek = 0;
        }
        public int PodajIlosc()
        {
            if (listaWiazana.Count() != IloscPaczek)
            {
                Console.WriteLine("\nLiczba paczek sie nie zgadza\n");
                return IloscPaczek;
            }
            return listaWiazana.Count();
        }
        public Paczka PodajBiezacy()
        {
            Paczka p = null;
            if (listaWiazana != null && listaWiazana.Count() > 0)
            {
                p = listaWiazana.First();
            }
            return p;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"nazwa: \"{nazwa}\" liczba paczek: {iloscPaczek}");
            foreach (Paczka p in listaWiazana)
                sb.AppendLine(p.ToString());
            return sb.ToString();
        }
    }
}
