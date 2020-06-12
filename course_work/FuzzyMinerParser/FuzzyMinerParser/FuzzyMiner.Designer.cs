namespace FuzzyMinerParser
{
    partial class FuzzyMiner
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FuzzyMiner));
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.binFrequencyVal = new System.Windows.Forms.NumericUpDown();
            this.unFrequencyVal = new System.Windows.Forms.NumericUpDown();
            this.routingSigVal = new System.Windows.Forms.NumericUpDown();
            this.distanceSigVal = new System.Windows.Forms.NumericUpDown();
            this.nameSigVal = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.autoParam1 = new System.Windows.Forms.TrackBar();
            this.autoParam2 = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EdgeCutoffValueLabel = new System.Windows.Forms.Label();
            this.NodeCutoffValueLabel = new System.Windows.Forms.Label();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.autoParam3 = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.RatioValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.binFrequencyVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unFrequencyVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routingSigVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceSigVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameSigVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoParam1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoParam2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoParam3)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Enabled = false;
            this.buttonCalculate.Location = new System.Drawing.Point(35, 153);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(104, 23);
            this.buttonCalculate.TabIndex = 1;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.Calculate);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "binFrequency";
            // 
            // binFrequencyVal
            // 
            this.binFrequencyVal.DecimalPlaces = 3;
            this.binFrequencyVal.Enabled = false;
            this.binFrequencyVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.binFrequencyVal.Location = new System.Drawing.Point(81, 6);
            this.binFrequencyVal.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.binFrequencyVal.Name = "binFrequencyVal";
            this.binFrequencyVal.Size = new System.Drawing.Size(58, 20);
            this.binFrequencyVal.TabIndex = 3;
            // 
            // unFrequencyVal
            // 
            this.unFrequencyVal.DecimalPlaces = 3;
            this.unFrequencyVal.Enabled = false;
            this.unFrequencyVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.unFrequencyVal.Location = new System.Drawing.Point(81, 32);
            this.unFrequencyVal.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.unFrequencyVal.Name = "unFrequencyVal";
            this.unFrequencyVal.Size = new System.Drawing.Size(58, 20);
            this.unFrequencyVal.TabIndex = 4;
            // 
            // routingSigVal
            // 
            this.routingSigVal.DecimalPlaces = 3;
            this.routingSigVal.Enabled = false;
            this.routingSigVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.routingSigVal.Location = new System.Drawing.Point(81, 58);
            this.routingSigVal.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.routingSigVal.Name = "routingSigVal";
            this.routingSigVal.Size = new System.Drawing.Size(58, 20);
            this.routingSigVal.TabIndex = 5;
            // 
            // distanceSigVal
            // 
            this.distanceSigVal.DecimalPlaces = 3;
            this.distanceSigVal.Enabled = false;
            this.distanceSigVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.distanceSigVal.Location = new System.Drawing.Point(81, 84);
            this.distanceSigVal.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.distanceSigVal.Name = "distanceSigVal";
            this.distanceSigVal.Size = new System.Drawing.Size(58, 20);
            this.distanceSigVal.TabIndex = 6;
            // 
            // nameSigVal
            // 
            this.nameSigVal.DecimalPlaces = 3;
            this.nameSigVal.Enabled = false;
            this.nameSigVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nameSigVal.Location = new System.Drawing.Point(81, 110);
            this.nameSigVal.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nameSigVal.Name = "nameSigVal";
            this.nameSigVal.Size = new System.Drawing.Size(58, 20);
            this.nameSigVal.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "unFrequency";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "routingSig";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "distanceSig";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "nameSig";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1085, 471);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // autoParam1
            // 
            this.autoParam1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autoParam1.Enabled = false;
            this.autoParam1.LargeChange = 1;
            this.autoParam1.Location = new System.Drawing.Point(213, 265);
            this.autoParam1.Maximum = 1000;
            this.autoParam1.Name = "autoParam1";
            this.autoParam1.Size = new System.Drawing.Size(573, 45);
            this.autoParam1.TabIndex = 19;
            this.autoParam1.Scroll += new System.EventHandler(this.autoParam1_Scroll);
            this.autoParam1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.autoParam1_MouseDown);
            this.autoParam1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.autoParam1_MouseUp);
            // 
            // autoParam2
            // 
            this.autoParam2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autoParam2.Enabled = false;
            this.autoParam2.LargeChange = 1;
            this.autoParam2.Location = new System.Drawing.Point(213, 312);
            this.autoParam2.Maximum = 1000;
            this.autoParam2.Name = "autoParam2";
            this.autoParam2.Size = new System.Drawing.Size(572, 45);
            this.autoParam2.TabIndex = 20;
            this.autoParam2.Scroll += new System.EventHandler(this.autoParam2_Scroll);
            this.autoParam2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.autoParam2_MouseDown);
            this.autoParam2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.autoParam2_MouseUp);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(111, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "Edge cutoff";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(111, 321);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 25);
            this.label10.TabIndex = 24;
            this.label10.Text = "Node cutoff";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(35, 188);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(104, 23);
            this.buttonOpenFile.TabIndex = 27;
            this.buttonOpenFile.Text = "Open file...";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.OpenFile);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(172, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 254);
            this.panel1.TabIndex = 28;
            // 
            // EdgeCutoffValueLabel
            // 
            this.EdgeCutoffValueLabel.Location = new System.Drawing.Point(60, 270);
            this.EdgeCutoffValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EdgeCutoffValueLabel.Name = "EdgeCutoffValueLabel";
            this.EdgeCutoffValueLabel.Size = new System.Drawing.Size(46, 25);
            this.EdgeCutoffValueLabel.TabIndex = 29;
            this.EdgeCutoffValueLabel.Text = "0";
            // 
            // NodeCutoffValueLabel
            // 
            this.NodeCutoffValueLabel.Location = new System.Drawing.Point(60, 321);
            this.NodeCutoffValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NodeCutoffValueLabel.Name = "NodeCutoffValueLabel";
            this.NodeCutoffValueLabel.Size = new System.Drawing.Size(46, 25);
            this.NodeCutoffValueLabel.TabIndex = 30;
            this.NodeCutoffValueLabel.Text = "0";
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Enabled = false;
            this.SaveFileButton.Location = new System.Drawing.Point(35, 222);
            this.SaveFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(104, 22);
            this.SaveFileButton.TabIndex = 31;
            this.SaveFileButton.Text = "Save model...";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFile);
            // 
            // autoParam3
            // 
            this.autoParam3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autoParam3.Enabled = false;
            this.autoParam3.LargeChange = 1;
            this.autoParam3.Location = new System.Drawing.Point(213, 365);
            this.autoParam3.Maximum = 1000;
            this.autoParam3.Name = "autoParam3";
            this.autoParam3.Size = new System.Drawing.Size(572, 45);
            this.autoParam3.TabIndex = 32;
            this.autoParam3.Scroll += new System.EventHandler(this.AutoParam3_Scroll);
            this.autoParam3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AutoParam3_MouseDown);
            this.autoParam3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AutoParam3_MouseUp);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(111, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 25);
            this.label6.TabIndex = 33;
            this.label6.Text = "Ratio threshold";
            // 
            // RatioValueLabel
            // 
            this.RatioValueLabel.Location = new System.Drawing.Point(60, 365);
            this.RatioValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RatioValueLabel.Name = "RatioValueLabel";
            this.RatioValueLabel.Size = new System.Drawing.Size(46, 25);
            this.RatioValueLabel.TabIndex = 34;
            this.RatioValueLabel.Text = "1";
            // 
            // FuzzyMiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(791, 447);
            this.Controls.Add(this.RatioValueLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.autoParam3);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.NodeCutoffValueLabel);
            this.Controls.Add(this.EdgeCutoffValueLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.autoParam2);
            this.Controls.Add(this.autoParam1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameSigVal);
            this.Controls.Add(this.distanceSigVal);
            this.Controls.Add(this.routingSigVal);
            this.Controls.Add(this.unFrequencyVal);
            this.Controls.Add(this.binFrequencyVal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCalculate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(807, 485);
            this.Name = "FuzzyMiner";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Fuzzy miner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FuzzyMiner_FormClosing);
            this.Resize += new System.EventHandler(this.FuzzyMiner_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.binFrequencyVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unFrequencyVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routingSigVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceSigVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameSigVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoParam1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoParam2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoParam3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown binFrequencyVal;
        private System.Windows.Forms.NumericUpDown unFrequencyVal;
        private System.Windows.Forms.NumericUpDown routingSigVal;
        private System.Windows.Forms.NumericUpDown distanceSigVal;
        private System.Windows.Forms.NumericUpDown nameSigVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar autoParam1;
        private System.Windows.Forms.TrackBar autoParam2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label EdgeCutoffValueLabel;
        private System.Windows.Forms.Label NodeCutoffValueLabel;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.TrackBar autoParam3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label RatioValueLabel;
    }
}

