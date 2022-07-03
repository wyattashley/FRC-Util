namespace FRC_Utility_Software
{
    partial class BlueAllianceAPI
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
            this.eventList = new System.Windows.Forms.ComboBox();
            this.loadFIMEvents = new System.Windows.Forms.Button();
            this.loadAllEvents = new System.Windows.Forms.Button();
            this.loadScoreStates = new System.Windows.Forms.Button();
            this.outputDialog = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eventList
            // 
            this.eventList.FormattingEnabled = true;
            this.eventList.Location = new System.Drawing.Point(12, 12);
            this.eventList.Name = "eventList";
            this.eventList.Size = new System.Drawing.Size(411, 28);
            this.eventList.TabIndex = 0;
            this.eventList.Text = "FIRST Event";
            // 
            // loadFIMEvents
            // 
            this.loadFIMEvents.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loadFIMEvents.ForeColor = System.Drawing.Color.Black;
            this.loadFIMEvents.Location = new System.Drawing.Point(429, 12);
            this.loadFIMEvents.Name = "loadFIMEvents";
            this.loadFIMEvents.Size = new System.Drawing.Size(143, 29);
            this.loadFIMEvents.TabIndex = 1;
            this.loadFIMEvents.Text = "Load FIM Events";
            this.loadFIMEvents.UseVisualStyleBackColor = true;
            this.loadFIMEvents.Click += new System.EventHandler(this.loadFIMEvents_Click);
            // 
            // loadAllEvents
            // 
            this.loadAllEvents.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loadAllEvents.ForeColor = System.Drawing.Color.Black;
            this.loadAllEvents.Location = new System.Drawing.Point(578, 12);
            this.loadAllEvents.Name = "loadAllEvents";
            this.loadAllEvents.Size = new System.Drawing.Size(133, 29);
            this.loadAllEvents.TabIndex = 2;
            this.loadAllEvents.Text = "Load All Events";
            this.loadAllEvents.UseVisualStyleBackColor = true;
            this.loadAllEvents.Click += new System.EventHandler(this.loadAllEvents_Click);
            // 
            // loadScoreStates
            // 
            this.loadScoreStates.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loadScoreStates.ForeColor = System.Drawing.Color.Black;
            this.loadScoreStates.Location = new System.Drawing.Point(12, 46);
            this.loadScoreStates.Name = "loadScoreStates";
            this.loadScoreStates.Size = new System.Drawing.Size(143, 29);
            this.loadScoreStates.TabIndex = 3;
            this.loadScoreStates.Text = "Load Score States";
            this.loadScoreStates.UseVisualStyleBackColor = true;
            this.loadScoreStates.Click += new System.EventHandler(this.loadScoreStates_Click);
            // 
            // outputDialog
            // 
            this.outputDialog.Location = new System.Drawing.Point(482, 122);
            this.outputDialog.Name = "outputDialog";
            this.outputDialog.Size = new System.Drawing.Size(447, 416);
            this.outputDialog.TabIndex = 4;
            this.outputDialog.Text = "";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(30, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Load Score States";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BlueAllianceAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.outputDialog);
            this.Controls.Add(this.loadScoreStates);
            this.Controls.Add(this.loadAllEvents);
            this.Controls.Add(this.loadFIMEvents);
            this.Controls.Add(this.eventList);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.Name = "BlueAllianceAPI";
            this.Text = "BlueAllianceAPI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox eventList;
        private System.Windows.Forms.Button loadFIMEvents;
        private System.Windows.Forms.Button loadAllEvents;
        private System.Windows.Forms.Button loadScoreStates;
        private System.Windows.Forms.RichTextBox outputDialog;
        private System.Windows.Forms.Button button1;
    }
}