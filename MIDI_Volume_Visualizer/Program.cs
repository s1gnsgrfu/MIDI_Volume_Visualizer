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
        //private static MidiIn? midiIn;
        //public static int MIDI_MSG_Value;




        [STAThread]
        static void Main()
        {
            //Open MIDI Port
            //midiIn = new MidiIn(1); 
            //midiIn.MessageReceived += MidiIn_MessageReceived;
            //midiIn.Start();

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

            //Close MIDI Port
            //midiIn.Stop();
            //midiIn.Dispose();

        }
        //private static void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        //{
        //    int DATA1 = 63;//DATA1 of MIDI Messages

        //    MidiEvent midiEvent = MidiEvent.FromRawMessage(e.RawMessage);
        //    if (midiEvent.CommandCode == MidiCommandCode.ControlChange)
        //    {
        //        ControlChangeEvent controlChangeEvent = (ControlChangeEvent)midiEvent;
        //        if ((int)controlChangeEvent.Controller == DATA1)
        //        {
        //            MIDI_MSG_Value = controlChangeEvent.ControllerValue;
        //            Console.WriteLine("Value:" + MIDI_MSG_Value);
        //        }
        //    }
        //}
    }
}