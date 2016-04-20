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
using SPTR.Proc;


namespace SPTR
{
    public partial class Form1 : Form
    {
        public SimulationController simulationController;
        public Timer simulationTimer;

        public Form1()
        {
            InitializeComponent();
            simulationTimer = new Timer();
            simulationTimer.Interval = 10;
            simulationTimer.Tick += new EventHandler(simulationTimer_Tick);
        }

        void simulationTimer_Tick(object sender, EventArgs e)
        {
            if (simulationController.temps <= simulationController.simulation.ParametresSimulation.Simulation) { 
                simulationController.run();
                updateText();
                display.Refresh();
             }
            else
            {
                simulationTimer.Enabled = false;
                reset();
            }
        }

        void initResultGrid()
        {
            dataGridResultats.Rows.Add(0,
                                      Proc.P01.Instance.formatedProcessState,
                                      Proc.P02.Instance.formatedProcessState,
                                      Proc.P03.Instance.formatedProcessState,
                                      Proc.P04.Instance.formatedProcessState,
                                      Proc.P05.Instance.formatedProcessState,
                                      Proc.P06.Instance.formatedProcessState,
                                      Proc.P07.Instance.formatedProcessState,
                                      Proc.P08.Instance.formatedProcessState,
                                      Proc.P09.Instance.formatedProcessState,
                                      Proc.P10.Instance.formatedProcessState,
                                      Proc.P11.Instance.formatedProcessState,
                                      Proc.P12.Instance.formatedProcessState,
                                      Proc.P13.Instance.formatedProcessState);
        }

        void updateText()
        {
            textBoxTemps.Text = "" + simulationController.temps;
            textBoxTemp.Text = ""+simulationController.simulation.TemperatureSimulation;
            textBoxX.Text = "" + simulationController.simulation.MaVoiture.CoordonneeX;
            textBoxY.Text = "" + simulationController.simulation.MaVoiture.CoordonneeY;
        }

        void resetParameters()
        {
            UDAcceleration.Value = simulationController.simulation.ParametresSimulation.Acceleration;
            UDAutoReparation.Value = simulationController.simulation.ParametresSimulation.AutoReparation;
            UDCollision.Value = simulationController.simulation.ParametresSimulation.Collision;
            UDCommunication.Value = simulationController.simulation.ParametresSimulation.Communication;
            UDConsommation.Value = simulationController.simulation.ParametresSimulation.Consommation;
            UDEchelle.Value = simulationController.simulation.ParametresSimulation.Echelle;
            UDFeuJaune.Value = simulationController.simulation.ParametresSimulation.FeuJaune;
            UDSimulation.Value = simulationController.simulation.ParametresSimulation.Simulation;
            UDTemperatureMax.Value = simulationController.simulation.ParametresSimulation.TemperatureMax;
            UDTemperatureMIn.Value = simulationController.simulation.ParametresSimulation.TemperatureMin;
            UDVitesse.Value = simulationController.simulation.ParametresSimulation.Vitesse;
            UDXArrivee.Value = simulationController.simulation.ParametresSimulation.XArrivee;
            UDXDepart.Value = simulationController.simulation.ParametresSimulation.XDepart;
            UDYArrivee.Value = simulationController.simulation.ParametresSimulation.YArrivee;
            UDYDepart.Value = simulationController.simulation.ParametresSimulation.YDepart;
            if (simulationController.simulation.ParametresSimulation.Strategie == "unique")
            {
                CBStrategie.SelectedIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            initResultGrid();

        }

        private void display1_Paint(object sender, PaintEventArgs e)
        {
            if (simulationController != null)
            {
                simulationController.paint(e.Graphics);
            }
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName= ofd.FileName;
                simulationController = new SimulationController(fileName);
                display.Refresh();
                updateText();
                resetParameters();
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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
            simulationController.simulation.ParametresSimulation.Acceleration = (int)UDAcceleration.Value;
            simulationController.simulation.ParametresSimulation.AutoReparation = (int)UDAutoReparation.Value;
            simulationController.simulation.ParametresSimulation.Collision = (int)UDCollision.Value;
            simulationController.simulation.ParametresSimulation.Communication = (int)UDCommunication.Value;
            simulationController.simulation.ParametresSimulation.Consommation = (int)UDConsommation.Value;
            simulationController.simulation.ParametresSimulation.Echelle = (int)UDEchelle.Value;
            simulationController.simulation.ParametresSimulation.FeuJaune = (int)UDFeuJaune.Value;
            simulationController.simulation.ParametresSimulation.Simulation = (int)UDSimulation.Value;
            simulationController.simulation.ParametresSimulation.TemperatureMax = (int)UDTemperatureMax.Value;
            simulationController.simulation.ParametresSimulation.TemperatureMin = (int)UDTemperatureMIn.Value;
            simulationController.simulation.ParametresSimulation.Vitesse = (int)UDVitesse.Value;
            simulationController.simulation.ParametresSimulation.XArrivee = (int)UDXArrivee.Value;
            simulationController.simulation.ParametresSimulation.XDepart = (int)UDXDepart.Value;
            simulationController.simulation.ParametresSimulation.YArrivee = (int)UDYArrivee.Value;
            simulationController.simulation.ParametresSimulation.YDepart = (int)UDYDepart.Value;
            if (CBStrategie.SelectedIndex == 0)
            {
                simulationController.simulation.ParametresSimulation.Strategie = "unique";
            }

            simulationController.simulation.MaVoiture.CoordonneeX = simulationController.simulation.ParametresSimulation.XDepart;
            simulationController.simulation.MaVoiture.CoordonneeY = simulationController.simulation.ParametresSimulation.YDepart;
            updateText();
        }



        private void buttonAppliquer_Click(object sender, EventArgs e)
        {
            if (simulationController != null)
            {
                updateParameters();
            }
        }

        private void demarrer_Click(object sender, EventArgs e)
        {
            if (simulationController != null)
            {
                simulationTimer.Enabled = !(simulationTimer.Enabled);
            }
        }

        private void reset()
        {
            if (simulationController != null)
            {
                simulationTimer.Enabled = false;
                simulationController.reset();
                updateText();
                display.Refresh();
                Console.WriteLine("Reseting...");
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
    

    
}
