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
                textBox1.Text = value.ToString();
                

            }
        }
        
        public NewAngleValueForm(double value)
        {
            InitializeComponent();
            Value = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Commit();

        }

        void Commit()
        {
            try
            {
                Value = Convert.ToDouble(textBox1.Text.Replace('.', ',')) % 360;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void NewAngleValueForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Value.ToString();
        //    textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Commit();
            }
        }

    }
}
