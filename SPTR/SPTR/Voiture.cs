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
            imageRight = new Bitmap(imageRight);
            imageLeft = new Bitmap(imageLeft);
            points = new Point[3];
            points[0] = new Point(CoordonneeXEchelle, CoordonneeYEchelle);
            points[1] = new Point(CoordonneeXEchelle + TailleCellule, CoordonneeYEchelle);
            points[2] = new Point(CoordonneeXEchelle, CoordonneeYEchelle + TailleCellule);
        }

        public override void paint(Graphics g)
        {
            g.DrawImage(imageLeft, points);
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
        private Point[] points;
        private VehiculeDirection carActualDirection
        {
            get;
            set;
        }
    }
}
