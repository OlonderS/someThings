using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


namespace cwiczenia4
{
    class MagazynArray : IMagazynuje
    {
        string nazwa;
        int iloscPaczek;
        ArrayList ListaTablicowa;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }

        public MagazynArray()
        {
            Nazwa = null;
            IloscPaczek = 0;
            ListaTablicowa = new ArrayList();
        }
        public MagazynArray(String naz) : this()
        {
            Nazwa = naz;
        }
        public void Umiesc(Paczka t)
        {
            ListaTablicowa.Add(t);
            ++IloscPaczek;
        }
        public Paczka Pobierz()
        {
            Paczka p = null;
            if (ListaTablicowa != null && ListaTablicowa.Count > 0)
            {
                p = (Paczka)ListaTablicowa[ListaTablicowa.Count - 1];
                ListaTablicowa.Remove(p);
                IloscPaczek--;
            }
            return p;
        }
        public void Wyczysc()
        {
            ListaTablicowa.Clear();
            IloscPaczek = 0;
        }
        public int PodajIlosc()
        {
            if (ListaTablicowa.Count != IloscPaczek)
            {
                Console.WriteLine("\nLiczba paczek sie nie zgadza\n");
                return 0;
            }
            return ListaTablicowa.Count;
        }
        public Paczka PodajBiezacy()
        {
            Paczka p = null;
            if (ListaTablicowa != null && ListaTablicowa.Count > 0)
            {
                p = (Paczka)ListaTablicowa[ListaTablicowa.Count-1];
            }
            return p;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"nazwa: \"{nazwa}\" liczba paczek: {iloscPaczek}");
            foreach (Paczka p in ListaTablicowa)
                sb.AppendLine(p.ToString());
            return sb.ToString();
        }
    }
}