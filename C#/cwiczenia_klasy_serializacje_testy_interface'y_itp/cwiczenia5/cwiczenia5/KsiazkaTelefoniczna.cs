using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia5
{
    class KsiazkaTelefoniczna : Ksiazka
    {
        Dictionary<string, Abonent> abonenci;
        public KsiazkaTelefoniczna(string tytul, string dataWydania, ENumWydawcy wydawca) : base(tytul, dataWydania, wydawca)
        {
            isbn += "-KT";
            abonenci = new Dictionary<string, Abonent>();
        }
        public void DodajAbonenta(Abonent abonent)
        {
            if (!abonenci.ContainsKey(abonent.NumerTelefonu))
                abonenci.Add(abonent.NumerTelefonu, abonent);
            else
            {
                Console.WriteLine($"Telefon o numerze {abonent.NumerTelefonu} nalezy do abonenta " +
                    $"{abonenci[abonent.NumerTelefonu].Imie} {abonenci[abonent.NumerTelefonu].Nazwisko}");
                return;
            }
        }
        public void UsunAbonenta(string telefon)
        {
            if (abonenci.ContainsKey(telefon))
            {
                Console.WriteLine($"Abonenta o numerze telefonu {telefon} nie ma w ksiazce telefonicznej");
                return;
            }
            else
                abonenci.Remove(telefon);
        }
        public List<Abonent> WyszukajAbonentow(string miasto)
        {
            return abonenci.Values.Where(a => a.Miasto.Equals(miasto)).ToList();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("\nLista abonentow ksiazki:");
            foreach (KeyValuePair<string, Abonent> a in abonenci)
            {
                sb.Append($"\n{a.ToString()}");
            }
            return base.ToString() + sb;
        }
    }
}
