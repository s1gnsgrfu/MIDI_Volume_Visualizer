using NAudio.CoreAudioApi;
using System.Diagnostics;

namespace MIDI_Volume_Visualizer
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Setting_default()
        {
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            label6.Text = (Form2.DefaultOpacity * 100).ToString() + "%";
            trackBar1.Value = (int)(Form2.DefaultOpacity * 100);

            List<ItemSet> src = new List<ItemSet>();

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
                if (src[i].ItemDisp == Form2.ProcessName)
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
            Form2.ProcessName = tmp.ItemDisp;
            Form2.PIDChange = int.Parse(comboBox1.SelectedValue.ToString());
            Form2.ProcessNameChange = 1;
            Form2.DefaultOpacity = (double)trackBar1.Value / 100;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Setting_Out()
        {
            string text = "ProcessName:" + Form2.ProcessName + "\n" +
                "Opacity:" + Form2.DefaultOpacity + "\n";
            File.WriteAllText(@"settings", text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Setting_Out();
            GC.Collect();
        }
    }
}
