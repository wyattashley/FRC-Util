
namespace FRC_Utility_Software
{
    partial class PathPlot
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
            this.addWaypointRatio = new System.Windows.Forms.RadioButton();
            this.addCommandRatio = new System.Windows.Forms.RadioButton();
            this.addPointRatio = new System.Windows.Forms.RadioButton();
            this.colorPicker = new System.Windows.Forms.ComboBox();
            this.removeCheck = new System.Windows.Forms.CheckBox();
            this.clearAll = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Save = new System.Windows.Forms.Button();
            this.generatePath = new System.Windows.Forms.Button();
            this.commandGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.continousGeneration = new System.Windows.Forms.CheckBox();
            this.angleTrackBar = new System.Windows.Forms.TrackBar();
            this.lowerYNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lowerXNumeric = new System.Windows.Forms.NumericUpDown();
            this.cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.maxAcceleration = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.maxVelocity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.extraTimeout = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cornerPercent = new System.Windows.Forms.NumericUpDown();
            this.time = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerYNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerXNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAcceleration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extraTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addWaypointRatio);
            this.flowLayoutPanel1.Controls.Add(this.addCommandRatio);
            this.flowLayoutPanel1.Controls.Add(this.addPointRatio);
            this.flowLayoutPanel1.Controls.Add(this.colorPicker);
            this.flowLayoutPanel1.Controls.Add(this.removeCheck);
            this.flowLayoutPanel1.Controls.Add(this.clearAll);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(132, 665);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // addWaypointRatio
            // 
            this.addWaypointRatio.Appearance = System.Windows.Forms.Appearance.Button;
            this.addWaypointRatio.BackColor = System.Drawing.Color.RoyalBlue;
            this.addWaypointRatio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addWaypointRatio.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addWaypointRatio.Location = new System.Drawing.Point(3, 3);
            this.addWaypointRatio.Name = "addWaypointRatio";
            this.addWaypointRatio.Size = new System.Drawing.Size(122, 32);
            this.addWaypointRatio.TabIndex = 0;
            this.addWaypointRatio.TabStop = true;
            this.addWaypointRatio.Text = "Add Waypoint";
            this.addWaypointRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addWaypointRatio.UseVisualStyleBackColor = false;
            // 
            // addCommandRatio
            // 
            this.addCommandRatio.Appearance = System.Windows.Forms.Appearance.Button;
            this.addCommandRatio.AutoSize = true;
            this.addCommandRatio.BackColor = System.Drawing.Color.Green;
            this.addCommandRatio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addCommandRatio.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addCommandRatio.Location = new System.Drawing.Point(3, 41);
            this.addCommandRatio.Name = "addCommandRatio";
            this.addCommandRatio.Size = new System.Drawing.Size(122, 32);
            this.addCommandRatio.TabIndex = 3;
            this.addCommandRatio.TabStop = true;
            this.addCommandRatio.Text = "Add Command";
            this.addCommandRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addCommandRatio.UseVisualStyleBackColor = false;
            // 
            // addPointRatio
            // 
            this.addPointRatio.Appearance = System.Windows.Forms.Appearance.Button;
            this.addPointRatio.BackColor = System.Drawing.Color.OrangeRed;
            this.addPointRatio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addPointRatio.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addPointRatio.Location = new System.Drawing.Point(3, 79);
            this.addPointRatio.Name = "addPointRatio";
            this.addPointRatio.Size = new System.Drawing.Size(122, 32);
            this.addPointRatio.TabIndex = 2;
            this.addPointRatio.TabStop = true;
            this.addPointRatio.Text = "Add Point";
            this.addPointRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addPointRatio.UseVisualStyleBackColor = false;
            // 
            // colorPicker
            // 
            this.colorPicker.FormattingEnabled = true;
            this.colorPicker.Items.AddRange(new object[] {
            "Orange",
            "Yellow",
            "Purple",
            "Pink"});
            this.colorPicker.Location = new System.Drawing.Point(3, 117);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(122, 28);
            this.colorPicker.TabIndex = 5;
            // 
            // removeCheck
            // 
            this.removeCheck.AutoSize = true;
            this.removeCheck.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeCheck.Location = new System.Drawing.Point(3, 151);
            this.removeCheck.Name = "removeCheck";
            this.removeCheck.Size = new System.Drawing.Size(89, 26);
            this.removeCheck.TabIndex = 4;
            this.removeCheck.Text = "Remove";
            this.removeCheck.UseVisualStyleBackColor = true;
            // 
            // clearAll
            // 
            this.clearAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.clearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearAll.Font = new System.Drawing.Font("SF Sports Night NS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clearAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.clearAll.Location = new System.Drawing.Point(3, 183);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(122, 27);
            this.clearAll.TabIndex = 39;
            this.clearAll.Text = "Clear All";
            this.clearAll.UseVisualStyleBackColor = false;
            this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Font = new System.Drawing.Font("SF Sports Night NS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.Save.Location = new System.Drawing.Point(1233, 638);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(159, 38);
            this.Save.TabIndex = 35;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // generatePath
            // 
            this.generatePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.generatePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generatePath.Font = new System.Drawing.Font("SF Sports Night NS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.generatePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.generatePath.Location = new System.Drawing.Point(150, 639);
            this.generatePath.Name = "generatePath";
            this.generatePath.Size = new System.Drawing.Size(181, 38);
            this.generatePath.TabIndex = 37;
            this.generatePath.Text = "generate";
            this.generatePath.UseVisualStyleBackColor = false;
            this.generatePath.Click += new System.EventHandler(this.onGenerate);
            // 
            // commandGroup
            // 
            this.commandGroup.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.commandGroup.Location = new System.Drawing.Point(1111, 15);
            this.commandGroup.Name = "commandGroup";
            this.commandGroup.Size = new System.Drawing.Size(502, 597);
            this.commandGroup.TabIndex = 0;
            this.commandGroup.WrapContents = false;
            // 
            // continousGeneration
            // 
            this.continousGeneration.AutoSize = true;
            this.continousGeneration.Font = new System.Drawing.Font("SF Sports Night", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.continousGeneration.Location = new System.Drawing.Point(347, 646);
            this.continousGeneration.Name = "continousGeneration";
            this.continousGeneration.Size = new System.Drawing.Size(259, 19);
            this.continousGeneration.TabIndex = 38;
            this.continousGeneration.Text = "Continuous Generation";
            this.continousGeneration.UseVisualStyleBackColor = true;
            this.continousGeneration.CheckedChanged += new System.EventHandler(this.continousGeneration_CheckedChanged);
            // 
            // angleTrackBar
            // 
            this.angleTrackBar.AutoSize = false;
            this.angleTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.angleTrackBar.LargeChange = 10;
            this.angleTrackBar.Location = new System.Drawing.Point(953, 638);
            this.angleTrackBar.Maximum = 360;
            this.angleTrackBar.Name = "angleTrackBar";
            this.angleTrackBar.Size = new System.Drawing.Size(156, 39);
            this.angleTrackBar.TabIndex = 39;
            this.angleTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lowerYNumeric
            // 
            this.lowerYNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.lowerYNumeric.Font = new System.Drawing.Font("SF Sports Night AltUpright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lowerYNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.lowerYNumeric.Location = new System.Drawing.Point(778, 642);
            this.lowerYNumeric.Name = "lowerYNumeric";
            this.lowerYNumeric.Size = new System.Drawing.Size(76, 27);
            this.lowerYNumeric.TabIndex = 41;
            this.lowerYNumeric.ValueChanged += new System.EventHandler(this.lowerYNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(619, 646);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(743, 646);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(860, 645);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 47;
            this.label3.Text = "Angle:";
            // 
            // lowerXNumeric
            // 
            this.lowerXNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.lowerXNumeric.Font = new System.Drawing.Font("SF Sports Night AltUpright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lowerXNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.lowerXNumeric.Location = new System.Drawing.Point(661, 642);
            this.lowerXNumeric.Name = "lowerXNumeric";
            this.lowerXNumeric.Size = new System.Drawing.Size(76, 27);
            this.lowerXNumeric.TabIndex = 48;
            this.lowerXNumeric.ValueChanged += new System.EventHandler(this.lowerXNumeric_ValueChanged);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("SF Sports Night NS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.cancel.Location = new System.Drawing.Point(1419, 638);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(159, 38);
            this.cancel.TabIndex = 49;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(150, 703);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Max Acceleration:";
            // 
            // maxAcceleration
            // 
            this.maxAcceleration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.maxAcceleration.DecimalPlaces = 2;
            this.maxAcceleration.Font = new System.Drawing.Font("SF Sports Night AltUpright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxAcceleration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.maxAcceleration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.maxAcceleration.Location = new System.Drawing.Point(395, 696);
            this.maxAcceleration.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxAcceleration.Name = "maxAcceleration";
            this.maxAcceleration.Size = new System.Drawing.Size(111, 27);
            this.maxAcceleration.TabIndex = 51;
            this.maxAcceleration.Value = new decimal(new int[] {
            328,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(516, 703);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 20);
            this.label5.TabIndex = 52;
            this.label5.Text = "Max Velocity:";
            // 
            // maxVelocity
            // 
            this.maxVelocity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.maxVelocity.DecimalPlaces = 2;
            this.maxVelocity.Font = new System.Drawing.Font("SF Sports Night AltUpright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxVelocity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.maxVelocity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.maxVelocity.Location = new System.Drawing.Point(702, 696);
            this.maxVelocity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxVelocity.Name = "maxVelocity";
            this.maxVelocity.Size = new System.Drawing.Size(111, 27);
            this.maxVelocity.TabIndex = 53;
            this.maxVelocity.Value = new decimal(new int[] {
            984,
            0,
            0,
            131072});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(1136, 703);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 20);
            this.label6.TabIndex = 54;
            this.label6.Text = "Extra Timeout:";
            // 
            // extraTimeout
            // 
            this.extraTimeout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.extraTimeout.DecimalPlaces = 2;
            this.extraTimeout.Font = new System.Drawing.Font("SF Sports Night AltUpright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.extraTimeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.extraTimeout.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.extraTimeout.Location = new System.Drawing.Point(1337, 696);
            this.extraTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.extraTimeout.Name = "extraTimeout";
            this.extraTimeout.Size = new System.Drawing.Size(111, 27);
            this.extraTimeout.TabIndex = 55;
            this.extraTimeout.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(819, 703);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 20);
            this.label7.TabIndex = 56;
            this.label7.Text = "Corner Speed:";
            // 
            // cornerPercent
            // 
            this.cornerPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.cornerPercent.DecimalPlaces = 2;
            this.cornerPercent.Font = new System.Drawing.Font("SF Sports Night AltUpright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cornerPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.cornerPercent.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.cornerPercent.Location = new System.Drawing.Point(1010, 696);
            this.cornerPercent.Name = "cornerPercent";
            this.cornerPercent.Size = new System.Drawing.Size(111, 27);
            this.cornerPercent.TabIndex = 57;
            this.cornerPercent.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.time.Location = new System.Drawing.Point(1136, 748);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(150, 20);
            this.time.TabIndex = 58;
            this.time.Text = "Total Time:";
            // 
            // PathPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1652, 804);
            this.Controls.Add(this.time);
            this.Controls.Add(this.cornerPercent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.extraTimeout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maxVelocity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxAcceleration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.lowerXNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lowerYNumeric);
            this.Controls.Add(this.angleTrackBar);
            this.Controls.Add(this.continousGeneration);
            this.Controls.Add(this.commandGroup);
            this.Controls.Add(this.generatePath);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.Name = "PathPlot";
            this.Text = "PathPlot";
            this.Load += new System.EventHandler(this.PathPlot_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerYNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerXNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAcceleration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extraTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerPercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton addCommandRatio;
        private System.Windows.Forms.RadioButton addWaypointRatio;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.RadioButton addPointRatio;
        private System.Windows.Forms.CheckBox removeCheck;
        private System.Windows.Forms.Button generatePath;
        private System.Windows.Forms.ComboBox colorPicker;
        private System.Windows.Forms.FlowLayoutPanel commandGroup;
        private System.Windows.Forms.CheckBox continousGeneration;
        private System.Windows.Forms.Button clearAll;
        private System.Windows.Forms.TrackBar angleTrackBar;
        private System.Windows.Forms.NumericUpDown lowerYNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown lowerXNumeric;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown maxAcceleration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown maxVelocity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown extraTimeout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown cornerPercent;
        private System.Windows.Forms.Label time;
    }
}