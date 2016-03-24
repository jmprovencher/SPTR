using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    enum VehiculeDirection
    {
        Default,
        North,
        South,
        East,
        West
    };

    public class Voiture: Cellule
    {
        public Voiture(int x, int y, int tailleCellule):base(x, y, tailleCellule)
        {
            // load le PNG ici...
            carActualDirection = VehiculeDirection.Default;
            imageRight = LoadImageWithDirection(VehiculeDirection.East);
            imageLeft = LoadImageWithDirection(VehiculeDirection.West);
            imageRight = new Bitmap(imageRight, new Size(tailleCellule, tailleCellule));
            imageLeft = new Bitmap(imageLeft, new Size(tailleCellule, tailleCellule));
        }

        public override void paint(Graphics g)
        {
            g.DrawImage(imageLeft, new Point(CoordonneeXEchelle, CoordonneeYEchelle));
        }

       

        private Bitmap LoadImageWithDirection(VehiculeDirection direction)
        {
            Bitmap image = null;
            if(direction == VehiculeDirection.West)
            {
                image = new Bitmap(global::SPTR.Properties.Resources.myCarLeft);
            }
            else if (direction == VehiculeDirection.East)
            {
                image = new Bitmap(global::SPTR.Properties.Resources.myCarRight);
            }

            return image;

        }

        private Bitmap imageRight;
        private Bitmap imageLeft;
        private VehiculeDirection carActualDirection
        {
            get;
            set;
        }
    }
}
