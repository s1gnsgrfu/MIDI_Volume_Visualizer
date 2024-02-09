namespace MIDI_Volume_Visualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            label1.Text += 1;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void Label_Set(string value)
        {
            label1.Text += " " + value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
