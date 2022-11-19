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
            this.dataTypes = new System.Windows.Forms.PropertyGrid();
            this.ShowFieldCheckBox = new System.Windows.Forms.CheckBox();
            this.enableMatchTime = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.graphForwardButton = new System.Windows.Forms.Button();
            this.graphBackButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.mainGraph = new ScottPlot.FormsPlot();
            this.GraphToolPannel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GraphToolPannel
            // 
            this.GraphToolPannel.Controls.Add(this.dataTypes);
            this.GraphToolPannel.Controls.Add(this.ShowFieldCheckBox);
            this.GraphToolPannel.Controls.Add(this.enableMatchTime);
            this.GraphToolPannel.Controls.Add(this.tableLayoutPanel1);
            this.GraphToolPannel.Controls.Add(this.richTextBox1);
            this.GraphToolPannel.Location = new System.Drawing.Point(14, 12);
            this.GraphToolPannel.Name = "GraphToolPannel";
            this.GraphToolPannel.Size = new System.Drawing.Size(246, 810);
            this.GraphToolPannel.TabIndex = 0;
            // 
            // dataTypes
            // 
            this.dataTypes.Location = new System.Drawing.Point(3, 3);
            this.dataTypes.Name = "dataTypes";
            this.dataTypes.Size = new System.Drawing.Size(236, 268);
            this.dataTypes.TabIndex = 3;
            this.dataTypes.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.dataTypes_PropertyValueChanged);
            // 
            // ShowFieldCheckBox
            // 
            this.ShowFieldCheckBox.AutoSize = true;
            this.ShowFieldCheckBox.Checked = true;
            this.ShowFieldCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowFieldCheckBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ShowFieldCheckBox.Location = new System.Drawing.Point(3, 277);
            this.ShowFieldCheckBox.Name = "ShowFieldCheckBox";
            this.ShowFieldCheckBox.Size = new System.Drawing.Size(194, 27);
            this.ShowFieldCheckBox.TabIndex = 0;
            this.ShowFieldCheckBox.Text = "Show Field Plot";
            this.ShowFieldCheckBox.UseVisualStyleBackColor = true;
            this.ShowFieldCheckBox.CheckedChanged += new System.EventHandler(this.ShowFieldCheckBox_CheckedChanged);
            // 
            // enableMatchTime
            // 
            this.enableMatchTime.AutoSize = true;
            this.enableMatchTime.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.enableMatchTime.Location = new System.Drawing.Point(3, 310);
            this.enableMatchTime.Name = "enableMatchTime";
            this.enableMatchTime.Size = new System.Drawing.Size(236, 27);
            this.enableMatchTime.TabIndex = 2;
            this.enableMatchTime.Text = "Enable Match Time";
            this.enableMatchTime.UseVisualStyleBackColor = true;
            this.enableMatchTime.CheckedChanged += new System.EventHandler(this.enableMatchTime_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.Controls.Add(this.graphForwardButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.graphBackButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pauseButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 343);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 34);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // graphForwardButton
            // 
            this.graphForwardButton.Location = new System.Drawing.Point(163, 3);
            this.graphForwardButton.Name = "graphForwardButton";
            this.graphForwardButton.Size = new System.Drawing.Size(77, 28);
            this.graphForwardButton.TabIndex = 1;
            this.graphForwardButton.Text = "--->";
            this.graphForwardButton.UseVisualStyleBackColor = true;
            // 
            // graphBackButton
            // 
            this.graphBackButton.Location = new System.Drawing.Point(3, 3);
            this.graphBackButton.Name = "graphBackButton";
            this.graphBackButton.Size = new System.Drawing.Size(74, 28);
            this.graphBackButton.TabIndex = 2;
            this.graphBackButton.Text = "<---";
            this.graphBackButton.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pauseButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.pauseButton.AutoSize = true;
            this.pauseButton.Location = new System.Drawing.Point(97, 3);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(45, 28);
            this.pauseButton.TabIndex = 3;
            this.pauseButton.Text = "  ||  ";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.CheckedChanged += new System.EventHandler(this.pauseButton_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 383);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(243, 120);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
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
            this.GraphToolPannel.ResumeLayout(false);
            this.GraphToolPannel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel GraphToolPannel;
        private System.Windows.Forms.CheckBox ShowFieldCheckBox;
        private ScottPlot.FormsPlot mainGraph;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button graphForwardButton;
        private System.Windows.Forms.Button graphBackButton;
        private System.Windows.Forms.CheckBox pauseButton;
        private System.Windows.Forms.CheckBox enableMatchTime;
        private System.Windows.Forms.PropertyGrid dataTypes;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}