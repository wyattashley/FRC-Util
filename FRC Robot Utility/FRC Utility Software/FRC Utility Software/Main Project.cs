using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRC_Utility_Software
{
    public partial class MainProject : Form
    {
        private string tmpFilePath;
        public MainProject()
        {
            InitializeComponent();
        }

        public void updateLogText(string tmpPath)
        {
            tmpFilePath = tmpPath;
            logTextboxView.Text = "";

            string[] lines = File.ReadAllLines(tmpPath);

            StringBuilder builder = new StringBuilder();

            int index = 0;

            foreach (string line in lines) {

                index += line.Length;

                if (line.Substring(20, 5).Equals("Warni") && WarningColorCheckbox.Checked)
                {
                    builder.AppendLine(line);
                }
                if (line.Substring(20, 5).Equals("Statu") && StatusColorCheckbox.Checked)
                {
                    builder.AppendLine(line);
                }
                if (line.Substring(20, 5).Equals("Error") && ErrorColorCheckbox.Checked)
                {
                    builder.AppendLine(line);
                }
                if (line.Substring(20, 5).Equals("Debug") && DebugColorCheckbox.Checked)
                {
                    builder.AppendLine(line);
                }
            }

            logTextboxView.Text = builder.ToString();

            //if (lines.Length < 20000)
            //{
            //    highlightTextType();
            //}
        }
        public void highlightTextType()
        {
            int lineIndex = 0;
            foreach(string line in logTextboxView.Text.Split("\n"))
            {
                logTextboxView.Select(logTextboxView.GetFirstCharIndexFromLine(lineIndex), line.Length);
                if (line.Length > 25)
                {
                    if (line.Substring(20, 5).Equals("Warni"))
                    {
                        logTextboxView.SelectionBackColor = Color.FromArgb(255, 212, 156);
                    }
                    if (line.Substring(20, 5).Equals("Statu"))
                    {
                        logTextboxView.SelectionBackColor = Color.FromArgb(156, 248, 255);
                    }
                    if (line.Substring(20, 5).Equals("Error"))
                    {
                        logTextboxView.SelectionBackColor = Color.FromArgb(255, 155, 155);
                    }
                    if (line.Substring(20, 5).Equals("Debug"))
                    {
                        logTextboxView.SelectionBackColor = Color.FromArgb(243, 255, 156);
                    }
                }
                lineIndex++;
            }
        }
        
        private void OpenNetActionButton_Click(object sender, EventArgs e)
        {
            new OpenNetPrompt().Show();
        }

        

        private void OpenActionButton_Click(object sender, EventArgs e)
        {
            if (openLogDialog.ShowDialog() == DialogResult.OK)
            {
                updateLogText(openLogDialog.FileName);
            }
        }

        private void ColorCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            updateLogText(tmpFilePath);
        }

        private void createAutonFile_Click(object sender, EventArgs e)
        {
            (new PathCreator()).Show();
        }

        private void SaveActionButton_Click(object sender, EventArgs e)
        {

        }
    }
}
