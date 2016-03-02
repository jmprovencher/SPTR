using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public class Asphalte : Cellule
    {
        public Asphalte(int x, int y, int tailleCellule):base(x, y , tailleCellule)
        {
            ListeRoute = new List<Route>();
        }

        public override void paint(Graphics g)
        {
            SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkGray);
            g.FillRectangle(myBrush, new Rectangle(CoordonneeXEchelle, CoordonneeYEchelle, TailleCellule, TailleCellule));
        }

        public List<Route> ListeRoute;

    }
}
