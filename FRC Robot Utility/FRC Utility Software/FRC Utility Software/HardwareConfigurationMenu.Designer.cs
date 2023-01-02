namespace FRC_Utility_Software.NetworkTableUtil
{
    partial class HardwareConfigurationMenu
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
            this.pullMethodDropdown = new System.Windows.Forms.ComboBox();
            this.pullButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.HardwareFlowTable = new System.Windows.Forms.FlowLayoutPanel();
            this.preview = new System.Windows.Forms.RichTextBox();
            this.homeButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.previewXML = new System.Windows.Forms.Button();
            this.addDeviceType = new System.Windows.Forms.ComboBox();
            this.addDeviceButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pullMethodDropdown
            // 
            this.pullMethodDropdown.AutoCompleteCustomSource.AddRange(new string[] {
            "NetworkTables",
            "XML Remote",
            "XML Local"});
            this.pullMethodDropdown.FormattingEnabled = true;
            this.pullMethodDropdown.Items.AddRange(new object[] {
            "XML Remote",
            "XML Local",
            "NetworkTables"});
            this.pullMethodDropdown.Location = new System.Drawing.Point(3, 3);
            this.pullMethodDropdown.Name = "pullMethodDropdown";
            this.pullMethodDropdown.Size = new System.Drawing.Size(164, 23);
            this.pullMethodDropdown.TabIndex = 0;
            // 
            // pullButton
            // 
            this.pullButton.AutoSize = true;
            this.pullButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pullButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.pullButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pullButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.pullButton.Location = new System.Drawing.Point(173, 3);
            this.pullButton.Name = "pullButton";
            this.pullButton.Size = new System.Drawing.Size(108, 25);
            this.pullButton.TabIndex = 1;
            this.pullButton.Text = "Pull Existing Map";
            this.pullButton.UseVisualStyleBackColor = false;
            this.pullButton.Click += new System.EventHandler(this.pullButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.pullMethodDropdown);
            this.flowLayoutPanel1.Controls.Add(this.pullButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 31);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // HardwareFlowTable
            // 
            this.HardwareFlowTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HardwareFlowTable.Location = new System.Drawing.Point(302, 12);
            this.HardwareFlowTable.Name = "HardwareFlowTable";
            this.HardwareFlowTable.Size = new System.Drawing.Size(1036, 499);
            this.HardwareFlowTable.TabIndex = 3;
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(12, 49);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(281, 462);
            this.preview.TabIndex = 4;
            this.preview.Text = "";
            // 
            // homeButton
            // 
            this.homeButton.AutoSize = true;
            this.homeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.homeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.homeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.homeButton.Location = new System.Drawing.Point(3, 3);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(50, 25);
            this.homeButton.TabIndex = 5;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = false;
            this.homeButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.homeButton);
            this.flowLayoutPanel2.Controls.Add(this.previewXML);
            this.flowLayoutPanel2.Controls.Add(this.addDeviceType);
            this.flowLayoutPanel2.Controls.Add(this.addDeviceButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(302, 517);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(400, 31);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // previewXML
            // 
            this.previewXML.AutoSize = true;
            this.previewXML.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.previewXML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.previewXML.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.previewXML.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.previewXML.Location = new System.Drawing.Point(59, 3);
            this.previewXML.Name = "previewXML";
            this.previewXML.Size = new System.Drawing.Size(85, 25);
            this.previewXML.TabIndex = 8;
            this.previewXML.Text = "Preview XML";
            this.previewXML.UseVisualStyleBackColor = false;
            this.previewXML.Click += new System.EventHandler(this.previewXML_Click);
            // 
            // addDeviceType
            // 
            this.addDeviceType.AutoCompleteCustomSource.AddRange(new string[] {
            "NetworkTables",
            "XML Remote",
            "XML Local"});
            this.addDeviceType.FormattingEnabled = true;
            this.addDeviceType.Items.AddRange(new object[] {
            "Motor",
            "Encoder",
            "Gyro",
            "SwerveModule",
            "SwerveDriveTrain"});
            this.addDeviceType.Location = new System.Drawing.Point(150, 3);
            this.addDeviceType.Name = "addDeviceType";
            this.addDeviceType.Size = new System.Drawing.Size(164, 23);
            this.addDeviceType.TabIndex = 0;
            // 
            // addDeviceButton
            // 
            this.addDeviceButton.AutoSize = true;
            this.addDeviceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addDeviceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.addDeviceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addDeviceButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.addDeviceButton.Location = new System.Drawing.Point(320, 3);
            this.addDeviceButton.Name = "addDeviceButton";
            this.addDeviceButton.Size = new System.Drawing.Size(77, 25);
            this.addDeviceButton.TabIndex = 1;
            this.addDeviceButton.Text = "Add Device";
            this.addDeviceButton.UseVisualStyleBackColor = false;
            this.addDeviceButton.Click += new System.EventHandler(this.addDeviceButton_Click);
            // 
            // HardwareConfigurationMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1350, 579);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.HardwareFlowTable);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.Name = "HardwareConfigurationMenu";
            this.Text = "HardwareConfigurationMenu";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pullMethodDropdown;
        private System.Windows.Forms.Button pullButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel HardwareFlowTable;
        private System.Windows.Forms.RichTextBox preview;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ComboBox addDeviceType;
        private System.Windows.Forms.Button addDeviceButton;
        private System.Windows.Forms.Button previewXML;
    }
}