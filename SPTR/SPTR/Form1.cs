using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SPTR
{
    public partial class Form1 : Form
    {
        public Simulation s;

        public Form1()
        {
            InitializeComponent();
            s = new Simulation();// new SimulationXMLParser("sptr-scenario.xml").getSimulationFromXML();
            //s.RemplirGrille();
        }

        void updateText()
        {
            textBoxTemp.Text = ""+s.TemperatureSimulation;
            textBoxX.Text = "" + s.Voiture.CoordonneeX;
            textBoxY.Text = "" + s.Voiture.CoordonneeY;
        }

        void resetParameters()
        {
            UDAcceleration.Value = s.ParametresSimulation.Acceleration;
            UDAutoReparation.Value = s.ParametresSimulation.AutoReparation;
            UDCollision.Value = s.ParametresSimulation.Collision;
            UDCommunication.Value = s.ParametresSimulation.Communication;
            UDConsommation.Value = s.ParametresSimulation.Consommation;
            UDEchelle.Value = s.ParametresSimulation.Echelle;
            UDFeuJaune.Value = s.ParametresSimulation.FeuJaune;
            UDSimulation.Value = s.ParametresSimulation.Simulation;
            UDTemperatureMax.Value = s.ParametresSimulation.TemperatureMax;
            UDTemperatureMIn.Value = s.ParametresSimulation.TemperatureMin;
            UDVitesse.Value = s.ParametresSimulation.Vitesse;
            UDXArrivee.Value = s.ParametresSimulation.XArrivee;
            UDXDepart.Value = s.ParametresSimulation.XDepart;
            UDYArrivee.Value = s.ParametresSimulation.YArrivee;
            UDYDepart.Value = s.ParametresSimulation.YDepart;
            if (s.ParametresSimulation.Strategie == "unique")
            {
                CBStrategie.SelectedIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void display1_Paint(object sender, PaintEventArgs e)
        {
            s.paint(e.Graphics);

        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName= ofd.FileName;
                s = new SimulationXMLParser(fileName).getSimulationFromXML();
                s.RemplirGrille();
                display.Refresh();
                updateText();
                resetParameters();
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }


        private void àProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


        void updateParameters()
        {
            s.ParametresSimulation.Acceleration = (int)UDAcceleration.Value;
            s.ParametresSimulation.AutoReparation = (int)UDAutoReparation.Value;
            s.ParametresSimulation.Collision = (int)UDCollision.Value;
            s.ParametresSimulation.Communication = (int)UDCommunication.Value;
            s.ParametresSimulation.Consommation = (int)UDConsommation.Value;
            s.ParametresSimulation.Echelle = (int)UDEchelle.Value;
            s.ParametresSimulation.FeuJaune = (int)UDFeuJaune.Value;
            s.ParametresSimulation.Simulation = (int)UDSimulation.Value;
            s.ParametresSimulation.TemperatureMax = (int)UDTemperatureMax.Value;
            s.ParametresSimulation.TemperatureMin = (int)UDTemperatureMIn.Value;
            s.ParametresSimulation.Vitesse = (int)UDVitesse.Value;
            s.ParametresSimulation.XArrivee = (int)UDXArrivee.Value;
            s.ParametresSimulation.XDepart = (int)UDXDepart.Value;
            s.ParametresSimulation.YArrivee = (int)UDYArrivee.Value;
            s.ParametresSimulation.YDepart = (int)UDYDepart.Value;
            if (CBStrategie.SelectedIndex == 0)
            {
                s.ParametresSimulation.Strategie = "unique";
            }

            s.Voiture.CoordonneeX = s.ParametresSimulation.XDepart;
            s.Voiture.CoordonneeY = s.ParametresSimulation.YDepart;
            updateText();
        }



        private void buttonAppliquer_Click(object sender, EventArgs e)
        {
            updateParameters();
        }
    }
    

    
}
