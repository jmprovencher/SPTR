using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public partial class Feu : Cellule
    {
        public Feu()
        {

        }

        public void paint(Graphics g)
        {
            int offsetX = 0, offsetY = 0;
            switch (Position)
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
                    offsetY =- 1;
                    break;
                case "O":
                    offsetX = -1;
                    offsetY = 1;
                    break;
            }
            SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            g.FillRectangle(myBrush, new Rectangle((CoordonneeX+offsetX)*20, (CoordonneeY+offsetY)*20, 20, 20));
        }

        public int CoordonneeX { get; set; }
        public int CoordonneeY { get; set; }
        public string Position { get; set; }
        public int Duree { get; set; }

    }
}
