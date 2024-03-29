﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public class SimulationController
    {
        public SimulationController(string path)
        {
            xmlPath = path;
            simulation = new SimulationXMLParser(path).getSimulationFromXML();
            simulation.RemplirGrille();
            temps = 0;
            ordonnanceur = new Ordonnanceur();
        }
        //contient tous les paramètres statiques
        public Simulation simulation
        {
            get;
            set;
        }

        private Simulation resetCopy
        {
            get;
            set;
        }
        public int temps
        {
            get;
            set;
        }

        private string xmlPath
        {
            get;
            set;
        }

        public void run()
        {
            temps++;
            simulation.run(temps);
        }

        public void reset()
        {
            temps = 0;
            simulation = new SimulationXMLParser(xmlPath).getSimulationFromXML();
            simulation.RemplirGrille();
        }

        

        public void paint(Graphics g)
        {
            simulation.paint(g);
        }

        public Ordonnanceur ordonnanceur
        {
            get;
            set;
        }
    }
}
