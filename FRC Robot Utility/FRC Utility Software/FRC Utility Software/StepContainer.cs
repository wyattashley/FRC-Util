using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace FRC_Utility_Software
{
    class StepContainer
    {
        public SplitContainer splitContainer = new SplitContainer();

        public Label stepNumberLabel = new Label();

        public Label actionLabel = new Label();
        public ComboBox actionComboBox = new ComboBox();
        public Label timeout = new Label();
        public NumericUpDown timeoutNumeric = new NumericUpDown();
        public CheckBox parrellelCheckBox = new CheckBox();
        public Label speedLabel = new Label();
        public NumericUpDown speedNumeric = new NumericUpDown();
        public Label xDistanceLabel = new Label();
        public NumericUpDown xDistanceNumeric = new NumericUpDown();
        public Label yDistanceLabel = new Label();
        public NumericUpDown yDistanceNumeric = new NumericUpDown();

        public Label parm1Label = new Label();
        public NumericUpDown parm1Numeric = new NumericUpDown();
        public Label parm2Label = new Label();
        public NumericUpDown parm2Numeric = new NumericUpDown();
        public Label parm3Label = new Label();
        public NumericUpDown parm3Numeric = new NumericUpDown();
        public Label parm4Label = new Label();
        public NumericUpDown parm4Numeric = new NumericUpDown();
        public Label parm5Label = new Label();
        public NumericUpDown parm5Numeric = new NumericUpDown();
        public Label parm6Label = new Label();
        public NumericUpDown parm6Numeric = new NumericUpDown();
        public Label parm7Label = new Label();
        public NumericUpDown parm7Numeric = new NumericUpDown();

       
        public StepContainer()
        {

            this.stepNumberLabel.AutoSize = true;
            this.stepNumberLabel.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stepNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.stepNumberLabel.Location = new System.Drawing.Point(3, 0);
            this.stepNumberLabel.Name = "stepNumberLabel";
            this.stepNumberLabel.Size = new System.Drawing.Size(63, 22);
            this.stepNumberLabel.TabIndex = 1;
            this.stepNumberLabel.Text = "Step ";

            this.actionComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Location = new System.Drawing.Point(63, 30);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(151, 28);
            this.actionComboBox.TabIndex = 0;

            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.actionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.actionLabel.Location = new System.Drawing.Point(3, 30);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(63, 22);
            this.actionLabel.TabIndex = 1;
            this.actionLabel.Text = "Action: ";

            // 
            // timeoutNumeric
            // 
            this.timeoutNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.timeoutNumeric.DecimalPlaces = 2;
            this.timeoutNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.timeoutNumeric.Location = new System.Drawing.Point(81, 59);
            this.timeoutNumeric.Name = "timeoutNumeric";
            this.timeoutNumeric.Size = new System.Drawing.Size(133, 27);
            this.timeoutNumeric.TabIndex = 2;
            this.timeoutNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeout
            // 
            this.timeout.AutoSize = true;
            this.timeout.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.timeout.Location = new System.Drawing.Point(3, 59);
            this.timeout.Name = "timeout";
            this.timeout.Size = new System.Drawing.Size(72, 22);
            this.timeout.TabIndex = 2;
            this.timeout.Text = "Timeout:";
            // 
            // parrellelCheckBox
            // 
            this.parrellelCheckBox.AutoSize = true;
            this.parrellelCheckBox.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parrellelCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.parrellelCheckBox.Location = new System.Drawing.Point(3, 87);
            this.parrellelCheckBox.Name = "parrellelCheckBox";
            this.parrellelCheckBox.Size = new System.Drawing.Size(89, 26);
            this.parrellelCheckBox.TabIndex = 3;
            this.parrellelCheckBox.Text = "Parallel";
            this.parrellelCheckBox.UseVisualStyleBackColor = true;
            // 
            // parm1Numeric
            // 
            this.parm1Numeric.DecimalPlaces = 2;
            this.parm1Numeric.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm1Numeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.parm1Numeric.Location = new System.Drawing.Point(70, 30);
            this.parm1Numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.parm1Numeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.parm1Numeric.Name = "parm1Numeric";
            this.parm1Numeric.Size = new System.Drawing.Size(118, 26);
            this.parm1Numeric.TabIndex = 4;
            this.parm1Numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parm1Numeric.ThousandsSeparator = true;
            // 
            // parm1Label
            // 
            this.parm1Label.AutoSize = true;
            this.parm1Label.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm1Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.parm1Label.Location = new System.Drawing.Point(9, 30);
            this.parm1Label.Name = "parm1Label";
            this.parm1Label.Size = new System.Drawing.Size(57, 22);
            this.parm1Label.TabIndex = 5;
            this.parm1Label.Text = "Parm 1";
            // 
            // parm2Label
            // 
            this.parm2Label.AutoSize = true;
            this.parm2Label.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm2Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.parm2Label.Location = new System.Drawing.Point(9, 60);
            this.parm2Label.Name = "parm2Label";
            this.parm2Label.Size = new System.Drawing.Size(59, 22);
            this.parm2Label.TabIndex = 7;
            this.parm2Label.Text = "Parm 2";
            // 
            // parm2Numeric
            // 
            this.parm2Numeric.DecimalPlaces = 2;
            this.parm2Numeric.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm2Numeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.parm2Numeric.Location = new System.Drawing.Point(70, 60);
            this.parm2Numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.parm2Numeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.parm2Numeric.Name = "parm2Numeric";
            this.parm2Numeric.Size = new System.Drawing.Size(118, 26);
            this.parm2Numeric.TabIndex = 6;
            this.parm2Numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parm2Numeric.ThousandsSeparator = true;
            // 
            // parm3Label
            // 
            this.parm3Label.AutoSize = true;
            this.parm3Label.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm3Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.parm3Label.Location = new System.Drawing.Point(9, 90);
            this.parm3Label.Name = "parm3Label";
            this.parm3Label.Size = new System.Drawing.Size(60, 22);
            this.parm3Label.TabIndex = 7;
            this.parm3Label.Text = "Parm 3";
            // 
            // parm3Numeric
            // 
            this.parm3Numeric.DecimalPlaces = 2;
            this.parm3Numeric.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm3Numeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.parm3Numeric.Location = new System.Drawing.Point(70, 90);
            this.parm3Numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.parm3Numeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.parm3Numeric.Name = "parm3Numeric";
            this.parm3Numeric.Size = new System.Drawing.Size(118, 26);
            this.parm3Numeric.TabIndex = 6;
            this.parm3Numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parm3Numeric.ThousandsSeparator = true;
            // 
            // parm4Label
            // 
            this.parm4Label.AutoSize = true;
            this.parm4Label.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm4Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.parm4Label.Location = new System.Drawing.Point(9, 120);
            this.parm4Label.Name = "parm4Label";
            this.parm4Label.Size = new System.Drawing.Size(59, 22);
            this.parm4Label.TabIndex = 7;
            this.parm4Label.Text = "Parm 4";
            // 
            // parm4Numeric
            // 
            this.parm4Numeric.DecimalPlaces = 2;
            this.parm4Numeric.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm4Numeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.parm4Numeric.Location = new System.Drawing.Point(70, 120);
            this.parm4Numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.parm4Numeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.parm4Numeric.Name = "parm4Numeric";
            this.parm4Numeric.Size = new System.Drawing.Size(118, 26);
            this.parm4Numeric.TabIndex = 6;
            this.parm4Numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parm4Numeric.ThousandsSeparator = true;
            // 
            // parm5Label
            // 
            this.parm5Label.AutoSize = true;
            this.parm5Label.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm5Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.parm5Label.Location = new System.Drawing.Point(9, 150);
            this.parm5Label.Name = "parm5Label";
            this.parm5Label.Size = new System.Drawing.Size(60, 22);
            this.parm5Label.TabIndex = 9;
            this.parm5Label.Text = "Parm 5";
            // 
            // parm5Numeric
            // 
            this.parm5Numeric.DecimalPlaces = 2;
            this.parm5Numeric.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm5Numeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.parm5Numeric.Location = new System.Drawing.Point(70, 150);
            this.parm5Numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.parm5Numeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.parm5Numeric.Name = "parm5Numeric";
            this.parm5Numeric.Size = new System.Drawing.Size(118, 26);
            this.parm5Numeric.TabIndex = 8;
            this.parm5Numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parm5Numeric.ThousandsSeparator = true;
            // 
            // parm6Label
            // 
            this.parm6Label.AutoSize = true;
            this.parm6Label.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm6Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.parm6Label.Location = new System.Drawing.Point(9, 180);
            this.parm6Label.Name = "parm6Label";
            this.parm6Label.Size = new System.Drawing.Size(60, 22);
            this.parm6Label.TabIndex = 7;
            this.parm6Label.Text = "Parm 6";
            // 
            // parm6Numeric
            // 
            this.parm6Numeric.DecimalPlaces = 2;
            this.parm6Numeric.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm6Numeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.parm6Numeric.Location = new System.Drawing.Point(70, 180);
            this.parm6Numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.parm6Numeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.parm6Numeric.Name = "parm6Numeric";
            this.parm6Numeric.Size = new System.Drawing.Size(118, 26);
            this.parm6Numeric.TabIndex = 6;
            this.parm6Numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parm6Numeric.ThousandsSeparator = true;
            // 
            // parm7Label
            // 
            this.parm7Label.AutoSize = true;
            this.parm7Label.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm7Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.parm7Label.Location = new System.Drawing.Point(9, 210);
            this.parm7Label.Name = "parm7Label";
            this.parm7Label.Size = new System.Drawing.Size(57, 22);
            this.parm7Label.TabIndex = 11;
            this.parm7Label.Text = "Parm 7";
            // 
            // parm7Numeric
            // 
            this.parm7Numeric.DecimalPlaces = 2;
            this.parm7Numeric.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parm7Numeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.parm7Numeric.Location = new System.Drawing.Point(70, 210);
            this.parm7Numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.parm7Numeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.parm7Numeric.Name = "parm7Numeric";
            this.parm7Numeric.Size = new System.Drawing.Size(118, 26);
            this.parm7Numeric.TabIndex = 10;
            this.parm7Numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parm7Numeric.ThousandsSeparator = true;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.speedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.speedLabel.Location = new System.Drawing.Point(3, 116);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(62, 22);
            this.speedLabel.TabIndex = 7;
            this.speedLabel.Text = "Speed: ";
            // 
            // speedNumeric
            // 
            this.speedNumeric.DecimalPlaces = 2;
            this.speedNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.speedNumeric.Location = new System.Drawing.Point(63, 116);
            this.speedNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.speedNumeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.speedNumeric.Name = "speedNumeric";
            this.speedNumeric.Size = new System.Drawing.Size(118, 27);
            this.speedNumeric.TabIndex = 6;
            this.speedNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.speedNumeric.ThousandsSeparator = true;
            // 
            // xDistanceLabel
            // 
            this.xDistanceLabel.AutoSize = true;
            this.xDistanceLabel.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.xDistanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.xDistanceLabel.Location = new System.Drawing.Point(3, 146);
            this.xDistanceLabel.Name = "xDistanceLabel";
            this.xDistanceLabel.Size = new System.Drawing.Size(90, 22);
            this.xDistanceLabel.TabIndex = 13;
            this.xDistanceLabel.Text = "X Distance:";
            // 
            // xDistanceNumeric
            // 
            this.xDistanceNumeric.DecimalPlaces = 2;
            this.xDistanceNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.xDistanceNumeric.Location = new System.Drawing.Point(96, 146);
            this.xDistanceNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.xDistanceNumeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.xDistanceNumeric.Name = "xDistanceNumeric";
            this.xDistanceNumeric.Size = new System.Drawing.Size(118, 27);
            this.xDistanceNumeric.TabIndex = 12;
            this.xDistanceNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.xDistanceNumeric.ThousandsSeparator = true;
            // 
            // yDistanceLabel
            // 
            this.yDistanceLabel.AutoSize = true;
            this.yDistanceLabel.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yDistanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.yDistanceLabel.Location = new System.Drawing.Point(3, 176);
            this.yDistanceLabel.Name = "yDistanceLabel";
            this.yDistanceLabel.Size = new System.Drawing.Size(90, 22);
            this.yDistanceLabel.TabIndex = 15;
            this.yDistanceLabel.Text = "Y Distance:";
            // 
            // yDistanceNumeric
            // 
            this.yDistanceNumeric.DecimalPlaces = 2;
            this.yDistanceNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.yDistanceNumeric.Location = new System.Drawing.Point(96, 176);
            this.yDistanceNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.yDistanceNumeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.yDistanceNumeric.Name = "yDistanceNumeric";
            this.yDistanceNumeric.Size = new System.Drawing.Size(118, 27);
            this.yDistanceNumeric.TabIndex = 14;
            this.yDistanceNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yDistanceNumeric.ThousandsSeparator = true;



            // 
            // splitContainer
            // 
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer.Location = new System.Drawing.Point(595, 83);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.stepNumberLabel);
            this.splitContainer.Panel1.Controls.Add(this.yDistanceLabel);
            this.splitContainer.Panel1.Controls.Add(this.actionLabel);
            this.splitContainer.Panel1.Controls.Add(this.yDistanceNumeric);
            this.splitContainer.Panel1.Controls.Add(this.actionComboBox);
            this.splitContainer.Panel1.Controls.Add(this.xDistanceLabel);
            this.splitContainer.Panel1.Controls.Add(this.xDistanceNumeric);
            this.splitContainer.Panel1.Controls.Add(this.speedLabel);
            this.splitContainer.Panel1.Controls.Add(this.speedNumeric);
            this.splitContainer.Panel1.Controls.Add(this.parrellelCheckBox);
            this.splitContainer.Panel1.Controls.Add(this.timeout);
            this.splitContainer.Panel1.Controls.Add(this.timeoutNumeric);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.parm1Label);
            this.splitContainer.Panel2.Controls.Add(this.parm1Numeric);

            this.splitContainer.Panel2.Controls.Add(this.parm2Label);
            this.splitContainer.Panel2.Controls.Add(this.parm2Numeric);

            this.splitContainer.Panel2.Controls.Add(this.parm3Label);
            this.splitContainer.Panel2.Controls.Add(this.parm3Numeric);

            this.splitContainer.Panel2.Controls.Add(this.parm4Label);
            this.splitContainer.Panel2.Controls.Add(this.parm4Numeric);

            this.splitContainer.Panel2.Controls.Add(this.parm5Label);
            this.splitContainer.Panel2.Controls.Add(this.parm5Numeric);

            this.splitContainer.Panel2.Controls.Add(this.parm6Label);
            this.splitContainer.Panel2.Controls.Add(this.parm6Numeric);

            this.splitContainer.Panel2.Controls.Add(this.parm7Label);
            this.splitContainer.Panel2.Controls.Add(this.parm7Numeric);

            this.splitContainer.Size = new System.Drawing.Size(433, 245);
            this.splitContainer.SplitterDistance = 238;
            this.splitContainer.TabIndex = 2;

        }

        public void addToControl(ControlCollection control, int stepNum)
        {
            this.stepNumberLabel.Text = "Step: " + stepNum;
            control.Add(this.splitContainer);
        }

        public void removeFromControl(ControlCollection control)
        {
            control.Remove(this.splitContainer);
        }

        override
        public string ToString()
        {
            return "\t<Step> \n" +
                "\t\t<command>" + actionComboBox.Text.ToLower() + "</command>\n" +
                "\t\t<timout>" + timeoutNumeric.Value.ToString() + "</timeout>\n" +
                "\t\t<speed>" + speedNumeric.Value.ToString() + "</speed>\n" +
                "\t\t<xdistance>" + xDistanceNumeric.Value.ToString() + "</xdistance>\n" +
                "\t\t<ydistance>" + yDistanceNumeric.Value.ToString() + "</ydistance>\n" +
                "\t\t<parallel>" + parrellelCheckBox.Checked.ToString() + "</parallel>\n" +
                "\t\t<parm1>" + parm1Numeric.Value.ToString() + "</parm1>\n" +
                "\t\t<parm2>" + parm2Numeric.Value.ToString() + "</parm2>\n" +
                "\t\t<parm3>" + parm3Numeric.Value.ToString() + "</parm3>\n" +
                "\t\t<parm4>" + parm4Numeric.Value.ToString() + "</parm4>\n" +
                "\t\t<parm5>" + parm5Numeric.Value.ToString() + "</parm5>\n" +
                "\t\t<parm6>" + parm6Numeric.Value.ToString() + "</parm6>\n" +
                "\t\t<parm7>" + parm7Numeric.Value.ToString() + "</parm7>\n" +
                "\t</Step>\n";
        }
    }
}
