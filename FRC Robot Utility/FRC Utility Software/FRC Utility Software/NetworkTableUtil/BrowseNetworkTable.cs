using MathNet.Numerics.Distributions;
using Microsoft.VisualBasic;
using NetworkTables;
using NetworkTables.Tables;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FRC_Utility_Software.NetworkTableUtil
{
    public partial class BrowseNetworkTable : Form
    {
        NetworkTable smartDashboard;
        private static Action<ITable, string, Value, NotifyFlags> onSubTableCreation;
        private static Action<ITable, string, Value, NotifyFlags> onTableChange;

        public BrowseNetworkTable()
        {
            InitializeComponent();
            NetworkTable.SetClientMode();
            NetworkTable.SetIPAddress("localhost");
            NetworkTable.SetPort(57231);
            //NetworkTable.SetTeam(2137);
            NetworkTable.Initialize();

            onSubTableCreation = (table, key, val, flag) =>
            {
                tableViewer.BeginInvoke(new Action(() =>
                {
                    string value = ((NetworkTable)table).ToString().Replace("NetworkTable: ", "");//.Replace("/", "");

                    if (flag == NotifyFlags.NotifyNew) //&& !table.GetSubTables().Contains(key))
                    {
                        TreeNode addedNode = convertDirectoryTreeNode(value + "/" + key, tableViewer.Nodes[0], smartDashboard);
                        if (addedNode != null)
                        {
                            addAllValuesToTree(addedNode, ((NetworkTable)table.GetSubTable(key)));
                            addValueListeners((NetworkTable)table.GetSubTable(key));
                        }
                    }
                    else if (flag == NotifyFlags.NotifyDelete)
                    {
                        convertDirectoryTreeNode(value + "/" + key, tableViewer.Nodes[0], smartDashboard, true);
                    }
                }));
            };

            onTableChange = (table, key, val, flag) =>
            {
                tableViewer.BeginInvoke(new Action(() =>
                {
                    string value = ((NetworkTable)table).ToString().Replace("NetworkTable: ", "");//.Replace("/", "");

                    if (flag == NotifyFlags.NotifyNew)
                        convertDirectoryTreeNode(value + "/" + key, tableViewer.Nodes[0], smartDashboard);
                    else if (flag == NotifyFlags.NotifyDelete)
                        convertDirectoryTreeNode(value + "/" + key, tableViewer.Nodes[0], smartDashboard, true);
                    else if (flag == NotifyFlags.NotifyUpdate)
                    {
                        convertDirectoryTreeNode(value + "/" + key, tableViewer.Nodes[0], smartDashboard);
                    }

                }));
            };

            Action<IRemote, ConnectionInfo, bool> onConnect = (iRemote, connectInfo, b) =>
            {
                smartDashboard = NetworkTable.GetTable("");
                addValueListeners(smartDashboard);
                //smartDashboard.AddSubTableListener(this);
            };

            NetworkTable.AddGlobalConnectionListener(onConnect, true);
        }

        private void addValueListeners(NetworkTable table)
        {
            table.AddTableListenerEx(onTableChange, NotifyFlags.NotifyNew | NotifyFlags.NotifyUpdate | NotifyFlags.NotifyDelete);
            table.AddSubTableListener(onSubTableCreation);
            foreach (string key in table.GetSubTables())
            {
                //table.AddTableListenerEx(key + "/", onSubTableCreation, NotifyFlags.NotifyDelete);
                addValueListeners((NetworkTable) table.GetSubTable(key));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode node = tableViewer.Nodes.Add("root", "NetworkTables");

            addAllValuesToTree(node, smartDashboard);
        }

        public void addAllValuesToTree(TreeNode parentNode, NetworkTable table)
        {
            foreach(string key in table.GetKeys())
            {
                if (parentNode.Nodes.ContainsKey(key))
                    continue;

                TreeNode child = new TreeNode();
                child.Name = key;
                child.Text = key + ": " + table.GetValue(key).ToString();
                parentNode.Nodes.Add(child);
            }

            foreach(string subTable in table.GetSubTables())
            {
                if (parentNode.Nodes.ContainsKey(subTable))
                    continue;

                TreeNode child = new TreeNode();
                child.Name = subTable;
                child.Text = subTable;
                parentNode.Nodes.Add(child);
                addAllValuesToTree(child, (NetworkTable) table.GetSubTable(subTable));
            }
        }

        private void tableViewer_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = tableViewer.SelectedNode;
            string[] path = node.FullPath.Split("\\");

            string[] tableVal = new string[path.Length - 2];
            Array.Copy(path, 1, tableVal, 0, path.Length - 2);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (string a in tableVal)
            {
                stringBuilder.Append('/');
                stringBuilder.Append(a);
            }
            stringBuilder.Remove(0, 1);
            stringBuilder.Append("/");
            stringBuilder.Append(node.Name);

            string key = stringBuilder.ToString();
            NtType type = smartDashboard.GetValue(key).Type;

            string title = node.Name;
            string prompt = "Set Value";
            string defaultVal = smartDashboard.GetValue(stringBuilder.ToString()).ToString();

            
                switch (type)
                {
                    case NtType.Boolean:
                        smartDashboard.PutBoolean(key, getValidUserValue<bool>(title, prompt, defaultVal));
                        break;
                    case NtType.Double:
                        smartDashboard.PutNumber(key, getValidUserValue<double>(title, prompt, defaultVal));
                        break;
                    case NtType.BooleanArray:
                        smartDashboard.PutBooleanArray(key, getValidUserValue<bool[]>(title, prompt, defaultVal));
                        break;
                    case NtType.DoubleArray:
                        smartDashboard.PutNumberArray(key, getValidUserValue<double[]>(title, prompt, defaultVal));
                        break;
                    case NtType.StringArray:
                        smartDashboard.PutStringArray(key, getValidUserValue<string[]>(title, prompt, defaultVal));
                        break;
                    case NtType.String:
                        smartDashboard.PutString(key, getValidUserValue<string>(title, prompt, defaultVal));
                        break;
                    default:
                        MessageBox.Show("Not Valid Network Tables Type");
                        break;

                }
            
        }

        public T getValidUserValue<T>(string title, string prompt, string defaultVal)
        {
            string response;
            bool valid = false;
            T val = (T) Convert.ChangeType(defaultVal, typeof(T));

            do
            {
                response = Interaction.InputBox(title, prompt, defaultVal);
                try
                {
                    val = (T)Convert.ChangeType(response, typeof(T));
                    valid = true;
                } catch (Exception e)
                {

                }
            } while (!valid);

            return val;
        }

        public TreeNode convertDirectoryTreeNode(string keyWithDir, TreeNode rootNode, NetworkTable rootTable, bool delete = false)
        {
            string[] splitValues = keyWithDir.Split("/");
            List<string> values = splitValues.ToList();
            values.RemoveAt(0);

            TreeNode tmpNode = rootNode;

            foreach(string value in values)
            {
                if (tmpNode.Nodes.ContainsKey(value))
                {
                    tmpNode = tmpNode.Nodes[value];
                } else if (!delete)
                {
                    TreeNode child = new TreeNode();
                    child.Name = value;
                    child.Text = value;
                    tmpNode.Nodes.Add(child);
                    tmpNode = child;
                } else
                {
                    return null;
                }
            }

            if (delete)
            {
                deleteHighestEntity(tmpNode);
                return null;
            } else
            {
                string key = keyWithDir.Substring(1, keyWithDir.Length - 1);
                if (rootTable.ContainsKey(key))
                {
                    tmpNode.Text = values[values.Count - 1] + ": " + rootTable.GetValue(key).ToString();
                }
                return tmpNode;
            }
        }

        private void deleteHighestEntity(TreeNode folder)
        {
            if (folder.Parent.Nodes.Count > 1)
            {
                folder.Remove();
                return;
            } else
            {
                deleteHighestEntity(folder.Parent);
            }
        }

        private void BrowseNetworkTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetworkTable.Shutdown();
            tableViewer.Nodes.Clear();
        }
    }
}
