
namespace FRC_Utility_Software
{
    partial class OpenNetPrompt
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
            this.TeamTitle = new System.Windows.Forms.Label();
            this.TeamNumberEntry = new System.Windows.Forms.NumericUpDown();
            this.TeamNumberLabel = new System.Windows.Forms.Label();
            this.FileLocationLabel = new System.Windows.Forms.Label();
            this.FileLocationEntry = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.AddressEntry = new System.Windows.Forms.TextBox();
            this.PortNumberLabel = new System.Windows.Forms.Label();
            this.PortNumberEntry = new System.Windows.Forms.NumericUpDown();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OpenNetButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UsernameEntity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PasswordEntity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UnkownLocation = new System.Windows.Forms.CheckBox();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TeamNumberEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumberEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // TeamTitle
            // 
            this.TeamTitle.AutoSize = true;
            this.TeamTitle.BackColor = System.Drawing.Color.Transparent;
            this.TeamTitle.Font = new System.Drawing.Font("SF Sports Night", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TeamTitle.Location = new System.Drawing.Point(10, 7);
            this.TeamTitle.Name = "TeamTitle";
            this.TeamTitle.Size = new System.Drawing.Size(181, 25);
            this.TeamTitle.TabIndex = 2;
            this.TeamTitle.Text = "Team 2137";
            // 
            // TeamNumberEntry
            // 
            this.TeamNumberEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.TeamNumberEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TeamNumberEntry.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TeamNumberEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.TeamNumberEntry.Location = new System.Drawing.Point(144, 50);
            this.TeamNumberEntry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TeamNumberEntry.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TeamNumberEntry.Name = "TeamNumberEntry";
            this.TeamNumberEntry.Size = new System.Drawing.Size(105, 22);
            this.TeamNumberEntry.TabIndex = 3;
            this.TeamNumberEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TeamNumberLabel
            // 
            this.TeamNumberLabel.AutoSize = true;
            this.TeamNumberLabel.Font = new System.Drawing.Font("SF Sports Night", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TeamNumberLabel.Location = new System.Drawing.Point(38, 50);
            this.TeamNumberLabel.Name = "TeamNumberLabel";
            this.TeamNumberLabel.Size = new System.Drawing.Size(94, 21);
            this.TeamNumberLabel.TabIndex = 24;
            this.TeamNumberLabel.Text = "Team #";
            // 
            // FileLocationLabel
            // 
            this.FileLocationLabel.AutoSize = true;
            this.FileLocationLabel.Font = new System.Drawing.Font("SF Sports Night", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FileLocationLabel.Location = new System.Drawing.Point(38, 181);
            this.FileLocationLabel.Name = "FileLocationLabel";
            this.FileLocationLabel.Size = new System.Drawing.Size(186, 21);
            this.FileLocationLabel.TabIndex = 25;
            this.FileLocationLabel.Text = "File Location";
            // 
            // FileLocationEntry
            // 
            this.FileLocationEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.FileLocationEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileLocationEntry.Font = new System.Drawing.Font("Adobe Gothic Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FileLocationEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.FileLocationEntry.Location = new System.Drawing.Point(245, 178);
            this.FileLocationEntry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FileLocationEntry.Name = "FileLocationEntry";
            this.FileLocationEntry.Size = new System.Drawing.Size(287, 24);
            this.FileLocationEntry.TabIndex = 26;
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("SF Sports Night", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddressLabel.Location = new System.Drawing.Point(38, 82);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(120, 21);
            this.AddressLabel.TabIndex = 27;
            this.AddressLabel.Text = "Address";
            // 
            // AddressEntry
            // 
            this.AddressEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.AddressEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AddressEntry.Font = new System.Drawing.Font("Adobe Gothic Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddressEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.AddressEntry.Location = new System.Drawing.Point(173, 80);
            this.AddressEntry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddressEntry.Name = "AddressEntry";
            this.AddressEntry.Size = new System.Drawing.Size(177, 24);
            this.AddressEntry.TabIndex = 28;
            // 
            // PortNumberLabel
            // 
            this.PortNumberLabel.AutoSize = true;
            this.PortNumberLabel.Font = new System.Drawing.Font("SF Sports Night", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PortNumberLabel.Location = new System.Drawing.Point(355, 82);
            this.PortNumberLabel.Name = "PortNumberLabel";
            this.PortNumberLabel.Size = new System.Drawing.Size(93, 21);
            this.PortNumberLabel.TabIndex = 29;
            this.PortNumberLabel.Text = "Port #";
            // 
            // PortNumberEntry
            // 
            this.PortNumberEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.PortNumberEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PortNumberEntry.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PortNumberEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.PortNumberEntry.Location = new System.Drawing.Point(462, 82);
            this.PortNumberEntry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PortNumberEntry.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PortNumberEntry.Name = "PortNumberEntry";
            this.PortNumberEntry.Size = new System.Drawing.Size(105, 22);
            this.PortNumberEntry.TabIndex = 30;
            this.PortNumberEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PortNumberEntry.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("SF Sports Night", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.CloseButton.Location = new System.Drawing.Point(324, 238);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(111, 32);
            this.CloseButton.TabIndex = 37;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OpenNetButton
            // 
            this.OpenNetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.OpenNetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenNetButton.Font = new System.Drawing.Font("SF Sports Night", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OpenNetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.OpenNetButton.Location = new System.Drawing.Point(455, 238);
            this.OpenNetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenNetButton.Name = "OpenNetButton";
            this.OpenNetButton.Size = new System.Drawing.Size(144, 32);
            this.OpenNetButton.TabIndex = 38;
            this.OpenNetButton.Text = "OpenNet";
            this.OpenNetButton.UseVisualStyleBackColor = false;
            this.OpenNetButton.Click += new System.EventHandler(this.OpenNetButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF Sports Night", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(295, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 39;
            this.label3.Text = "OR";
            // 
            // UsernameEntity
            // 
            this.UsernameEntity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.UsernameEntity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameEntity.Font = new System.Drawing.Font("Adobe Gothic Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UsernameEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.UsernameEntity.Location = new System.Drawing.Point(185, 107);
            this.UsernameEntity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UsernameEntity.Name = "UsernameEntity";
            this.UsernameEntity.Size = new System.Drawing.Size(177, 24);
            this.UsernameEntity.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Sports Night", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(38, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 21);
            this.label4.TabIndex = 40;
            this.label4.Text = "Username";
            // 
            // PasswordEntity
            // 
            this.PasswordEntity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.PasswordEntity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordEntity.Font = new System.Drawing.Font("Adobe Gothic Std B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PasswordEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.PasswordEntity.Location = new System.Drawing.Point(521, 106);
            this.PasswordEntity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PasswordEntity.Name = "PasswordEntity";
            this.PasswordEntity.Size = new System.Drawing.Size(177, 24);
            this.PasswordEntity.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SF Sports Night", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(367, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 21);
            this.label5.TabIndex = 42;
            this.label5.Text = "Password";
            // 
            // UnkownLocation
            // 
            this.UnkownLocation.AutoSize = true;
            this.UnkownLocation.Checked = true;
            this.UnkownLocation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UnkownLocation.Font = new System.Drawing.Font("SF Sports Night", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UnkownLocation.Location = new System.Drawing.Point(538, 178);
            this.UnkownLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UnkownLocation.Name = "UnkownLocation";
            this.UnkownLocation.Size = new System.Drawing.Size(122, 20);
            this.UnkownLocation.TabIndex = 44;
            this.UnkownLocation.Text = "Unknown";
            this.UnkownLocation.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(295, 17);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(38, 15);
            this.statusLabel.TabIndex = 45;
            this.statusLabel.Text = "label1";
            // 
            // OpenNetPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(700, 379);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.UnkownLocation);
            this.Controls.Add(this.PasswordEntity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UsernameEntity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OpenNetButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PortNumberEntry);
            this.Controls.Add(this.PortNumberLabel);
            this.Controls.Add(this.AddressEntry);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.FileLocationEntry);
            this.Controls.Add(this.FileLocationLabel);
            this.Controls.Add(this.TeamNumberLabel);
            this.Controls.Add(this.TeamNumberEntry);
            this.Controls.Add(this.TeamTitle);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OpenNetPrompt";
            this.Text = "OpenNetPrompt";
            ((System.ComponentModel.ISupportInitialize)(this.TeamNumberEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumberEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TeamTitle;
        private System.Windows.Forms.NumericUpDown TeamNumberEntry;
        private System.Windows.Forms.Label TeamNumberLabel;
        private System.Windows.Forms.Label FileLocationLabel;
        private System.Windows.Forms.TextBox FileLocationEntry;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TextBox AddressEntry;
        private System.Windows.Forms.Label PortNumberLabel;
        private System.Windows.Forms.NumericUpDown PortNumberEntry;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button OpenNetButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UsernameEntity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PasswordEntity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox UnkownLocation;
        private System.Windows.Forms.Label statusLabel;
    }
}