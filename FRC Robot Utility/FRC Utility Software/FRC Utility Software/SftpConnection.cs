using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FRC_Utility_Software
{
    class SftpConnection
    {
        private SftpClient mSftpClient;

        public SftpConnection(string host, string username, string password)
        {
            mSftpClient = new SftpClient(host, username, password);
            Console.WriteLine("Starting Sftp connection");
            mSftpClient.Connect();
        }

        public string DownloadSftpFile(string remoteFilePath)
        {
            string fileName = Path.GetTempFileName();

            var file = File.OpenWrite(fileName);
            mSftpClient.DownloadFile(remoteFilePath, file);

            mSftpClient.Disconnect();
            return fileName;
        }

        public IEnumerable<SftpFile> ListSftpDirectory(string remoteDirectory)
        {
            // . always refers to the current directory.
            var files = mSftpClient.ListDirectory(remoteDirectory);
            return files;
        }

        public string DownloadMostCurrentSftpFile(string remoteFilePath)
        {
            var files = mSftpClient.ListDirectory(remoteFilePath);
            SftpFile mostRecentFile = null;
            DateTime mostRecentDate = new DateTime();

            foreach(SftpFile file in files) {
                if (mostRecentFile == null) {
                    mostRecentFile = file;
                    mostRecentDate = getDateFromString(file.Name);
                } else if (mostRecentDate.CompareTo(getDateFromString(file.Name)) > 0) {
                    mostRecentFile = file;
                    mostRecentDate = getDateFromString(file.Name);
                }
            }

            return DownloadSftpFile(mostRecentFile.FullName);
        }

        public string DownloadMostCurrentSftpFile(string remoteFilePath, string type)
        {
            var files = mSftpClient.ListDirectory(remoteFilePath);
            SftpFile mostRecentFile = null;
            DateTime mostRecentDate = new DateTime();

            foreach (SftpFile file in files)
            {
                if (file.Name.Substring(4, 4).Equals(type))
                {
                    if (mostRecentFile == null)
                    {
                        mostRecentFile = file;
                        mostRecentDate = getDateFromString(file.Name);
                    }
                    else if (mostRecentDate.CompareTo(getDateFromString(file.Name)) > 0)
                    {
                        mostRecentFile = file;
                        mostRecentDate = getDateFromString(file.Name);
                    }
                }
            }

            return DownloadSftpFile(mostRecentFile.FullName);
        }

        private DateTime getDateFromString(string dataString)
        {
            int month = Convert.ToInt32(dataString.Substring(0 + 9, 2));
            int day = Convert.ToInt32(dataString.Substring(2 + 9, 2));
            int year = Convert.ToInt32(dataString.Substring(4 + 9, 4));
            int hour = Convert.ToInt32(dataString.Substring(9 + 9, 2));
            int min = Convert.ToInt32(dataString.Substring(11 + 9, 2));
            int sec = Convert.ToInt32(dataString.Substring(13 + 9, 2));
            return new DateTime(year, month, day, hour, min, sec);
        }

        void CloseSftpClient()
        {
            mSftpClient.Disconnect();
        }
    }
}
