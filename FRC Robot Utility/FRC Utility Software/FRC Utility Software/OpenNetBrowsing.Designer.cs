namespace FRC_Utility_Software
{
    partial class OpenNetBrowsing
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
            this.FilePath = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DirectoryList0 = new System.Windows.Forms.ComboBox();
            this.GoActionButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilePath
            // 
            this.FilePath.AutoSize = true;
            this.FilePath.Location = new System.Drawing.Point(28, 17);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(64, 20);
            this.FilePath.TabIndex = 0;
            this.FilePath.Text = "File Path";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.DirectoryList0);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(28, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(330, 323);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // DirectoryList0
            // 
            this.DirectoryList0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.DirectoryList0.FormattingEnabled = true;
            this.DirectoryList0.Location = new System.Drawing.Point(3, 3);
            this.DirectoryList0.Name = "DirectoryList0";
            this.DirectoryList0.Size = new System.Drawing.Size(327, 28);
            this.DirectoryList0.TabIndex = 0;
            this.DirectoryList0.SelectedIndexChanged += new System.EventHandler(this.DirectoryList1_SelectedIndexChanged);
            // 
            // GoActionButton
            // 
            this.GoActionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.GoActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoActionButton.Font = new System.Drawing.Font("SF Sports Night NS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GoActionButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.GoActionButton.Location = new System.Drawing.Point(221, 379);
            this.GoActionButton.Name = "GoActionButton";
            this.GoActionButton.Size = new System.Drawing.Size(137, 39);
            this.GoActionButton.TabIndex = 26;
            this.GoActionButton.Text = "Pull File";
            this.GoActionButton.UseVisualStyleBackColor = false;
            this.GoActionButton.Click += new System.EventHandler(this.GoActionButton_Click);
            // 
            // OpenNetBrowsing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GoActionButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.FilePath);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.Name = "OpenNetBrowsing";
            this.Text = "OpenNetBrowsing";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FilePath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox DirectoryList0;
        private System.Windows.Forms.Button GoActionButton;
    }
}