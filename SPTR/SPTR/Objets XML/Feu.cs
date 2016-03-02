using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public enum Couleur { Rouge, Jaune, Vert };

    public class Feu : Cellule
    {
        public Feu():base(0,0,0)
        {
            // Constructor for the XML parser
        }

        public Feu(int cell_size, Feu feu):base(feu.CoordonneeX, feu.CoordonneeY, cell_size)
        {
            // Copy constructor to create the proper derived object from Cellule.
            Position = feu.Position;
            Duree = feu.Duree;
            CouleurFeu = Couleur.Rouge;
        }
        
        public override void paint(Graphics g)
        {
            //Console.WriteLine(CoordonneeX);
            SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            if (CouleurFeu == Couleur.Jaune) { myBrush.Color = Color.Yellow; }
            else if(CouleurFeu == Couleur.Vert) { myBrush.Color = Color.Green; }
            g.FillRectangle(myBrush, new Rectangle((CoordonneeX)*TailleCellule, (CoordonneeY)* TailleCellule, TailleCellule, TailleCellule));
            myBrush.Color = Color.Black;

            // Create font and brush.
            Font drawFont = new Font("Arial", (int)(TailleCellule*0.7));
            SolidBrush drawBrush = new SolidBrush(Color.WhiteSmoke);

            // Create point for upper-left corner of drawing.
            PointF drawPoint = new PointF(CoordonneeX*TailleCellule, CoordonneeY*TailleCellule);
            //Console.WriteLine("Writing: " + Position+" at:" +CoordonneeX+" , "+CoordonneeY);
            // Draw string to screen.
            g.DrawString(Position, drawFont, drawBrush, drawPoint);
        }

        public override int CoordonneeX { get; set; }
        public override int CoordonneeY { get; set; }
        public string Position { get; set; }
        public int Duree { get; set; }
        public Couleur CouleurFeu{ get; set; }

    }
}
