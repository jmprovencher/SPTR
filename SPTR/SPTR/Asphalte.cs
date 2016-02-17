using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public partial class Asphalte : Cellule
    {
        public Asphalte(int x, int y)
        {
            CoordonneeX = x;
            CoordonneeY = y;
            ListeRoute = new List<Route>();
        }

        public int CoordonneeX
        {
            get;

            set;
        }

        public int CoordonneeY
        {
            get;

            set;
        }

        public void paint(Graphics g)
        {
            SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkGray);
            g.FillRectangle(myBrush, new Rectangle(CoordonneeX * 20, CoordonneeY * 20, 20, 20));
        }
        public List<Route> ListeRoute;
        public Voiture Voiture;

    }
}
