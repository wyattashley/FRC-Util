using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FRC_Utility_Software
{
    public partial class OpenNetPrompt : Form
    {
        Action<string> onResult;
        public OpenNetPrompt(Action<string> _onResult)
        {
            onResult = _onResult;
            InitializeComponent();
        }
        private void OpenNetButton_Click(object sender, EventArgs e)
        {
            int teamNumber = (int) TeamNumberEntry.Value;
            TeamNumberEntry.Enabled = false;
            string fileLocation = FileLocationEntry.Text;
            FileLocationEntry.Enabled = false;
            string address = AddressEntry.Text;
            AddressEntry.Enabled = false;
            string username = UsernameEntity.Text;
            UsernameEntity.Enabled = false;
            string password = PasswordEntity.Text;
            PasswordEntity.Enabled = false;
            int portNumber = (int) PortNumberEntry.Value;
            PortNumberEntry.Enabled = false;

            SftpConnection sftp;


            //sftp = new SftpConnection(address, username, password, StatusDisplay);
            
            if (!teamNumber.Equals(0))
            {
                sftp = new SftpConnection("roborio-" + teamNumber + "-frc.local", "lvuser", "", statusLabel);
            } else
            {
                sftp = new SftpConnection(address, username, password, statusLabel);
            }

            if (UnkownLocation.Checked)
            {
                (new OpenNetBrowsing(sftp, onResult)).Show();
            }

            /*

                        string stringValue;

                        if(mostRecentLog)
                        {
                            if (logType.Equals("All"))
                            {
                                stringValue = sftp.DownloadMostCurrentSftpFile(fileLocation);
                            }
                            else
                            {
                                stringValue = sftp.DownloadMostCurrentSftpFile(fileLocation, logType);
                            }
                        }
                        else
                        {
                            stringValue = sftp.DownloadSftpFile(fileLocation + logName);
                        }*/
            //Program.mainProjectInstance.openFile(stringValue);
            this.Close();
            //Program.mainProjectInstance.OpenActionButton_Click(sender, e);
            //Program.mainProjectInstance.updateLogText(stringValue);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
