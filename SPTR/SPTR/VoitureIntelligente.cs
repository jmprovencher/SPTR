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

        private double speed = 5;
        private int targetI = 27;
        private int targetJ = 17;

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

        private bool isAsphalt(Grille grille, int i, int j)
        {
            return grille.getCellule(i, j) is Asphalte;
        }

        private List<Direction> directionsAvailable(Grille grille)
        {
            List<Direction> list = new List<Direction>();
            Direction old = carActualDirection;
            foreach(Direction dir in  Enum.GetValues(typeof(Direction))){
                if (tryDirection(dir, grille))
                {
                    list.Add(dir);
                }
            }
            carActualDirection = old;
            return list;
        }

        private bool tryDirection(Direction newDirection, Grille grille)
        {
            bool success = false;
            switch (newDirection)
            {
                case Direction.EST:
                    if (isAsphalt(grille, CoordonneeXInt + 1, CoordonneeYInt)){
                        CoordonneeX = CoordonneeXInt + 1;
                        CoordonneeY = CoordonneeYInt;
                        success = true;
                    }
                    break;
                case Direction.NORD:
                    if (isAsphalt(grille, CoordonneeXInt, CoordonneeYInt - 1))
                    {
                        CoordonneeX = CoordonneeXInt;
                        CoordonneeY = CoordonneeYInt - 1;
                        success = true;
                    }
                    break;
                case Direction.OUEST:
                    if (isAsphalt(grille, CoordonneeXInt - 1, CoordonneeYInt))
                    {
                        CoordonneeX = CoordonneeXInt - 1;
                        CoordonneeY = CoordonneeYInt;
                        success = true;
                    }
                    break;
                case Direction.SUD:
                    if (isAsphalt(grille, CoordonneeXInt, CoordonneeYInt + 1))
                    {
                        CoordonneeX = CoordonneeXInt;
                        CoordonneeY = CoordonneeYInt + 1;
                        success = true;
                    }
                    break;
            }
            if(success)
                carActualDirection = newDirection;

            return success;
        }

        public double update(int temps, Grille grille)
        {
            bool chooseEast = CoordonneeDeFinX - CoordonneeXInt > 0;
            bool chooseSouth = CoordonneeDeFinY - CoordonneeYInt > 0;

            if (CoordonneeXInt == (int)CoordonneeDeFinX && CoordonneeYInt == (int)CoordonneeDeFinY)
            {
                speed = 0;
                return speed;
            }

            if (chooseEast && carActualDirection != Direction.OUEST && carActualDirection != Direction.EST)
            {
                tryDirection(Direction.EST, grille);
                return speed;
            }

            if (!chooseEast && carActualDirection != Direction.EST && carActualDirection != Direction.OUEST)
            {
                tryDirection(Direction.OUEST, grille);
                return speed;
            }

            if (chooseSouth && carActualDirection != Direction.NORD && carActualDirection != Direction.SUD)
            {
                tryDirection(Direction.SUD, grille);
                return speed;
            }

            if (!chooseSouth && carActualDirection != Direction.SUD && carActualDirection != Direction.NORD)
            {
                tryDirection(Direction.NORD, grille);
                return speed;
            }

           

            return speed;
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
