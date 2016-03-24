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

        private bool upDownLine;
        private bool leftRightLine;

        public Asphalte(int x, int y, int tailleCellule):base(x, y , tailleCellule)
        {
            ListeRoute = new List<Route>();
            upDownLine = false;
            leftRightLine = false;
        }

        public override void paint(Graphics g)
        {
            SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkGray);
            g.FillRectangle(myBrush, new Rectangle(CoordonneeXEchelle, CoordonneeYEchelle, TailleCellule, TailleCellule));
            Pen myPen = new System.Drawing.Pen(myBrush);
            myPen.Color = Color.Yellow;
            if (upDownLine)
            {
                Point middleUp = new Point(CoordonneeXEchelle + TailleCellule / 2, CoordonneeYEchelle);
                Point middleDown = new Point(CoordonneeXEchelle + TailleCellule / 2, CoordonneeYEchelle + TailleCellule);
                g.DrawLine(myPen, middleUp, middleDown);
            }

            if (leftRightLine)
            {
                Point middleLeft = new Point(CoordonneeXEchelle, CoordonneeYEchelle + TailleCellule / 2);
                Point middleRight = new Point(CoordonneeXEchelle + TailleCellule, CoordonneeYEchelle + TailleCellule / 2);
                g.DrawLine(myPen, middleLeft, middleRight);
            }
        }

        public void addLeftRightLine()
        {
            leftRightLine = true;
        }

        public void addUpDownLine()
        {
            upDownLine = true;
        }

        public List<Route> ListeRoute;

    }
}
