using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    public interface Cellule
    {
        void paint(Graphics g);

        int CoordonneeX
        {
            get;

            set;
        }

        int CoordonneeY
        {
            get;

            set;
        }
    }
}
