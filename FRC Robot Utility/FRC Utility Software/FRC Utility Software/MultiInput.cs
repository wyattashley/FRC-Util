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
    public partial class MultiInput : Form
    {
        Dictionary<string, object> entries = new Dictionary<string, object>();
        private bool shown;
        Action<Dictionary<string, object>, MultiInput> callback;

        public MultiInput()
        {
            InitializeComponent();
            mainPanel.VerticalScroll.Enabled = true;
        }

        public void addOnFinish(Action<Dictionary<string, object>, MultiInput> onFinish)
        {
            callback = onFinish;
        }

        public void addPrompt<T>(string _prompt, T defaultValue)
        {
            entries.Add(_prompt, defaultValue);
        }

        public void addPrompt(KeyValuePair<string, object> pair)
        {
            entries.Add(pair.Key, pair.Value);
        }

        public void addPrompts(Dictionary<string, object> promptsAndKeys)
        {
            entries.Concat(promptsAndKeys);
        }

        public void addButton(string message, Action<object, EventArgs> onClick)
        {
            Button tmp = new Button();
            tmp.Location = new System.Drawing.Point(84, 3);
            tmp.AutoSize = true;
            tmp.Text = message;
            tmp.UseVisualStyleBackColor = true;
            tmp.Click += new System.EventHandler(onClick);
            flowLayoutPanel2.Controls.Add(tmp);
        }

        public T get<T>(string key)
        {
            var entry = entries[key];
            return (T) Convert.ChangeType(entry, typeof(T));
        }

        public object get(string key)
        {
            return entries[key];
        }

        public Type getEntryType(string key)
        {
            return entries[key].GetType();
        }

        public Dictionary<string, object> getResults()
        {
            if(!shown) throw new NullReferenceException();
            return entries;
        }

        private TableLayoutPanel getNumeric(string prompt, double defaultVal, Action<double> onChange, bool withDecimal = true, bool allowNegative = true)
        {
            Label label = new Label();
            label.Text = prompt + ": ";
            label.AutoSize = true;
            label.Anchor = AnchorStyles.None;
            
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.AutoSize = true;
            numericUpDown.DecimalPlaces = (withDecimal ? 2 : 0);
            numericUpDown.Anchor = AnchorStyles.None;
            numericUpDown.Value = (decimal) defaultVal;
            numericUpDown.Leave += new EventHandler((e, args) => onChange.Invoke((double) numericUpDown.Value));
            if (!allowNegative) numericUpDown.Minimum = 0;

            return formGroup(label, numericUpDown);
        }

        private TableLayoutPanel getTextBox(string prompt, string defaultVal, Action<string> onChange)
        {
            Label label = new Label();
            label.Text = prompt + ": ";
            label.AutoSize = true;
            label.Anchor = AnchorStyles.None;

            TextBox textBox = new TextBox();
            textBox.AutoSize = true;
            textBox.Text = defaultVal;
            textBox.Anchor = AnchorStyles.None;
            textBox.Leave += new EventHandler((e, args) => onChange.Invoke(textBox.Text));

            return formGroup(label, textBox);
        }

        private TableLayoutPanel getToggle(string prompt, bool defaultVal, Action<bool> onChange)
        {
            Label label = new Label();
            label.Text = prompt + ": ";
            label.AutoSize = true;
            label.Anchor = AnchorStyles.None;

            CheckBox box = new CheckBox();
            box.Appearance = Appearance.Button;

            box.CheckedChanged += new EventHandler((obj, args) =>
            {
                if (box.Checked)
                    box.Text = "True";
                else
                    box.Text = "False";

                onChange.Invoke(box.Checked);
            });

            if (defaultVal)
                box.Text = "True";
            else
                box.Text = "False";

            box.Checked = defaultVal;
            box.Anchor = AnchorStyles.None;
            box.TextAlign = ContentAlignment.MiddleCenter;

            return formGroup(label, box);
        }

        private TableLayoutPanel getDropDown(string prompt, string[] possibleValues, Action<string> onChange)
        {
            Label label = new Label();
            label.Text = prompt + ": ";
            label.AutoSize = true;
            label.Anchor = AnchorStyles.None;

            ComboBox box = new ComboBox();
            box.Anchor = AnchorStyles.None;
            box.Items.AddRange(possibleValues.ToArray());
            box.SelectedValueChanged += new EventHandler((e, args) => onChange.Invoke(box.Text));

            return formGroup(label, box);
        }

        private TableLayoutPanel formGroup(Control a, Control b)
        {
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.ColumnCount = 2;
            panel.RowCount = 1;
            panel.AutoSize = true;

            panel.Controls.Add(a, 0, 0);
            panel.Controls.Add(b, 1, 0);

            return panel;
        }

        private bool isNumericType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public new void Show()
        {
            foreach(var a in entries)
            {
                Type type = a.Value.GetType();

                if (isNumericType(type))
                {
                    mainPanel.Controls.Add(getNumeric(a.Key, get<double>(a.Key), (d) =>
                    {
                        entries[a.Key] = d;
                    }));
                } else if(type == typeof(bool))
                {
                    mainPanel.Controls.Add(getToggle(a.Key, get<bool>(a.Key), (d) =>
                    {
                        entries[a.Key] = d;
                    }));
                } else
                {
                    mainPanel.Controls.Add(getTextBox(a.Key, get<string>(a.Key), (d) =>
                    {
                        entries[a.Key] = d;
                    }));
                }
            }
            base.Show();
            shown = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);

            callback.Invoke(entries, this);
        }
    }
}
