using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    class VoitureIntelligente : Voiture
    {
        public VoitureIntelligente(int x, int y, int tailleCellule, string direction) : base(x, y, tailleCellule, direction)
        {
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
    }
}
