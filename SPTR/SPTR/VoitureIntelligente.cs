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

        private struct AvailableDirection
        {
            internal static bool sud;
            internal static bool est;
            internal static bool ouest;
            internal static bool nord;
        }

        private void initAvailableDirection()
        {
            AvailableDirection.nord = false;
            AvailableDirection.sud = false;
            AvailableDirection.est = false;
            AvailableDirection.ouest = false;
        }

        public VoitureIntelligente(int x, int y, int tailleCellule, string direction, int goalPointX, int goalPointY) : base(x, y, tailleCellule, direction)
        {
            CoordonneeDeFinX = (double)goalPointX;
            CoordonneeDeFinY = (double)goalPointY;
            OldDirection = carActualDirection;

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
            foreach (Direction dir in Enum.GetValues(typeof(Direction))) {
                if (tryDirection(dir, grille))
                {
                    list.Add(dir);
                }
            }
            carActualDirection = old;
            return list;
        }

        private void updateAvailableDirection(Grille grille)
        {
            AvailableDirection.est = isAsphalt(grille, CoordonneeXInt + 1, CoordonneeYInt);
            AvailableDirection.nord = isAsphalt(grille, CoordonneeXInt, CoordonneeYInt - 1);
            AvailableDirection.ouest = isAsphalt(grille, CoordonneeXInt - 1, CoordonneeYInt);
            AvailableDirection.sud = isAsphalt(grille, CoordonneeXInt, CoordonneeYInt + 1);
        }

        private bool tryDirection(Direction newDirection, Grille grille)
        {
            bool success = false;
            switch (newDirection)
            {
                case Direction.EST:
                    if (isAsphalt(grille, CoordonneeXInt + 1, CoordonneeYInt)) {
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
            if (success)
                carActualDirection = newDirection;

            return success;
        }

        private bool updateToMyBestDirectionIfPossible(Grille grille)
        {
            bool chooseEast = CoordonneeDeFinX - CoordonneeXInt > 0;
            bool chooseSouth = CoordonneeDeFinY - CoordonneeYInt > 0;
            Random rnd = new Random();
            speed = rnd.Next(4, 7);


            bool changeDirectionSucceed = false;

            if (CoordonneeXInt == (int)CoordonneeDeFinX && CoordonneeYInt == (int)CoordonneeDeFinY)
            {
                speed = 0;
                return changeDirectionSucceed;
            }

            if (chooseEast && carActualDirection != Direction.OUEST && carActualDirection != Direction.EST)
            {
                changeDirectionSucceed = tryDirection(Direction.EST, grille); ;
            }

            if (!chooseEast && carActualDirection != Direction.EST && carActualDirection != Direction.OUEST)
            {
                changeDirectionSucceed = tryDirection(Direction.OUEST, grille);
            }

            if (chooseSouth && carActualDirection != Direction.NORD && carActualDirection != Direction.SUD)
            {
                changeDirectionSucceed = tryDirection(Direction.SUD, grille);
            }

            if (!chooseSouth && carActualDirection != Direction.SUD && carActualDirection != Direction.NORD)
            {
                changeDirectionSucceed = tryDirection(Direction.NORD, grille);
            }

            return changeDirectionSucceed;
        }

        private bool directionIsSameAsLastTime()
        {
            return OldDirection == carActualDirection;
        }

        private Direction getAValidDirection(Direction carLastDirection)
        {
            Direction newDirection = carLastDirection;
            if (carLastDirection == Direction.NORD || carLastDirection == Direction.SUD)
            {
                if (AvailableDirection.est == true)
                    newDirection = Direction.EST;
                else
                    newDirection = Direction.OUEST;
            }
            else if (carLastDirection == Direction.EST || carLastDirection == Direction.OUEST)
            {
                if (AvailableDirection.nord == true)
                    newDirection = Direction.NORD;
                else
                    newDirection = Direction.SUD;
            }

            return newDirection;
        }

        public double update(int temps, Grille grille)
        {
            OldDirection = carActualDirection;
            updateAvailableDirection(grille);

            if (updateToMyBestDirectionIfPossible(grille))
                return speed;
           
            if (directionIsSameAsLastTime() && !tryDirection(carActualDirection, grille))
            {
                carActualDirection = getAValidDirection(carActualDirection);
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
        public Direction OldDirection
        {
            get;
            set;
        }
    }
}
