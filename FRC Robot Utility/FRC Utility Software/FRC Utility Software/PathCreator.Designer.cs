
using System.Windows.Forms;

namespace FRC_Utility_Software
{
    partial class PathCreator
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addStepButton = new System.Windows.Forms.Button();
            this.removeStepNumeric = new System.Windows.Forms.NumericUpDown();
            this.removeStepButton = new System.Windows.Forms.Button();
            this.flipStepButton = new System.Windows.Forms.Button();
            this.flipStepNumeric1 = new System.Windows.Forms.NumericUpDown();
            this.flipStepNumeric2 = new System.Windows.Forms.NumericUpDown();
            this.saveNet = new System.Windows.Forms.Button();
            this.openNet = new System.Windows.Forms.Button();
            this.openLocalButton = new System.Windows.Forms.Button();
            this.saveLocalButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rotateStepNumeric = new System.Windows.Forms.NumericUpDown();
            this.red1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.blue2 = new System.Windows.Forms.RadioButton();
            this.blue3 = new System.Windows.Forms.RadioButton();
            this.blue1 = new System.Windows.Forms.RadioButton();
            this.red3 = new System.Windows.Forms.RadioButton();
            this.red2 = new System.Windows.Forms.RadioButton();
            this.saveLocalDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.removeStepNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flipStepNumeric1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flipStepNumeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateStepNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(26, 25);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1080, 1533);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // addStepButton
            // 
            this.addStepButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.addStepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addStepButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.addStepButton.Location = new System.Drawing.Point(1169, 43);
            this.addStepButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addStepButton.Name = "addStepButton";
            this.addStepButton.Size = new System.Drawing.Size(255, 78);
            this.addStepButton.TabIndex = 1;
            this.addStepButton.Text = "Add Step";
            this.addStepButton.UseVisualStyleBackColor = false;
            this.addStepButton.Click += new System.EventHandler(this.addStepButton_Click);
            // 
            // removeStepNumeric
            // 
            this.removeStepNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.removeStepNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.removeStepNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeStepNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.removeStepNumeric.Location = new System.Drawing.Point(1519, 137);
            this.removeStepNumeric.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.removeStepNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.removeStepNumeric.Name = "removeStepNumeric";
            this.removeStepNumeric.Size = new System.Drawing.Size(189, 69);
            this.removeStepNumeric.TabIndex = 25;
            this.removeStepNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.removeStepNumeric.ThousandsSeparator = true;
            // 
            // removeStepButton
            // 
            this.removeStepButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.removeStepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeStepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeStepButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.removeStepButton.Location = new System.Drawing.Point(1169, 133);
            this.removeStepButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.removeStepButton.Name = "removeStepButton";
            this.removeStepButton.Size = new System.Drawing.Size(338, 78);
            this.removeStepButton.TabIndex = 26;
            this.removeStepButton.Text = "Remove Step #";
            this.removeStepButton.UseVisualStyleBackColor = false;
            this.removeStepButton.Click += new System.EventHandler(this.removeStepButton_Click);
            // 
            // flipStepButton
            // 
            this.flipStepButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.flipStepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flipStepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flipStepButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.flipStepButton.Location = new System.Drawing.Point(1169, 223);
            this.flipStepButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flipStepButton.Name = "flipStepButton";
            this.flipStepButton.Size = new System.Drawing.Size(287, 78);
            this.flipStepButton.TabIndex = 27;
            this.flipStepButton.Text = "Flip Steps";
            this.flipStepButton.UseVisualStyleBackColor = false;
            this.flipStepButton.Click += new System.EventHandler(this.flipStepButton_Click);
            // 
            // flipStepNumeric1
            // 
            this.flipStepNumeric1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.flipStepNumeric1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flipStepNumeric1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flipStepNumeric1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.flipStepNumeric1.Location = new System.Drawing.Point(1468, 228);
            this.flipStepNumeric1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flipStepNumeric1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.flipStepNumeric1.Name = "flipStepNumeric1";
            this.flipStepNumeric1.Size = new System.Drawing.Size(189, 69);
            this.flipStepNumeric1.TabIndex = 28;
            this.flipStepNumeric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.flipStepNumeric1.ThousandsSeparator = true;
            // 
            // flipStepNumeric2
            // 
            this.flipStepNumeric2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.flipStepNumeric2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flipStepNumeric2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flipStepNumeric2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.flipStepNumeric2.Location = new System.Drawing.Point(1670, 228);
            this.flipStepNumeric2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flipStepNumeric2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.flipStepNumeric2.Name = "flipStepNumeric2";
            this.flipStepNumeric2.Size = new System.Drawing.Size(189, 69);
            this.flipStepNumeric2.TabIndex = 29;
            this.flipStepNumeric2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.flipStepNumeric2.ThousandsSeparator = true;
            // 
            // saveNet
            // 
            this.saveNet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.saveNet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveNet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.saveNet.Location = new System.Drawing.Point(2100, 43);
            this.saveNet.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.saveNet.Name = "saveNet";
            this.saveNet.Size = new System.Drawing.Size(255, 78);
            this.saveNet.TabIndex = 30;
            this.saveNet.Text = "Save Net";
            this.saveNet.UseVisualStyleBackColor = false;
            // 
            // openNet
            // 
            this.openNet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.openNet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openNet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.openNet.Location = new System.Drawing.Point(2367, 43);
            this.openNet.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.openNet.Name = "openNet";
            this.openNet.Size = new System.Drawing.Size(255, 78);
            this.openNet.TabIndex = 31;
            this.openNet.Text = "Open Net";
            this.openNet.UseVisualStyleBackColor = false;
            // 
            // openLocalButton
            // 
            this.openLocalButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.openLocalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openLocalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openLocalButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.openLocalButton.Location = new System.Drawing.Point(2367, 137);
            this.openLocalButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.openLocalButton.Name = "openLocalButton";
            this.openLocalButton.Size = new System.Drawing.Size(291, 78);
            this.openLocalButton.TabIndex = 32;
            this.openLocalButton.Text = "Open Local";
            this.openLocalButton.UseVisualStyleBackColor = false;
            this.openLocalButton.Click += new System.EventHandler(this.openLocalButton_Click);
            // 
            // saveLocalButton
            // 
            this.saveLocalButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.saveLocalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveLocalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveLocalButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.saveLocalButton.Location = new System.Drawing.Point(2063, 137);
            this.saveLocalButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.saveLocalButton.Name = "saveLocalButton";
            this.saveLocalButton.Size = new System.Drawing.Size(291, 78);
            this.saveLocalButton.TabIndex = 33;
            this.saveLocalButton.Text = "Save Local";
            this.saveLocalButton.UseVisualStyleBackColor = false;
            this.saveLocalButton.Click += new System.EventHandler(this.saveLocalButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.button1.Location = new System.Drawing.Point(1169, 308);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(338, 78);
            this.button1.TabIndex = 34;
            this.button1.Text = "Rotate Steps";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // rotateStepNumeric
            // 
            this.rotateStepNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.rotateStepNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rotateStepNumeric.DecimalPlaces = 1;
            this.rotateStepNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rotateStepNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.rotateStepNumeric.Location = new System.Drawing.Point(1519, 310);
            this.rotateStepNumeric.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rotateStepNumeric.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rotateStepNumeric.Name = "rotateStepNumeric";
            this.rotateStepNumeric.Size = new System.Drawing.Size(278, 69);
            this.rotateStepNumeric.TabIndex = 35;
            this.rotateStepNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rotateStepNumeric.ThousandsSeparator = true;
            // 
            // red1
            // 
            this.red1.AutoSize = true;
            this.red1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.red1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.red1.Location = new System.Drawing.Point(108, 49);
            this.red1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.red1.Name = "red1";
            this.red1.Size = new System.Drawing.Size(163, 50);
            this.red1.TabIndex = 36;
            this.red1.TabStop = true;
            this.red1.Text = "Red 1";
            this.red1.UseVisualStyleBackColor = true;
            this.red1.CheckedChanged += new System.EventHandler(this.onPositionChange);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.blue2);
            this.groupBox1.Controls.Add(this.blue3);
            this.groupBox1.Controls.Add(this.blue1);
            this.groupBox1.Controls.Add(this.red3);
            this.groupBox1.Controls.Add(this.red2);
            this.groupBox1.Controls.Add(this.red1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.groupBox1.Location = new System.Drawing.Point(1169, 508);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(370, 441);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start Position";
            // 
            // blue2
            // 
            this.blue2.AutoSize = true;
            this.blue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.blue2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.blue2.Location = new System.Drawing.Point(108, 324);
            this.blue2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.blue2.Name = "blue2";
            this.blue2.Size = new System.Drawing.Size(170, 50);
            this.blue2.TabIndex = 41;
            this.blue2.TabStop = true;
            this.blue2.Text = "Blue 2";
            this.blue2.UseVisualStyleBackColor = true;
            this.blue2.CheckedChanged += new System.EventHandler(this.onPositionChange);
            // 
            // blue3
            // 
            this.blue3.AutoSize = true;
            this.blue3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.blue3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.blue3.Location = new System.Drawing.Point(108, 379);
            this.blue3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.blue3.Name = "blue3";
            this.blue3.Size = new System.Drawing.Size(170, 50);
            this.blue3.TabIndex = 40;
            this.blue3.TabStop = true;
            this.blue3.Text = "Blue 3";
            this.blue3.UseVisualStyleBackColor = true;
            this.blue3.CheckedChanged += new System.EventHandler(this.onPositionChange);
            // 
            // blue1
            // 
            this.blue1.AutoSize = true;
            this.blue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.blue1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.blue1.Location = new System.Drawing.Point(108, 269);
            this.blue1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.blue1.Name = "blue1";
            this.blue1.Size = new System.Drawing.Size(170, 50);
            this.blue1.TabIndex = 38;
            this.blue1.TabStop = true;
            this.blue1.Text = "Blue 1";
            this.blue1.UseVisualStyleBackColor = true;
            this.blue1.CheckedChanged += new System.EventHandler(this.onPositionChange);
            // 
            // red3
            // 
            this.red3.AutoSize = true;
            this.red3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.red3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.red3.Location = new System.Drawing.Point(108, 160);
            this.red3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.red3.Name = "red3";
            this.red3.Size = new System.Drawing.Size(163, 50);
            this.red3.TabIndex = 38;
            this.red3.TabStop = true;
            this.red3.Text = "Red 3";
            this.red3.UseVisualStyleBackColor = true;
            this.red3.CheckedChanged += new System.EventHandler(this.onPositionChange);
            // 
            // red2
            // 
            this.red2.AutoSize = true;
            this.red2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.red2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.red2.Location = new System.Drawing.Point(108, 105);
            this.red2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.red2.Name = "red2";
            this.red2.Size = new System.Drawing.Size(163, 50);
            this.red2.TabIndex = 39;
            this.red2.TabStop = true;
            this.red2.Text = "Red 2";
            this.red2.UseVisualStyleBackColor = true;
            this.red2.CheckedChanged += new System.EventHandler(this.onPositionChange);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.button2.Location = new System.Drawing.Point(1158, 1359);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(701, 199);
            this.button2.TabIndex = 38;
            this.button2.Text = "Path Plotter";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.button3.Location = new System.Drawing.Point(1169, 398);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(391, 78);
            this.button3.TabIndex = 39;
            this.button3.Text = "z";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PathCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(2828, 1583);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rotateStepNumeric);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveLocalButton);
            this.Controls.Add(this.openLocalButton);
            this.Controls.Add(this.openNet);
            this.Controls.Add(this.saveNet);
            this.Controls.Add(this.flipStepNumeric2);
            this.Controls.Add(this.flipStepNumeric1);
            this.Controls.Add(this.flipStepButton);
            this.Controls.Add(this.removeStepButton);
            this.Controls.Add(this.removeStepNumeric);
            this.Controls.Add(this.addStepButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "PathCreator";
            this.Text = "PathCreator";
            ((System.ComponentModel.ISupportInitialize)(this.removeStepNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flipStepNumeric1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flipStepNumeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateStepNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addStepButton;
        private System.Windows.Forms.NumericUpDown removeStepNumeric;
        private System.Windows.Forms.Button removeStepButton;
        private System.Windows.Forms.Button flipStepButton;
        private System.Windows.Forms.NumericUpDown flipStepNumeric1;
        private System.Windows.Forms.NumericUpDown flipStepNumeric2;
        private System.Windows.Forms.Button saveNet;
        private System.Windows.Forms.Button openNet;
        private System.Windows.Forms.Button openLocalButton;
        private System.Windows.Forms.Button saveLocalButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown rotateStepNumeric;
        private System.Windows.Forms.RadioButton red1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton blue2;
        private System.Windows.Forms.RadioButton blue3;
        private System.Windows.Forms.RadioButton blue1;
        private System.Windows.Forms.RadioButton red3;
        private System.Windows.Forms.RadioButton red2;
        private System.Windows.Forms.SaveFileDialog saveLocalDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}