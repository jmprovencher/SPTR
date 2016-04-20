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
                Voiture voitureIntelligente = new Voiture(start.CoordonneeX, start.CoordonneeY, start.TailleCellule, "O");
                Voiture = voitureIntelligente;
            }
            
        }

        string getDirectionOpposee(string direction)
        {
            switch (direction)
            {
                case "N":
                    return "S";
                case "S":
                    return "N";
                case "E":
                    return "O";
                case "O":
                    return "E";
                default:
                    return "D";

            }
        }

        public void run(int temps)
        {
            runParcours(temps);
            runFeux(temps);
        }

        public void runParcours(int temps)
        {
            //int count = 0;
            foreach (Parcours parcours in ListeParcours)
            {
                /*count++;
                if (count != 3)
                {
                    continue;
                }*/
                //mouvement des voitures
                string ParcoursDirection = parcours.getDirection();
                Voiture voitureTerminee = null;
                foreach (Voiture voiture in parcours.ListeVoitures)
                {
                    //regarde si feu rouge
                    Cellule celluleDroiteDeLaVoiture = GrilleSimulation.getCelluleDroite((int)voiture.CoordonneeX, (int)voiture.CoordonneeY, voiture.carActualDirection);
                    if (celluleDroiteDeLaVoiture.GetType() == typeof(Feu))
                    {

                        Feu feu = (Feu)celluleDroiteDeLaVoiture;
                        
                        if (feu.CouleurFeu == Couleur.Rouge && feu.Position == getDirectionOpposee(voiture.carActualDirection))
                        {
                            //Si rouge, bouge pas !
                            continue;
                        }
                    }
                    //si vert ou pas de feu, avance

                    voiture.run((double)parcours.Vitesse / (double)ParametresSimulation.Echelle);
                    //si atteint la fin, disparait
                    if ((Math.Abs(voiture.CoordonneeX-parcours.XDebut) + Math.Abs(voiture.CoordonneeX - parcours.XFin))> Math.Abs(parcours.XFin-parcours.XDebut))
                    {
                        voitureTerminee = voiture;
                    }
                    else if ((Math.Abs(voiture.CoordonneeY - parcours.YDebut) + Math.Abs(voiture.CoordonneeY - parcours.YFin))> Math.Abs(parcours.YFin - parcours.YDebut))
                    {
                        voitureTerminee = voiture;
                    }
                }

                if (voitureTerminee != null)
                {
                    parcours.ListeVoitures.Remove(voitureTerminee);
                }

                //Ajout des voitures
                int tempsAjuste = temps - parcours.Phase;
                if (tempsAjuste >= 0)
                {
                    if (tempsAjuste % parcours.Periode == 0)
                    {
                        parcours.ListeVoitures.Add(new Voiture(parcours.XDebut, parcours.YDebut, GrilleSimulation.TailleCellules, ParcoursDirection));
                    }
                }
            }
        }

        public void runFeux(int temps)
        {
            foreach (Feu feu in ListeFeux)
            {
                int offset = 0;
                
                switch (feu.Position)
                {
                    case "N":
                        offset = 1;
                        break;
                    case "O":
                        offset = 2;
                        break;
                    case "S":
                        offset = 3;
                        break;
                    default:
                        offset = 0;
                        break;
                }
                int offsetTemps = temps - offset*(feu.Duree);

                if (offsetTemps < 0)
                {
                    continue;
                }

                if (feu.CouleurFeu == Couleur.Vert)
                {
                    int restant = offsetTemps % feu.Duree;
                    if (restant == (feu.Duree-ParametresSimulation.FeuJaune))
                    {
                        feu.CouleurFeu = Couleur.Jaune;
                        continue;
                    }
                }
                else if (feu.CouleurFeu == Couleur.Jaune)
                {
                    int restant = offsetTemps % feu.Duree;
                    if (restant == 0)
                    {
                        feu.CouleurFeu = Couleur.Rouge;
                        continue;
                    }
                }
                else
                {
                    int restant = offsetTemps % (4*feu.Duree);
                    if (restant == 0)
                    {
                        feu.CouleurFeu = Couleur.Vert;
                        continue;
                    }
                }
            }
        }

        public void paint(Graphics e)
        {
            GrilleSimulation.paint(e);
            if (Voiture != null)
            {
                Voiture.paint(e);
            }
            foreach(Parcours parcours in ListeParcours)
            {
                parcours.paint(e);
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
        [XmlArray("Trafic")]
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
