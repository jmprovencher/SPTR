using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public class SimulationController
    {
        public SimulationController(Simulation newSimulation)
        {
            simulation = newSimulation;
            ordonnanceur = new Ordonnanceur();

        }
        //contient tous les paramètres statiques
        public Simulation simulation
        {
            get;
            set;
        }
        //ordonne les processus (dynamique)
        public Ordonnanceur ordonnanceur
        {
            get;
            set;
        }
    }
}
