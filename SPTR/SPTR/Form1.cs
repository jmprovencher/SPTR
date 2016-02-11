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
using System.Xml;
using System.Xml.Serialization;

namespace SPTR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            System.IO.StreamReader stream = new System.IO.StreamReader("sptr-scenario.xml");
            using (XmlReader reader = XmlReader.Create(stream))
            {
                reader.MoveToContent();
                switch (reader.Name)
                {
                    case "SPTR":
                        s = (Simulation)(new XmlSerializer(typeof(Simulation)).Deserialize(reader));
                        break;
                    default:
                        throw new NotSupportedException("Unexpected: " + reader.Name);
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(Route r in s.ListeRoutes)
            {
                Console.WriteLine(r.Numero);
            }
        }
        public Simulation s;
    }
}
