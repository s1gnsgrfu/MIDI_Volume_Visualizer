using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using NAudio.Midi;

namespace MIDI_Volume_Visualizer
{

    internal class Program
    {
        public static int PID = 0;

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
                    PID = p.Id;
                    string tmp = "ProcessName : " + p.ProcessName + "\nPID : " + p.Id;
                    form1.Label_Set(tmp);
                }
            }

            Application.Run(form1);
            Application.Run(form2);
        }
    }
}