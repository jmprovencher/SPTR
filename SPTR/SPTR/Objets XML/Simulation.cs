using System;
using System.Collections.Generic;
using System.Drawing;
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
            GrilleSimulation = new Grille(33, 50, 0, 0);
        }

        public void RemplirGrille()
        {
            //Ajout des routes
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
                        if (GrilleSimulation.getCellule(i, j).GetType() != typeof(Asphalte))
                        {
                            Asphalte asphalte = new Asphalte(i, j, GrilleSimulation.TailleCellules);
                            GrilleSimulation.setCellule(i,j,asphalte);
                            if (i > 0 && GrilleSimulation.getCellule(i - 1, j).GetType() == typeof(Asphalte))
                            {
                                asphalte.addLeftRightLine();
                            }

                            if (j > 0 && GrilleSimulation.getCellule(i , j - 1).GetType() == typeof(Asphalte))
                            {
                                asphalte.addUpDownLine();
                            }
                        }
                        ((Asphalte)GrilleSimulation.getCellule(i, j)).ListeRoute.Add(r);

                    }
                }
                
            }
            // Ajout des feux
            for (int i = 0; i<ListeFeux.Count;i++)
            {
                Feu f = ListeFeux[i];
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
                f.CoordonneeX += offsetX;
                f.CoordonneeY += offsetY;
                Feu nouveauFeu = new Feu(GrilleSimulation.TailleCellules, f);
                GrilleSimulation.setCellule(f.CoordonneeX,f.CoordonneeY,  nouveauFeu);
                ListeFeux[i] = nouveauFeu;
            }

            //Ajout de la voiture
            int voitureX = ParametresSimulation.XDepart;
            int voitureY = ParametresSimulation.YDepart;

            if (GrilleSimulation.getCellule(voitureX, voitureY).GetType() == typeof(Asphalte))
            {
                Asphalte start = (Asphalte)GrilleSimulation.getCellule(voitureX, voitureY);
                Voiture voitureIntelligente = new Voiture(start.CoordonneeX, start.CoordonneeY, start.TailleCellule);
                Voiture = voitureIntelligente;
            }
            
        }

        public void paint(Graphics e)
        {
            GrilleSimulation.paint(e);
            if (Voiture != null)
            {
                Voiture.paint(e);
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
        public int TemperatureSimulation;
        [XmlElement("Bris")]
        public Bris BrisSimulation;
        [XmlElement("Conducteur")]
        public Conducteur ConducteurSimulation;
        [XmlIgnoreAttribute]
        public Grille GrilleSimulation;
        [XmlIgnoreAttribute]
        public Voiture Voiture;
    }
}
