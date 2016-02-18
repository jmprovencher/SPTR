using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SPTR
{
    public class Route
    {
        public Route()
        {

        }

        [XmlAttribute("numero")]
        public int Numero { get; set; }
        public int XDebut { get; set; }
        public int YDebut { get; set; }
        public int XFin { get; set; }
        public int YFin { get; set; }
        public int Vitesse { get; set; }


    }
}

