using ScottPlot;
using ScottPlot.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace FRC_Utility_Software
{
    public partial class GraphingUtility : Form
    {
        private double feildHeightFT = 27;
        private double feildLenghtFT = 54;
        private ScottPlot.Plottable.Image feildGraphImage;
        private Plot mainPlot;
        private string valueKey = "";

        private string standardFormatedLineRegex = @"^\d{4}[_]\d{6}[_]\d{3}[-][Q][~].{1,20}[~]";
        private Dictionary<string, List<string>> lineKeyDictionary = new Dictionary<string, List<string>>();
        private Dictionary<string, bool> lineKeyDisplayDictionary = new Dictionary<string, bool>();

        private DateTime startTime;
        private DateTime startLogTime;
        private DateTime nextDisplayTime;

        private System.Timers.Timer timer;
        private string motionKey;
        private Action<string, string> displayAction;
        private List<string> stringValues;

        private int idx = 1;
        public GraphingUtility(String _valueKey, String[] logLines)
        {
            InitializeComponent();

            valueKey = _valueKey;

            //mainGraphPlot.plt.AddPoint(0, 0);

            if (logLines == null)
                return;

            foreach(String a in logLines)
            {
                if(Regex.Match(a, standardFormatedLineRegex).Success)
                {
                    String lineKey = a.Split("~")[1];
                    
                    if(lineKeyDictionary.ContainsKey(lineKey))
                    {
                        lineKeyDictionary[lineKey].Add(a);
                    } else
                    {
                        List<string> tmp = new List<string>();
                        tmp.Add(a);

                        lineKeyDictionary.Add(lineKey, tmp);
                    }
                }
            }

            foreach (var a in lineKeyDictionary.Keys)
            {
                lineKeyDisplayDictionary.Add(a, false);
            }

            mainPlot = mainGraph.Plot;
            dataTypes.SelectedObject = new DictionaryAdapter(lineKeyDisplayDictionary);

            mainGraph.Configuration.UseRenderQueue = false;

            ShowFieldCheckBox.Checked = true;
            ShowFieldCheckBox_CheckedChanged(this, null);

            //addVectorArrow(0, 0, toRadians(45), 6, Color.OrangeRed, 4);
            //showSwerveModuleState(new Size(3, 3), new Point(10, 10), 0, 0.7853981633974483, 0.7853981633974483, 0.7853981633974483, 0.7853981633974483, Color.DeepPink);
            graphValues();
        }

        public double toRadians(double degress)
        {
            return (Math.PI / 180) * degress;
        }

        //Angle in Radians
        private void addVectorArrow(double x, double y, double a, double l, Color color, float w = 2)
        {
            double x2 = (l * Math.Cos(a)) + x;
            double y2 = (l * Math.Sin(a)) + y;
            mainPlot.AddArrow(x2, y2, x, y, w, color);
        }

        private void showSwerveModuleState(Size robotSize, double robotX, double robotY, double robotAngle, double[] lf, double[] lb, double[] rf, double[] rb, Color baseColor, double lineWidth = 2)
        {
            double halfRobotWidth = robotSize.Width / 2;
            double halfRobotHeight = robotSize.Height / 2;
            double[] xs1 = { robotX - (halfRobotWidth * Math.Cos(robotAngle)) - (halfRobotHeight * Math.Sin(robotAngle)), //Left Front
                             robotX - (halfRobotWidth * Math.Cos(robotAngle)) + (halfRobotHeight * Math.Sin(robotAngle)), //Left Back
                             robotX + (halfRobotWidth * Math.Cos(robotAngle)) + (halfRobotHeight * Math.Sin(robotAngle)), //Right Back
                             robotX + (halfRobotWidth * Math.Cos(robotAngle)) - (halfRobotHeight * Math.Sin(robotAngle)), //Right Front
                             }; 
            
            double[] ys1 = { robotY - (halfRobotWidth * Math.Sin(robotAngle)) + (halfRobotHeight * Math.Cos(robotAngle)),
                             robotY - (halfRobotWidth * Math.Sin(robotAngle)) - (halfRobotHeight * Math.Cos(robotAngle)),
                             robotY + (halfRobotWidth * Math.Sin(robotAngle)) - (halfRobotHeight * Math.Cos(robotAngle)),
                             robotY + (halfRobotWidth * Math.Sin(robotAngle)) + (halfRobotHeight * Math.Cos(robotAngle)),
                             };

            addVectorArrow(xs1[0], ys1[0], lf[0] - robotAngle, lf[1] * 5.0, Color.OrangeRed);
            addVectorArrow(xs1[1], ys1[1], lb[0] - robotAngle, lb[1] * 5.0, Color.OrangeRed);
            addVectorArrow(xs1[2], ys1[2], rb[0] - robotAngle, rb[1] * 5.0, Color.OrangeRed);
            addVectorArrow(xs1[3], ys1[3], rf[0] - robotAngle, rf[1] * 5.0, Color.OrangeRed);
            //addVectorArrow(xs1[0], ys1[0], lf[0], lf[1], Color.OrangeRed);
            //addVectorArrow(xs1[1], ys1[1], lb[0], lb[1], Color.OrangeRed);
            //addVectorArrow(xs1[2], ys1[2], rb[0], rb[1], Color.OrangeRed);
            //addVectorArrow(xs1[3], ys1[3], rf[0], rf[1], Color.OrangeRed);

            mainPlot.AddPolygon(xs1, ys1, Color.Transparent, lineWidth, baseColor);
        }

        private void ShowFieldCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(ShowFieldCheckBox.Checked)
            {
                feildGraphImage = mainPlot.AddImage(Properties.Resources.FIELD, 0, feildHeightFT);
                mainPlot.AxisScaleLock(true);
                mainGraph.Width = 1408;
                mainGraph.Height = 742;
                mainPlot.SetOuterViewLimits(0, feildLenghtFT, 0, feildHeightFT);
                mainPlot.SetInnerViewLimits(0, feildLenghtFT, 0, feildHeightFT);
            } else
            {
                mainPlot.Remove(feildGraphImage);
                mainPlot.AxisScaleLock(false);
                mainPlot.SetOuterViewLimits(double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity);
                mainPlot.SetInnerViewLimits(double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity);
            }

            mainGraph.Refresh();
        }

        private void mainGraphPlot_Load(object sender, EventArgs e)
        {

        }

        private void enableMatchTime_CheckedChanged(object sender, EventArgs e)
        {
            mainPlot.Clear();

            ShowFieldCheckBox_CheckedChanged(this, null);

            graphValues();
        }

        public void graphValues()
        {
            if (!enableMatchTime.Checked)
            {
                if (valueKey.Equals("ALL"))
                {
                    foreach (var a in lineKeyDisplayDictionary)
                    {
                        if (a.Value)
                        {
                            foreach (var b in lineKeyDictionary[a.Key])
                            {
                                displaySingleValue(a.Key, b);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var b in lineKeyDictionary[valueKey])
                    {
                        displaySingleValue(valueKey, b);
                    }
                }

                mainGraph.Refresh();
            } else
            {
                if (valueKey.Equals("ALL"))
                {
                    foreach (var a in lineKeyDisplayDictionary)
                    {
                        if (a.Value)
                        {
                            displayValuesOverTime(a.Key, lineKeyDictionary[a.Key], (string key, string line) =>
                            {
                                displaySingleValue(key, line);
                                //mainGraph.RefreshRequest();
                            });
                        }
                    }
                } else
                {
                    displayValuesOverTime(valueKey, lineKeyDictionary[valueKey], (string key, string line) =>
                    {
                        displaySingleValue(key, line);
                        //mainGraph.RefreshRequest();
                    });
                }
            }
        }

        private void dataTypes_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            graphValues();
        }

        public void graphRefresh()
        {

            lock (mainGraph)
            {
                mainGraph.Refresh(true, true);
            }
            //mainGraph.Update();
        }

        public void displayValuesOverTime(string key, List<string> lines, Action<string, string> display)
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(NextDisplayItemTimer_Tick);
            timer.Interval = 50;

            display.Invoke(key, lines[0]);

            stringValues = lineKeyDictionary[key];

            motionKey = key;
            displayAction = display;

            startTime = DateTime.Now;
            startLogTime = MainProject.getLineTime((string)lines[0]);
            nextDisplayTime = startTime + (MainProject.getLineTime((string)lines[1]) - startLogTime);

            timer.Start();
        }

        public void displaySingleValue(string key, string line)
        {
            if(key.Contains("RPG"))
            {
                displayRPG(key, line);
            } else if(key.Equals("SWDSE"))
            {
                displaySWDSE(key, line);
            }
        }

        public void displayRPG(string key, string line)
        {
            Color dotColor;
            switch(key.ToCharArray()[3])
            {
                case 'A':
                    dotColor = Color.Aqua;
                    break;
                case 'B':
                    dotColor = Color.Blue;
                    break;
                case 'C':
                    dotColor = Color.Crimson;
                    break;
                default:
                    dotColor = Color.Black;
                    break;
            }

            string[] parts = line.Split(" ");
            mainPlot.AddPoint(Double.Parse(parts[1]), Double.Parse(parts[2]), dotColor);
        }

        public void displaySWDSE(string key, string line)
        {
            string[] parts = line.Split(" ");

            showSwerveModuleState(new Size(3, 3), Double.Parse(parts[9]), Double.Parse(parts[10]), -Math.PI / 2.0,
                   //Double.Parse(parts[11]), 
                   new double[] { Double.Parse(parts[1]), Double.Parse(parts[2]) },
                   new double[] { Double.Parse(parts[3]), Double.Parse(parts[4]) },
                   new double[] { Double.Parse(parts[5]), Double.Parse(parts[6]) },
                   new double[] { Double.Parse(parts[7]), Double.Parse(parts[8]) },
                   Color.DeepPink);
        }

        private void NextDisplayItemTimer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show(nextDisplayTime.ToString() + " < " + DateTime.Now.ToString());
            if (nextDisplayTime < DateTime.Now)
            {
                mainPlot.Clear();
                displayAction.Invoke(motionKey, stringValues[idx]);

                TimeSpan time;

                while (true)
                {
                    idx++;

                    time = (MainProject.getLineTime((string)stringValues[idx]) - startLogTime);
                    DateTime proposedNextTime = startTime + time;

                    if ((proposedNextTime - nextDisplayTime).Milliseconds > 50 || idx >= stringValues.Count - 1)
                    {
                        break;
                    }
                }

                nextDisplayTime = startTime + time;

                try
                {
                    mainGraph.Refresh(true, true);
                } catch (InvalidOperationException error)
                {
                    Console.WriteLine(error.Message);
                }

                if (idx >= stringValues.Count - 1)
                {
                    timer.Stop();
                }
            }
        }

        private void pauseButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
