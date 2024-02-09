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

    namespace MIDI_Volume_Visualizer
    {
    public partial class Form2 : Form
    {
        int prog = 0;
        static double stepSize = (double)127 / 100;    //Converts 127 to 100 steps
        static int stepIndex;
        private static MidiIn? midiIn;
        private static int MIDI_MSG_Value;

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public Form2()
        {
            AllocConsole();
            InitializeComponent();
            InitializeMidiInput();
            webView21.EnsureCoreWebView2Async();
        }
        private void InitializeMidiInput()
        {
            midiIn = new MidiIn(1); // MIDIデバイスのインデックスを指定して初期化
            midiIn.MessageReceived += MidiIn_MessageReceived;
            midiIn.Start();
        }

        private void WebView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                //Assign local folders to domains
                webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("assets.view", "assets", CoreWebView2HostResourceAccessKind.Allow);
                webView21.CoreWebView2.Navigate("https://assets.view/index.html");
                webView21.Focus();
            }
            else
            {
                MessageBox.Show($"Initialization failed : WebView2\nError : {e.InitializationException}");
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            stepIndex = (int)((MIDI_MSG_Value) / stepSize);
            string str = "updateProgressBar("+stepIndex+");";
            webView21.ExecuteScriptAsync(str);
        }

        private void webView21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("click");
        }

        private void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            int DATA1 = 63;//DATA1 of MIDI Messages

            MidiEvent midiEvent = MidiEvent.FromRawMessage(e.RawMessage);
            if (midiEvent.CommandCode == MidiCommandCode.ControlChange)
            {
                ControlChangeEvent controlChangeEvent = (ControlChangeEvent)midiEvent;
                if ((int)controlChangeEvent.Controller == DATA1)
                {
                    MIDI_MSG_Value = controlChangeEvent.ControllerValue;
                    Console.WriteLine("Value:" + MIDI_MSG_Value);

                    stepIndex = (int)((MIDI_MSG_Value) / stepSize);
                    string str = "setProgressBarWidth('"+ stepIndex+"%');";

                    webView21.Invoke(new Action(() => {
                        webView21.ExecuteScriptAsync(str);
                    }));
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            midiIn?.Stop();
            midiIn?.Dispose();
        }

    }
}
