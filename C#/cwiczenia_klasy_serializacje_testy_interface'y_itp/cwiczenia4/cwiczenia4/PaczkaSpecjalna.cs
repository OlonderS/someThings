using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia4
{
    [Serializable] class WrongDateException : Exception
    {
        public WrongDateException(string blad) :base(blad) { }
    }
    class PaczkaSpecjalna : Paczka
    {
        DateTime dataDostarczenia;
        public DateTime DataDostarczenia { get; set; }
        public PaczkaSpecjalna() : base() { }
        public PaczkaSpecjalna(string nad, int roz, string dataDos) : base(nad, roz)
        {
            if (DateTime.TryParseExact(dataDos, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, System.Globalization.DateTimeStyles.None, out this.dataDostarczenia)) 
            {
                if (DateTime.Now.Date > dataDostarczenia)
                {
                    Console.WriteLine(dataDostarczenia);
                    throw new WrongDateException("\nDostawca nie cofnie sie w czasie!");
                }
            }
        }
        public override float KosztWysylki()
        {
            return base.KosztWysylki() + (float)10/(dataDostarczenia.Day-DateTime.Now.Day);
        }
    }
}
