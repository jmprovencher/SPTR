using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{

    public class Voiture
    {
        public Voiture(int x, int y, int tailleCellule, string direction)
        {
            // load le PNG ici...
            CoordonneeX = (double)x;
            CoordonneeY = (double)y;
            carActualDirection = direction;
            imageRight = LoadImageWithDirection("E");
            imageLeft = LoadImageWithDirection("O");
            imageRight = new Bitmap(imageRight);
            imageLeft = new Bitmap(imageLeft);
            points = new Point[3];
            TailleCellule = tailleCellule;
            points[0] = new Point(CoordonneeXEchelle, CoordonneeYEchelle);
            points[1] = new Point(CoordonneeXEchelle + TailleCellule, CoordonneeYEchelle);
            points[2] = new Point(CoordonneeXEchelle, CoordonneeYEchelle + TailleCellule);
            
        }

        public void paint(Graphics g)
        {
            //update les points?
            points[0].X = CoordonneeXEchelle;
            points[0].Y = CoordonneeYEchelle;
            points[1].X = CoordonneeXEchelle+TailleCellule;
            points[1].Y = CoordonneeYEchelle;
            points[2].X = CoordonneeXEchelle;
            points[2].Y = CoordonneeYEchelle + TailleCellule;
            g.DrawImage(imageLeft, points);
        }

       

        private Bitmap LoadImageWithDirection(string direction)
        {
            Bitmap image = null;
            if(direction == "O")
            {
                image = new Bitmap(global::SPTR.Properties.Resources.myCarLeft);
            }
            else if (direction == "E")
            {
                image = new Bitmap(global::SPTR.Properties.Resources.myCarRight);
            }

            return image;

        }

        public void run(double vitesseEchelle)
        {

            switch (carActualDirection)
            {
                case "N":
                    CoordonneeY -= vitesseEchelle;
                    break;
                case "S":
                    CoordonneeY += vitesseEchelle;
                    break;
                case "E":
                    CoordonneeX += vitesseEchelle;
                    break;
                case "O":
                    
                    CoordonneeX -= vitesseEchelle;
                    break;
                default:
                    break;
            }
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



        public int TailleCellule;
        private Bitmap imageRight;
        private Bitmap imageLeft;
        private Point[] points;
        public string carActualDirection
        {
            get;
            set;
        }
    }
}
