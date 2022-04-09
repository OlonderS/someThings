using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia4
{
    class PaczkaPolecona : Paczka
    {
        static float oplataDodatkowa;

        public static float OplataDodatkowa { get => oplataDodatkowa; set => oplataDodatkowa = value; }

        static PaczkaPolecona()
        {
            oplataDodatkowa = 10.0f;
        }
        public PaczkaPolecona() : base() { }
        public PaczkaPolecona(string nad, int roz) : base(nad, roz) { }
        public override float KosztWysylki()
        {
            return base.KosztWysylki() + OplataDodatkowa;
        }
    }
}
