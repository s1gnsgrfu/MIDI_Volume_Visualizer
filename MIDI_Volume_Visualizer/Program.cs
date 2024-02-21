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

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Form2 form2 = new();

            if (File.Exists("settings"))
            {
                IEnumerable<string> lines = File.ReadLines("settings");
                int cnt = 0;

                foreach (string line in lines)
                {
                    int index=line.IndexOf(':');
                    string Setting = line.Substring(index + 1);
                    Debug.WriteLine(Setting);
                    if (cnt == 0)
                    {
                        Form2.ProcessName = Setting;
                    }else if (cnt == 1)
                    {
                        Form2.DefaultOpacity = double.Parse(Setting);
                    }
                    cnt++;
                }
            }

            Application.Run(form2);
        }
    }
}