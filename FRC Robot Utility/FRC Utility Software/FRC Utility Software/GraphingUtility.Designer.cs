namespace FRC_Utility_Software
{
    partial class GraphingUtility
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
            this.GraphToolPannel = new System.Windows.Forms.FlowLayoutPanel();
            this.ShowFieldCheckBox = new System.Windows.Forms.CheckBox();
            this.mainGraph = new ScottPlot.FormsPlot();
            this.GraphToolPannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GraphToolPannel
            // 
            this.GraphToolPannel.Controls.Add(this.ShowFieldCheckBox);
            this.GraphToolPannel.Location = new System.Drawing.Point(14, 12);
            this.GraphToolPannel.Name = "GraphToolPannel";
            this.GraphToolPannel.Size = new System.Drawing.Size(246, 810);
            this.GraphToolPannel.TabIndex = 0;
            // 
            // ShowFieldCheckBox
            // 
            this.ShowFieldCheckBox.AutoSize = true;
            this.ShowFieldCheckBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ShowFieldCheckBox.Location = new System.Drawing.Point(3, 3);
            this.ShowFieldCheckBox.Name = "ShowFieldCheckBox";
            this.ShowFieldCheckBox.Size = new System.Drawing.Size(194, 27);
            this.ShowFieldCheckBox.TabIndex = 0;
            this.ShowFieldCheckBox.Text = "Show Field Plot";
            this.ShowFieldCheckBox.UseVisualStyleBackColor = true;
            this.ShowFieldCheckBox.CheckedChanged += new System.EventHandler(this.ShowFieldCheckBox_CheckedChanged);
            // 
            // mainGraph
            // 
            this.mainGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainGraph.Location = new System.Drawing.Point(267, 12);
            this.mainGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainGraph.Name = "mainGraph";
            this.mainGraph.Size = new System.Drawing.Size(1408, 742);
            this.mainGraph.TabIndex = 1;
            this.mainGraph.Load += new System.EventHandler(this.mainGraphPlot_Load);
            // 
            // GraphingUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1688, 836);
            this.Controls.Add(this.mainGraph);
            this.Controls.Add(this.GraphToolPannel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.Name = "GraphingUtility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GraphingUtility";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.GraphToolPannel.ResumeLayout(false);
            this.GraphToolPannel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel GraphToolPannel;
        private System.Windows.Forms.CheckBox ShowFieldCheckBox;
        private ScottPlot.FormsPlot mainGraph;
    }
}