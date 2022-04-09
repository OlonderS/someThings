using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
   public class Zakup
    {

        public Produkt produkt;
        public  int ilosc;

        public Zakup(Produkt produkt, int ilosc)
        {
            this.produkt = produkt;
            this.ilosc = ilosc;
        }
        public float ObliczCene()
        {
            return produkt.Cena * ilosc;
        }

        public override string ToString()
        {
            return $"{produkt.Model}  Ilosc: {ilosc}   Cena: { ObliczCene() }  ";
        }
    }
}
