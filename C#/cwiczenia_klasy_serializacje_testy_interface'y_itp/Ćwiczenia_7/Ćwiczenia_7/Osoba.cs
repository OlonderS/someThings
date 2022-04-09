using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ćwiczenia_7
{
    [Serializable] //do zaposu do pliku
    abstract class Osoba : IEquatable<Osoba>
    {
        private string imie;
        private string nazwisko;
        private DateTime dataUrodzenia;
        private string pesel;
        private Plcie plec;

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }
        public DateTime DataUrodzenia
        {
            get { return dataUrodzenia; }
            set { dataUrodzenia = value; }
        }
        public string PESEL
        {
            get
            {
                return pesel;
            }
            set
            {
                /*
                try 
                {
                    if (SetPESEL(value) == 1)
                    {
                        pesel = value;
                    }
                    else
                    {
                        throw new WrongPESELException("Bledny PESEL");
                    }

                }
                catch(WrongPESELException e)
                {
                    Console.WriteLine(e.Message);
                    pesel = new string('0', 11);
                }
                */
                if (SetPESEL(value) == 1)
                {
                    pesel = value;
                }
                else
                {
                    throw new WrongPESELException("Bledny PESEL.");
                }
            }
        }

        private int SetPESEL(string pesel)
        {
            string data = Convert.ToString(this.DataUrodzenia);
            int controlSum = 0;
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            if (pesel.Length != 11 || Char.IsNumber(pesel[10]) == false)
            {
                return 0;
            }

            for (int i = 0; i < 10; i++)
            {
                if (Char.IsNumber(pesel[i]) == false)
                {
                    return 0;
                }
                controlSum += ((pesel[i] - '0') * weights[i]); // - '0' char na int, '0' == 48(ASCII)
            }
            controlSum %= 10;
            controlSum = 10 - controlSum;
            controlSum %= 10;

            if (data[2] == pesel[0] && data[3] == pesel[1] && data[5] == pesel[2] && data[6] == pesel[3] && data[8] == pesel[4] && data[9] == pesel[5] && controlSum == (pesel[10] - '0'))
            {
                if ((((pesel[9] - '0') % 2 == 0) && Convert.ToInt32(this.plec) == 0) || (((pesel[9] - '0') % 2 == 1) && Convert.ToInt32(this.plec) != 0))
                {
                    return 1;
                }
            }
            return 0;
        }
        public Plcie Plec
        {
            get { return plec; }
            set { plec = value; }
        }

        public Osoba()
        {
            Imie = null;
            Nazwisko = null;
            DataUrodzenia = DateTime.MinValue;
            PESEL = new String('0', 11);
            //PESEL = "00000000000";
        }
        public Osoba(string i, string n)
        {
            Imie = i;
            Nazwisko = n;
        }
        public Osoba(string i, string n, string d, string pesel, Plcie p) : this(i, n)
        {
            //dataUrodzenia = Convert.ToDateTime(d);
            DataUrodzenia = DateTime.Parse(d);
            Plec = p;
            PESEL = pesel;
        }

        //metody
        public int Wiek()
        {
            return (DateTime.Today.Year - DataUrodzenia.Year);
        }
        public override string ToString()
        {
            return this.Imie + " " + this.Nazwisko + " " + this.DataUrodzenia + " " + this.PESEL + " " + this.Plec + " (Lat " + Wiek() + ")";
        }

        public bool Equals(Osoba o)
        {
            if (this.pesel == o.pesel)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
