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
            image = new Bitmap(global::SPTR.Properties.Resources.car);
            image = new Bitmap(image, new Size(tailleCellule, tailleCellule));
        }

        public override void paint(Graphics g)
        {
            g.DrawImage(image, new Point(CoordonneeXEchelle, CoordonneeYEchelle));
        }

        private Bitmap image;
    }
}
