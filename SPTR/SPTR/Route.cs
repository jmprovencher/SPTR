using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    class Route
    {
        public Route(int arg_numero)
        {
            Numero = arg_numero;
        }
        public int Numero;
        public int XDebut { get; set; }
        public int YDebut { get; set; }
        public int XFin { get; set; }
        public int YFin { get; set; }
        public int Vitesse { get; set; }
    }
}
