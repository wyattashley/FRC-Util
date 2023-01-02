using ScottPlot.Drawing.Colormaps;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FRC_Utility_Software.BluetoothGyro
{
    internal class BWT61CL
    {
        Container components = new System.ComponentModel.Container();

        public class GyroValues
        {
            public AxialReading Acceleration;
            public AxialReading RotationalVelocity;
            public AxialReading Angle;
            public AxialReading MagneticFeild;
            public short[] ChipTime;
            public double[] Port;
            public double Temperature;
            public double Pressure;
            public double Altitude;
            public double Longitude;
            public double Latitude;
            public double GPSHeight;
            public double GPSYaw;
            public double GroundVelocity;

            public GyroValues()
            {
                Acceleration = new AxialReading();
                RotationalVelocity = new AxialReading();
                Angle = new AxialReading();
                MagneticFeild = new AxialReading();
                ChipTime = new short[7];
                Port = new double[4];
                Temperature = 0;
                Pressure = 0;
                Altitude = 0;
                Longitude = 0;
                Latitude = 0;
                GPSHeight = 0;
                GPSYaw = 0;
                GroundVelocity = 0;
            }

            public override string ToString()
            {
                StringBuilder b = new StringBuilder();
                b.Append("ChipDate: ").Append(ChipTime[0]).Append("-").Append(ChipTime[1]).Append("-").Append(ChipTime[2]).Append("\n");
                b.Append("ChipTime: ").Append(ChipTime[3]).Append(":").Append(ChipTime[4]).Append(":").Append(ChipTime[5]).Append(".").Append(ChipTime[6]).Append("\n");
                b.Append("X Acceleration: ").Append(Acceleration.x).Append(" g\n");
                b.Append("Y Acceleration: ").Append(Acceleration.y).Append(" g\n");
                b.Append("Z Acceleration: ").Append(Acceleration.z).Append(" g\n");
                b.Append("X RotationalVelocity: ").Append(RotationalVelocity.x).Append(" °/s\n");
                b.Append("Y RotationalVelocity: ").Append(RotationalVelocity.y).Append(" °/s\n");
                b.Append("Z RotationalVelocity: ").Append(RotationalVelocity.z).Append(" °/s\n");
                b.Append("X Angle: ").Append(Angle.x).Append(" °\n");
                b.Append("Y Angle: ").Append(Angle.y).Append(" °\n");
                b.Append("Z Angle: ").Append(Angle.z).Append("° \n");
                b.Append("X MagneticFeild: ").Append(MagneticFeild.x).Append(" mG\n");
                b.Append("Y MagneticFeild: ").Append(MagneticFeild.y).Append(" mG\n");
                b.Append("Z MagneticFeild: ").Append(MagneticFeild.z).Append(" mG\n");
                b.Append("Temperature: ").Append(Temperature).Append(" ℃\n");
                b.Append("Pressure: ").Append(Pressure).Append(" Pa\n");
                b.Append("Altitude: ").Append(Altitude).Append(" m\n");
                b.Append("Longitude: ").Append(Longitude).Append("\n");
                b.Append("Latitude: ").Append(Latitude).Append("\n");
                b.Append("GPSHeight: ").Append(GPSHeight).Append(" m\n");
                b.Append("GPSYaw: ").Append(GPSYaw).Append(" °\n");
                b.Append("GroundVelocity: ").Append(GroundVelocity).Append(" km/h\n");
                b.Append("AccelCount: ").Append(AccelCount).Append("\n");
                b.Append("AngleCount: ").Append(AngleCount).Append("\n");

                return b.ToString();
            }
        }

        public struct AxialReading
        {
            public double x;
            public double y;
            public double z;
        }

        private SerialPort sp;
        //private Timer baudrateTimer;
        private byte[] RxBuffer = new byte[400];
        private int remainIndexFromLastCycle = 0;
        private long tmp = 0;
        private GyroValues currentValues = new GyroValues();
        private Action<GyroValues> valueCallback;
        private DateTime lastDataTime;
        private static double AccelCount = 0;
        private static int AngleCount = 0;

        public BWT61CL()
        {
            sp = new System.IO.Ports.SerialPort(components);
            //baudrateTimer = new Timer();
            sp.DataReceived += new SerialDataReceivedEventHandler(onDataReceived);
        }

        public void setValueRecievedCallback(Action<GyroValues> callback)
        {
            valueCallback = callback;
        }


        public void onDataReceived(object e, SerialDataReceivedEventArgs args)
        {
            UInt16 dataLength = 0;
            try
            {
                dataLength = (UInt16)sp.Read(RxBuffer, remainIndexFromLastCycle, 400 - remainIndexFromLastCycle);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            UInt16 currentPosition = 0;
            int totalDataLength = dataLength + remainIndexFromLastCycle;
            Span<byte> span = RxBuffer.AsSpan();

            while (totalDataLength - currentPosition >= 11)
            {
                while (span[currentPosition] != 0x55)
                {
                    currentPosition++;
                }

                if (totalDataLength - currentPosition < 11) continue;

                //if (span[currentPosition + 1] == 0x51) AccelCount++;
                if (span[currentPosition + 1] == 0x53)
                {
                    tmp += (DateTime.Now - lastDataTime).Milliseconds;
                    AccelCount = (double)tmp / (double)AngleCount;
                    lastDataTime = DateTime.Now;
                    AngleCount++;
                }

                praseData(span.Slice(currentPosition, 11).ToArray());
                currentPosition += 11;
            }


            valueCallback.Invoke(currentValues);

            for (int i = 0; i < totalDataLength - currentPosition; i++)
            {
                RxBuffer[i] = RxBuffer[currentPosition + i];
            }

            //MessageBox.Show(Convert.ToHexString(new byte[] { RxBuffer[0] }));

            remainIndexFromLastCycle = totalDataLength - currentPosition;
        }

        private void praseData(byte[] bytes)
        {

            switch(bytes[1])
            {
                case 0x50:
                    //Chip Time
                    currentValues.ChipTime[0] = (short)(2000 + bytes[2]);
                    currentValues.ChipTime[1] = bytes[3];
                    currentValues.ChipTime[2] = bytes[4];
                    currentValues.ChipTime[3] = bytes[5];
                    currentValues.ChipTime[4] = bytes[6];
                    currentValues.ChipTime[5] = bytes[7];
                    currentValues.ChipTime[6] = BitConverter.ToInt16(bytes, 8);
                    break;

                case 0x51:
                    //Acceleration Packet
                    currentValues.Temperature = BitConverter.ToInt16(bytes, 8) / 100.0;

                    currentValues.Acceleration.x = BitConverter.ToInt16(bytes, 2) / 32768.0 * 16.0;
                    currentValues.Acceleration.y = BitConverter.ToInt16(bytes, 4) / 32768.0 * 16.0;
                    currentValues.Acceleration.z = BitConverter.ToInt16(bytes, 6) / 32768.0 * 16.0;
                    break;

                case 0x52:
                    //Velocity Packet
                    currentValues.Temperature = BitConverter.ToInt16(bytes, 8) / 100.0;

                    currentValues.RotationalVelocity.x = BitConverter.ToInt16(bytes, 2) / 32768.0 * 2000;
                    currentValues.RotationalVelocity.y = BitConverter.ToInt16(bytes, 4) / 32768.0 * 2000;
                    currentValues.RotationalVelocity.z = BitConverter.ToInt16(bytes, 6) / 32768.0 * 2000;
                    break;

                case 0x53:
                    currentValues.Temperature = BitConverter.ToInt16(bytes, 8) / 100.0;

                    currentValues.Angle.x = BitConverter.ToInt16(bytes, 2) / 32768.0 * 180;
                    currentValues.Angle.y = BitConverter.ToInt16(bytes, 4) / 32768.0 * 180;
                    currentValues.Angle.z = BitConverter.ToInt16(bytes, 6) / 32768.0 * 180;
                    break;

                case 0x54:
                    currentValues.Temperature = BitConverter.ToInt16(bytes, 8) / 100.0;

                    currentValues.MagneticFeild.x = BitConverter.ToInt16(bytes, 2);
                    currentValues.MagneticFeild.y = BitConverter.ToInt16(bytes, 4);
                    currentValues.MagneticFeild.z = BitConverter.ToInt16(bytes, 6);
                    break;

                case 0x55:
                    currentValues.Port[0] = BitConverter.ToInt16(bytes, 2);
                    currentValues.Port[1] = BitConverter.ToInt16(bytes, 4);
                    currentValues.Port[2] = BitConverter.ToInt16(bytes, 6);
                    currentValues.Port[3] = BitConverter.ToInt16(bytes, 8);
                    break;

                case 0x56:
                    currentValues.Pressure = BitConverter.ToInt32(bytes, 2);
                    currentValues.Altitude = (double) BitConverter.ToInt32(bytes, 6) / 100.0;
                    break;

                case 0x57:
                    currentValues.Longitude = BitConverter.ToInt32(bytes, 2);
                    currentValues.Latitude = BitConverter.ToInt32(bytes, 6);
                    break;

                case 0x58:
                    currentValues.GPSHeight = (double)BitConverter.ToInt16(bytes, 2) / 10.0;
                    currentValues.GPSYaw = (double)BitConverter.ToInt16(bytes, 4) / 10.0;
                    currentValues.GroundVelocity = BitConverter.ToInt16(bytes, 6) / 1e3;
                    break;
            }
        }

        public GyroValues getCurrentReading()
        {
            return currentValues;
        }

        public string[] RefreshAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }

        public void setPortName(string name)
        {
            closePort();
            sp.PortName = name;
        }

        public void setBaudrate(uint rate)
        {
            closePort();
            sp.BaudRate = (int) rate;
        }

        public void initalize()
        {
            sp.Open();
            lastDataTime = DateTime.Now;
            //baudrateTimer.Start();
        }

        public bool closePort()
        {
            if (sp.IsOpen)
            {
                sp.Dispose();
                sp.Close();

                return true;
            } else
            {
                return false;
            }
        }

        public void close()
        {
            closePort();
        }
    }
}
