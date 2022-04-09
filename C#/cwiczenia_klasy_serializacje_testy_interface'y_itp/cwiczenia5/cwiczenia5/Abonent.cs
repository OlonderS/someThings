using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cwiczenia5
{
    class BlednyNumerException : Exception
    {
        public BlednyNumerException() : base() { }
        public BlednyNumerException(string msg) : base(msg) { }
    }
    class Abonent
    {
        string imie;
        string nazwisko;
        string numerTelefonu;
        string miasto;
        public string Imie { get => imie;}
        public string Nazwisko { get => nazwisko;}
        public string Miasto { get => miasto;}
        public string NumerTelefonu
        {
            get => numerTelefonu;
            set
            {
                if (!SprawdzNumer(value))
                    throw new BlednyNumerException("zly format numeru");
                numerTelefonu = value;
            }
        }

        public Abonent(string imie, string nazwisko, string numerTelefonu, string miasto)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            NumerTelefonu = numerTelefonu;
            this.miasto = miasto;
        }
        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, {Miasto}, tel: {NumerTelefonu}";
        }

        public bool SprawdzNumer(string numer)
        {
            Regex r = new Regex(@"^\d{3}(-\d{3}){2}$");
            return r.IsMatch(numer);
        }
    }
}
