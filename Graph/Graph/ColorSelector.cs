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
    public partial class ColorSelector : Form
    {
        public ColorSelector()
        {
            InitializeComponent();
        }
        ColorItem GraphColorItem, NetColorItem, CoordColotItem;
        private void ColorSelector_Load(object sender, EventArgs e)
        {
            GraphColorItem = new ColorItem("Graph", Form1.graphColor);
            GraphColorItem.Left = 5;
            GraphColorItem.Top = 15;
            NetColorItem = new ColorItem("Structure net", Form1.netColor);
            NetColorItem.Left = GraphColorItem.Left;
            NetColorItem.Top = GraphColorItem.Bottom + 5;
            CoordColotItem = new ColorItem("Coordinates", Form1.coordColor);
            CoordColotItem.Left = NetColorItem.Left;
            CoordColotItem.Top = NetColorItem.Bottom + 5;
            this.Controls.Add(GraphColorItem);
            this.Controls.Add(NetColorItem);
            this.Controls.Add(CoordColotItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.graphColor = GraphColorItem.MyColor;
            Form1.netColor = NetColorItem.MyColor;
            Form1.coordColor = CoordColotItem.MyColor;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
