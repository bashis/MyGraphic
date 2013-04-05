using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MathParser;
using MathParser.TextModel;
using System.Diagnostics;
using FormExtensions;
using System.Threading.Tasks;

namespace Graph
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Структура, отвечающая за хранение точек со значениями функции в памяти
        /// </summary>
        struct PointValue
        {
            public double X, Y, Value; //координаты точки и значение функции в этой точке
            public PointValue(double X, double Y)
            {
                this.X = X; //конструктор координаты X
                this.Y = Y; //конструктор координаты Y
                this.Value = Function(X, Y); //конструктор координаты Value (значение функции)
            }

        }

        List<PointValue> ValueList = new List<PointValue>(); //Список точек и значений функции в них, уже загруженных в память


        public Form1()
        {
            InitializeComponent(); //Загрузка формы
        }

        Pen coordinatePen = Pens.Blue; //Ручка для отрисовки координатных осей
        int xMin = -100, xMax = 100; //Максимум и минимум, на которые должен отрисовываться график, по оси Х
        int yMin = -100, yMax = 100; //Максимум и минимум, на которые должен отрисовываться график, по оси Y
        //int y0;
        // double scaleX = 100, scaleY = 100;
        double step = 0.05; // Шаг закраски точек при отрисовке поверхности

        /// <summary>
        /// Восстановление коэфициентов Эйлера по умолчанию
        /// </summary>
        void RestoreAngles()
        {
            a = 0;
            b = -90;
            c = 0;
        }

        public static Color graphColor = Color.Red, netColor = Color.DeepPink, coordColor = Color.DimGray; //Цвета графика, сетки и координат
        private void Form1_Load(object sender, EventArgs e)
        {
            this.scheduler = TaskScheduler.FromCurrentSynchronizationContext(); //Инициализация помощника Tasks
            ChangeSourceData(); //Задать текущую формулу формулой по умолчанию из текстбокса
            RestoreAngles(); //Задать коэффициенты Эйлера
            SpinTimer.Interval = 10; //Задать интервал таймера вращения графика
            SpinTimer.Tick += new EventHandler(SpinTimer_Tick); //Привязываем событие Tick к таймеру
        }
        #region angles
        // поиск коэфициентов для матрицы Эйлера преобразования координат. 

        private double angleA;
        public double a
        {
            get { return angleA; }
            set
            {
                angleA = value % 360;
                angleLabelA.Text = "a=" + (value % 360).ToString();
            }
        }

        private double angleB;
        public double b
        {
            get { return angleB; }
            set
            {
                angleB = value % 360;
                angleLabelB.Text = "b=" + (value % 360).ToString();
            }
        }

        private double angleC;
        public double c
        {
            get { return angleC; }
            set
            {
                angleC = value % 360;
                angleLabelC.Text = "c=" + (value % 360).ToString();
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


        static Parser parser = new Parser(); //Объявление парсера формулы

        /// <summary>
        /// Вычисление значения функции из текстбокса
        /// </summary>
        /// <param name="x">координата X</param>
        /// <param name="y">координата Y</param>
        /// <returns></returns>
        static double Function(double x, double y)
        {
            Parser p = new Parser();
            string tmp; // Текущее значение текстбокса будет храниться здесь.
            tmp = s.ToLower().Replace("x", x.ToString()).Replace("y", y.ToString()); //Заменяем в формуле все x и y на соответствующие им численные значения.

            var parsingResult = p.Parse(tmp); //Парсим формулу
            return (double)parsingResult.Evaluate(); //Вычисляем значение формулы

        }

        /// <summary>
        /// Поиск значения функции по координатам в списке. Если точки с такими координатами нет, она будет добавлена.
        /// </summary>
        /// <param name="x">координата X</param>
        /// <param name="y">координата Y</param>
        /// <returns></returns>
        double GetValue(double x, double y)
        {
            for (int i = 0; i < ValueList.Count; i++) //Проходим по всем элементам в списке
            {
                if (ValueList[i].X == x && ValueList[i].Y == y) //Если нашли точку с данными координатами X и Y
                {
                    return ValueList[i].Value; //Возвращаем значение функции в ней
                }
            }
            //Если прошли все точки, а подходящую так и не нашли
            PointValue newValue = new PointValue(x, y); //Объявляем новую точку по данным координатам
            ValueList.Add(newValue); //Добавляем её в список
            return newValue.Value; //Возвращаем значение функции в неё
        }


        /// <summary>
        /// Отрисовка координатных линий
        /// </summary>
        /// <param name="x0">Положение начала координат относительно контейнера по оси Х</param>
        /// <param name="y0">Положение начала координат относительно контейнера по оси Y</param>
        /// <param name="g">Графический контейнер, в котором будет производиться рисование</param>
        void DrawCoordinates(int x0, int y0, Graphics g)
        {

            int l = 100; //Длина координатной линии
            int p, q, r; //коэффициенты Эйлера
            p = l;
            q = 0;
            r = 0;
            Point coord = new Point(x0 + (int)(l1() * p + l2() * q + l3() * r), y0 - (int)(m1() * p + m2() * q + m3() * r)); //Вычисление конечной точки координатного отрезка X
            g.DrawLine(new Pen(coordColor, 1), new Point(x0, y0), coord); //Рисуем отрезок X по двум точкам
            g.DrawString("X", new Font("Arial", 14f), new SolidBrush(coordColor), coord); //Рисуем букву X, обозначающую координатный отрезок
            p = 0;
            q = l;
            r = 0;
            coord = new Point(x0 + (int)(l1() * p + l2() * q + l3() * r), y0 - (int)(m1() * p + m2() * q + m3() * r));//Вычисление конечной точки координатного отрезка Y
            g.DrawLine(new Pen(coordColor, 1), new Point(x0, y0), coord);//Рисуем отрезок Y по двум точкам
            g.DrawString("Y", new Font("Arial", 14f), new SolidBrush(coordColor), coord);//Рисуем букву Y, обозначающую координатный отрезок
            p = 0;
            q = 0;
            r = l;
            coord = new Point(x0 + (int)(l1() * p + l2() * q + l3() * r), y0 - (int)(m1() * p + m2() * q + m3() * r));//Вычисление конечной точки координатного отрезка Z
            g.DrawLine(new Pen(coordColor, 1), new Point(x0, y0), coord);//Рисуем отрезок Z по двум точкам
            g.DrawString("Z", new Font("Arial", 14f), new SolidBrush(coordColor), coord);//Рисуем букву Z, обозначающую координатный отрезок
        }



        private TaskScheduler scheduler = null;

        /// <summary>
        /// Поточечная отрисовка графика
        /// </summary>
        /// <param name="xMin">Минимальная координата функции по оси X</param>
        /// <param name="yMin">Минимальная координата функции по оси Y</param>
        /// <param name="xMax">Максимальная координата функции по оси X</param>
        /// <param name="yMax">Максимальная координата функции по оси Y</param>
        /// <param name="x0">Положение начала координат относительно контейнера по оси X</param>
        /// <param name="y0">Положение начала координат относительно контейнера по оси Y</param>
        /// <param name="g">Графический контейнер, в котором будет производиться отрисовка</param>
        public void DrawGraph(double xMin, double yMin, double xMax, double yMax, int x0, int y0, Graphics g)
        {

            for (double p = xMin; p < xMax; p += step) //Проходим по всем точкам на оси X с заданным шагом
            {
                for (double q = yMin; q < yMax; q += step) //Проходим по всем точкам на оси X с заданным шагом
                {
                    Point newPoint = GetPoint(p, q); //Получаем значение точки, которую надо отрисовать, по координатам
                    DrawPoint(x0 + newPoint.X, y0 - newPoint.Y, g, graphColor);
                    //       this.ThreadSafe(_ => DrawPoint(x0 + newPoint.X, y0 - newPoint.Y, g, graphColor)); //Рисуем эту точку
                          this.ThreadSafe(_ => _.pb.Value += 1);
                }
            }
        }

        /// <summary>
        /// Отрисовка сетки по форме функции
        /// </summary>
        /// <param name="xMin">Минимальная координата функции по оси X</param>
        /// <param name="yMin">Минимальная координата функции по оси Y</param>
        /// <param name="xMax">Максимальная координата функции по оси X</param>
        /// <param name="yMax">Максимальная координата функции по оси Y</param>
        /// <param name="x0">Положение начала координат относительно контейнера по оси X</param>
        /// <param name="y0">Положение начала координат относительно контейнера по оси Y</param>
        /// <param name="structStep">Шаг сетки</param>
        /// <param name="g">Графический контейнер, в котором будет производиться отрисовка</param>
        void DrawStructure2(double xMin, double yMin, double xMax, double yMax, int x0, int y0, int structStep, Graphics g)
        {
            Point[,] structPoints = new Point[(int)(xMax - xMin) / structStep + 1, (int)(yMax - yMin) / structStep + 1]; //точки, по которым производятся вычисления
            int pcnt = 0, qcnt = 0; //счетчики
            for (double p = xMin; p <= xMax; p += structStep) //в цикле проходим по всем точкам на оси Х
            {
                qcnt = 0;
                for (double q = yMin; q <= yMax; q += structStep) //в цикле проходим по всем точкам на оси Y
                {

                    Point newPoint = GetPoint(p, q); //Вычисляем значение функции в точке (спроецированное на текущую плоскость)
                 //   if (!(newPoint.X <= -x0 || newPoint.Y <= -y0 || newPoint.X > pictureBox1.Width || newPoint.Y > pictureBox1.Height)) //Если функция не вернула ошибку, то:
                    {

                        structPoints[pcnt, qcnt] = new Point(x0 + newPoint.X, y0 - newPoint.Y); //добавляем точку в массив для отрисовки
                    }


                    qcnt++;
                }
                pcnt++;
            }

            List<Point> pointArr = new List<Point>(); //Список точек для отрисовкки


            for (int i = 0; i < structPoints.GetLength(0) - 1; i++) //проходим по всем точкам в массиве по оси Х
            {
                pointArr.Clear(); //Очищаем список точек для отрисовки
                for (int j = 0; j < structPoints.GetLength(1) - 1; j++)//проходим по всем точкам в массиве по оси Y
                {
                    if (!(structPoints[i, j].X == 0 && structPoints[i, j].Y == 0))//Если в точке нет ошибки, то
                    {

                        pointArr.Add(structPoints[i, j]); //Добавляем точку в список отрисовки
                    }
                }
                if (pointArr.Count > 1) //Если список отрисовки создан, то
                {
                    g.DrawCurve(new Pen(netColor, 1), pointArr.ToArray()); //Рисуем кривую по точкам из списка отрисовки
                }



            }

            for (int i = 0; i < structPoints.GetLength(1) - 1; i++)//проходим по всем точкам в массиве по оси Y
            {
                pointArr.Clear(); //Очищаем список точек для отрисовки
                for (int j = 0; j < structPoints.GetLength(0) - 1; j++)//проходим по всем точкам в массиве по оси X
                {
                    if (!(structPoints[j, i].X == 0 && structPoints[j, i].Y == 0))//Если в точке нет ошибки, то
                    {

                        pointArr.Add(structPoints[j, i]);//Добавляем точку в список отрисовки
                        if (pointsCB.Checked) g.DrawString("[" + (structPoints[j, i].X).ToString() + ";" + (structPoints[j, i].Y).ToString() + "]", new Font("Arial", 8f, FontStyle.Regular), new SolidBrush(coordColor), structPoints[j, i]);//Если отмечен  соответствующий чекбокс, то рисуем надпись над точкой
                    }
                }
                if (pointArr.Count > 1)//Если список отрисовки создан, то
                {
                    g.DrawCurve(new Pen(netColor, 1), pointArr.ToArray());//Рисуем кривую по точкам из списка отрисовки
                }



            }
        }

        /// <summary>
        /// Вычисление проекции значения функции на текущую плоскость
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        Point GetPoint(double p, double q)
        {
            double r = GetValue(p, q);// Вычисляем значение функции
            return new Point((int)(l1() * p + l2() * q + l3() * r), (int)(m1() * p + m2() * q + m3() * r)); //Возвращаем значение проекции

        }
        enum coordinate
        {
            X, Y
        }
        //void DrawMark(double value, coordinate coord, int x0, int y0, double angle2, Graphics g)
        //{
        //    int l = 2;
        //    switch (coord)
        //    {
        //        case coordinate.X:
        //            g.DrawLine(Pens.RoyalBlue, x0 - (int)(Math.Sin(angle2) * value), y0 - (int)(Math.Cos(angle2) * value) - l, x0 - (int)(Math.Sin(angle2) * value), y0 - (int)(Math.Cos(angle2) * value) + l);
        //            break;
        //        case coordinate.Y:
        //            g.DrawLine(Pens.RoyalBlue, x0 + (int)(Math.Sin(angle2) * value), y0 - (int)(Math.Cos(angle2) * value) - l, x0 + (int)(Math.Sin(angle2) * value), y0 - (int)(Math.Cos(angle2) * value) + l);
        //            break;
        //        default:
        //            break;
        //    }
        //}
        Graphics g;// = Graphics.FromImage(result);
        private  void button1_Click(object sender, EventArgs e)
        {
            try
            {

                step = Convert.ToDouble(textBox1.Text.Replace('.', ','));
                int x0 = pictureBox1.Width / 2, y0 = pictureBox1.Height / 2;
                Bitmap result = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(result);
                button1.Enabled = false;

                pb.Maximum = (int)((xMax - xMin) / step * (yMax - yMin) / step);
                pb.Value = 0;
                
            //    Task t = Task.Factory. 
             //   Thread t = new Thread(new ThreadStart(() =>
                    Task.Factory.StartNew(() =>
                        {

                            using (g)
                            {

                                if (coordCB.Checked) DrawCoordinates(x0, y0, g);
                                if (graphCB.Checked) DrawGraph(xMin, yMin, xMax, yMax, x0, y0, g);
                                if (netCB.Checked) DrawStructure2(xMin, yMin, xMax, yMax, x0, y0, 10, g);
                            }
                        }).ContinueWith(_ => this.pictureBox1.Image = result);

             //   await t;
                // t.Wait();
                
              //  this.Invoke( new Action(() =>
              //  pictureBox1.Image = result));
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
            try
            {

                Bitmap pixel = new Bitmap(1, 1);
                pixel.SetPixel(0, 0, clr);
                g.DrawImageUnscaled(pixel, x, y);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ColorSelector cs = new ColorSelector();
            cs.Show();
        }

        void DrawNet()
        {
            try
            {
                int x0 = pictureBox1.Width / 2, y0 = pictureBox1.Height / 2;
                Bitmap result = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(result);
                using (g)
                {
                    if (coordCB.Checked) DrawCoordinates(x0, y0, g);
                    if (netCB.Checked) DrawStructure2(xMin, yMin, xMax, yMax, x0, y0, 20, g);
                }
                pictureBox1.Image = result;
            }
            catch (Exception)
            {
                FreeRunning = false;
                MessageBox.Show("Ошибка парсера. Проверьте формулу.");

                //  throw;
            }


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                // throw;
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            RestoreAngles();
            DrawNet();
        }


        #region angleLabels
        private void angleLabelA_MouseEnter(object sender, EventArgs e)
        {
            angleLabelA.BorderSides = ToolStripStatusLabelBorderSides.All;
        }

        private void angleLabelA_MouseHover(object sender, EventArgs e)
        {
            angleLabelA.BorderSides = ToolStripStatusLabelBorderSides.All;
        }

        private void angleLabelB_MouseEnter(object sender, EventArgs e)
        {
            angleLabelB.BorderSides = ToolStripStatusLabelBorderSides.All;
        }

        private void angleLabelB_MouseHover(object sender, EventArgs e)
        {
            angleLabelB.BorderSides = ToolStripStatusLabelBorderSides.All;
        }

        private void angleLabelC_MouseEnter(object sender, EventArgs e)
        {
            angleLabelC.BorderSides = ToolStripStatusLabelBorderSides.All;
        }

        private void angleLabelC_MouseHover(object sender, EventArgs e)
        {
            angleLabelC.BorderSides = ToolStripStatusLabelBorderSides.All;
        }

        private void angleLabelA_MouseLeave(object sender, EventArgs e)
        {
            angleLabelA.BorderSides = ToolStripStatusLabelBorderSides.None;
        }

        private void angleLabelB_MouseLeave(object sender, EventArgs e)
        {
            angleLabelB.BorderSides = ToolStripStatusLabelBorderSides.None;
        }

        private void angleLabelC_MouseLeave(object sender, EventArgs e)
        {
            angleLabelC.BorderSides = ToolStripStatusLabelBorderSides.None;
        }


        private void angleLabelA_Click(object sender, EventArgs e)
        {
            NewAngleValueForm nvf = new NewAngleValueForm(a);
            if (nvf.ShowDialog() == DialogResult.OK)
            {
                a = nvf.Value;
                DrawNet();
            }
        }

        private void angleLabelB_Click(object sender, EventArgs e)
        {
            NewAngleValueForm nvf = new NewAngleValueForm(b);
            if (nvf.ShowDialog() == DialogResult.OK)
            {
                b = nvf.Value;
                DrawNet();
            }
        }

        private void angleLabelC_Click(object sender, EventArgs e)
        {
            NewAngleValueForm nvf = new NewAngleValueForm(c);
            if (nvf.ShowDialog() == DialogResult.OK)
            {
                c = nvf.Value;
                DrawNet();
            }
        }
        #endregion


        static string s;
        private void button6_Click(object sender, EventArgs e)
        {
            ChangeSourceData();
        }

        private void srcData_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///Изменение текста формулы и перерисовка графика 
        /// </summary>
        void ChangeSourceData()
        {
            ValueList.Clear();
            s = srcData.Text;
            DrawNet();


        }
        private void srcData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangeSourceData();
            }

        }

        private void XMinNUD_ValueChanged(object sender, EventArgs e)
        {
            xMin = (int)XMinNUD.Value;
            ValueList.Clear();
        }

        private void XMaxNUD_ValueChanged(object sender, EventArgs e)
        {
            xMax = (int)XMaxNUD.Value;
            ValueList.Clear();
        }

        private void YMinNUD_ValueChanged(object sender, EventArgs e)
        {
            yMin = (int)YMinNUD.Value;
            ValueList.Clear();
        }

        private void YMaxNUD_ValueChanged(object sender, EventArgs e)
        {
            yMax = (int)YMaxNUD.Value;
            ValueList.Clear();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Text = this.Width + " " + this.Height;
        }
    }
}
