using FRC_Utility_Software.BluetoothGyro;
using NetworkTables.Tables;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Linq;

namespace FRC_Utility_Software.NetworkTableUtil
{
    public partial class HardwareConfigurationMenu : Form
    {
        public class XmlHardwareObject
        {
            public string name;
            public uint id;

            public XmlNode nameNode;
            public XmlNode idNode;

            public XmlHardwareObject (XmlNode node) {
                nameNode = getName(node);
                idNode = getNode(node, "ID");

                if (nameNode.NodeType == XmlNodeType.Attribute)
                    name = nameNode.Value;
                else if (nameNode.NodeType == XmlNodeType.Element && nameNode != node)
                    name = nameNode.InnerText;
                else
                    name = node.Name;

                id = uint.Parse(idNode.InnerText);
            }

            public XmlHardwareObject()
            {

            }

            public virtual void pushToXML()
            {
                nameNode.InnerText = name;
                idNode.InnerText = id.ToString();
            }

            public virtual void addToXML(XmlNode node, XmlDocument doc)
            {
                addTextElement(node, "Name", name, doc);
                addTextElement(node, "ID", id.ToString(), doc);
            }

            public virtual void addValuesToMultiInput(MultiInput input)
            {
                input.addPrompt<string>("Name", name);
                input.addPrompt<uint>("ID", id);
            }

            public virtual void getValuesFromMultiInput(MultiInput input)
            {
                name = input.get<string>("Name");
                id = input.get<uint>("ID");
            }

            public virtual void print(StringBuilder builder, int tabs = 0)
            {
                string tabString = new string('\t', tabs);
                builder.Append(tabString).Append("Name: ").AppendLine(name);
                builder.Append(tabString).Append("ID: ").AppendLine(id.ToString());
            }
        }

        class PID : XmlHardwareObject
        {
            double p;
            double i;
            double d;
            double ff;
            double iz;

            public XmlNode pNode;
            public XmlNode iNode;
            public XmlNode dNode;

            public PID (XmlNode node) : base(node)
            {
                pNode = getNode(node, "P");
                iNode = getNode(node, "I");
                dNode = getNode(node, "D");

                if(pNode != null)
                    double.TryParse(pNode.InnerText, out p);

                if(iNode != null)
                    double.TryParse(iNode.InnerText, out i);

                if(dNode != null)
                    double.TryParse(dNode.InnerText, out d);

                //pid.p = double.Parse(getNode(node, "P"));
                //pid.i = double.Parse(getNode(node, "I"));
                //pid.d = double.Parse(getNode(node, "D"));
            }

            public PID() : base()
            {

            }

            public override void pushToXML()
            {
                pNode.InnerText = p.ToString();
                iNode.InnerText = i.ToString();
                dNode.InnerText = d.ToString();
            }

            public override void addToXML(XmlNode node, XmlDocument doc)
            {
                addTextElement(node, "P", p.ToString(), doc);
                addTextElement(node, "I", i.ToString(), doc);
                addTextElement(node, "D", d.ToString(), doc);
            }

            public override void print(StringBuilder builder, int tabs = 0)
            {
                base.print(builder, tabs);

                string tabString = new string('\t', tabs);
                builder.Append(tabString).Append("P: ").AppendLine(p.ToString());
                builder.Append(tabString).Append("I: ").AppendLine(i.ToString());
                builder.Append(tabString).Append("D: ").AppendLine(d.ToString());
            }
            public override void addValuesToMultiInput(MultiInput input)
            {
                base.addValuesToMultiInput(input);
                input.addPrompt<double>("P", p);
                input.addPrompt<double>("I", i);
                input.addPrompt<double>("D", d);
            }

            public override void getValuesFromMultiInput(MultiInput input)
            {
                base.getValuesFromMultiInput(input);
                p = input.get<double>("P");
                i = input.get<double>("I");
                d = input.get<double>("D");
            }
        }

        class Motor : XmlHardwareObject
        {
            public string type;
            public bool inverted;
            public double gearRatio;
            public double currentLimit;
            public double rampRate;
            public PID pid;

            public XmlNode typeNode;
            public XmlNode invertedNode;
            public XmlNode gearRatioNode;
            public XmlNode currentLimitNode;
            public XmlNode rampRateNode;

            public Motor() : base()
            {

            }
            public Motor (XmlNode node) : base(node)
            {
                typeNode = getNode(node, "Type");
                invertedNode = getNode(node, "Inverted");
                gearRatioNode = getNode(node, "GearRatio");
                currentLimitNode = getNode(node, "CurrentLimit");
                rampRateNode = getNode(node, "RampRate");

                type = typeNode.InnerText;
                inverted = bool.Parse(invertedNode.InnerText);
                gearRatio = double.Parse(gearRatioNode.InnerText);
                currentLimit = double.Parse(currentLimitNode.InnerText);
                rampRate = double.Parse(rampRateNode.InnerText);

                pid = new PID(node);
            }

            public override void pushToXML()
            {
                typeNode.InnerText = type;
                invertedNode.InnerText = inverted.ToString();
                gearRatioNode.InnerText = gearRatio.ToString();
                currentLimitNode.InnerText = currentLimit.ToString();
                rampRateNode.InnerText = rampRate.ToString();
            }

            public override void addToXML(XmlNode node, XmlDocument doc)
            {
                addTextElement(node, "Type", type, doc);
                addTextElement(node, "Inverted", inverted.ToString(), doc);
                addTextElement(node, "GearRatio", gearRatio.ToString(), doc);
                addTextElement(node, "CurrentLimit", currentLimit.ToString(), doc);
                addTextElement(node, "RampRate", rampRate.ToString(), doc);
            }

            public override void print(StringBuilder builder, int tabs = 0)
            {
                base.print(builder, tabs);

                string tabString = new string('\t', tabs);
                builder.Append(tabString).Append("Type: ").AppendLine(type);
                builder.Append(tabString).Append("Inverted: ").AppendLine(inverted.ToString());
                builder.Append(tabString).Append("GearRatio: ").AppendLine(gearRatio.ToString());
                builder.Append(tabString).Append("CurrentLimit: ").AppendLine(currentLimit.ToString());
                builder.Append(tabString).Append("RampRate: ").AppendLine(rampRate.ToString());
                pid.print(builder, tabs);
            }

            public override void addValuesToMultiInput(MultiInput input)
            {
                base.addValuesToMultiInput(input);
                input.addPrompt<string>("Type", type);
                input.addPrompt<bool>("Inverted", inverted);
                input.addPrompt<double>("GearRatio", gearRatio);
                input.addPrompt<double>("CurrentLimit", currentLimit);
                input.addPrompt<double>("RampRate", rampRate);
            }

            public override void getValuesFromMultiInput(MultiInput input)
            {
                base.getValuesFromMultiInput(input);
                name = input.get<string>("Name");
                inverted = input.get<bool>("Inverted");
                gearRatio = input.get<double>("GearRatio");
                currentLimit = input.get<double>("CurrentLimit");
                rampRate = input.get<double>("RampRate");
            }
        }

        class Encoder : XmlHardwareObject
        {
            public string type;
            public bool inverted;
            public double offset;

            public XmlNode typeNode;
            public XmlNode invertedNode;
            public XmlNode offsetNode;

            public Encoder() : base()
            {

            }

            public Encoder (XmlNode node) : base(node)
            {
                typeNode = getNode(node, "Type");
                invertedNode = getNode(node, "Inverted");
                offsetNode = getNode(node, "Offset");

                type = typeNode.InnerText;
                inverted = bool.Parse(invertedNode.InnerText);
                offset = double.Parse(offsetNode.InnerText);
            }

            public override void pushToXML()
            {
                typeNode.InnerText = type;
                invertedNode.InnerText = inverted.ToString();
            }

            public override void addToXML(XmlNode node, XmlDocument doc)
            {
                addTextElement(node, "Type", type, doc);
                addTextElement(node, "Inverted", inverted.ToString(), doc);
            }

            public override void print(StringBuilder builder, int tabs = 0)
            {
                base.print(builder, tabs);

                string tabString = new string('\t', tabs);
                builder.Append(tabString).Append("Type: ").AppendLine(type);
                builder.Append(tabString).Append("Inverted: ").AppendLine(inverted.ToString());
                builder.Append(tabString).Append("Offset: ").AppendLine(offset.ToString());
            }
            public override void addValuesToMultiInput(MultiInput input)
            {
                base.addValuesToMultiInput(input);
                input.addPrompt<string>("Type", type);
                input.addPrompt<bool>("Inverted", inverted);
            }

            public override void getValuesFromMultiInput(MultiInput input)
            {
                base.getValuesFromMultiInput(input);
                name = input.get<string>("Name");
                inverted = input.get<bool>("Inverted");
            }
        }

        class Gyro : XmlHardwareObject
        {
            public string type;

            public XmlNode typeNode;

            public Gyro() : base()
            {

            }

            public Gyro(XmlNode node) : base(node)
            {
                typeNode = getNode(node, "Type");

                type = typeNode.InnerText;
            }

            public override void pushToXML()
            {
                typeNode.InnerText = type;
            }

            public override void addToXML(XmlNode node, XmlDocument doc)
            {
                addTextElement(node, "Type", type, doc);
            }

            public override void print(StringBuilder builder, int tabs = 0)
            {
                base.print (builder, tabs);

                string tabString = new string('\t', tabs);
                builder.Append(tabString).Append("Type:").AppendLine(type);
            }

            public override void addValuesToMultiInput(MultiInput input)
            {
                base.addValuesToMultiInput(input);
                input.addPrompt<string>("Type", type);
            }

            public override void getValuesFromMultiInput(MultiInput input)
            {
                base.getValuesFromMultiInput(input);
                type = input.get<string>("Type");
            }
        }

        private struct HardwareMapEntry
        {
            public bool subsystem;
            public XmlHardwareObject childObject;
            public List<HardwareMapEntry> childList;
            public string type;
            public string subType;
            public string name;
            public Button imageButton;
            public XmlNode node;
        }

        XmlDocument xmlDocument = new XmlDocument();
        private HardwareMapEntry hardwareMap = new HardwareMapEntry();
        private string[] supportedDevices = new string[] { "Motor", "Encoder", "Gyro" };
        private HardwareMapEntry currentScope;
        private HardwareMapEntry parentScope;

        public HardwareConfigurationMenu()
        {
            InitializeComponent();
            //BWT61CL gyro = new BWT61CL();
            //gyro.setPortName("COM6");
            //gyro.setBaudrate(115200);
            //gyro.initalize();

            //gyro.setValueRecievedCallback((values) =>
            //{
            //    preview.BeginInvoke(new Action(() => {
            //        preview.Text = values.ToString();
            //    }));
            //});

            //this.FormClosing += new FormClosingEventHandler((e, args) => gyro.close());
        }

        public XmlHardwareObject ParseHardware(XmlNode node, string type)
        {
            switch(type)
            {
                case "Motor":
                    return new Motor(node);
                case "Encoder":
                    return new Encoder(node);
                case "Gyro":
                    return new Gyro(node);
                default:
                    return null;
            }
        }

        public Image getHardwareImage(string type, string subType)
        {

            switch(type)
            {
                case "Motor":
                    switch(subType.ToLower())
                    {
                        case "neo":
                            return global::FRC_Utility_Software.Properties.Resources.Neo;
                        case "neo550":
                            return global::FRC_Utility_Software.Properties.Resources.Neo550;
                        case "falcon":
                            return global::FRC_Utility_Software.Properties.Resources.Falcon;
                        case "cim":
                            return global::FRC_Utility_Software.Properties.Resources.CIM;
                        case "bag":
                            return global::FRC_Utility_Software.Properties.Resources.BAG;
                        case "window":
                            return global::FRC_Utility_Software.Properties.Resources.Window;

                        default:
                            return global::FRC_Utility_Software.Properties.Resources.MotorGeneric;

                    }

                case "Encoder":
                    switch(subType.ToLower())
                    {
                        case "ctre_can_abs":
                            return global::FRC_Utility_Software.Properties.Resources.CanCoder;

                        default:
                            return global::FRC_Utility_Software.Properties.Resources.EncoderGeneric;
                    }

                case "Gyro":
                    switch(subType.ToLower())
                    {
                        case "pigeon":
                            return global::FRC_Utility_Software.Properties.Resources.Pigeon;

                        default:
                            return global::FRC_Utility_Software.Properties.Resources.GyroGeneric;
                    }

                case "SwerveModule":
                    return global::FRC_Utility_Software.Properties.Resources.SwerveModule;

                case "DriveTrain":
                    return global::FRC_Utility_Software.Properties.Resources.DriveTrain;

                default:
                    return global::FRC_Utility_Software.Properties.Resources.Generic;
            }
        }

        private void pullButton_Click(object sender, EventArgs e)
        {
            switch (pullMethodDropdown.SelectedItem)
            {
                case "NetworkTables":
                    break;
                case "XML Remote":
                    new OpenNetPrompt((path) =>
                    {
                        xmlDocument.Load(path);
                    }).Show();
                    break;
                case "XML Local":
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        xmlDocument.Load(openFileDialog1.FileName);
                    }
                    break;
            }
            hardwareMap.childList = new List<HardwareMapEntry>();
            hardwareMap.subsystem = true;
            hardwareMap.name = "Robot";
            //hardwareMap.controlObject = new Control[1];

            defineHardwareMap(xmlDocument.ChildNodes[1], hardwareMap);
            printHardwareTree(0, hardwareMap);
            updateButtonScope(hardwareMap);
            parentScope = hardwareMap;
        }

        private void defineHardwareMap(XmlNode node, HardwareMapEntry parent)
        {
            foreach(XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name == "Settings")
                    continue;

                string type = childNode.Name;

                HardwareMapEntry entry = new HardwareMapEntry();
                entry.type = type;
                entry.name = getNameString(childNode);
                entry.subType = getNodeString(childNode, "Type");
                entry.childList = new List<HardwareMapEntry>();

                entry.imageButton = getImageButton((a, eventArgs) =>
                {
                    updateButtonScope(entry);
                }, getHardwareImage(entry.type, entry.subType), entry.name, entry.name);

                if (supportedDevices.Contains(type))
                {
                    entry.subsystem = false;
                    entry.childObject = ParseHardware(childNode, type);
                } else
                {
                    entry.subsystem = true;
                    entry.childList = new List<HardwareMapEntry>();

                    defineHardwareMap(childNode, entry);
                }

                parent.childList.Add(entry);
            }
        }

        private void printHardwareTree(int layer, HardwareMapEntry hardware)
        {
            foreach(var a in hardware.childList)
            {
                preview.Text += "\n" + (new string('\t', layer)) + a.name;
                if(a.subsystem)
                {
                    printHardwareTree(layer + 1, (HardwareMapEntry) a);
                } else
                {
                    StringBuilder tmp = new StringBuilder();
                    a.childObject.print(tmp, layer);
                    preview.Text += tmp.ToString();
                }
            }
        }

        private static XmlNode getName(XmlNode node)
        {
            if (node.Attributes != null)
                foreach(XmlAttribute attr in node.Attributes)
                {
                    if (attr.Name.Equals("name"))
                        return attr;
                }

            foreach (XmlNode a in node.ChildNodes)
            {
                if (a.Name.Equals("Name"))
                    return a;
            }

            return node;
        }

        private static string getNameString(XmlNode node)
        {
            if (node.Attributes != null)
                foreach (XmlAttribute attr in node.Attributes)
                {
                    if (attr.Name.Equals("name"))
                        return attr.Value;
                }

            foreach (XmlNode a in node.ChildNodes)
            {
                if (a.Name.Equals("Name"))
                    return a.InnerText;
            }

            return node.Name;
        }

        private static string getAttribute(XmlNode node, string key)
        {
            foreach (XmlAttribute attr in node.Attributes)
            {
                if (attr.Name.Equals(key))
                    return attr.Value;
            }

            return null;
        }

        private static XmlNode getNode(XmlNode node, string key)
        {
            foreach (XmlNode a in node.ChildNodes)
            {
                if (a.Name.Equals(key))
                    return a;
            }

            return null;
        }

        private static string getNodeString(XmlNode node, string key)
        {
            foreach (XmlNode a in node.ChildNodes)
            {
                if (a.Name.Equals(key))
                    return a.InnerText;
            }

            return null;
        }

        private void updateButtonScope(HardwareMapEntry scopedMap)
        {

            if (scopedMap.subsystem)
            {
                HardwareFlowTable.Controls.Clear();

                parentScope = currentScope;
                currentScope = scopedMap;

                foreach (HardwareMapEntry entry in scopedMap.childList)
                {
                    HardwareFlowTable.Controls.Add(entry.imageButton);
                }
            } else
            {
                MultiInput input = new MultiInput();
                scopedMap.childObject.addValuesToMultiInput(input);

                input.addOnFinish((e, inputObject) =>
                {
                    scopedMap.childObject.getValuesFromMultiInput(inputObject);
                });

                input.addButton("Delete", (e, arg) =>
                {
                    currentScope.childList.Remove(scopedMap);

                    input.Close();

                    backButton_Click(e, arg);
                });

                input.Show();
            }
        }

        private Button getImageButton(Action<object, EventArgs> onClick, Image image, string id, string text)
        {
            Button tmp = new Button();
            tmp.BackgroundImage = image;//global::FRC_Utility_Software.Properties.Resources.DriveTrain;
            tmp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            tmp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            tmp.Location = new System.Drawing.Point(3, 3);
            tmp.Name = id;
            tmp.Size = new System.Drawing.Size(170, 170);
            tmp.TabIndex = 0;
            tmp.Text = text;
            tmp.ForeColor = Color.Black;
            tmp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            tmp.UseVisualStyleBackColor = true;
            tmp.Click += new System.EventHandler(onClick);
            return tmp;
        }

        private static Control getStringInputControl(string id, string defaultString, Action<TextBox, string> onleave)
        {
            TextBox tmp = new TextBox();
            tmp.Text = defaultString;
            tmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tmp.AutoSize = true;
            tmp.Name = id;
            tmp.Leave += new EventHandler((a, args) =>
            {
                onleave.Invoke(tmp, tmp.Text);
            });

            return tmp;
        }

        private static Control getTextLabelControl(string textContent)
        {
            Label text = new Label();
            text.Text = textContent;
            text.AutoSize = true;
            text.Padding = new System.Windows.Forms.Padding(10);

            return text;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            updateButtonScope(hardwareMap);
            parentScope = hardwareMap;
        }

        private void addDeviceButton_Click(object sender, EventArgs e)
        {
            if (!currentScope.subsystem) return;

            switch (addDeviceType.Text)
            {
                case "Motor":
                    HardwareMapEntry motor = new HardwareMapEntry();
                    motor.type = "Motor";
                    motor.name = "TBD";
                    motor.subType = "TBD";
                    motor.subsystem = false;
                    motor.childObject = new Motor();

                    motor.imageButton = getImageButton((a, eventArgs) =>
                    {
                        updateButtonScope(motor);
                    }, getHardwareImage(motor.type, motor.subType), motor.name, motor.name);

                    currentScope.childList.Add(motor);
                    break;

                case "Encoder":
                    HardwareMapEntry encoder = new HardwareMapEntry();
                    encoder.type = "Encoder";
                    encoder.name = "TBD";
                    encoder.subType = "TBD";
                    encoder.subsystem = false;
                    encoder.childObject = new Encoder();

                    encoder.imageButton = getImageButton((a, eventArgs) =>
                    {
                        updateButtonScope(encoder);
                    }, getHardwareImage(encoder.type, encoder.subType), encoder.name, encoder.name);

                    currentScope.childList.Add(encoder);
                    break;

                case "Gyro":
                    HardwareMapEntry gyro = new HardwareMapEntry();
                    gyro.type = "Gyro";
                    gyro.name = "TBD";
                    gyro.subType = "TBD";
                    gyro.subsystem = false;
                    gyro.childObject = new Gyro();

                    gyro.imageButton = getImageButton((a, eventArgs) =>
                    {
                        updateButtonScope(gyro);
                    }, getHardwareImage(gyro.type, gyro.subType), gyro.name, gyro.name);

                    currentScope.childList.Add(gyro);
                    break;
                case "SwerveModule":
                    break;
                case "SwerveDriveTrain":
                    break;
            }

            updateButtonScope(currentScope);
        }

        private void previewXML_Click(object sender, EventArgs e)
        {
            //xmlDocument = new XmlDocument();
            //xmlDocument.PreserveWhitespace = true;
            //XmlNode robot = xmlDocument.AppendChild(xmlDocument.CreateNode(XmlNodeType.Element, "Robot", ""));

            //foreach(var a in parentScope.childList)
            //    addXMLObjects(robot, a, xmlDocument);

            pushXMLForChild(parentScope);

            preview.Text = xmlDocument.OuterXml;
            //using (var stringWriter = new StringWriter())
            //using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            //{
            //    xmlDocument.WriteTo(xmlTextWriter);
            //    xmlTextWriter.Flush();
            //    preview.Text = stringWriter.GetStringBuilder().ToString();
            //}
        }

        private void pushXMLForChild(HardwareMapEntry entry)
        {
            if(entry.subsystem)
            {
                foreach(var a in entry.childList)
                {
                    pushXMLForChild(a);
                }
            } else
            {
                entry.childObject.pushToXML();
            }
        }

        private void addXMLObjects(XmlNode node, HardwareMapEntry entry, XmlDocument doc)
        {
            if (entry.subsystem)
            {
                foreach (var a in entry.childList)
                {
                    XmlNode tmp = node.AppendChild(doc.CreateNode(XmlNodeType.Element, a.type, ""));
                    addXMLObjects(tmp, a, doc);
                }
            }
            else
            {
                //XmlNode tmp = node.AppendChild(doc.CreateNode(XmlNodeType.Element, entry.type, ""));
                entry.childObject.addToXML(node, doc);
            }
        }

        public static void addTextElement(XmlNode node, string type, string content, XmlDocument doc)
        {
            XmlNode tmp = doc.CreateNode(XmlNodeType.Element, type, "");
            tmp.InnerText = content;
            tmp.AppendChild(doc.CreateNode(XmlNodeType.Text, content, ""));

            node.AppendChild(tmp);
        }
    }
}
