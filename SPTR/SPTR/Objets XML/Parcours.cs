using System;
using System.Collections.Generic;
using System.Drawing;
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
        public void paint(Graphics g)
        {
            foreach (Voiture voiture in ListeVoitures)
            {
                voiture.paint(g);
            }
        }

        public String getDirection()
        {
            int XDirection = 0;
            int YDirection = 0;
            if (XFin != XDebut)
            {
                XDirection = (XFin - XDebut) / Math.Abs(XDebut - XFin);
            }
            if (YFin != YDebut)
            {
                YDirection = (YFin - YDebut) / Math.Abs(YDebut - YFin);
            }
            if (XDirection == 1)
            {
                return "E";
            }
            if (XDirection == -1)
            {
                return "O";
            }
            if (YDirection == -1)
            {
                return "N";
            }
            if (YDirection == 1)
            {
                return "S";
            }
            else
            {
                return "D";
            }
        }

        [XmlAttribute("numero")]
        public int Numero { get; set; }
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
