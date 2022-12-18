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
            this.label1 = new System.Windows.Forms.Label();
            this.TeamNumberNumeric = new System.Windows.Forms.NumericUpDown();
            this.LoadTeam = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TeamNumberNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // eventList
            // 
            this.eventList.FormattingEnabled = true;
            this.eventList.Location = new System.Drawing.Point(26, 25);
            this.eventList.Margin = new System.Windows.Forms.Padding(6);
            this.eventList.Name = "eventList";
            this.eventList.Size = new System.Drawing.Size(869, 49);
            this.eventList.TabIndex = 0;
            this.eventList.Text = "FIRST Event";
            // 
            // loadFIMEvents
            // 
            this.loadFIMEvents.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loadFIMEvents.ForeColor = System.Drawing.Color.Black;
            this.loadFIMEvents.Location = new System.Drawing.Point(912, 25);
            this.loadFIMEvents.Margin = new System.Windows.Forms.Padding(6);
            this.loadFIMEvents.Name = "loadFIMEvents";
            this.loadFIMEvents.Size = new System.Drawing.Size(304, 59);
            this.loadFIMEvents.TabIndex = 1;
            this.loadFIMEvents.Text = "Load FIM Events";
            this.loadFIMEvents.UseVisualStyleBackColor = true;
            this.loadFIMEvents.Click += new System.EventHandler(this.loadFIMEvents_Click);
            // 
            // loadAllEvents
            // 
            this.loadAllEvents.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loadAllEvents.ForeColor = System.Drawing.Color.Black;
            this.loadAllEvents.Location = new System.Drawing.Point(1228, 25);
            this.loadAllEvents.Margin = new System.Windows.Forms.Padding(6);
            this.loadAllEvents.Name = "loadAllEvents";
            this.loadAllEvents.Size = new System.Drawing.Size(283, 59);
            this.loadAllEvents.TabIndex = 2;
            this.loadAllEvents.Text = "Load All Events";
            this.loadAllEvents.UseVisualStyleBackColor = true;
            this.loadAllEvents.Click += new System.EventHandler(this.loadAllEvents_Click);
            // 
            // loadScoreStates
            // 
            this.loadScoreStates.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loadScoreStates.ForeColor = System.Drawing.Color.Black;
            this.loadScoreStates.Location = new System.Drawing.Point(26, 94);
            this.loadScoreStates.Margin = new System.Windows.Forms.Padding(6);
            this.loadScoreStates.Name = "loadScoreStates";
            this.loadScoreStates.Size = new System.Drawing.Size(304, 59);
            this.loadScoreStates.TabIndex = 3;
            this.loadScoreStates.Text = "Load Score States";
            this.loadScoreStates.UseVisualStyleBackColor = true;
            this.loadScoreStates.Click += new System.EventHandler(this.loadScoreStates_Click);
            // 
            // outputDialog
            // 
            this.outputDialog.Location = new System.Drawing.Point(1171, 116);
            this.outputDialog.Margin = new System.Windows.Forms.Padding(6);
            this.outputDialog.Name = "outputDialog";
            this.outputDialog.Size = new System.Drawing.Size(1274, 997);
            this.outputDialog.TabIndex = 4;
            this.outputDialog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 41);
            this.label1.TabIndex = 5;
            this.label1.Text = "Team Number:";
            // 
            // TeamNumberNumeric
            // 
            this.TeamNumberNumeric.Location = new System.Drawing.Point(244, 247);
            this.TeamNumberNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TeamNumberNumeric.Name = "TeamNumberNumeric";
            this.TeamNumberNumeric.Size = new System.Drawing.Size(300, 47);
            this.TeamNumberNumeric.TabIndex = 6;
            // 
            // LoadTeam
            // 
            this.LoadTeam.ForeColor = System.Drawing.Color.Black;
            this.LoadTeam.Location = new System.Drawing.Point(356, 327);
            this.LoadTeam.Name = "LoadTeam";
            this.LoadTeam.Size = new System.Drawing.Size(188, 58);
            this.LoadTeam.TabIndex = 7;
            this.LoadTeam.Text = "Load Team";
            this.LoadTeam.UseVisualStyleBackColor = true;
            this.LoadTeam.Click += new System.EventHandler(this.LoadTeam_Click);
            // 
            // BlueAllianceAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(2460, 1128);
            this.Controls.Add(this.LoadTeam);
            this.Controls.Add(this.TeamNumberNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputDialog);
            this.Controls.Add(this.loadScoreStates);
            this.Controls.Add(this.loadAllEvents);
            this.Controls.Add(this.loadFIMEvents);
            this.Controls.Add(this.eventList);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(5)))));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BlueAllianceAPI";
            this.Text = "BlueAllianceAPI";
            ((System.ComponentModel.ISupportInitialize)(this.TeamNumberNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox eventList;
        private System.Windows.Forms.Button loadFIMEvents;
        private System.Windows.Forms.Button loadAllEvents;
        private System.Windows.Forms.Button loadScoreStates;
        private System.Windows.Forms.RichTextBox outputDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TeamNumberNumeric;
        private System.Windows.Forms.Button LoadTeam;
    }
}