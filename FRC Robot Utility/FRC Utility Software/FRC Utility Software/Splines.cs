using FRC_Utility_Software;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace FRCWaypointPloter
{

    public class Spline
    {
        private int m_degree;
        private Matrix<double> coefficients;

        public Spline(int degree, Matrix<double> coe)
        {
            m_degree = degree;
            coefficients = coe;
        }

        public Spline(Matrix<double> coe)
        {
            m_degree = 5;
            coefficients = coe;
        }

        public Matrix<double> getCoefficients()
        {
            return coefficients;
        }

        public PoseWithCurvature getPoint(double t)
        {
            Matrix<double> polynomialBases = Matrix<double>.Build.DenseOfArray(new double[m_degree + 1, 1]);

            for (int i = 0; i <= m_degree; i++)
            {
                polynomialBases[i, 0] = Math.Pow(t, m_degree - i);
            }

            Matrix<double> mixed = coefficients * polynomialBases;

            double x = mixed[0, 0];
            double y = mixed[1, 0];

            double dx, dy, ddx, ddy;

            if (t == 0)
            {
                dx = coefficients[2, m_degree - 1];
                dy = coefficients[3, m_degree - 1];
                ddx = coefficients[4, m_degree - 2];
                ddy = coefficients[5, m_degree - 2];
            }
            else
            {
                dx = mixed[2, 0] / t;
                dy = mixed[3, 0] / t;

                ddx = mixed[4, 0] / t / t;
                ddy = mixed[5, 0] / t / t;
            }

            double curve = (dx * ddy - ddx * dy) / ((dx * dx + dy * dy) * Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));

            return new PoseWithCurvature(new Pose2d(new Point2d(x, y), new Rotation2d(dx, dy)), Rotation2d.fromRadians(curve));
        }
    }

    public class QuinticHermiteSpline
    {
        private Matrix<double> hermiteBasisMatrix;
        private List<Spline> splines = new List<Spline>();

        public QuinticHermiteSpline(List<Pose2d> waypoints, double horizontalScaler)
        {
            hermiteBasisMatrix = getHermiteBasis();

            for (int a = 0; a < waypoints.Count() - 1; a++)
            {
                ControlVectorPair controlVector = new ControlVectorPair(waypoints[a], waypoints[a + 1], horizontalScaler);

                var x = controlVector.getXControlMatrix();
                var y = controlVector.getYControlMatrix();

                var xCoeffs = (hermiteBasisMatrix * x).Transpose();
                var yCoeffs = (hermiteBasisMatrix * y).Transpose();

                Matrix<double> tmp = Matrix<double>.Build.DenseOfArray(new double[6, 6]);
                tmp.SetRow(0, xCoeffs.Row(0).ToArray());
                tmp.SetRow(1, yCoeffs.Row(0).ToArray());

                for (int i = 0; i < 6; i++)
                {
                    tmp[2, i] = tmp[0, i] * (5 - i);
                    tmp[3, i] = tmp[1, i] * (5 - i);
                }
                for (int i = 0; i < 6; i++)
                {
                    tmp[4, i] = tmp[2, i] * (4 - i);
                    tmp[5, i] = tmp[3, i] * (4 - i);
                }

                splines.Add(new Spline(tmp));
            }

            Console.WriteLine(splines.Count());
        }

        //public QuinticHermiteSpline(DataPointCollection points, List<Rotation2d> pointAngles, double horizontalScaler)
        //{
        //    List<Pose2d> pose = new List<Pose2d>();

        //    if (points.Count() == 0)
        //        return;


            //Rotation2d rotation = Rotation2d.fromDegrees(0);
            //double maxAngles = pointAngles.Count();

            //for (int a = 0; a < points.Count() - 1; a++)
            //{

            //    if (maxAngles > a && (double) pointAngles[a].getDegrees() != 0.0)
            //    {
            //        rotation = pointAngles[a];
            //    }
            //    else
            //    {
            //        rotation = Rotation2d.fromRadians(Math.Atan2(points[a + 1].YValues[0] - points[a].YValues[0], points[a + 1].XValue - points[a].XValue));
            //    }
            //    pose.Add(new Pose2d(new Point2d(points[a].XValue, points[a].YValues[0]), rotation));
            //}

            //if (pointAngles.Count() >= points.Count())
            //{
            //    pose.Add(new Pose2d(new Point2d(points[points.Count() - 1].XValue, points[points.Count() - 1].YValues[0]), pointAngles[points.Count() - 1]));
            //}
            //else
            //{
            //    pose.Add(new Pose2d(new Point2d(points[points.Count() - 1].XValue, points[points.Count() - 1].YValues[0]), rotation));
            //}

        //    QuinticHermiteSpline b = new QuinticHermiteSpline(pose, horizontalScaler);
        //    splines = b.getSplines();
        //}


        public static Matrix<double> getHermiteBasis()
        {
            double[,] matrix = new double[,]
            {
                { -06.0, -03.0, -00.5, +06.0, -03.0, +00.5 },
                { +15.0, +08.0, +01.5, -15.0, +07.0, +01.0 },
                { -10.0, -06.0, -01.5, +10.0, -04.0, +00.5 },
                { +00.0, +00.0, +00.5, +00.0, +00.0, +00.0 },
                { +00.0, +01.0, +00.0, +00.0, +00.0, +00.0 },
                { +01.0, +00.0, +00.0, +00.0, +00.0, +00.0 }
            };
            return Matrix<double>.Build.DenseOfArray(matrix);
        }

        public List<Spline> getSplines()
        {
            return splines;
        }

        public List<PoseWithCurvature> getSplinePoints()
        {
            if (splines.Count() == 0)
                return new List<PoseWithCurvature>();

            var splinePoints = new List<PoseWithCurvature>();

            splinePoints.Add(splines[0].getPoint(0.0));

            for (int i = 0; i < splines.Count(); i++)
            {
                var points = parameterizeSpline(splines[i]);
                points.RemoveAt(0);
                splinePoints.AddRange(points);
            }

            return splinePoints;
        }

        private List<PoseWithCurvature> parameterizeSpline(Spline spline)
        {
            return parameterizeSpline(spline, 0.0, 1.0, 0.00127, 0.127, 0.0872, 5000);
        }


        private List<PoseWithCurvature> parameterizeSpline(Spline spline, double t0, double t1, double kMaxDy, double kMaxDx, double kMaxDTheata, double kMaxIterations)
        {
            var splinePoints = new List<PoseWithCurvature>();

            splinePoints.Add(spline.getPoint(t0));

            Point2d current;
            PoseWithCurvature start;
            PoseWithCurvature end;

            List<Point2d> toRun = new List<Point2d>();
            toRun.Add(new Point2d(t0, t1));

            int index = 0;

            while (toRun.Count() != 0)
            {
                current = toRun[0];
                toRun.RemoveAt(0);
                start = spline.getPoint(current.getX());
                end = spline.getPoint(current.getY());

                var twist = start.pose.log(end.pose);

                //Console.WriteLine(start.pose.getRotation().getRadians() + "," + end.pose.getRotation().getRadians()); This is fine
                //Console.WriteLine(twist.getAngularComponent().getRadians());
                //Console.WriteLine(current.getX() + "," + current.getY() + "," + Math.Abs(twist.getLinearComponent().getY()) + "," + Math.Abs(twist.getLinearComponent().getX()) + "," + Math.Abs(twist.getAngularComponent().getRadians()) + ","  + start.pose.getX() + "," + start.pose.getY() + "," + end.pose.getX() + "," + end.pose.getY());

                if (Math.Abs(twist.getLinearComponent().getY()) > kMaxDy
                    || Math.Abs(twist.getLinearComponent().getX()) > kMaxDx
                    || Math.Abs(twist.getAngularComponent().getRadians()) > kMaxDTheata)
                {
                    toRun.Insert(0, new Point2d((current.getX() + current.getY()) / 2, current.getY()));
                    //Console.WriteLine("Adding " + ((current.getX() + current.getY()) / 2) + " and " + current.getY());

                    toRun.Insert(0, new Point2d(current.getX(), (current.getX() + current.getY()) / 2));
                    //Console.WriteLine("Adding " + (current.getX()) + " and " + ((current.getX() + current.getY()) / 2));
                }
                else
                {
                    splinePoints.Add(spline.getPoint(current.getY()));
                }

                index++;

                if (index >= kMaxIterations)
                {
                    throw new Exception("Could Not parameterize a malformed spline");
                }
            }

            return splinePoints;
        }
    }

    public class ControlVectorPair
    {
        private Pose2d poseInitial;
        private Pose2d poseFinal;
        private double scalar;

        public ControlVectorPair(Pose2d pose1, Pose2d pose2, double _horizontalScalar)
        {
            poseInitial = pose1;
            poseFinal = pose2;
            scalar = _horizontalScalar * pose1.getTranslation().getDistance(pose2.getTranslation());
        }

        public Matrix<double> getXControlMatrix()
        {
            if (poseInitial == null || poseFinal == null)
                throw new ArgumentNullException("Posed passed is null");
            return Matrix<double>.Build.DenseOfArray(new double[,]
            {
                { poseInitial.getX() }, { poseInitial.getRotation().getCos() * scalar }, {0.0 },
                { poseFinal.getX() }, { poseFinal.getRotation().getCos() * scalar }, { 0.0 }
            });
        }

        public Matrix<double> getYControlMatrix()
        {
            if (poseInitial == null || poseFinal == null)
                throw new ArgumentException("Pose passed is null");

            return Matrix<double>.Build.DenseOfArray(new double[,]
            {
                { poseInitial.getY() }, { poseInitial.getRotation().getSin() * scalar }, { 0.0 },
                { poseFinal.getY() }, { poseFinal.getRotation().getSin() * scalar }, { 0.0 }
            });
        }
    }


    #region extras
    public class Point2d
    {
        private double x, y;

        public Point2d(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public void setX(double _x)
        {
            x = _x;
        }

        public void setY(double _y)
        {
            y = _y;
        }

        public double getDistance(Point2d other)
        {
            return Math.Sqrt(Math.Pow(other.getX() - x, 2) + Math.Pow(other.getY() - y, 2));
        }

        public double getNorm()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public Point2d rotateBy(Rotation2d angle)
        {
            return new Point2d(x * angle.getCos() - y * angle.getSin(), x * angle.getSin() + y * angle.getCos());
        }

        public Point2d plus(Point2d other)
        {
            return new Point2d(x + other.getX(), y + other.getY());
        }

        public Point2d minus(Point2d other)
        {
            return new Point2d(x - other.getX(), y - other.getY());
        }

        public Point2d unaryMinus()
        {
            return new Point2d(-x, -y);
        }

        public Point2d times(double scalar)
        {
            return new Point2d(x * scalar, y * scalar);
        }

        public double getVectorMagnitude(Point2d other)
        {
            return Math.Sqrt(Math.Pow(getX() - other.getX(), 2) + Math.Pow(getY() - other.getY(), 2));
        }

        public Pose2d vectorizeNormal(Point2d other)
        {
            double mag = getVectorMagnitude(other);
            double x = Math.Abs(getX() - other.getX()) / mag;
            double y = Math.Abs(getY() - other.getY()) / mag;
            Rotation2d r = Rotation2d.fromRadians(Math.Atan2(y, x));

            return new Pose2d(x, y, r);
        }

        public Pose2d vectorizeToNext(Point2d other)
        {
            double mag = getVectorMagnitude(other);
            double x = (getX() - other.getX()) / mag;
            double y = (getY() - other.getY()) / mag;
            Rotation2d r = Rotation2d.fromRadians(Math.Atan2(x, y));

            return new Pose2d(other.getX(), other.getY(), r);
        }

    }

    public class Rotation2d
    {
        private double angleRadians;
        private double angleCos;
        private double angleSin;

        private Rotation2d(double radians)
        {
            angleRadians = radians;
            angleCos = Math.Cos(radians);
            angleSin = Math.Sin(radians);
        }

        public Rotation2d(double x, double y)
        {
            double magnitude = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            if (magnitude > 1e-6)
            {
                angleSin = y / magnitude;
                angleCos = x / magnitude;
            }
            else
            {
                angleSin = 0.0;
                angleCos = 1.0;
            }

            angleRadians = Math.Atan2(angleSin, angleCos);
        }

        public static Rotation2d fromDegrees(double value)
        {
            return new Rotation2d(degreeToRadians(value));
        }

        public static Rotation2d fromRadians(double value)
        {
            return new Rotation2d(value);
        }

        private static double radiansToDegree(double radians)
        {
            return (180.0 / Math.PI) * radians;
        }

        public static double degreeToRadians(double degree)
        {
            return (Math.PI / 180.0) * degree;
        }

        public double getDegrees()
        {
            return radiansToDegree(angleRadians);
        }

        public double getRadians()
        {
            return angleRadians;
        }

        public double getCos()
        {
            return angleCos;
        }

        public double getSin()
        {
            return angleSin;
        }

        public Rotation2d rotateBy(Rotation2d other)
        {
            return new Rotation2d(angleCos * other.getCos() - angleSin * other.getSin(), angleCos * other.getSin() + angleSin * other.getCos());
        }

        public Rotation2d plus(Rotation2d other)
        {
            return rotateBy(other);
        }

        public Rotation2d minus(Rotation2d other)
        {
            return rotateBy(other.unaryMinus());
        }

        public Rotation2d unaryMinus()
        {
            return new Rotation2d(-angleRadians);
        }
    }

    public class Pose2d
    {
        private Point2d point;
        private Rotation2d angle;

        public Pose2d(Point2d _point, Rotation2d _angle)
        {
            point = _point;
            angle = _angle;
        }

        public Pose2d(double x, double y, Rotation2d _angle)
        {
            point = new Point2d(x, y);
            angle = _angle;
        }

        public Point2d getTranslation()
        {
            return point;
        }

        public double getX()
        {
            return point.getX();
        }

        public double getY()
        {
            return point.getY();
        }

        public Rotation2d getRotation()
        {
            return angle;
        }

        public Pose2d plus(Transform2d other)
        {
            return transformBy(other);
        }

        public Pose2d transformBy(Transform2d other)
        {
            return new Pose2d(point.plus(other.getTranslation().rotateBy(angle)), angle.plus(other.getRotation()));
        }

        public Pose2d relativeTo(Pose2d other)
        {
            Transform2d transform = new Transform2d(other, this);
            return new Pose2d(transform.getTranslation(), transform.getRotation());
        }

        public Twist2d log(Pose2d end)
        {
            var transform = end.relativeTo(this);
            var dtheta = transform.getRotation().getRadians();
            var halfDTheata = dtheta / 2.0;

            var cosMinusOne = transform.getRotation().getCos() - 1;

            double halfThetaByTanOfHalftheta;
            if (Math.Abs(cosMinusOne) < 1E-9)
            {
                halfThetaByTanOfHalftheta = 1.0 - 1.0 / 12.0 * dtheta * dtheta;
            }
            else
            {
                halfThetaByTanOfHalftheta = -(halfDTheata * transform.getRotation().getSin()) / cosMinusOne;
            }

            Point2d point = transform.getTranslation()
                .rotateBy(new Rotation2d(halfThetaByTanOfHalftheta, -halfDTheata))
                .times(Math.Sqrt(Math.Pow(halfThetaByTanOfHalftheta, 2) + Math.Pow(halfDTheata, 2)));


            return new Twist2d(point, Rotation2d.fromRadians(dtheta));
        }

        override
        public String ToString()
        {
            return "X: " + getX() + " Y: " + getY() + " R: " + getRotation().getDegrees();
        }
    }

    public class Transform2d
    {
        private Point2d point;
        private Rotation2d rotation;

        public Transform2d(Pose2d inital, Pose2d last)
        {
            point = last.getTranslation().minus(inital.getTranslation()).rotateBy(inital.getRotation().unaryMinus());

            rotation = last.getRotation().minus(inital.getRotation());
        }

        public Transform2d(Point2d _translation, Rotation2d _rotation)
        {
            point = _translation;
            rotation = _rotation;
        }

        public Point2d getTranslation()
        {
            return point;
        }

        public Rotation2d getRotation()
        {
            return rotation;
        }
    }

    public class Twist2d
    {

        private Point2d xyChange;
        private Rotation2d thetaChange;

        public Twist2d(Point2d _xy, Rotation2d theta)
        {
            xyChange = _xy;
            thetaChange = theta;
        }

        public Point2d getLinearComponent()
        {
            return xyChange;
        }

        public Rotation2d getAngularComponent()
        {
            return thetaChange;
        }
    }

    public class PoseWithCurvature
    {
        public Pose2d pose;
        public Rotation2d curvature; //Angle Unit Per Foot

        public PoseWithCurvature(Pose2d _pose, Rotation2d curve)
        {
            this.pose = _pose;
            this.curvature = curve;
        }
    }

    public struct WayPoint
    {
        public double x;
        public double y;
        public double v;

        public WayPoint(double _x, double _y, double _v)
        {
            x = _x;
            y = _y;
            v = _v;
        }
    }

    public class PurePersuit
    {
        private List<WayPoint> wayPoints;
        private List<WayPoint> injectedWayPointList;

        public PurePersuit(List<WayPoint> _wayPoints)
        {
            this.wayPoints = _wayPoints;
            this.injectedWayPointList = new List<WayPoint>();
        }

        public void updateWayPoints(WayPoint _wayPoints)
        {
            this.wayPoints.Add(_wayPoints);
        }

        public List<WayPoint> injectPoints(double spacing)
        {
            for (int path = 0; path < wayPoints.Count - 1; path++)
            {
                double vectorMag = getVectorMagnitude(wayPoints[path], wayPoints[path + 1]);
                double pointToAdd = Math.Ceiling(vectorMag / spacing);
                WayPoint vectorNormilized = normilizeVector(wayPoints[path], wayPoints[path + 1]);


                for (int i = 0; i < pointToAdd; i++)
                {
                    WayPoint tmp = new WayPoint();
                    tmp.x = wayPoints[path].x + ((spacing * vectorNormilized.x) * i);
                    tmp.y = wayPoints[path].y + ((spacing * vectorNormilized.y) * i);
                    tmp.v = wayPoints[path].v + ((spacing * vectorNormilized.v) * i);

                    injectedWayPointList.Add(tmp);
                }
            }

            return injectedWayPointList;
        }

        public WayPoint[] smoother(double a, double b, double tolerance)
        {
            WayPoint[] newPath = injectedWayPointList.ToArray();
            double change = tolerance;
            while (change >= tolerance)
            {
                change = 0.0;
                double aux = 0;
                for (int i = 1; i < injectedWayPointList.Count - 1; i++)
                {
                    aux = newPath[i].x;
                    newPath[i].x += a * (injectedWayPointList[i].x - newPath[i].x) + b * (newPath[i - 1].x + newPath[i + 1].x - (2.0 * newPath[i].x));
                    change += Math.Abs(aux - newPath[i].x);
                }

                for (int i = 1; i < injectedWayPointList.Count - 1; i++)
                {
                    aux = newPath[i].y;
                    newPath[i].y += a * (injectedWayPointList[i].y - newPath[i].y) + b * (newPath[i - 1].y + newPath[i + 1].y - (2.0 * newPath[i].y));
                    change += Math.Abs(aux - newPath[i].y);
                }
            }

            for (int i = 0; i < newPath.Length; i++)
            {
                Console.WriteLine("(" + newPath[i].x + "," + newPath[i].y + ")");
            }

            return newPath;
        }

        public void printInjectedPoints()
        {
            for (int i = 0; i < injectedWayPointList.Count; i++)
            {
                Console.WriteLine("(" + injectedWayPointList[i].x + "," + injectedWayPointList[i].y + "," + injectedWayPointList[i].v + ")");
            }
        }

        public double getVectorMagnitude(WayPoint point1, WayPoint point2)
        {
            return Math.Sqrt(Math.Pow(point1.x - point2.x, 2) + Math.Pow(point1.y - point2.y, 2));
        }

        public WayPoint normilizeVector(WayPoint point1, WayPoint point2)
        {
            double mag = getVectorMagnitude(point1, point2);

            WayPoint tmp = new WayPoint();
            tmp.x = Math.Abs(point1.x - point2.x) / mag;
            tmp.y = Math.Abs(point1.y - point2.y) / mag;
            tmp.v = Math.Abs(point1.v - point2.v) / mag;

            return tmp;
        }
    }
    #endregion
}
