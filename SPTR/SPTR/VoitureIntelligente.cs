using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public class VoitureIntelligente : Voiture
    {
        public VoitureIntelligente(int x, int y, int tailleCellule, string direction, int goalPointX, int goalPointY) : base(x, y, tailleCellule, direction)
        {
            CoordonneeDeFinX = (double)goalPointX;
            CoordonneeDeFinY = (double)goalPointY;
        }


        override public Bitmap LoadImageWithDirection(Direction dir)
        {
            Bitmap image = null;
            if (dir == Direction.OUEST)
            {
                image = new Bitmap(global::SPTR.Properties.Resources.myCarLeft);
            }
            else if (dir == Direction.EST)
            {
                image = new Bitmap(global::SPTR.Properties.Resources.myCarRight);
            }
            return image;
        }

        public double CoordonneeDeFinX
        {
            get;

            set;
        }

        public double CoordonneeDeFinY
        {
            get;

            set;
        }
    }
}
