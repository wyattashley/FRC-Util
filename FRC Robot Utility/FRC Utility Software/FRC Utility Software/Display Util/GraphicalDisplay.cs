using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FRC_Utility_Software.Display_Util
{
    public partial class GraphicalDisplay : Form
    {
        private Chart mainChart;
        public GraphicalDisplay(Series[] series)
        {
            InitializeComponent();

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();

            // 
            // mainChart
            // 
            //this.mainChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(49)))));
            //chartArea1.BackImage = "C:\\Users\\Wyatt\\Pictures\\2022 FRC Feild.png";
            //chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            //chartArea1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            //chartArea1.CursorX.AutoScroll = false;
            //chartArea1.CursorX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            //chartArea1.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            //chartArea1.CursorY.AutoScroll = false;
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            //this.mainChart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mainChart.Location = new System.Drawing.Point(10, 10);
            this.mainChart.Name = "mainChart";
            this.mainChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainChart.Size = new System.Drawing.Size(1000, 540);
            //this.mainChart.TabIndex = 4;
            this.mainChart.Text = "mainChart";
            this.Controls.Add(this.mainChart);

            mainChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            //mainChart.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            mainChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            //mainChart.ChartAreas[0].AxisX.Maximum = 50.4375;
            //mainChart.ChartAreas[0].AxisX.Minimum = 0;

            mainChart.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            //mainChart.ChartAreas[0].AxisY.IsLabelAutoFit = false;
            mainChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            //mainChart.ChartAreas[0].AxisY.Maximum = 26.9375;
            //mainChart.ChartAreas[0].AxisY.Minimum = 0;

            mainChart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            mainChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

            //mainChart.ChartAreas[0].CursorY.Position = 0;

            foreach (Series serie in series)
            {
                this.mainChart.Legends.Add(serie.Name);
                this.mainChart.Series.Add(serie);
            }
        }
    }
}
