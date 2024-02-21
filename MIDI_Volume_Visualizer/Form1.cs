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

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = Form2.ProcessName;
            label6.Text = (Form2.DefaultOpacity * 100).ToString() + "%";
            trackBar1.Value = (int)(Form2.DefaultOpacity * 100);

            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                ItemSet tmp = ((ItemSet)comboBox1.SelectedItem);
                label4.Text = tmp.ItemDisp;
                Form2.ProcessName = tmp.ItemDisp;
                Form2.PIDChange = int.Parse(comboBox1.SelectedValue.ToString());
                Form2.ProcessNameChange = 1;
            }
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


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Form2.DefaultOpacity = (double)trackBar1.Value / 100;
            label6.Text = trackBar1.Value.ToString() + "%";
        }
    }
}
