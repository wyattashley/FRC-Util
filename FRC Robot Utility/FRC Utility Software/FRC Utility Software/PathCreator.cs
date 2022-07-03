using FRCWaypointPloter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FRC_Utility_Software
{
    public partial class PathCreator : Form
    {
        StepList stepList = new StepList();
        //List<StepContainer> stepList = new List<StepContainer>();
        public PathCreator()
        {
            InitializeComponent();

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.VerticalScroll.Visible = true;
            flowLayoutPanel1.VerticalScroll.Enabled = true;

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

                    //sw.Write(stepList[0].ToXML());
                    foreach (StepContainer a in stepList.getList())
                    {
                        sw.Write(a.ToXML());
                        //a.ToXML(sw);
                    }

                    sw.WriteLine("</Steps>");
                    sw.Flush();
                }
            }
        }

        private void addStepButton_Click(object sender, EventArgs e)
        {
            stepList.addStep(new StepContainer());
            updateUserStepList();
        }

        private void removeStepButton_Click(object sender, EventArgs e)
        {
            int stepNumber = (int) removeStepNumeric.Value - 1;

            if (stepNumber >= 0)
                stepList.removeStep(stepNumber);

            updateUserStepList();
        }

        private void flipStepButton_Click(object sender, EventArgs e)
        {
            int stepNumber1 = (int) flipStepNumeric1.Value - 1;
            int stepNumber2 = (int) flipStepNumeric2.Value - 1;

            if (stepNumber1 >= 0 && stepNumber2 >= 0 && stepNumber1 != stepNumber2 && stepNumber1 < stepList.getLength() && stepNumber2 < stepList.getLength())
            {
                stepList.flipStep(stepNumber1, stepNumber2);
            }

            updateUserStepList();
        }

        public void addToStepList(StepList steps)
        {
            stepList = new StepList(steps);
            updateUserStepList();
            //if (inheritedValues)
            //    stepList.Clear();

            //stepList.AddRange(givenSteps);
            //updateUserStepList();
        }

        public void updateUserStepList()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach(StepContainer stepContainer in stepList.getList())
            {
                stepContainer.addToControl(flowLayoutPanel1.Controls);
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

                            stepList.addStep(container);
                        }
                    }
                }

                updateUserStepList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PathPlot plot = new PathPlot(this, stepList);
            plot.Show();
            plot.FormClosed += onPathPlotClosed;
        }

        private void onPathPlotClosed(object sender, EventArgs e)
        {
            updateUserStepList();
        }

        private void onPositionChange(object sender, EventArgs e)
        { 
            Point2d startPosition = getStartingPosition();
            foreach (StepContainer step in stepList.getList())
            {
                if (step.actionComboBox.Text.ToLower().Equals("setposition"))
                {
                    step.xDistanceNumeric.Value = (decimal) startPosition.getX();
                    step.yDistanceNumeric.Value = (decimal) startPosition.getY();
                    return;
                }
            }

            StepContainer stepContainer = new StepContainer();
            stepContainer.actionComboBox.Text = "SetPosition";
            stepContainer.xDistanceNumeric.Value = (decimal)startPosition.getX();
            stepContainer.yDistanceNumeric.Value = (decimal)startPosition.getY();
            stepList.insertBeginningStep(stepContainer);

            updateUserStepList();
        }

        public Point2d getStartingPosition()
        {
            if (red1.Checked)
                return new Point2d(27.50, 19.50);

            if (red2.Checked)
                return new Point2d(31.00, 13.75);

            if (red3.Checked)
                return new Point2d(30.00, 10.00);


            if (blue1.Checked)
                return new Point2d(23.00, 7.50);

            if (blue2.Checked)
                return new Point2d(19.25, 14.25);

            if (blue3.Checked)
                return new Point2d(23.00, 7.50);

            return null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stepList.clear();
            updateUserStepList();
        }
    }
}
