using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public class Cellule
    {
        public Cellule(int x, int y, int tailleCellule)
        {
            CoordonneeX = x;
            CoordonneeY = y;
            TailleCellule = tailleCellule;
        }
        virtual public void paint(Graphics g) {
            SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkGreen);
            g.FillRectangle(myBrush, new Rectangle((CoordonneeX) * TailleCellule, (CoordonneeY ) * TailleCellule, TailleCellule, TailleCellule));
        }

        public int TailleCellule { get; set; }

        virtual public int CoordonneeX
        {
            get;

            set;
        }

        virtual public int CoordonneeY
        {
            get;

            set;
        }
    }
}
