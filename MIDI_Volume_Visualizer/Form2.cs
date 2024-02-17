using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Midi;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi;
using static System.Windows.Forms.DataFormats;
using System.Security.Cryptography;


namespace MIDI_Volume_Visualizer
    {
    public partial class Form2 : Form
    {
        int prog = 0;
        static double stepSize = (double)127 / 100;    //Converts 127 to 100 steps
        static int stepIndex;
        private static MidiIn? midiIn;
        private static int MIDI_MSG_Value;
        static int volume = 0;
        static int PID = 0;
        static string ProcessName = "Spotify";

        private System.Windows.Forms.Timer timer;
        private const int InactivityTimeout = 3000; // 3 seconds in milliseconds


        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public Form2()
        {
            //AllocConsole();
            InitializeComponent();
            InitializeMidiInput();
            webView21.EnsureCoreWebView2Async();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = InactivityTimeout;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => {
                this.Hide();
                timer.Stop();
            }));
        }

        private void InitializeMidiInput()
        {
            try
            {
                midiIn = new MidiIn(1);
                midiIn.MessageReceived += MidiIn_MessageReceived;
                midiIn.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not initialize the MIDI device.\nCheck to see if the device is connected and if any other software that uses MIDI devices is running.");
                Environment.Exit(1);
            }
        }
            
        private void WebView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                //Assign local folders to domains
                webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("assets.view", "assets", CoreWebView2HostResourceAccessKind.Allow);
                webView21.CoreWebView2.Navigate("https://assets.view/index.html");
                
            }
            else
            {
                MessageBox.Show($"Initialization failed : WebView2\nError : {e.InitializationException}");
                Environment.Exit(1);
            }
        }

        private void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            this.Invoke(new Action(() => {
                this.Show();
                timer.Stop();
                timer.Start();
            }));

            if (PID == 0)
            {
                //Get Spotify process information
                foreach (System.Diagnostics.Process p in
                    System.Diagnostics.Process.GetProcessesByName(ProcessName))
                {
                    //Only when the title of the main window
                    if (p.MainWindowTitle.Length != 0)
                    {
                        PID = p.Id;
                        string tmp = "ProcessName : " + p.ProcessName + "\nPID : " + p.Id;
                        Console.WriteLine(tmp);
                    }
                }
            }

            int DATA1 = 63;//DATA1 of MIDI Messages

            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            MidiEvent midiEvent = MidiEvent.FromRawMessage(e.RawMessage);
            if (midiEvent.CommandCode == MidiCommandCode.ControlChange)
            {
                ControlChangeEvent controlChangeEvent = (ControlChangeEvent)midiEvent;
                if ((int)controlChangeEvent.Controller == DATA1)
                {
                    MIDI_MSG_Value = controlChangeEvent.ControllerValue;
                    Console.WriteLine("Value:" + MIDI_MSG_Value);

                    stepIndex = (int)((MIDI_MSG_Value) / stepSize);
                    string str = "setProgressBarWidth('" + stepIndex + "%');";
                    string str2 = "setPercent(" + stepIndex + ");";
                    string str3 = "setTitle(\"" + ProcessName + "\");";

                    webView21.Invoke(new Action(() =>
                    {
                        webView21.ExecuteScriptAsync(str);
                        webView21.ExecuteScriptAsync(str2);
                        webView21.ExecuteScriptAsync(str3);
                    }));

                    SetProcessVolume(PID, stepIndex / 100.0f);
                }
            }
        }

        private void SetProcessVolume(int processId, float volumeLevel)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            for (int i = 0; i < device.AudioSessionManager.Sessions.Count; i++)
            {
                var session = device.AudioSessionManager.Sessions[i];
                if (session.GetProcessID == processId)
                {
                    session.SimpleAudioVolume.Volume = volumeLevel;
                    Console.WriteLine($"PID {processId} -> Change volume level : {volumeLevel * 100}%");
                    return;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            midiIn?.Stop();
            midiIn?.Dispose();
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}
