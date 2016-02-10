using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    class Parametres
    {
        public Parametres()
        {

        }

        public int Simulation { get; set; }
        public int Communication { get; set; }
        public int AutoReparation { get; set; }
        public int Collision { get; set; }
        public int Echelle { get; set; }
        public int XDepart { get; set; }
        public int YDepart { get; set; }
        public int XArrivee { get; set; }
        public int YArrivee { get; set; }
        public int Vitesse { get; set; }
        public int Acceleration { get; set; }
        public int Consommation { get; set; }
        public int FeuJaune { get; set; }
        public int TemperatureMin { get; set; }
        public int TemperatureMax { get; set; }
        public string Strategie { get; set; }
    }
}
