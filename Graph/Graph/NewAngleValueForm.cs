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
    public partial class NewAngleValueForm : Form
    {

        private double myvalue;

        public double Value
        {
            get { return myvalue; }
            set 
            {
                myvalue = value;
            }
        }
        
        public NewAngleValueForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void NewAngleValueForm_Load(object sender, EventArgs e)
        {

        }
    }
}
