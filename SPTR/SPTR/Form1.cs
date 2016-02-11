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
        public Form1()
        {
            InitializeComponent();
            s = new SimulationXMLParser("sptr-scenario.xml").getSimulationFromXML();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Route r in s.ListeRoutes) { 
                listBox1.Items.Add("Route "+r.Numero+", vitesse: "+r.Vitesse);
            }
        }
        public Simulation s;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    
}
