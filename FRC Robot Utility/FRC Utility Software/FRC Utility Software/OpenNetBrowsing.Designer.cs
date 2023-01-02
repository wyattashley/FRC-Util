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
            this.GoActionButton = new System.Windows.Forms.Button();
            this.fileTreeViewer = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // FilePath
            // 
            this.FilePath.AutoSize = true;
            this.FilePath.Location = new System.Drawing.Point(12, 25);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(52, 15);
            this.FilePath.TabIndex = 0;
            this.FilePath.Text = "File Path";
            // 
            // GoActionButton
            // 
            this.GoActionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.GoActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoActionButton.Font = new System.Drawing.Font("SF Sports Night NS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GoActionButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.GoActionButton.Location = new System.Drawing.Point(524, 427);
            this.GoActionButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoActionButton.Name = "GoActionButton";
            this.GoActionButton.Size = new System.Drawing.Size(120, 29);
            this.GoActionButton.TabIndex = 26;
            this.GoActionButton.Text = "Pull File";
            this.GoActionButton.UseVisualStyleBackColor = false;
            this.GoActionButton.Click += new System.EventHandler(this.GoActionButton_Click);
            // 
            // fileTreeViewer
            // 
            this.fileTreeViewer.Location = new System.Drawing.Point(12, 43);
            this.fileTreeViewer.Name = "fileTreeViewer";
            this.fileTreeViewer.Size = new System.Drawing.Size(506, 413);
            this.fileTreeViewer.TabIndex = 27;
            this.fileTreeViewer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.fileTreeViewer_BeforeExpand);
            this.fileTreeViewer.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.fileTreeViewer_BeforeSelect);
            this.fileTreeViewer.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.fileTreeViewer_NodeMouseDoubleClick);
            // 
            // OpenNetBrowsing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(700, 468);
            this.Controls.Add(this.fileTreeViewer);
            this.Controls.Add(this.GoActionButton);
            this.Controls.Add(this.FilePath);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OpenNetBrowsing";
            this.Text = "OpenNetBrowsing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FilePath;
        private System.Windows.Forms.Button GoActionButton;
        private System.Windows.Forms.TreeView fileTreeViewer;
    }
}