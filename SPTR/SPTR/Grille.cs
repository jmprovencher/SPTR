using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public class Grille
    {
        public Grille(int nbCellules, int tailleCellules, int origineX, int origineY)
        {
            NbCellules = nbCellules;
            TailleCellules = tailleCellules;
            ListesCellules = new List<List<Cellule>>();
            OrigineX = origineX;
            OrigineY = origineY;
            for (int i = 0; i< NbCellules; i++)
            {
                ListesCellules.Add( new List<Cellule>());
                for (int j = 0; j < NbCellules; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        ListesCellules[i].Add(new Numero(i + OrigineX, j + OrigineY, TailleCellules));
                        continue;
                    }
                    ListesCellules[i].Add(new Cellule(i+OrigineX,j+OrigineY, TailleCellules));
                }
            }
        }

        public Cellule getCellule(int i, int j)
        {
            return ListesCellules[i - OrigineX][j-OrigineY];
        }

        public Cellule getCelluleDroite(int x, int y, string direction)
        {
            if (direction == "O")
            {
                if (y == 1)
                {
                    return null;
                }
                else
                {
                    return getCellule(x, y - 1);
                }
            }
            if (direction == "E")
            {
                if (y == NbCellules-1)
                {
                    return null;
                }
                else
                {
                    return getCellule(x, y +1);
                }
            }
            if (direction == "N")
            {
                if (x == NbCellules-1)
                {
                    return null;
                }
                else
                {
                    return getCellule(x+1, y);
                }
            }
            if (direction == "S")
            {
                if (x == 1)
                {
                    return null;
                }
                else
                {
                    return getCellule(x-1, y);
                }
            }
            return null;
        }
        
        public void setCellule(int i, int j, Cellule c)
        {
            ListesCellules[i - OrigineX][j - OrigineY] = c;
        }

        public void paint(Graphics g)
        {
            foreach (List<Cellule> l in ListesCellules)
            {
                foreach (Cellule c in l)
                {
                    c.paint(g);
                }
            }

            //Make a 32x32 grid
            Pen p = new Pen(Color.FromArgb(255, 0, 0, 0));

            for (int y = OrigineY; y <= NbCellules + OrigineY; ++y)
            {
                g.DrawLine(p, OrigineY*TailleCellules, y * TailleCellules, (NbCellules+OrigineY) * TailleCellules, y * TailleCellules);
            }

            for (int x = OrigineX; x <= NbCellules + OrigineX; ++x)
            {
                g.DrawLine(p, x * TailleCellules, OrigineX*TailleCellules, x * TailleCellules, (NbCellules+OrigineX) * TailleCellules);
            }
            
        }

        private List<List<Cellule>> ListesCellules; 
        public int NbCellules { get; set; }
        public int TailleCellules { get; set; }
        public int OrigineX { get; set; }
        public int OrigineY { get; set; }
    }
}
