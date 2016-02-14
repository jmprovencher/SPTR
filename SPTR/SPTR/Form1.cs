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
            
            s = new SimulationXMLParser("sptr-scenario.xml").getSimulationFromXML();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display1.BackColor = Color.Green;
            foreach (Route r in s.ListeRoutes) { 
                
            }
        }


 
    }

    
}
