using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public class Voiture: Cellule
    {
        public Voiture(int x, int y, int tailleCellule):base(x, y, tailleCellule)
        {
            // load le PNG ici...
        }

        public override void paint(Graphics g)
        {
            // en proportion avec tailleCellule
        }
    }
}
