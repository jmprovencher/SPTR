using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SPTR
{
    class SimulationXMLParser
    {
        public SimulationXMLParser(string arg_XmlPath)
        {
            XmlPath = arg_XmlPath;
        }

        public Simulation getSimulationFromXML()
        {
            System.IO.StreamReader stream = new System.IO.StreamReader(XmlPath);
            using (XmlReader reader = XmlReader.Create(stream))
            {
                reader.MoveToContent();
                switch (reader.Name)
                {
                    case "SPTR":
                        return (Simulation)(new XmlSerializer(typeof(Simulation)).Deserialize(reader));
                    default:
                        throw new NotSupportedException("Unexpected: " + reader.Name);
                }

            }
        }

        public string XmlPath {get; set;}
    }
}
