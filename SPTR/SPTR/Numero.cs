using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    class Numero: Cellule
    {
        public Numero(int x, int y, int tailleCellule):base(x, y, tailleCellule)
        {

        }

        public override void paint(Graphics g)
        {
            base.paint(g);
            // Create font and brush.
            Font drawFont = new Font("Arial", (int)(TailleCellule * 0.5));
            SolidBrush drawBrush = new SolidBrush(Color.WhiteSmoke);

            // Create point for upper-left corner of drawing.
            PointF drawPoint = new PointF(CoordonneeX * TailleCellule, CoordonneeY * TailleCellule);
            //Console.WriteLine("Writing: " + Position+" at:" +CoordonneeX+" , "+CoordonneeY);
            // Draw string to screen.
            string drawString = "0";
            if (CoordonneeX > CoordonneeY)
            {
                drawString = CoordonneeX.ToString();
            }
            else if(CoordonneeY > CoordonneeX)
            {
                drawString = CoordonneeY.ToString();
            }
            g.DrawString(drawString, drawFont, drawBrush, drawPoint);
        }
    }
}
