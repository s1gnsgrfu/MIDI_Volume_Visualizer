namespace MIDI_Volume_Visualizer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //Button button = new Button();

            //button.Text = "Exit";
            //button.BackColor = Color.White;
            //this.CancelButton = button;
            //f.Controls.Add(button);


            Application.Run(new Form1());
        }
    }
}