using FRCWaypointPloter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRC_Utility_Software
{
    public class VelocityGenerator
    {
        private double timeTotal = 0;
        private List<double> speeds = new List<double>();

        //Corner percent is the amount to stretch the original slow down determined by the percent of curve (degree change / 180)
        public VelocityGenerator(List<PoseWithCurvature> poses, double maxDrivetrainVelocity, double maxDrivetrainAcceleration, double cornerSpeed)
        {//, Speed2d startSpeed, Speed2d endSpeed) {
         //Max RadPerMeter is 2Pi
            speeds.Add(0);

            for (int i = 1; i < poses.Count(); i++)
            {
                double previousSpeed = speeds[i - 1];
                double maxAccel = maxDrivetrainAcceleration;
                double distanceBetweenWaypoint = Math.Sqrt(
                        Math.Pow(poses[i].pose.getX() - poses[i - 1].pose.getX(), 2) +
                        Math.Pow(poses[i].pose.getY() - poses[i - 1].pose.getY(), 2));

                double maxAccelSpeed = Math.Sqrt(Math.Pow(previousSpeed, 2) + (2 * maxAccel * distanceBetweenWaypoint));
                double curveSpeed = (1 - Math.Abs(poses[i].curvature.getRadians() / Math.PI)) * cornerSpeed;
                //if (maxAccelSpeed > maxDrivetrainVelocity)
                //    maxAccelSpeed = maxDrivetrainVelocity;
                //double curveSpeed = (Math.Abs((poses[i].curvature.getRadians()) / (Math.PI))) * maxAccelSpeed;
                //curveSpeed = stretchedValue;
                //MessageBox.Show((poses[i].curvature.getRadians() * 12).ToString());
                if (curveSpeed < maxAccelSpeed)
                    speeds.Add(Math.Clamp(curveSpeed, -maxDrivetrainVelocity, maxDrivetrainVelocity));
                else
                    speeds.Add(Math.Clamp(maxAccelSpeed, -maxDrivetrainVelocity, maxDrivetrainVelocity));
                //if (maxAccelSpeed > maxDrivetrainVelocity)
                //        maxAccelSpeed = maxDrivetrainVelocity;

                //if (curveSpeed < maxAccelSpeed)
                //    speeds.Add(curveSpeed);
                //else
                //    speeds.Add(maxAccelSpeed);

            }

            speeds[speeds.Count() - 1] = 0;

            for (int i = poses.Count() - 2; i >= 0; i--)
            {
                double previousSpeed = speeds[i + 1];
                double maxAccel = maxDrivetrainAcceleration;
                double distanceBetweenWaypoint = Math.Sqrt(
                        Math.Pow(poses[i].pose.getX() - poses[i + 1].pose.getX(), 2) +
                                Math.Pow(poses[i].pose.getY() - poses[i + 1].pose.getY(), 2));

                double maxAccelSpeed = Math.Sqrt(Math.Pow(previousSpeed, 2) + (2 * maxAccel * distanceBetweenWaypoint));
                double curveSpeed = (1 -Math.Abs((poses[i].curvature.getRadians()) / (Math.PI))) * cornerSpeed;
                // double curveSpeed = (1 - Math.Abs(poses[i].curvature.getRadians() / Math.PI)) * maxDrivetrainVelocity;
                double speed;

                if (curveSpeed < maxAccelSpeed)
                    speed = curveSpeed;
                else
                    speed = maxAccelSpeed;

                if (speed < speeds[i])
                    speeds[i] = Math.Clamp(speed, -maxDrivetrainVelocity, maxDrivetrainVelocity);

                if(speeds[i] != 0)
                    timeTotal += (distanceBetweenWaypoint / speeds[i]);
            }
        }

        public double getTotalTime()
        {
            return timeTotal;
        }
        
        public List<double> getSpeeds()
        {
            return speeds;
        }
    }
}
