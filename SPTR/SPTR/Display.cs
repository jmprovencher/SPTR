using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPTR
{
    public partial class Display : Panel
    {
        public float scale = 1;
        public int centerPositionX = 0;
        public int centerPositionY = 0;
        public bool left_click_hold = false;
        public int pressedX = 0;
        public int pressedY = 0;

        public Display()
        {
            this.DoubleBuffered = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.display_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.display_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.display_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.display_MouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.display_MouseWheel);
        }


        public int getGridPositionX(int mouseX)
        {
            return (int)(mouseX / scale - (-1 + (1 / scale)) * Width / 2 - centerPositionX);
        }

        public int getGridPositionY(int mouseY)
        {
            return (int)(mouseY / scale - (-1 + (1 / scale)) * Height / 2 - centerPositionY);
        }

        private void display_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w = Width;// real width of canvas
            int h = Height;// real height of canvas


            g.TranslateTransform((w / 2) - ((w / 2 - centerPositionX) * (scale)),
                        (h / 2) - ((h / 2 - centerPositionY) * (scale)));
            g.ScaleTransform(scale, scale);
            // Create string to draw.
            String drawString = "SPTR";

            // Create font and brush.
            Font drawFont = new Font("Arial", 30);
            SolidBrush drawBrush = new SolidBrush(Color.DarkGray);

            // Create point for upper-left corner of drawing.
            PointF drawPoint = new PointF(0, 0);

            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);

            //Make a 32x32 grid
            Pen p = new Pen(Color.FromArgb(255, 0, 0, 0));
            int numOfCells = 32;
            int cellSize = 10;

            for (int y = 0; y < numOfCells + 1; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells + 1; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }

        private void display_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                left_click_hold = true;
                pressedX = (int)(e.X / scale - (-1 + (1 / scale)) * Width / 2 - centerPositionX);
                pressedY = (int)(e.Y / scale - (-1 + (1 / scale)) * Height / 2 - centerPositionY);
            }
        }

        private void display_MouseMove(object sender, MouseEventArgs e)
        {
            if (left_click_hold)
            {
                centerPositionX -= pressedX - getGridPositionX(e.X);
                centerPositionY -= pressedY - getGridPositionY(e.Y);
                Refresh();
            }
        }

        private void display_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                left_click_hold = false;
            }
        }

        private void display_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            float scaleFactor = 1.1F;
            if (e.Delta > 0)
            {
                scale = scale * scaleFactor;
            }
            else if (e.Delta < 0)
            {
                scale = scale / scaleFactor;
            }
            Refresh();
        }

    }

}