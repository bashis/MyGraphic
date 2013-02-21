using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double xMin = -100, xMax = 100;
        int y0;
        double scaleX = 100, scaleY = 100;
        double step = 0.001;

        private void Form1_Load(object sender, EventArgs e)
        {
            y0 = pictureBox1.Height / 2;
        }

        void DrawLine(double x1, double y1, double x2, double y2)
        {
            pictureBox1.CreateGraphics().DrawLine(Pens.Black, new Point((int)(x1), (int)(y1) + y0), new Point((int)(x2), (int)(y2) + y0));
        }

        double Function(double x)
        {
            return Math.Pow(x, 3);
            //return Math.Sin(x);
        }

        void DrawCoordinates(int x0, int y0)
        {
            double angle2 = Math.PI / 3;
            DrawLine(x0, y0 - pictureBox1.Height, x0, y0 + pictureBox1.Height);
            //   DrawLine(x0, y0, Math.Sin(angle2) * x0, Math.Cos(angle2) * y0);
            int l = 1000;

            pictureBox1.CreateGraphics().DrawLine(Pens.RoyalBlue, x0 - (int)(Math.Sin(angle2) * l), y0 - (int)(Math.Cos(angle2) * l), x0 + (int)(Math.Sin(angle2) * l), y0 + (int)(Math.Cos(angle2) * l));

            pictureBox1.CreateGraphics().DrawLine(Pens.RoyalBlue, x0 + (int)(Math.Sin(angle2) * l), y0 - (int)(Math.Cos(angle2) * l), x0 - (int)(Math.Sin(angle2) * l), y0 + (int)(Math.Cos(angle2) * l));
            //DrawLine(x0, y0, Math.Sin(angle2) * x0, -Math.Cos(angle2) * y0);
            pictureBox1.CreateGraphics().DrawRectangle(Pens.Red, x0, y0, 10, 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawCoordinates(500, 100);

            //double xPrev = xMin, yPrev = Function(xMin);
            //for (double x = xMin; x < xMax; x=x+step)
            //{
            //    //DrawLine(xPrev * scaleX, yPrev * scaleY, x * scaleX, Function(x) * scaleY);
            //    //xPrev = x;
            //    //yPrev = Function(x);
            //    button1.Enabled = false;
            //    DrawPoint((int)(x*scaleX), (int)(Function(x)*scaleY) + y0);
            //    if ((x * scaleX) > pictureBox1.Width) break;

            //}
            button1.Enabled = true;
            //  DrawPoint(10, 10);
        }

        private void DrawPoint(int x, int y)
        {
            Bitmap pixel = new Bitmap(1, 1);
            Graphics g = pictureBox1.CreateGraphics();
            //lock (g)
            //{
            pixel.SetPixel(0, 0, Color.Red);
            g.DrawImageUnscaled(pixel, x, y);
            // }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
