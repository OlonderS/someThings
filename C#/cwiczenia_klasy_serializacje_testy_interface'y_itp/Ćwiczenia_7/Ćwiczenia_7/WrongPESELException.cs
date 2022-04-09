using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ćwiczenia_7
{
    class WrongPESELException : System.Exception
    {
        public WrongPESELException(string messege) : base(messege)
        {

        }
    }
}
