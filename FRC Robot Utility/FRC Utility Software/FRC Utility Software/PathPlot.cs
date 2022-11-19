using FRCWaypointPloter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FRC_Utility_Software
{
    public partial class PathPlot : Form
    {
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;

        private bool inheritedStepList = false;

        private bool pointSelected = false;
        private bool pointSelectedMutable = false;
        private int selectedPoint;

        StepList stepList;

        //Splines Objecct
        QuinticHermiteSpline spline;
        List<Point2d> splinePoints = new List<Point2d>();
        List<Rotation2d> splinePointAngles = new List<Rotation2d>();

        Series waypoints;
        Series selectedPointSeries;
        Series generatedWaypoints;
        Series commandPoints;
        List<Series> regularPoints;

        PathCreator pathCreator;

        //Dictonary that hold what to do when pulling values from StepContainers
        Dictionary<string, Func<StepContainer, bool>> stepContainerReadMethods = new Dictionary<string, Func<StepContainer, bool>>();

        public PathPlot(PathCreator previousForm, StepList previousStepList)
        {
            InitializeComponent();

            pathCreator = previousForm;

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();

            // 
            // mainChart
            // 
            this.mainChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            chartArea1.BackImage = "C:\\Users\\Wyatt\\Pictures\\2022 FRC Feild.png";
            chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            chartArea1.CursorX.AutoScroll = false;
            chartArea1.CursorX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.CursorY.AutoScroll = false;
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            this.mainChart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mainChart.Location = new System.Drawing.Point(125, 8);
            this.mainChart.Name = "mainChart";
            this.mainChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainChart.Size = new System.Drawing.Size(1000, 540);
            this.mainChart.TabIndex = 4;
            this.mainChart.Text = "mainChart";
            this.mainChart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.onDoubleClick);
            this.mainChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseDrag);
            this.mainChart.Click += new System.EventHandler(this.addPoint);
            this.mainChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainChart_MouseMove);
            this.Controls.Add(this.mainChart);

            waypoints = new Series();
            selectedPointSeries = new Series();
            generatedWaypoints = new Series();
            commandPoints = new Series();
            regularPoints = new List<Series>();


            waypoints.ChartArea = "ChartArea1";
            waypoints.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            waypoints.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            waypoints.Name = "Waypoints";
            waypoints.Color = Color.RoyalBlue;

            selectedPointSeries.ChartArea = "ChartArea1";
            selectedPointSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            selectedPointSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            selectedPointSeries.Name = "Selected Waypoint";
            selectedPointSeries.MarkerSize = 10;
            selectedPointSeries.Color = Color.Violet;

            generatedWaypoints.ChartArea = "ChartArea1";
            generatedWaypoints.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            generatedWaypoints.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            generatedWaypoints.Name = "Generated Waypoints";
            //generatedWaypoints.Color = Color.Blue;

            commandPoints.ChartArea = "ChartArea1";
            commandPoints.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            commandPoints.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            commandPoints.Name = "Command";
            commandPoints.Color = System.Drawing.Color.Green;

            Series tmp = new Series();
            tmp.ChartArea = "ChartArea1";
            tmp.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            tmp.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            tmp.Name = "Regular Orange";
            tmp.Color = System.Drawing.Color.OrangeRed;
            regularPoints.Add(tmp);


            tmp = new Series();
            tmp.ChartArea = "ChartArea1";
            tmp.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            tmp.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            tmp.Name = "Regular Yellow";
            tmp.Color = System.Drawing.Color.Yellow;
            regularPoints.Add(tmp);


            tmp = new Series();
            tmp.ChartArea = "ChartArea1";
            tmp.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            tmp.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            tmp.Name = "Regular Purple";
            tmp.Color = System.Drawing.Color.Purple;
            regularPoints.Add(tmp);


            tmp = new Series();
            tmp.ChartArea = "ChartArea1";
            tmp.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            tmp.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            tmp.Name = "Regular Pink";
            tmp.Color = System.Drawing.Color.Pink;
            regularPoints.Add(tmp);

            this.mainChart.Series.Add(waypoints);
            this.mainChart.Series.Add(selectedPointSeries);
            this.mainChart.Series.Add(generatedWaypoints);
            this.mainChart.Series.Add(commandPoints);
            foreach (Series a in regularPoints)
            {
                this.mainChart.Series.Add(a);
            }

            mainChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            mainChart.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            mainChart.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
            mainChart.ChartAreas[0].AxisX.ScaleView.Size = 50.4375;
            mainChart.ChartAreas[0].AxisX.Maximum = 50.4375;
            mainChart.ChartAreas[0].AxisX.Minimum = 0;

            mainChart.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            mainChart.ChartAreas[0].AxisY.IsLabelAutoFit = false;
            mainChart.ChartAreas[0].AxisY.ScrollBar.Enabled = false;
            mainChart.ChartAreas[0].AxisY.ScaleView.Size = 26.9375;
            mainChart.ChartAreas[0].AxisY.Maximum = 26.9375;
            mainChart.ChartAreas[0].AxisY.Minimum = 0;

            mainChart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            mainChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;

            mainChart.ChartAreas[0].CursorY.Position = 0;

            commandGroup.AutoScroll = true;
            commandGroup.VerticalScroll.Visible = true;
            commandGroup.VerticalScroll.Enabled = true;

            addWaypointRatio.Checked = true;

            stepList = new StepList(previousStepList);



            stepContainerReadMethods.Add("setposition", (a) =>
            {
                waypoints.Points.AddXY((double)a.xDistanceNumeric.Value, (double)a.yDistanceNumeric.Value);
                splinePointAngles.Add(Rotation2d.fromDegrees((double) a.parm1Numeric.Value));
                //a.addOnDistanceChange(onCommandChanged);
                return false;
            });
            stepContainerReadMethods.Add("drive", (a) =>
            {
                waypoints.Points.AddXY((double)a.xDistanceNumeric.Value, (double)a.yDistanceNumeric.Value);
                splinePointAngles.Add(Rotation2d.fromDegrees((double) a.parm1Numeric.Value));
                //a.addOnDistanceChange(onCommandChanged);
                return false;
            });
            stepList.forEachType(stepContainerReadMethods, updateUserStepList);
        }

        private void onDoubleClick(object sender, MouseEventArgs e) {
            removeCheck.Checked = !removeCheck.Checked;

            if (removeCheck.Checked)
            {
                selectedPoint = -1;
                pointSelected = false;

                selectedPointSeries.Points.Clear();
                generatedWaypoints.Points.Clear();
            }
            else
            {
                if (continousGeneration.Checked)
                    onGenerate(sender, e);
            }
        }

        private void mouseDrag(object sender, MouseEventArgs e)
        {
            if(removeCheck.Checked)
            {
                double x = mainChart.ChartAreas[0].CursorX.Position;
                double y = mainChart.ChartAreas[0].CursorY.Position;
                if (addWaypointRatio.Checked || addCommandRatio.Checked)
                {
                    for(int i = 0; i <= stepList.getLength(); i++) //waypoints.Points.Count;)
                    {
                        generatedWaypoints.Points.Clear();
                        //double tmpX = waypoints.Points[i].XValue;
                        double tmpX = (double) stepList.get(i).xDistanceNumeric.Value;
                        double tmpY = (double)stepList.get(i).yDistanceNumeric.Value;
                        //double tmpY = waypoints.Points[i].YValues[0];
                        if (x - 1 <= tmpX && x + 1 >= tmpX && y - 1 <= tmpY && y + 1 >= tmpY && stepList.get(i).actionComboBox.Text.ToLower().Equals("drive"))
                        {
                            stepList.removeStepNumberInWaypoints(i);
                            //splinePointAngles.RemoveAt(i);
                            updateUserStepList(sender, e);
                            onCommandChanged(sender, e);
                            break;
                        }
                    }
                }
                else if (addPointRatio.Checked)
                {
                    generatedWaypoints.Points.Clear();
                    for (int a = 0; a < regularPoints.Count; a++)
                    {
                        for (int i = 0; i < regularPoints[a].Points.Count;)
                        {
                            double tmpX = regularPoints[a].Points[i].XValue;
                            double tmpY = regularPoints[a].Points[i].YValues[0];
                            if (x - 1 <= tmpX && x + 1 >= tmpX && y - 1 <= tmpY && y + 1 >= tmpY)
                            {
                                regularPoints[a].Points.RemoveAt(i);
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
            }
        }

        public void updateUserStepList(object sender, EventArgs e)
        {
            commandGroup.Controls.Clear();
            stepList.addAllToControl(commandGroup.Controls);
        }

        private void addPoint(object sender, EventArgs e)
        {
            double x = mainChart.ChartAreas[0].CursorX.Position;
            double y = mainChart.ChartAreas[0].CursorY.Position;

            if (pointSelected)
            {
                if (pointSelectedMutable)
                {
                    pointSelectedMutable = false;
                    pointSelected = false;
                    selectedPoint = -1;
                    selectedPointSeries.Points.Clear();
                    return;
                }

                StepContainer step = stepList.get(selectedPoint);
                step.xDistanceNumeric.Value = (decimal)x;
                step.yDistanceNumeric.Value = (decimal)y;

                if(selectedPoint < stepList.getLength() - 1)
                {
                    StepContainer nextStep = stepList.get(selectedPoint + 1);
                    Rotation2d angle = Rotation2d.fromRadians(Math.Atan2((double)(nextStep.yDistanceNumeric.Value - step.yDistanceNumeric.Value), (double)(nextStep.xDistanceNumeric.Value - step.xDistanceNumeric.Value)));
                    step.parm1Numeric.Value = (decimal) angle.getDegrees();
                }

                selectedPointSeries.Points.Clear();

                pointSelected = false;
                return;
            }

            //If we are not removing step Must be adding
            if (!removeCheck.Checked)
            {
                StepContainer step = new StepContainer();

                if (addWaypointRatio.Checked)
                {
                    double boxWidth = 1;

                    for (int index = 0; index < stepList.getLength(); index++)
                    {
                        //Point2d point = splinePoints[index];
                        StepContainer point = stepList.get(index);
                        if ((x < (double) point.xDistanceNumeric.Value + boxWidth && x > (double) point.xDistanceNumeric.Value - boxWidth) &&
                            (y < (double) point.yDistanceNumeric.Value + boxWidth && y > (double) point.yDistanceNumeric.Value - boxWidth))
                        {
                            selectedPoint = index;
                            selectedPointSeries.Points.AddXY(x, y);
                            commandGroup.ScrollControlIntoView(stepList.getList()[index].GetContainer());

                            lowerXNumeric.Value = point.xDistanceNumeric.Value;
                            lowerYNumeric.Value = point.yDistanceNumeric.Value;
                            angleTrackBar.Value = (int) point.parm1Numeric.Value;

                            pointSelected = true;
                            pointSelectedMutable = false;

                            return;
                        }
                    }

                    //TODO add point to list to add 
                    step.addValues("drive", 10, .5, x, y, false, new double[0]);

                    if (stepList.getLength() > 1)
                    {
                        StepContainer preiviousStep = stepList.get(stepList.getLength() - 1);
                        Rotation2d angle = Rotation2d.fromRadians(Math.Atan2((double)(step.yDistanceNumeric.Value - preiviousStep.yDistanceNumeric.Value), (double)(step.xDistanceNumeric.Value - preiviousStep.xDistanceNumeric.Value)));
                        preiviousStep.parm1Numeric.Value = (decimal)angle.getDegrees();
                    }

                    step.addOnDistanceChange(onCommandChanged);
                    stepList.addStep(step);
                    step.addToControl(commandGroup.Controls);
                    waypoints.Points.AddXY(x, y);
                    //onCommandChanged(sender, e);
                }
                else if (addCommandRatio.Checked)
                {
                    step.addValues("cmd", 0, 0, x, y, false, new double[0]);

                    step.addOnDistanceChange(onCommandChanged);
                    stepList.addStep(step);
                    onCommandChanged(sender, e);
                }
                else if (addPointRatio.Checked)
                {
                    try
                    {
                        regularPoints[colorPicker.SelectedIndex].Points.AddXY(x, y);
                    } catch (Exception exception)
                    {

                    }
                    return;
                }

                //commandGroup.Controls.Clear();
                //step.addToControl(commandGroup.Controls, steps.Count);
            }
        }

        private void mainChart_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            mainChart.ChartAreas[0].CursorX.Interval = 0.25;
            mainChart.ChartAreas[0].CursorY.Interval = 0.25;
            mainChart.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            mainChart.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

            //labelX.Text = "X: " + mainChart.ChartAreas[0].CursorX.Position;
            //labelY.Text = "Y: " + mainChart.ChartAreas[0].CursorY.Position;
        }

        private void onGenerate(object sender, EventArgs e)
        {
            List<Pose2d> poses = new List<Pose2d>();
            foreach(StepContainer step in stepList.getList())
            {
                if (step.actionComboBox.Text.Equals("drive") || step.actionComboBox.Text.ToLower().Equals("setposition"))
                {
                    poses.Add(new Pose2d(new Point2d((double)step.xDistanceNumeric.Value, (double)step.yDistanceNumeric.Value), Rotation2d.fromDegrees((double)step.parm1Numeric.Value)));
                }
            }
            spline = new QuinticHermiteSpline(poses, 0.6); //0.8

            List<PoseWithCurvature> poseWithCurvatures = spline.getSplinePoints();
            VelocityGenerator velocityGenerator = new VelocityGenerator(poseWithCurvatures, (double)maxVelocity.Value, (double)maxAcceleration.Value, (double)cornerPercent.Value);
            List<double> speeds = velocityGenerator.getSpeeds();

            generatedWaypoints.Points.Clear();

            if (velocityGenerator.getTotalTime() > 15)
                time.BackColor = Color.Red;
            else
                time.BackColor = Color.Transparent;

            time.Text = "Time: " + velocityGenerator.getTotalTime().ToString();

            for(int i = 0; i < poseWithCurvatures.Count; i++)
            {
                PoseWithCurvature correctedPose = restrictPoints(poseWithCurvatures[i], 0, 0, 1000, 540);
                generatedWaypoints.Points.AddXY(correctedPose.pose.getX(), correctedPose.pose.getY());
                generatedWaypoints.Points[i].Color = Color.FromArgb(0, Math.Clamp((int)Math.Abs((speeds[i]/(double) maxVelocity.Value) * 255), 0, 255), 255);
            }

        }
        public static PoseWithCurvature restrictPoints(PoseWithCurvature pose, double minX, double minY, double maxX, double maxY)
        {
            double x = pose.pose.getX();
            double y = pose.pose.getY();
            if (pose.pose.getX() > maxX)
            {
                x = maxX;
            }
            if (pose.pose.getX() < minX)
            {
                x = minX;
            }

            if (pose.pose.getY() > maxY)
            {
                y = maxY;
            }
            if (pose.pose.getY() < minY)
            {
                y = minY;
            }

            return new PoseWithCurvature(new Pose2d(new Point2d(x, y), pose.pose.getRotation()), pose.curvature);
        }

        private void onCommandChanged(object sender, EventArgs e) 
        {
            waypoints.Points.Clear();
            generatedWaypoints.Points.Clear();
            commandPoints.Points.Clear();
            splinePoints.Clear();
            splinePointAngles.Clear();

            stepList.forEachType(stepContainerReadMethods, updateUserStepList);

            if(continousGeneration.Checked)
            {
                onGenerate(sender, e);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            pathCreator.addToStepList(stepList);
            this.Close();
        }

        private void PathPlot_Load(object sender, EventArgs e)
        {

        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            splinePoints.Clear();
            splinePointAngles.Clear();

            regularPoints.Clear();

            waypoints.Points.Clear();
            selectedPointSeries.Points.Clear();
            commandPoints.Points.Clear();
            generatedWaypoints.Points.Clear();

            stepList.clear();

            updateUserStepList(sender, e);
        }

        private void continousGeneration_CheckedChanged(object sender, EventArgs e)
        {
            onGenerate(sender, e);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Rotation2d angle = Rotation2d.fromDegrees(angleTrackBar.Value);

            if (pointSelected)
            {
                stepList.get(selectedPoint).parm1Numeric.Value = (decimal) angle.getDegrees();       
                //onCommandChanged(sender, e);
                pointSelectedMutable = true;
            }
        }

        private void lowerXNumeric_ValueChanged(object sender, EventArgs e)
        {
            double x = (double)lowerXNumeric.Value;

            if (pointSelected)
            {
                stepList.get(selectedPoint).xDistanceNumeric.Value = (decimal) x;
                //onCommandChanged(sender, e);
                pointSelectedMutable = true;
            }
        }

        private void lowerYNumeric_ValueChanged(object sender, EventArgs e)
        {
            double y = (double)lowerYNumeric.Value;

            if (pointSelected)
            {
                stepList.get(selectedPoint).yDistanceNumeric.Value = (decimal) y;
                //onCommandChanged(sender, e);
                pointSelectedMutable = true;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
