using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{

    public class Voiture
    {
        public enum Direction {EST, OUEST, NORD, SUD};
        public int TailleCellule;
        private Bitmap imageRight;
        private Bitmap imageLeft;
        private Point[] points;
        private Point[] points90;


        public Direction carActualDirection
        {
            get;
            set;
        }

        public Voiture(int x, int y, int tailleCellule, string direction)
        {
            // load le PNG ici...
            CoordonneeX = (double)x;
            CoordonneeY = (double)y;
            carActualDirection = dirFromString(direction);
            imageRight = LoadImageWithDirection(Direction.EST);
            imageLeft = LoadImageWithDirection(Direction.OUEST);
            points = new Point[3];
            points90 = new Point[3];
            TailleCellule = tailleCellule;
            MovingFlag = true;
            
        }

        public Direction dirFromString(string dir)
        {
            Direction direction = Direction.EST;
            switch (dir)
            {
                case "N":
                    direction = Direction.NORD;
                    break;
                case "S":
                    direction = Direction.SUD;
                    break;
                case "E":
                    direction = Direction.EST;
                    break;
                case "O":
                    direction = Direction.OUEST;
                    break;
                default:
                    break;
            }
            return direction;
        }

        public string getCarDirectionString()
        {
            string str = null;
            switch (carActualDirection)
            {
                case Direction.NORD:
                    str = "N";
                    break;
                case Direction.EST:
                    str = "E";
                    break;
                case Direction.SUD:
                    str = "S";
                    break;
                case Direction.OUEST:
                    str = "O";
                    break;
            }
            return str;
        }

        public void paint(Graphics g)
        {
            bool rotate90 = false;
            Bitmap image = imageLeft;

            updatePoints();

            switch (carActualDirection)
            {
                case Direction.NORD:
                    rotate90 = true;
                    image = imageRight;
                    break;
                case Direction.EST:
                    image = imageRight;
                    break;
                case Direction.SUD:
                    rotate90 = true;
                    image = imageLeft;
                    break;
                case Direction.OUEST:
                    image = imageLeft;
                    break;
            }

            if (rotate90)
                g.DrawImage(image, points90);
            else
                g.DrawImage(image, points);

        }

        private void updatePoints()
        {
            points[0].X = CoordonneeXEchelle;
            points[0].Y = CoordonneeYEchelle;
            points[1].X = CoordonneeXEchelle + TailleCellule;
            points[1].Y = CoordonneeYEchelle;
            points[2].X = CoordonneeXEchelle;
            points[2].Y = CoordonneeYEchelle + TailleCellule;

            points90[0].X = CoordonneeXEchelle;
            points90[0].Y = CoordonneeYEchelle + TailleCellule;
            points90[1].X = CoordonneeXEchelle;
            points90[1].Y = CoordonneeYEchelle;
            points90[2].X = CoordonneeXEchelle + TailleCellule;
            points90[2].Y = CoordonneeYEchelle + TailleCellule;
        }

       

        virtual public Bitmap LoadImageWithDirection(Direction dir)
        {
            Bitmap image = null;
            if(dir == Direction.OUEST)
            {
                image = new Bitmap(global::SPTR.Properties.Resources.carLeft);
            }
            else if (dir == Direction.EST)
            {
                image = new Bitmap(global::SPTR.Properties.Resources.carRight);
            }
            return image;
        }

        public bool run(double vitesseEchelle)
        {
            int x_old = (int)CoordonneeX;
            int y_old = (int)CoordonneeY;
            bool nouvelleCellule = false;
            switch (carActualDirection)
            {
                case Direction.NORD:
                    CoordonneeY -= vitesseEchelle;
                    break;
                case Direction.SUD:
                    CoordonneeY += vitesseEchelle;
                    break;
                case Direction.EST:
                    CoordonneeX += vitesseEchelle;
                    break;
                case Direction.OUEST:
                    CoordonneeX -= vitesseEchelle;
                    break;
                default:
                    break;
            }

            //if (x_old != (int)CoordonneeX || y_old != (int)CoordonneeY)
                nouvelleCellule = true;

            return nouvelleCellule;
        }

        public bool MovingFlag
        {
            get;
            set;
        }

        public double CoordonneeX
        {
            get;

            set;
        }

        public double CoordonneeY
        {
            get;

            set;
        }

        public int CoordonneeXEchelle
        {
            get { return (int)(CoordonneeX * TailleCellule); }
        }

        public int CoordonneeYEchelle
        {
            get { return (int)(CoordonneeY * TailleCellule); }
        }


    }
}
