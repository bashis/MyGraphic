namespace Graph
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.graphCB = new System.Windows.Forms.CheckBox();
            this.netCB = new System.Windows.Forms.CheckBox();
            this.coordCB = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.angleLabelA = new System.Windows.Forms.ToolStripStatusLabel();
            this.angleLabelB = new System.Windows.Forms.ToolStripStatusLabel();
            this.angleLabelC = new System.Windows.Forms.ToolStripStatusLabel();
            this.pb = new System.Windows.Forms.ToolStripProgressBar();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pointsCB = new System.Windows.Forms.CheckBox();
            this.srcData = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.XMinNUD = new System.Windows.Forms.NumericUpDown();
            this.XMaxNUD = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.YMinNUD = new System.Windows.Forms.NumericUpDown();
            this.YMaxNUD = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new Graph.DoubleBufferedPictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XMinNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMaxNUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YMinNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMaxNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(83, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "DRAAAAAAW";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // graphCB
            // 
            this.graphCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.graphCB.AutoSize = true;
            this.graphCB.Checked = true;
            this.graphCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.graphCB.Location = new System.Drawing.Point(200, 512);
            this.graphCB.Name = "graphCB";
            this.graphCB.Size = new System.Drawing.Size(55, 17);
            this.graphCB.TabIndex = 2;
            this.graphCB.Text = "Graph";
            this.graphCB.UseVisualStyleBackColor = true;
            // 
            // netCB
            // 
            this.netCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.netCB.AutoSize = true;
            this.netCB.Checked = true;
            this.netCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.netCB.Location = new System.Drawing.Point(261, 512);
            this.netCB.Name = "netCB";
            this.netCB.Size = new System.Drawing.Size(87, 17);
            this.netCB.TabIndex = 3;
            this.netCB.Text = "Structure net";
            this.netCB.UseVisualStyleBackColor = true;
            // 
            // coordCB
            // 
            this.coordCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.coordCB.AutoSize = true;
            this.coordCB.Checked = true;
            this.coordCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.coordCB.Location = new System.Drawing.Point(354, 512);
            this.coordCB.Name = "coordCB";
            this.coordCB.Size = new System.Drawing.Size(82, 17);
            this.coordCB.TabIndex = 4;
            this.coordCB.Text = "Coordinates";
            this.coordCB.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(689, 510);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(651, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Step:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 45);
            this.button2.TabIndex = 10;
            this.button2.Text = "Colors";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 45);
            this.button3.TabIndex = 13;
            this.button3.Text = "Free";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.angleLabelA,
            this.angleLabelB,
            this.angleLabelC,
            this.pb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 543);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(806, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // angleLabelA
            // 
            this.angleLabelA.Name = "angleLabelA";
            this.angleLabelA.Size = new System.Drawing.Size(13, 17);
            this.angleLabelA.Text = "a";
            this.angleLabelA.Click += new System.EventHandler(this.angleLabelA_Click);
            this.angleLabelA.MouseEnter += new System.EventHandler(this.angleLabelA_MouseEnter);
            this.angleLabelA.MouseLeave += new System.EventHandler(this.angleLabelA_MouseLeave);
            this.angleLabelA.MouseHover += new System.EventHandler(this.angleLabelA_MouseHover);
            // 
            // angleLabelB
            // 
            this.angleLabelB.Name = "angleLabelB";
            this.angleLabelB.Size = new System.Drawing.Size(14, 17);
            this.angleLabelB.Text = "b";
            this.angleLabelB.Click += new System.EventHandler(this.angleLabelB_Click);
            this.angleLabelB.MouseEnter += new System.EventHandler(this.angleLabelB_MouseEnter);
            this.angleLabelB.MouseLeave += new System.EventHandler(this.angleLabelB_MouseLeave);
            this.angleLabelB.MouseHover += new System.EventHandler(this.angleLabelB_MouseHover);
            // 
            // angleLabelC
            // 
            this.angleLabelC.Name = "angleLabelC";
            this.angleLabelC.Size = new System.Drawing.Size(13, 17);
            this.angleLabelC.Text = "c";
            this.angleLabelC.Click += new System.EventHandler(this.angleLabelC_Click);
            this.angleLabelC.MouseEnter += new System.EventHandler(this.angleLabelC_MouseEnter);
            this.angleLabelC.MouseLeave += new System.EventHandler(this.angleLabelC_MouseLeave);
            this.angleLabelC.MouseHover += new System.EventHandler(this.angleLabelC_MouseHover);
            // 
            // pb
            // 
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 16);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(12, 429);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 45);
            this.button4.TabIndex = 15;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 114);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(65, 45);
            this.button5.TabIndex = 16;
            this.button5.Text = "Restore";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pointsCB
            // 
            this.pointsCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pointsCB.AutoSize = true;
            this.pointsCB.Location = new System.Drawing.Point(442, 512);
            this.pointsCB.Name = "pointsCB";
            this.pointsCB.Size = new System.Drawing.Size(55, 17);
            this.pointsCB.TabIndex = 17;
            this.pointsCB.Text = "Points";
            this.pointsCB.UseVisualStyleBackColor = true;
            // 
            // srcData
            // 
            this.srcData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.srcData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.srcData.Location = new System.Drawing.Point(83, 480);
            this.srcData.Name = "srcData";
            this.srcData.Size = new System.Drawing.Size(270, 22);
            this.srcData.TabIndex = 18;
            this.srcData.Text = "sqrt(x*x+y*y)";
            this.srcData.TextChanged += new System.EventHandler(this.srcData_TextChanged);
            this.srcData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.srcData_KeyUp);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Location = new System.Drawing.Point(359, 480);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(77, 23);
            this.button6.TabIndex = 19;
            this.button6.Text = "Apply";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // XMinNUD
            // 
            this.XMinNUD.Location = new System.Drawing.Point(6, 32);
            this.XMinNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XMinNUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.XMinNUD.Name = "XMinNUD";
            this.XMinNUD.Size = new System.Drawing.Size(53, 20);
            this.XMinNUD.TabIndex = 20;
            this.XMinNUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.XMinNUD.ValueChanged += new System.EventHandler(this.XMinNUD_ValueChanged);
            // 
            // XMaxNUD
            // 
            this.XMaxNUD.Location = new System.Drawing.Point(6, 74);
            this.XMaxNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XMaxNUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.XMaxNUD.Name = "XMaxNUD";
            this.XMaxNUD.Size = new System.Drawing.Size(53, 20);
            this.XMaxNUD.TabIndex = 21;
            this.XMaxNUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.XMaxNUD.ValueChanged += new System.EventHandler(this.XMaxNUD_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.XMinNUD);
            this.groupBox1.Controls.Add(this.XMaxNUD);
            this.groupBox1.Location = new System.Drawing.Point(12, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(65, 100);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Max";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Min";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.YMinNUD);
            this.groupBox2.Controls.Add(this.YMaxNUD);
            this.groupBox2.Location = new System.Drawing.Point(12, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(65, 100);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Max";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Min";
            // 
            // YMinNUD
            // 
            this.YMinNUD.Location = new System.Drawing.Point(6, 32);
            this.YMinNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YMinNUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.YMinNUD.Name = "YMinNUD";
            this.YMinNUD.Size = new System.Drawing.Size(53, 20);
            this.YMinNUD.TabIndex = 20;
            this.YMinNUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.YMinNUD.ValueChanged += new System.EventHandler(this.YMinNUD_ValueChanged);
            // 
            // YMaxNUD
            // 
            this.YMaxNUD.Location = new System.Drawing.Point(6, 74);
            this.YMaxNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YMaxNUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.YMaxNUD.Name = "YMaxNUD";
            this.YMaxNUD.Size = new System.Drawing.Size(53, 20);
            this.YMaxNUD.TabIndex = 21;
            this.YMaxNUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.YMaxNUD.ValueChanged += new System.EventHandler(this.YMaxNUD_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(83, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(711, 462);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 565);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.srcData);
            this.Controls.Add(this.pointsCB);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.coordCB);
            this.Controls.Add(this.netCB);
            this.Controls.Add(this.graphCB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(667, 552);
            this.Name = "Form1";
            this.Text = "FUCKING Graph Plotter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XMinNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMaxNUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YMinNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMaxNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox graphCB;
        private System.Windows.Forms.CheckBox netCB;
        private System.Windows.Forms.CheckBox coordCB;
        private System.Windows.Forms.TextBox textBox1;
        private DoubleBufferedPictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel angleLabelA;
        private System.Windows.Forms.ToolStripStatusLabel angleLabelB;
        private System.Windows.Forms.ToolStripStatusLabel angleLabelC;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox pointsCB;
        private System.Windows.Forms.TextBox srcData;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.NumericUpDown XMinNUD;
        private System.Windows.Forms.NumericUpDown XMaxNUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown YMinNUD;
        private System.Windows.Forms.NumericUpDown YMaxNUD;
        private System.Windows.Forms.ToolStripProgressBar pb;
    }
}

