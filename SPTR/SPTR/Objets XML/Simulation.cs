using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SPTR
{
    [XmlRoot("SPTR")]
    public class Simulation
    {
        public Simulation()
        {
            ListeRoutes = new List<Route>();
            ListeFeux = new List<Feu>();
            ListeParcours = new List<Parcours>();
            GrilleSimulation = new Grille(32, 20);
        }

        public void RemplirGrille()
        {
            foreach (Route r in ListeRoutes)
            {
                int startX = 0, startY = 0, stopX = 0, stopY = 0;

                if (r.XDebut == r.XFin)
                {
                    startX = r.XDebut;
                    stopX = startX;
                    if (r.YDebut < r.YFin)
                    {
                        startY = r.YDebut;
                        stopY = r.YFin;
                    }
                    else
                    {
                        startY = r.YFin;
                        stopY = r.YDebut;
                    }
                }
                else if (r.YDebut == r.YFin)
                {
                    startY = r.YDebut;
                    stopY = startY;
                    if (r.XDebut < r.XFin)
                    {
                        startX = r.XDebut;
                        stopX = r.XFin;
                    }
                    else
                    {
                        startX = r.XFin;
                        stopX = r.XDebut;
                    }
                }
                for (int i = startX; i <= stopX; i++)
                {
                    for (int j = startY; j <= stopY; j++)
                    {
                        if (GrilleSimulation.ListesCellules[i][j].GetType() != typeof(Asphalte))
                        {
                            GrilleSimulation.ListesCellules[i][j] = (new Asphalte(i, j));
                        }
                        ((Asphalte)GrilleSimulation.ListesCellules[i][j]).ListeRoute.Add(r);

                    }
                }
            }

            foreach (Feu f in ListeFeux)
            {
                int offsetX = 0, offsetY = 0;
                switch (f.Position)
                {
                    case "N":
                        offsetY = -1;
                        offsetX = -1;
                        break;
                    case "S":
                        offsetY = 1;
                        offsetX = 1;
                        break;
                    case "E":
                        offsetX = 1;
                        offsetY = -1;
                        break;
                    case "O":
                        offsetX = -1;
                        offsetY = 1;
                        break;
                }
                GrilleSimulation.ListesCellules[f.CoordonneeX + offsetX][f.CoordonneeY + offsetY] = f;
            }
        }

        [XmlElement("Parametres")]
        public Parametres ParametresSimulation;
        [XmlArray("Routes")]
        [XmlArrayItem("Route")]
        public List<Route> ListeRoutes;
        [XmlArray("Feux")]
        [XmlArrayItem("Feu")]
        public List<Feu> ListeFeux;
        [XmlArray("Traffic")]
        [XmlArrayItem("Parcours")]
        public List<Parcours> ListeParcours;
        [XmlElement("Temperature")]
        public Temperature TemperatureSimulation;
        [XmlElement("Bris")]
        public Bris BrisSimulation;
        [XmlElement("Conducteur")]
        public Conducteur ConducteurSimulation;
        [XmlIgnoreAttribute]
        public Grille GrilleSimulation;
    }
}
