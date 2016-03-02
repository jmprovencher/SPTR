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
    }
    

    
}
