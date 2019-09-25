namespace OS_Test_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CmbBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.TxtBoxMaxPrsNum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.GrbBox = new System.Windows.Forms.GroupBox();
            this.LblQuan = new System.Windows.Forms.Label();
            this.TxtBoxQuan = new System.Windows.Forms.TextBox();
            this.GrbBoxArr = new System.Windows.Forms.GroupBox();
            this.GrbBoxBurst = new System.Windows.Forms.GroupBox();
            this.GrbBoxP = new System.Windows.Forms.GroupBox();
            this.GrbBoxL = new System.Windows.Forms.GroupBox();
            this.SumBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GrbBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbBoxAlgorithm
            // 
            this.CmbBoxAlgorithm.FormattingEnabled = true;
            this.CmbBoxAlgorithm.Items.AddRange(new object[] {
            "first come first served",
            "shortest job first preemptive",
            "shortest job first non-preemptive",
            "priority preemptive",
            "priority non-preemptive",
            "round robin"});
            this.CmbBoxAlgorithm.Location = new System.Drawing.Point(88, 39);
            this.CmbBoxAlgorithm.Name = "CmbBoxAlgorithm";
            this.CmbBoxAlgorithm.Size = new System.Drawing.Size(153, 21);
            this.CmbBoxAlgorithm.TabIndex = 0;
            this.CmbBoxAlgorithm.Text = "choose your algorithm ..";
            this.CmbBoxAlgorithm.SelectedIndexChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // TxtBoxMaxPrsNum
            // 
            this.TxtBoxMaxPrsNum.Location = new System.Drawing.Point(423, 39);
            this.TxtBoxMaxPrsNum.Name = "TxtBoxMaxPrsNum";
            this.TxtBoxMaxPrsNum.Size = new System.Drawing.Size(48, 20);
            this.TxtBoxMaxPrsNum.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "max number of processes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(584, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Run";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GrbBox
            // 
            this.GrbBox.AutoSize = true;
            this.GrbBox.Controls.Add(this.LblQuan);
            this.GrbBox.Controls.Add(this.TxtBoxQuan);
            this.GrbBox.Controls.Add(this.GrbBoxArr);
            this.GrbBox.Controls.Add(this.GrbBoxBurst);
            this.GrbBox.Controls.Add(this.GrbBoxP);
            this.GrbBox.Controls.Add(this.GrbBoxL);
            this.GrbBox.Location = new System.Drawing.Point(88, 194);
            this.GrbBox.Name = "GrbBox";
            this.GrbBox.Size = new System.Drawing.Size(307, 216);
            this.GrbBox.TabIndex = 5;
            this.GrbBox.TabStop = false;
            this.GrbBox.Text = "Add Your Prosseses";
            this.GrbBox.Visible = false;
            // 
            // LblQuan
            // 
            this.LblQuan.AutoSize = true;
            this.LblQuan.Location = new System.Drawing.Point(104, 35);
            this.LblQuan.Name = "LblQuan";
            this.LblQuan.Size = new System.Drawing.Size(51, 13);
            this.LblQuan.TabIndex = 7;
            this.LblQuan.Text = "Quantum";
            this.LblQuan.Visible = false;
            // 
            // TxtBoxQuan
            // 
            this.TxtBoxQuan.Location = new System.Drawing.Point(161, 32);
            this.TxtBoxQuan.Name = "TxtBoxQuan";
            this.TxtBoxQuan.Size = new System.Drawing.Size(57, 20);
            this.TxtBoxQuan.TabIndex = 7;
            this.TxtBoxQuan.Visible = false;
            // 
            // GrbBoxArr
            // 
            this.GrbBoxArr.AutoSize = true;
            this.GrbBoxArr.Location = new System.Drawing.Point(88, 70);
            this.GrbBoxArr.Name = "GrbBoxArr";
            this.GrbBoxArr.Size = new System.Drawing.Size(67, 100);
            this.GrbBoxArr.TabIndex = 1;
            this.GrbBoxArr.TabStop = false;
            this.GrbBoxArr.Text = "Arrival Time";
            // 
            // GrbBoxBurst
            // 
            this.GrbBoxBurst.AutoSize = true;
            this.GrbBoxBurst.Location = new System.Drawing.Point(161, 70);
            this.GrbBoxBurst.Name = "GrbBoxBurst";
            this.GrbBoxBurst.Size = new System.Drawing.Size(67, 100);
            this.GrbBoxBurst.TabIndex = 1;
            this.GrbBoxBurst.TabStop = false;
            this.GrbBoxBurst.Text = "Burst Time";
            // 
            // GrbBoxP
            // 
            this.GrbBoxP.AutoSize = true;
            this.GrbBoxP.Location = new System.Drawing.Point(234, 70);
            this.GrbBoxP.Name = "GrbBoxP";
            this.GrbBoxP.Size = new System.Drawing.Size(67, 100);
            this.GrbBoxP.TabIndex = 1;
            this.GrbBoxP.TabStop = false;
            this.GrbBoxP.Text = "Priority";
            this.GrbBoxP.Visible = false;
            // 
            // GrbBoxL
            // 
            this.GrbBoxL.AutoSize = true;
            this.GrbBoxL.Location = new System.Drawing.Point(15, 70);
            this.GrbBoxL.Name = "GrbBoxL";
            this.GrbBoxL.Size = new System.Drawing.Size(67, 100);
            this.GrbBoxL.TabIndex = 0;
            this.GrbBoxL.TabStop = false;
            // 
            // SumBox
            // 
            this.SumBox.Location = new System.Drawing.Point(106, 29);
            this.SumBox.Name = "SumBox";
            this.SumBox.Size = new System.Drawing.Size(57, 20);
            this.SumBox.TabIndex = 6;
            this.SumBox.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(88, 78);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(571, 74);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Avg. Waiting Time";
            this.label2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SumBox);
            this.groupBox1.Location = new System.Drawing.Point(456, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 68);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            this.groupBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(766, 371);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.GrbBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtBoxMaxPrsNum);
            this.Controls.Add(this.CmbBoxAlgorithm);
            this.Name = "Form1";
            this.Text = "Your fav project";
            this.GrbBox.ResumeLayout(false);
            this.GrbBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbBoxAlgorithm;
        private System.Windows.Forms.TextBox TxtBoxMaxPrsNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox GrbBox;
        private System.Windows.Forms.TextBox SumBox;
        private System.Windows.Forms.GroupBox GrbBoxArr;
        private System.Windows.Forms.GroupBox GrbBoxBurst;
        private System.Windows.Forms.GroupBox GrbBoxP;
        private System.Windows.Forms.GroupBox GrbBoxL;
        private System.Windows.Forms.Label LblQuan;
        private System.Windows.Forms.TextBox TxtBoxQuan;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;


    }
}

