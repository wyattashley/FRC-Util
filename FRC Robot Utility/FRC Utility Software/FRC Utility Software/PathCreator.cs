using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FRC_Utility_Software
{
    public partial class PathCreator : Form
    {
        List<StepContainer> stepList;
        public PathCreator()
        {
            InitializeComponent();

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.VerticalScroll.Visible = true;
            flowLayoutPanel1.VerticalScroll.Enabled = true;

            stepList = new List<StepContainer>();
        }

        private void saveLocalButton_Click(object sender, EventArgs e)
        {
            saveLocalDialog.FileName = "Team2137Red1.xml";

            if (saveLocalDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = File.CreateText(saveLocalDialog.FileName))
                {
                    sw.WriteLine("<?xml version=\"1.0\"?>");
                    sw.WriteLine("<Steps>");
                    
                    foreach(StepContainer a in stepList)
                    {
                        sw.WriteLine(a.ToString());
                    }

                    sw.WriteLine("</Steps>");
                }
            }
        }

        private void addStepButton_Click(object sender, EventArgs e)
        {
            stepList.Add(new StepContainer());
        }

        private void removeStepButton_Click(object sender, EventArgs e)
        {
            int stepNumber = (int) removeStepNumeric.Value - 1;

            if (stepNumber != -1)
                stepList.RemoveAt(stepNumber);

            updateUserStepList();
        }

        private void flipStepButton_Click(object sender, EventArgs e)
        {
            int stepNumber1 = (int) flipStepNumeric1.Value - 1;
            int stepNumber2 = (int) flipStepNumeric2.Value - 1;

            if (stepNumber1 != -1 && stepNumber2 != -1 && stepNumber1 != stepNumber2 && stepNumber1 < stepList.Count && stepNumber2 < stepList.Count)
            {
                StepContainer tmp1 = stepList[stepNumber1];
                StepContainer tmp2 = stepList[stepNumber2];

                stepList.RemoveAt(stepNumber1);
                stepList.Insert(stepNumber1, tmp2);

                stepList.RemoveAt(stepNumber2);
                stepList.Insert(stepNumber2, tmp1);
            }

            updateUserStepList();
        }

        public void updateUserStepList()
        {
            flowLayoutPanel1.Controls.Clear();

            for(int i = 0; i < stepList.Count; i++)
            {
                stepList[i].addToControl(flowLayoutPanel1.Controls, i + 1);
            }
        }

        private void parseString(StepContainer container, string line2)
        {
            string value = Regex.Match(line2, @">(.*?)<").Groups[1].Value;

            if(value.Length < 1)
            {
                value = "null";

            }


            if (line2.Contains("command"))
            {
                container.actionComboBox.Text = value;
            }
            else if (line2.Contains("timeout"))
            {
                container.timeoutNumeric.Value = Convert.ToDecimal(value);
            }
            else if (line2.Contains("parallel"))
            {
                if (value.Contains("True"))
                    container.parrellelCheckBox.Checked = true;
            }
            else if (line2.Contains("speed"))
            {
                container.speedNumeric.Value = Convert.ToDecimal(value);
            }
            else if (line2.Contains("xdistance"))
            {
                container.xDistanceNumeric.Value = Convert.ToDecimal(value);
            }
            else if (line2.Contains("ydistance"))
            {
                container.yDistanceNumeric.Value = Convert.ToDecimal(value);
            }
            else if (line2.Contains("parm1"))
            {
                container.parm1Numeric.Value = Convert.ToDecimal(value);
            }
            else if (line2.Contains("parm2"))
            {
                container.parm2Numeric.Value = Convert.ToDecimal(value);
            }
            else if (line2.Contains("parm3"))
            {
                container.parm3Numeric.Value = Convert.ToDecimal(value);
            }
            else if (line2.Contains("parm4"))
            {
                container.parm4Numeric.Value = Convert.ToDecimal(value);
            }
            else if (line2.Contains("parm5"))
            {
                container.parm5Numeric.Value = Convert.ToDecimal(value);
            }
            else if (line2.Contains("parm6"))
            {
                container.parm6Numeric.Value = Convert.ToDecimal(value);
            }
            else if (line2.Contains("parm7"))
            {
                container.parm7Numeric.Value = Convert.ToDecimal(value);
            }
        }

        private void openLocalButton_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using(StreamReader reader = File.OpenText(openFileDialog1.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if(line.Contains("<Step>"))
                        {
                            StepContainer container = new StepContainer();
                            string line2 = reader.ReadLine();
                            while(!line2.Contains("</Step>"))
                            {
                                parseString(container, line2);
                                line2 = reader.ReadLine();
                            }

                            container.addToControl(flowLayoutPanel1.Controls, stepList.Count + 1);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new PathPlot()).Show();
        }
    }
}
