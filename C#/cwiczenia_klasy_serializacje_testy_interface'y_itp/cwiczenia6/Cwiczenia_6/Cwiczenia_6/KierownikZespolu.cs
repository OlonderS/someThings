using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia_6
{
    class KierownikZespolu : Osoba, ICloneable
    {
        int doswiadczenie;

        public int Doswiadczenie
        {
            get { return doswiadczenie; }
            set { doswiadczenie = value; }
        }
        public KierownikZespolu() : base()
        {

        }
        public KierownikZespolu(string i, string n, string d, string pesel, Plcie p, int dos) : base(i, n, d, pesel, p)
        {
            doswiadczenie = dos;
        }
        public override string ToString()
        {
            return this.Imie + " " + this.Nazwisko + " " + this.DataUrodzenia + " " + this.PESEL + " " + this.Plec + " " + this.Doswiadczenie;
        }
        //--------------------------------

        public object Clone() //inna metoda
        {
            return (KierownikZespolu)this.MemberwiseClone();
        }

    }
}


