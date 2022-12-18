using Microsoft.VisualBasic;
using NetworkTables;
using NetworkTables.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FRC_Utility_Software.NetworkTableUtil
{
    public partial class BrowseNetworkTable : Form
    {
        volatile bool _connected = true;
        NetworkTable smartDashboard;

        public BrowseNetworkTable()
        {
            InitializeComponent();
            NetworkTable.SetClientMode();
            NetworkTable.SetIPAddress("localhost");
            NetworkTable.SetPort(57231);
            //NetworkTable.SetTeam(2137);
            NetworkTable.Initialize();

            Action<IRemote, ConnectionInfo, bool> onConnect = (iRemote, connectInfo, b) =>
            {
                smartDashboard = NetworkTable.GetTable("SmartDashboard");
            };

            NetworkTable.AddGlobalConnectionListener(onConnect, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode node = tableViewer.Nodes.Add("root", "SmartDashboard");

            foreach (String a in smartDashboard.GetKeys())
            {
                TreeNode tn = new TreeNode();
                tn.Text = a + ": " + smartDashboard.GetValue(a).ToString();
                node.Nodes.Add(tn);
            }

        }

        private void tableViewer_DoubleClick(object sender, EventArgs e)
        {
            Interaction.InputBox("Question?", "Title", "Default Text");
        }
    }
}
