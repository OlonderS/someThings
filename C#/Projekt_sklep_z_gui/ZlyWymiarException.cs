using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class ZlyWymiarException : Exception
    {
        public ZlyWymiarException() { }
        public ZlyWymiarException(string messege) : base(messege) { }
    }
}
