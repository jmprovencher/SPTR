using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public partial class Parcours
    {
        public Parcours()
        {

        }
        public int XDebut { get; set; }
        public int YDebut { get; set; }
        public int XFin { get; set; }
        public int YFin { get; set; }
        public int Vitesse { get; set; }
        public int Periode { get; set; }
        public int Phase { get; set; }
    }
}
