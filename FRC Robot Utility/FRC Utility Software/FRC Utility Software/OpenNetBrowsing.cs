using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRC_Utility_Software
{
    public partial class OpenNetBrowsing : Form
    {
        List<KeyValuePair<ComboBox, List<SftpFile>>> directory = new List<KeyValuePair<ComboBox, List<SftpFile>>>();
        SftpConnection connection;

        public OpenNetBrowsing(SftpConnection _connection)
        {
            InitializeComponent();
            connection = _connection;
            FilePath.Text = "/";

            List<SftpFile> files = connection.ListSftpDirectory(FilePath.Text).ToList();
            foreach(SftpFile file in files)
            {
                DirectoryList0.Items.Add(file.Name);
            }
            directory.Add(KeyValuePair.Create(DirectoryList0, files));
        }

        private void DirectoryList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = int.Parse(((ComboBox)sender).Name[13..]);
            ComboBox comboBox = directory[i].Key;

            if (i < directory.Count - 1)
            {
                while (i < directory.Count - 1)
                {
                    flowLayoutPanel1.Controls.RemoveAt(i+1);
                    directory.RemoveAt(i+1);
                }

                FilePath.Text = "";

                for(int a = 0; a < i ; a++)
                {
                    FilePath.Text += "/" + directory[a].Key.Text;
                }
            }

            if (directory[i].Value[comboBox.SelectedIndex].IsDirectory)
            {
                FilePath.Text += "/" + comboBox.Text;

                ComboBox DirectoryListX = new ComboBox();
                DirectoryListX.Name = "DirectoryList" + directory.Count;
                DirectoryListX.Size = new System.Drawing.Size(327, 28);
                DirectoryListX.SelectedIndexChanged += new System.EventHandler(this.DirectoryList1_SelectedIndexChanged);

                flowLayoutPanel1.Controls.Add(DirectoryListX);

                List<SftpFile> files = connection.ListSftpDirectory(FilePath.Text).ToList();
                foreach (SftpFile file in files)
                {
                     DirectoryListX.Items.Add(file.Name);
                }

                directory.Add(KeyValuePair.Create(DirectoryListX, files));
            }
        }

        private void GoActionButton_Click(object sender, EventArgs e)
        {
            ComboBox combo = directory[directory.Count - 1].Key;
            SftpFile file = directory[directory.Count - 1].Value[combo.SelectedIndex];
            if (file.IsDirectory)
            {

            } else
            {
                Program.mainProjectInstance.openFile(connection.DownloadSftpFile(file.FullName));
                //connection.CloseSftpClient();
                this.Close();
            }
        }
    }
}
