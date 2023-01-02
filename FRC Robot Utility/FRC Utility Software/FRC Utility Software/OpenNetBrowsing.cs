using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRC_Utility_Software
{
    public partial class OpenNetBrowsing : Form
    {
        char directoryNameDiliminator = '/';
        int fileSizeLimit = 10 * 1_000_000;
        SftpConnection connection;
        Action<string> onDownload;

        public OpenNetBrowsing(SftpConnection _connection, Action<string> onSelected)
        {
            InitializeComponent();
            connection = _connection;
            FilePath.Text = "/";
            onDownload = onSelected;

            List<SftpFile> files = connection.ListSftpDirectory(FilePath.Text).ToList();
            foreach(SftpFile file in files)
            {
                TreeNode child = new TreeNode();
                child.Name = file.Name;
                child.Text = file.Name;
                fileTreeViewer.Nodes.Add(child);
            }
        }

        private void GoActionButton_Click(object sender, EventArgs e)
        {
            SftpFile file = (SftpFile) fileTreeViewer.SelectedNode.Tag;
            if (file.Attributes.Size > fileSizeLimit)
                return;

            string fileDownload = connection.DownloadSftpFile(file.FullName);
            connection.CloseSftpClient();
            onDownload.Invoke(fileDownload);
            this.Close();
        }

        private void fileTreeViewer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
        }

        private void fileTreeViewer_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = directoryNameDiliminator + e.Node.FullPath.Replace('\\', directoryNameDiliminator);
            try
            {
                List<SftpFile> files = connection.ListSftpDirectory(path).ToList();
                
                if (e.Node.Name.EndsWith('/') && files.Count > 0)
                {
                    string a = e.Node.Name.Substring(0, e.Node.Name.Length - 1);
                    e.Node.Name = a;
                    e.Node.Text = a;
                }
                
                foreach (SftpFile file in files)
                {
                    if (!file.Name[0].Equals('.') && !file.Name.Equals(".."))
                    {
                        TreeNode child = new TreeNode();
                        child.Name = file.Name + (file.IsDirectory ? '/' : "");
                        child.Text = file.Name + (file.IsDirectory ? '/' : "");
                        child.Tag = file;
                        e.Node.Nodes.Add(child);
                    }
                }

                e.Node.Expand();
            } catch (Exception a)
            {
                MessageBox.Show("Not directory!" + a.Message);
            }
        }

        private void fileTreeViewer_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            string path = directoryNameDiliminator + e.Node.FullPath.Replace('\\', directoryNameDiliminator);
            FilePath.Text = path;
        }
    }
}
