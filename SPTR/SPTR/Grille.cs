using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public partial class Grille
    {
        public Grille(int nbCellules, int tailleCellules)
        {
            NbCellules = nbCellules;
            TailleCellules = tailleCellules;
            ListesCellules = new List<List<Cellule>>();
            for (int i = 0; i< NbCellules; i++)
            {
                ListesCellules.Add( new List<Cellule>());
                for (int j = 0; j < NbCellules; j++)
                {
                    ListesCellules[i].Add( new Vide(i,j));
                }
            }
        }

        public void paint(Graphics g)
        {
            //Make a 32x32 grid
            Pen p = new Pen(Color.FromArgb(255, 0, 0, 0));

            for (int y = 1; y <= NbCellules + 1; ++y)
            {
                g.DrawLine(p, TailleCellules, y * TailleCellules, (NbCellules+1) * TailleCellules, y * TailleCellules);
            }

            for (int x = 1; x <= NbCellules + 1; ++x)
            {
                g.DrawLine(p, x * TailleCellules, TailleCellules, x * TailleCellules, (NbCellules+1) * TailleCellules);
            }
            foreach (List<Cellule> l in ListesCellules)
            {
                foreach(Cellule c in l)
                {
                    c.paint(g);
                }
            }
        }

        public List<List<Cellule>> ListesCellules; 
        public int NbCellules { get; set; }
        public int TailleCellules { get; set; }
    }
}
