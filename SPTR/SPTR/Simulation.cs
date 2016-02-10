using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SPTR
{
    class Simulation
    {
        public Simulation(string XMLFilePath)
        {
            ListeRoutes = new List<Route>();
            ListeFeux = new List<Feu>();
            ListeParcours = new List<Parcours>();
            LoadXML(XMLFilePath);
        }

        private void LoadXML(string XMLFIlePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFIlePath);
            //Parametres
            XmlNode node = doc.DocumentElement.SelectSingleNode("Parametres");
            ParametresSimulation = new Parametres();
            ParametresSimulation.Simulation = Convert.ToInt32(node.SelectSingleNode("Simulation").InnerText);
            ParametresSimulation.Communication = Convert.ToInt32(node.SelectSingleNode("Communication").InnerText);
            ParametresSimulation.AutoReparation = Convert.ToInt32(node.SelectSingleNode("AutoReparation").InnerText);
            ParametresSimulation.Collision = Convert.ToInt32(node.SelectSingleNode("Collision").InnerText);
            ParametresSimulation.Echelle = Convert.ToInt32(node.SelectSingleNode("Echelle").InnerText);
            ParametresSimulation.XDepart = Convert.ToInt32(node.SelectSingleNode("XDepart").InnerText);
            ParametresSimulation.YDepart = Convert.ToInt32(node.SelectSingleNode("YDepart").InnerText);
            ParametresSimulation.XArrivee = Convert.ToInt32(node.SelectSingleNode("XArrivee").InnerText);
            ParametresSimulation.YArrivee = Convert.ToInt32(node.SelectSingleNode("YArrivee").InnerText);
            ParametresSimulation.Vitesse = Convert.ToInt32(node.SelectSingleNode("Vitesse").InnerText);
            ParametresSimulation.Acceleration = Convert.ToInt32(node.SelectSingleNode("Acceleration").InnerText);
            ParametresSimulation.Consommation = Convert.ToInt32(node.SelectSingleNode("Consommation").InnerText);
            ParametresSimulation.FeuJaune = Convert.ToInt32(node.SelectSingleNode("FeuJaune").InnerText);
            ParametresSimulation.TemperatureMin = Convert.ToInt32(node.SelectSingleNode("TemperatureMin").InnerText);
            ParametresSimulation.TemperatureMax = Convert.ToInt32(node.SelectSingleNode("TemperatureMax").InnerText);
            ParametresSimulation.Strategie = node.SelectSingleNode("Strategie").InnerText;

            XmlNodeList routeNodes = doc.DocumentElement.SelectNodes("/SPTR//Routes/Route");

            foreach (XmlNode routeNode in routeNodes)
            {
                string numeroString = routeNode.Attributes["numero"].Value;
                int numero = Convert.ToInt32(numeroString);
                Route r = new Route(numero);
                r.Vitesse = Convert.ToInt32(routeNode.SelectSingleNode("Vitesse").InnerText);
                r.XDebut = Convert.ToInt32(routeNode.SelectSingleNode("XDebut").InnerText);
                r.YDebut = Convert.ToInt32(routeNode.SelectSingleNode("YDebut").InnerText);
                r.XFin = Convert.ToInt32(routeNode.SelectSingleNode("XFin").InnerText);
                r.YFin = Convert.ToInt32(routeNode.SelectSingleNode("YFin").InnerText);

                ListeRoutes.Add(r);
            }

    }

        public Parametres ParametresSimulation;
        public List<Route> ListeRoutes;
        public List<Feu> ListeFeux;
        public List<Parcours> ListeParcours;
        public Temperature TemperatureSimulation;
        public Bris BrisSimulation;
        public Conducteur ConducteurSimulation;

    }
}
