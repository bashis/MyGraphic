using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pen coordinatePen = Pens.Blue;
        double xMin = -100, xMax = 100;
        //int y0;
        double scaleX = 100, scaleY = 100;
        double step = 0.05;





        //double a=0, b=225, c=45;
        public static Color graphColor = Color.Red, netColor = Color.DeepPink, coordColor = Color.DimGray;
        private void Form1_Load(object sender, EventArgs e)
        {
            a = 0;
            b = 45;
            c = 225;
            SpinTimer.Interval = 10;
            SpinTimer.Tick += new EventHandler(SpinTimer_Tick);
        }
        #region angles
        private double angleA = 0;

        public double a
        {
            get { return angleA; }
            set 
            { 
                angleA = value%360;
                angleLabelA.Text = "a=" + (value%360).ToString();
            }
        }
        private double angleB = 255;

        public double b
        {
            get { return angleB; }
            set 
            { 
                angleB = value%360;
                angleLabelB.Text = "b=" + (value%360).ToString();
            }
        }
        private double angleC = 45;

        public double c
        {
            get { return angleC; }
            set 
            {
                angleC = value%360;
                angleLabelC.Text = "c=" + (value%360).ToString();
            }
        }


        double sin(double x)
        {
            return Math.Sin(x * Math.PI / 180);
        }
        double cos(double x)
        {
            return Math.Cos(x * Math.PI / 180);
        }
        double l1()
        {
            return cos(a) * cos(c) - cos(b) * sin(a) * sin(c);
        }
        double m1()
        {
            return sin(a) * cos(c) + cos(b) * cos(a) * sin(c);
        }
        double n1()
        {
            return sin(b) * sin(c);
        }
        double l2()
        {
            return -cos(a) * sin(c) + cos(b) * sin(a) * cos(c);
        }
        double m2()
        {
            return -sin(a) * sin(c) + cos(b) * cos(a) * cos(c);
        }
        double n2()
        {
            return sin(b) * cos(c);
        }
        double l3()
        {
            return sin(b) * sin(a);
        }
        double m3()
        {
            return -sin(b) * cos(a);
        }
        double n3()
        {
            return cos(b);
        }
        #endregion

        double Function(double x, double y)
        {
            try
            {
                return Math.Sqrt( x * x + y * y);
            }
            catch (Exception)
            {
                return double.NaN;
            }
        }

  

        void DrawCoordinates(int x0, int y0, Graphics g)
        {

           // double angle2 = Math.PI / 3;
           // g.DrawLine(new Pen(coordColor, 1), x0, y0 - pictureBox1.Height, x0, y0 + pictureBox1.Height);

            int l = 100;
            int p,q,r;
            p=l;
            q=0;
            r=0;
            Point coord=new Point(x0+(int)(l1() * p + l2() * q + l3() * r), y0-(int)(m1() * p + m2() * q + m3() * r));
            g.DrawLine(new Pen(coordColor, 1), new Point(x0, y0), coord);
            g.DrawString("X", new Font("Arial", 14f), new SolidBrush(coordColor), coord);
            p = 0;
            q = l;
            r = 0;
            coord = new Point(x0 + (int)(l1() * p + l2() * q + l3() * r), y0 - (int)(m1() * p + m2() * q + m3() * r));
            g.DrawLine(new Pen(coordColor, 1), new Point(x0, y0), coord);
            g.DrawString("Y", new Font("Arial", 14f), new SolidBrush(coordColor), coord);
            p = 0;
            q = 0;
            r = l;
            coord = new Point(x0 + (int)(l1() * p + l2() * q + l3() * r), y0 - (int)(m1() * p + m2() * q + m3() * r));
            g.DrawLine(new Pen(coordColor, 1), new Point(x0, y0), coord);
            g.DrawString("Z", new Font("Arial", 14f), new SolidBrush(coordColor), coord);
            //new Point(x0 + newPoint.X, y0 - newPoint.Y)


           // g.DrawLine(new Pen(coordColor, 1), x0 - (int)(Math.Sin(angle2) * l), y0 - (int)(Math.Cos(angle2) * l), x0 + (int)(Math.Sin(angle2) * l), y0 + (int)(Math.Cos(angle2) * l));

            //g.DrawLine(new Pen(coordColor, 1), x0 + (int)(Math.Sin(angle2) * l), y0 - (int)(Math.Cos(angle2) * l), x0 - (int)(Math.Sin(angle2) * l), y0 + (int)(Math.Cos(angle2) * l));
           // for (int i = -1000; i < 1000; i += 10)
            //{
            //    DrawMark(i, coordinate.X, x0, y0, angle2, g);
             //   DrawMark(i, coordinate.Y, x0, y0, angle2, g);
           // }
        }

        public void DrawGraph(int xMin, int yMin, int xMax, int yMax, int x0, int y0, Graphics g)
        {
            //howmuchisdone = 0;
            for (double p = xMin; p < xMax; p += step)
            {
                for (double q = yMin; q < yMax; q += step)
                {
                    //howmuchisdone += 1;
                    double funcValue = Function(p, q);
                    if (!double.IsNaN(funcValue))
                    {
                        int y = y0 - (int)funcValue;
                        //   Color clr = Color.Red;
                        Point newPoint = GetPoint(p, q);
                        DrawPoint(x0 + newPoint.X, y0 - newPoint.Y, g, graphColor);
                        // DrawPoint((int)(x0 + p * Math.Cos(Math.PI / 6) + q * Math.Cos(Math.PI / 6)), (int)(y0 - funcValue), g, clr);//oldPoint.X * Math.Cos(Math.PI / 3) - oldPoint.Y * Math.Cos(Math.PI / 3)));//(int)Function(newPoint.X, newPoint.Y));
                    }
                }
            }
        }

        //int howmuchisdone = 0;

        void DrawStructure2(int xMin, int yMin, int xMax, int yMax, int x0, int y0, int structStep, Graphics g)
        {
            Point[,] structPoints = new Point[(xMax - xMin) / structStep + 1, (yMax - yMin) / structStep + 1];
            int pcnt = 0, qcnt = 0;
            for (double p = xMin; p <= xMax; p += structStep)
            {
                qcnt = 0;
                for (double q = yMin; q <= yMax; q += structStep)
                {
                    // howmuchisdone++;
                    Point newPoint = GetPoint(p, q);
                    if (!(newPoint.X < -10000 || newPoint.Y < -10000))
                    {

                        structPoints[pcnt, qcnt] = new Point(x0 + newPoint.X, y0 - newPoint.Y);
                    }


                    qcnt++;
                }
                pcnt++;
            }
            List<Point> pointArr = new List<Point>();
            for (int i = 0; i < structPoints.GetLength(0) - 1; i++)
            {
                pointArr.Clear();
                for (int j = 0; j < structPoints.GetLength(1) - 1; j++)
                {
                    if (!structPoints[i, j].IsEmpty)
                    {

                        pointArr.Add(structPoints[i, j]);
                    }
                }
                if (pointArr.Count > 1)
                {
                    g.DrawCurve(new Pen(netColor, 1), pointArr.ToArray());
                }



            }

            for (int i = 0; i < structPoints.GetLength(1) - 1; i++)
            {
                pointArr.Clear();
                for (int j = 0; j < structPoints.GetLength(0) - 1; j++)
                {
                    if (!structPoints[i, j].IsEmpty)
                    {

                        pointArr.Add(structPoints[j, i]);
                    }
                }
                if (pointArr.Count > 1)
                {
                    g.DrawCurve(new Pen(netColor, 1), pointArr.ToArray());
                }



            }
            //howmuchisdone = 0;

        }
        //void DrawStructure(int xMin, int yMin, int xMax, int yMax, int x0, int y0, int structStep, Graphics g)
        //{
        //    // Point lastPainted = new Point();
        //    //int myStep = Math.Max((int)step, 1);



        //    for (double p = xMin; p <= xMax; p += step)
        //    {
        //        for (double q = yMin; q <= yMax; q += step)
        //        {
        //            //howmuchisdone++;
        //            double funcValue = Function(p, q);
        //            int y = y0 - (int)funcValue;
        //            if (((int)p % structStep == 0 || (int)q % structStep == 0 || (int)funcValue == 0) && ((!double.IsNaN(funcValue))))
        //            {
        //                //  Color clr = Color.Black;
        //                Point newPoint = GetPoint(p, q);
        //                DrawPoint(x0 + newPoint.X, y0 - newPoint.Y, g, netColor);//(int)(x0 + p * Math.Cos(Math.PI / pina) - q * Math.Cos(Math.PI / pina)), (int)(y0 + p * Math.Sin(Math.PI / pina) + q * Math.Sin(Math.PI / pina) - funcValue), g, clr);//oldPoint.X * Math.Cos(Math.PI / 3) - oldPoint.Y * Math.Cos(Math.PI / 3)));//(int)Function(newPoint.X, newPoint.Y)); 
        //            }
        //        }
        //    }
        //}
        Point GetPoint(double p, double q)
        {
            double r = Function(p, q);
            return new Point((int)(l1() * p + l2() * q + l3() * r), (int)(m1() * p + m2() * q + m3() * r));

        }
        enum coordinate
        {
            X, Y
        }
        void DrawMark(double value, coordinate coord, int x0, int y0, double angle2, Graphics g)
        {
            int l = 2;
            switch (coord)
            {
                case coordinate.X:
                    g.DrawLine(Pens.RoyalBlue, x0 - (int)(Math.Sin(angle2) * value), y0 - (int)(Math.Cos(angle2) * value) - l, x0 - (int)(Math.Sin(angle2) * value), y0 - (int)(Math.Cos(angle2) * value) + l);
                    break;
                case coordinate.Y:
                    g.DrawLine(Pens.RoyalBlue, x0 + (int)(Math.Sin(angle2) * value), y0 - (int)(Math.Cos(angle2) * value) - l, x0 + (int)(Math.Sin(angle2) * value), y0 - (int)(Math.Cos(angle2) * value) + l);
                    break;
                default:
                    break;
            }
        }
        Graphics g;// = Graphics.FromImage(result);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                step = Convert.ToDouble(textBox1.Text.Replace('.', ','));
                int x0 = pictureBox1.Width / 2, y0 = pictureBox1.Height / 2;
                Bitmap result = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(result);
                using (g)
                {

                    button1.Enabled = false;
                    // Thread DrawGraphThread = new Thread(new ThreadStart(this.stuff));
                    if (coordCB.Checked) DrawCoordinates(x0, y0, g);
                    if (graphCB.Checked) DrawGraph(-100, -100, 100, 100, x0, y0, g);
                    if (netCB.Checked) DrawStructure2(-100, -100, 100, 100, x0, y0, 10, g);
                }

                pictureBox1.Image = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                button1.Enabled = true;
            }
        }
     
      
        private void DrawPoint(int x, int y, Graphics g, Color clr)
        {
            Bitmap pixel = new Bitmap(1, 1);
            pixel.SetPixel(0, 0, clr);
            g.DrawImageUnscaled(pixel, x, y);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ColorSelector cs = new ColorSelector();
            cs.Show();
        }

        //private void trackBar1_Scroll(object sender, EventArgs e)
        //{
        //    c = trackBar1.Value;
        //    int x0 = pictureBox1.Width / 2, y0 = pictureBox1.Height / 2;
        //    Bitmap result = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        //    g = Graphics.FromImage(result);
        //    using (g)
        //    {
        //        if (netCB.Checked) DrawStructure2(-100, -100, 100, 100, x0, y0, 10, g);
        //    }
        //    pictureBox1.Image = result;

        //}

        //private void trackBar2_Scroll(object sender, EventArgs e)
        //{
        //    b = trackBar2.Value;
        //    DrawNet();
        //}

        void DrawNet()
        {
            int x0 = pictureBox1.Width / 2, y0 = pictureBox1.Height / 2;
            Bitmap result = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(result);
            using (g)
            {
                if (coordCB.Checked) DrawCoordinates(x0, y0, g);
                if (netCB.Checked) DrawStructure2(-100, -100, 100, 100, x0, y0, 20, g);
            }
            pictureBox1.Image = result;

        }
        int prevX, prevY;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
              if (e.Button == MouseButtons.Left)
            {
                c -= e.X - prevX;
                b += e.Y - prevY;
                DrawNet();
            }
              prevX = e.X;
              prevY = e.Y;
        }

        System.Windows.Forms.Timer SpinTimer = new System.Windows.Forms.Timer();
        private bool freerunning = false;

        public bool FreeRunning
        {
            get { return freerunning; }
            set
            {
                freerunning = value;
                if (value)
                {
                    SpinTimer.Start();
                    button3.Text = "Stop";

                }
                else
                {
                    button3.Text = "Free";
                    SpinTimer.Stop();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FreeRunning = !FreeRunning;
        }

        void SpinTimer_Tick(object sender, EventArgs e)
        {
            b += 1;
            c += 0.5;
            DrawNet();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FreeRunning = false;
        }

        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {
            a += e.NewValue - e.OldValue ;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            a += e.Delta;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Width, pictureBox1.Height));
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.Filter = "PNG Image (*.png)|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception)
            {
               
               // throw;
            }
          
            
        }


    }
}
