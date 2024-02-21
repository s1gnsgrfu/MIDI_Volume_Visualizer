using System.Diagnostics;

namespace MIDI_Volume_Visualizer
{

    internal class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Form2 form2 = new();

            Application.Run(form2);
        }
    }
}