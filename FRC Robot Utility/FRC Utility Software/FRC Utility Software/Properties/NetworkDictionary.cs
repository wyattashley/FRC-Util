using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FRC_Utility_Software.Properties
{
    class NetworkDictionary
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct NetworkDictionaryHeader
        {
            public UInt16 magic_number;
            public UInt16 packet_type;
            public UInt32 packet_size;
            public UInt16 header_size;
            public UInt32 status_flag;
            public UInt16 number_values;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NetworkDictionaryEntry
        {
            public UInt32 key;
            public double value;
        }

        private struct NetworkDictionaryEntryImpl
        {
            public NetworkDictionaryEntry entry;
            public DateTime time;
        }

        private Dictionary<UInt32, NetworkDictionaryEntryImpl> dictionaryValues;
        
        private UdpClient udpClient;
        private IPEndPoint roborio;
        private Thread udpRecieveThread;
        private bool activlyWatching = true;

        public NetworkDictionary(IPAddress roborioIP, UInt16 portNumber)
        {
            udpClient = new UdpClient(portNumber);

            roborio = new IPEndPoint(roborioIP, portNumber);
            udpClient.Connect(roborio);

            udpRecieveThread = new Thread(new ThreadStart(udpWatcher));
        }

        private void udpWatcher()
        {
            while (activlyWatching)
            {
                byte[] data = udpClient.Receive(ref roborio);
                Span<byte> dataSpan = data.AsSpan();

                NetworkDictionaryHeader header = MemoryMarshal.Cast<byte, NetworkDictionaryHeader>(dataSpan)[0];

                for(int i = 0; i < header.number_values; i++)
                {
                    NetworkDictionaryEntry entryTmp = MemoryMarshal.Cast<byte, NetworkDictionaryEntry>(dataSpan.Slice(i * 12))[0];
                    
                    if(dictionaryValues.ContainsKey(entryTmp.key))
                    {
                        NetworkDictionaryEntryImpl impl = dictionaryValues[entryTmp.key];
                        impl.entry = entryTmp;
                        impl.time = DateTime.Now;
                    } else
                    {
                        NetworkDictionaryEntryImpl impl = new NetworkDictionaryEntryImpl();
                        impl.entry = entryTmp;
                        impl.time = DateTime.Now;
                    }
                }
            }
        }

        private void udpSender()
        {
            foreach(NetworkDictionaryEntryImpl impl in dictionaryValues.Values)
            {
                int size = Marshal.SizeOf(impl);
                byte[] arr = new byte[size];

                IntPtr ptr = IntPtr.Zero;
                try
                {
                    ptr = Marshal.AllocHGlobal(size);
                    Marshal.StructureToPtr(impl, ptr, true);
                    Marshal.Copy(ptr, arr, 0, size);
                }
                finally
                {
                    Marshal.FreeHGlobal(ptr);
                }

                udpClient.Send(arr, arr.Length, roborio);
            }
        }
    }
}
