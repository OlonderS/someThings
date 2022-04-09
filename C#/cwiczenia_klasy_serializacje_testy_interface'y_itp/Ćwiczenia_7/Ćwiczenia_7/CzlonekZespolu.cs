using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ćwiczenia_7
{
    [Serializable]
    class CzlonekZespolu : Osoba, ICloneable, IComparable
    {
        string funkcja;

        public string Funkcja
        {
            get { return funkcja; }
            set { funkcja = value; }
        }
        public CzlonekZespolu() : base()
        {

        }
        public CzlonekZespolu(string i, string n, string d, string pesel, Plcie p, string f) : base(i, n, d, pesel, p)
        {
            funkcja = f;
        }
        public override string ToString()
        {
            return this.Imie + " " + this.Nazwisko + " " + this.DataUrodzenia + " " + this.PESEL + " " + this.Plec + " (" + this.Funkcja + ")";
        }

        //klonowanie i powrowywanie
        public object Clone()
        {
            return (CzlonekZespolu)this.MemberwiseClone();
        }
        public int CompareTo(object o) // porownywanie obiektow
        {
            //CzlonekZespolu c = o as CzlonekZespolu; //rzutowanie
            if (o is CzlonekZespolu c && c != null)
            {
                if (Nazwisko.CompareTo(c.Nazwisko) != 0) //porownywanie stringow
                {
                    return Nazwisko.CompareTo(c.Nazwisko);
                }
                else
                {
                    return Imie.CompareTo(c.Imie);
                }
            }
            return 0;
        }
    }
}
