/*
Settings.cs

Copyright (c) 2024 S'(s1gnsgrfu)

This software is released under the MIT License.
see https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/blob/master/LICENSE
*/

using NAudio.CoreAudioApi;
using System.Diagnostics;

namespace MIDI_Volume_Visualizer
{
    public partial class Settings : Form
    {
        public class ItemSet
        {
            public String ItemDisp { get; set; }
            public int ItemValue { get; set; }

            public ItemSet(int v, String s)
            {
                ItemDisp = s;
                ItemValue = v;
            }
        }

        public Settings()
        {
            InitializeComponent();
        }

        private void Setting_default()
        {
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            label6.Text = (display.DefaultOpacity * 100).ToString() + "%";
            trackBar1.Value = (int)(display.DefaultOpacity * 100);

            List<ItemSet> src = [];

            for (int i = 0; i < device.AudioSessionManager.Sessions.Count; i++)
            {
                var session = device.AudioSessionManager.Sessions[i];
                int processId = (int)session.GetProcessID;
                string processName = GetProcessName((uint)processId);

                src.Add(new ItemSet(processId, processName));
            }

            comboBox1.DataSource = src;
            comboBox1.DisplayMember = "ItemDisp";
            comboBox1.ValueMember = "ItemValue";

            int selectedIndex = -1;
            for (int i = 0; i < src.Count; i++)
            {
                if (src[i].ItemDisp == display.ProcessName)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex != -1)
            {
                comboBox1.SelectedIndex = selectedIndex;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Setting_default();
        }

        static string GetProcessName(uint processId)
        {
            try
            {
                Process process = Process.GetProcessById((int)processId);
                return process.ProcessName;
            }
            catch (ArgumentException)
            {
                return "Unknown";
            }
        }

        public void AddComboBox1(string processName)
        {
            Action<string> addItemDelegate = (string newItem) =>
            {
                comboBox1.Items.Add(newItem);
            };

            comboBox1.Invoke(addItemDelegate, processName);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = trackBar1.Value.ToString() + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItemSet tmp = ((ItemSet)comboBox1.SelectedItem);
            display.ProcessName = tmp.ItemDisp;
            display.PIDChange = int.Parse(comboBox1.SelectedValue.ToString());
            display.ProcessNameChange = 1;
            display.DefaultOpacity = (double)trackBar1.Value / 100;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static void Setting_Out()
        {
            string text = "ProcessName:" + display.ProcessName + "\n" +
                "Opacity:" + display.DefaultOpacity + "\n";
            File.WriteAllText(@"settings", text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Setting_Out();
            GC.Collect();
        }
    }
}
