using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private string[] lines;
        private int[] lengths;
        private string tmpFilePath;
        private string standardFormatedLineRegex = @"^\d{4}[_]\d{6}[_]\d{3}[-][WESD]";
        private string standardDateFormat = "MMdd_HHmmss_fff";
        private DateTime startTime;

        public MainProject()
        {
            InitializeComponent();
        }

        public void updateLogText()
        {

            if (lines.Length == 0)
                return;

            int totalLength = 0;

            if (WarningColorCheckbox.Checked)
                totalLength += lengths[0];
            if (StatusColorCheckbox.Checked)
                totalLength += lengths[1];
            if (ErrorColorCheckbox.Checked)
                totalLength += lengths[2];
            if (DebugColorCheckbox.Checked)
                totalLength += lengths[3];
            if (OtherColorCheckbox.Checked)
                totalLength += lengths[4];

            verticalScrollBar.Minimum = -1;
            verticalScrollBar.Maximum = totalLength + 34;

            StringBuilder builder = new StringBuilder();

            int displayedLines = 0;
            int currentEligableLineCount = 0;
            for (int lineNumber = 0; displayedLines < 34; lineNumber++)
            {
                if (lineNumber >= lines.Count())
                    break;

                string line = lines[lineNumber];

                Action lineCount = () =>
                {
                    if (currentEligableLineCount >= verticalScrollBar.Value)
                    {
                        builder.AppendLine(line);
                        displayedLines++;
                    }
                    else
                    {
                        currentEligableLineCount++;
                    }
                };

                if (!Regex.Match(line, standardFormatedLineRegex).Success)
                {
                    if (OtherColorCheckbox.Checked)
                    {
                        lineCount();
                    }
                    continue;
                }

                char id = line[16];
                switch (id)
                {
                    case 'W':
                        if (WarningColorCheckbox.Checked)
                        {
                            lineCount();
                        }
                        break;
                    case 'S':
                        if (StatusColorCheckbox.Checked)
                        {
                            lineCount();
                        }
                        break;
                    case 'E':
                        if (ErrorColorCheckbox.Checked)
                        {
                            lineCount();
                        }
                        break;
                    case 'D':
                        if (DebugColorCheckbox.Checked)
                        {
                            lineCount();
                        }
                        break;
                }
            }

            logTextboxView.Text = builder.ToString();

            highlightTextType();
        }


        public void highlightTextType()
        {
            int lineIndex = 0;
            foreach (string line in logTextboxView.Text.Split("\n"))
            {
                logTextboxView.Select(logTextboxView.GetFirstCharIndexFromLine(lineIndex), line.Length);

                lineIndex++;

                if (!Regex.Match(line, standardFormatedLineRegex).Success)
                {
                    continue;
                }

                char id = line[16];
                switch (id)
                {
                    case 'W':
                        logTextboxView.SelectionBackColor = Color.FromArgb(255, 127, 0);
                        break;
                    case 'S':
                        logTextboxView.SelectionBackColor = Color.FromArgb(156, 248, 255);
                        break;
                    case 'E':
                        logTextboxView.SelectionBackColor = Color.FromArgb(255, 0, 0);
                        break;
                    case 'D':
                        logTextboxView.SelectionBackColor = Color.FromArgb(243, 255, 156);
                        break;
                }
            }
        }

        private void OpenNetActionButton_Click(object sender, EventArgs e)
        {
            new OpenNetPrompt().Show();
        }

        public void openFile(string path) {
            tmpFilePath = path;
            logTextboxView.Text = "";

            lines = File.ReadAllLines(tmpFilePath);

            totalTimeLabel.Text = findElaspedTime().ToString();

            lengths = new int[5];

            foreach (string line in lines)
            {
                if (!Regex.Match(line, standardFormatedLineRegex).Success)
                {
                    lengths[4]++;
                    continue;
                }

                char id = line[16];

                switch (id)
                {
                    case 'W':
                        lengths[0]++;
                        break;
                    case 'S':
                        lengths[1]++;
                        break;
                    case 'E':
                        lengths[2]++;
                        break;
                    case 'D':
                        lengths[3]++;
                        break;
                }
            }

            updateLogText();
        }

        public string findFirstValidLine()
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (Regex.Match(lines[i], standardFormatedLineRegex).Success)
                    return lines[i];
            }

            return "None";
        }

        public string findLastValidLine()
        {
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                if (Regex.Match(lines[i], standardFormatedLineRegex).Success)
                    return lines[i];
            }

            return "None";
        }

        public TimeSpan findElaspedTime()
        {
            startTime = getLineTime(findFirstValidLine());
            DateTime end = getLineTime(findLastValidLine());
            return end - startTime;
        }

        public void OpenActionButton_Click(object sender, EventArgs e)
        {
            if (openLogDialog.ShowDialog() == DialogResult.OK)
            {
                openFile(openLogDialog.FileName);
            }
        }

        private void ColorCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            updateLogText();
        }

        private void createAutonFile_Click(object sender, EventArgs e)
        {
            (new PathCreator()).Show();
        }

        private void SaveActionButton_Click(object sender, EventArgs e)
        {

        }

        private void verticalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            updateLogText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new BlueAllianceAPI()).Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void GoActionButton_Click(object sender, EventArgs e)
        {
            DateTime toSearchTime = startTime.AddHours((int)HourEntry.Value);
            toSearchTime = toSearchTime.AddMinutes((int)MinuteEntry.Value);
            toSearchTime = toSearchTime.AddSeconds((int)SecondEntry.Value);

            int targetLine = searchTimeInLines(0, lines.Length, toSearchTime);

            int viableLines = 0;
            for (int i = 0; i <= targetLine; i++)
            {
                if (!Regex.Match(lines[i], standardFormatedLineRegex).Success)
                {
                    if (OtherColorCheckbox.Checked)
                    {
                        viableLines++;
                    }
                    continue;
                }

                char id = lines[i][16];
                switch (id)
                {
                    case 'W':
                        if (WarningColorCheckbox.Checked)
                        {
                            viableLines++;
                        }
                        break;
                    case 'S':
                        if (StatusColorCheckbox.Checked)
                        {
                            viableLines++;
                        }
                        break;
                    case 'E':
                        if (ErrorColorCheckbox.Checked)
                        {
                            viableLines++;
                        }
                        break;
                    case 'D':
                        if (DebugColorCheckbox.Checked)
                        {
                            viableLines++;
                        }
                        break;
                }
            }

            verticalScrollBar.Value = viableLines;
            updateLogText();
        }
        public int searchTimeInLines(int start, int end, DateTime timeToSearch)
        {
            DateTime currentLineDate = getLineTime(lines[(start + end) / 2]);

            if (start == end || Math.Abs(start - end) <= 1)
                return start;

            if (currentLineDate > timeToSearch)
                return searchTimeInLines(start, (start + end) / 2, timeToSearch);
            else if (currentLineDate < timeToSearch)
                return searchTimeInLines((start + end) / 2, end, timeToSearch);
            else
                return (start + end) / 2;
        }

        public DateTime getLineTime(string line)
        {
            return DateTime.ParseExact(line.Substring(0, 15), standardDateFormat, CultureInfo.InvariantCulture);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new GraphingUtility(keyValue.Text, lines)).Show();
        }
    }
}
