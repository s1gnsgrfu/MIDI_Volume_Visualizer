using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MIDI_Volume_Visualizer
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Form1 form1 = new();
            Form2 form2 = new();

            //Get Spotify process information
            foreach (System.Diagnostics.Process p in
                System.Diagnostics.Process.GetProcessesByName("Spotify"))
            {
                //Only when the title of the main window
                if (p.MainWindowTitle.Length != 0)
                {
                    string tmp = "ProcessName : " + p.ProcessName + "\nPID : " + p.Id;
                    form1.Label_Set(tmp);
                }
            }

            Application.Run(form1);
            Application.Run(form2);
            
        }


        //public static void form2ad(string name)
        //{
        //    Form2 form2 = new Form2();
        //    form2.Label_Set(name);
        //    Application.Run(form2);
        //}
    }
}