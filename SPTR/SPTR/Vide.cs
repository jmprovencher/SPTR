using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    class Vide : Cellule

    {
        public Vide(int x, int y)
        {
            CoordonneeX = x;
            CoordonneeY = y;
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
            
        }
    }
}
