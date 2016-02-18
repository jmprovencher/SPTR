using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SPTR
{
    public class Parcours
    {
        public Parcours()
        {
            ListeVoitures = new List<Voiture>();
        }
        public int XDebut { get; set; }
        public int YDebut { get; set; }
        public int XFin { get; set; }
        public int YFin { get; set; }
        public int Vitesse { get; set; }
        public int Periode { get; set; }
        public int Phase { get; set; }
        [XmlIgnoreAttribute]
        public List<Voiture> ListeVoitures;
    }
}
