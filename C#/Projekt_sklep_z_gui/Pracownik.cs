using System;

namespace WpfApp2
{
    static class Pracownik
    {
        public static void DodajProdukt(Produkt produkt)
        {
            if (Sklep.ListaProduktow.Find(x => x.Producent == produkt.Producent && x.Model==produkt.Model) is object)
                throw new Exception("W sklepie już jest taki produkt");
            Sklep.ListaProduktow.Add(produkt);
        }
    }
}
