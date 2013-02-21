using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graph
{
    public partial class ColorItem : UserControl
    {


        private Color myColor;
        public Color MyColor
        {
            get { return myColor; }
            set
            {

                pictureBox1.BackColor = value;//CreateGraphics().FillRectangle(new SolidBrush(value), 0, 0, pictureBox1.Width, pictureBox1.Height);
                myColor = value; 
            }
        }

        private string myText;

        public string MyText
        {
            get { return myText; }
            set {
                label1.Text = value;
                myText = value; 
            }
        }
        

        public ColorItem(string Text, Color defaultColor)
        {
            InitializeComponent();

            MyText = Text;
            MyColor = defaultColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectColor();
        }
        void SelectColor()
        {

            ColorDialog clrdlg = new ColorDialog();
            clrdlg.Color = MyColor;
            if (clrdlg.ShowDialog() == DialogResult.OK) MyColor = clrdlg.Color;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectColor();
        }
    }
}
