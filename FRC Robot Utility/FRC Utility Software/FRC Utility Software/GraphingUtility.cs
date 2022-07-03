using ScottPlot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FRC_Utility_Software
{
    public partial class GraphingUtility : Form
    {
        private double feildHeightFT = 27;
        private double feildLenghtFT = 54;
        private ScottPlot.Plottable.Image feildGraphImage;
        private Plot mainPlot;

        private string standardFormatedLineRegex = @"^\d{4}[_]\d{6}[_]\d{3}[-][Q][~].{1,20}[~]";

        public GraphingUtility(String valueKey, String[] logLines)
        {
            InitializeComponent();

            //mainGraphPlot.plt.AddPoint(0, 0);
            ArrayList linesWithKey = new ArrayList();
            
            foreach(String a in logLines)
            {
                if(Regex.Match(a, standardFormatedLineRegex).Success)
                {
                    String lineKey = a.Split("~")[1];
                    
                    if(lineKey.Equals(valueKey))
                    {
                        linesWithKey.Add(a);
                    }
                }
            }

            mainPlot = mainGraph.Plot;

            if (valueKey.Equals("SWDSE"))
            {

                ShowFieldCheckBox.Checked = true;

                foreach (String a in linesWithKey)
                {
                    String[] parts = a.Split(" ");
                    showSwerveModuleState(new Size(3, 3), Double.Parse(parts[9]), Double.Parse(parts[10]), -Math.PI / 2.0,
                        //Double.Parse(parts[11]), 
                        new double[] { Double.Parse(parts[1]), Double.Parse(parts[2]) },
                        new double[] { Double.Parse(parts[3]), Double.Parse(parts[4]) },
                        new double[] { Double.Parse(parts[5]), Double.Parse(parts[6]) },
                        new double[] { Double.Parse(parts[7]), Double.Parse(parts[8]) },
                        Color.DeepPink);
                }
            }

            //addVectorArrow(0, 0, toRadians(45), 6, Color.OrangeRed, 4);
            //showSwerveModuleState(new Size(3, 3), new Point(10, 10), 0, 0.7853981633974483, 0.7853981633974483, 0.7853981633974483, 0.7853981633974483, Color.DeepPink);
            mainGraph.Refresh();
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

            addVectorArrow(xs1[0], ys1[0], lf[0] - robotAngle, lf[1], Color.OrangeRed);
            addVectorArrow(xs1[1], ys1[1], lb[0] - robotAngle, lb[1], Color.OrangeRed);
            addVectorArrow(xs1[2], ys1[2], rb[0] - robotAngle, rb[1], Color.OrangeRed);
            addVectorArrow(xs1[3], ys1[3], rf[0] - robotAngle, rf[1], Color.OrangeRed);
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
    }
}
