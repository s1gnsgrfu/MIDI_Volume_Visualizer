using Microsoft.Web.WebView2.Core;
using NAudio.Midi;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi;


namespace MIDI_Volume_Visualizer
{
    public partial class Form2 : Form
    {
        Form1 form1 = new();

        int prog = 0;
        static double stepSize = (double)127 / 100;    //Converts 127 to 100 steps
        static int stepIndex;
        private static MidiIn? midiIn;
        private static int MIDI_MSG_Value;
        static int volume = 0;
        static int PID = 0;
        public static int ProcessNameChange = 1;
        public static int PIDChange = 0;
        public static string? ProcessName;

        public static double? DefaultOpacity;

        private const int FadeInInterval = 10; // Fade-in interval (ms)
        private const double FadeInStep = 0.05;
        private const int FadeOutInterval = 30; // Fade-out interval (ms)
        private const double FadeOutStep = 0.05;
        private const int InactivityTimeout = 2000; // 3 seconds in milliseconds
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer fadeInTimer;
        private System.Windows.Forms.Timer fadeOutTimer;

        public Form2()
        {
            InitializeComponent();
            InitializeMidiInput();
            webView21.EnsureCoreWebView2Async();

            if (ProcessName == null)
            {
                ProcessName = "Spotify";
            }
            if (DefaultOpacity == null)
            {
                DefaultOpacity = 0.9;
            }

            ShowInTaskbar = false;
            TopMost = true;

            this.BackColor = Color.Black;
            this.Opacity = (double)DefaultOpacity;
            int radius = 10;
            int diameter = radius * 2;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddPie(0, 0, diameter, diameter, 180, 90);
            gp.AddPie(this.Width - diameter, 0, diameter, diameter, 270, 90);
            gp.AddPie(0, this.Height - diameter, diameter, diameter, 90, 90);
            gp.AddPie(this.Width - diameter, this.Height - diameter, diameter, diameter, 0, 90);
            gp.AddRectangle(new Rectangle(radius, 0, this.Width - diameter, this.Height));
            gp.AddRectangle(new Rectangle(0, radius, radius, this.Height - diameter));
            gp.AddRectangle(new Rectangle(this.Width - radius, radius, radius, this.Height - diameter));

            this.Region = new Region(gp);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = InactivityTimeout;
            timer.Tick += Timer_Tick;
            timer.Start();

            fadeInTimer = new System.Windows.Forms.Timer();
            fadeInTimer.Interval = FadeInInterval;
            fadeInTimer.Tick += FadeInTimer_Tick;
            FadeIn();

            fadeOutTimer = new System.Windows.Forms.Timer();
            fadeOutTimer.Interval = FadeOutInterval;
            fadeOutTimer.Tick += FadeOutTimer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            StartFadeOutTimer();
        }

        private void FadeIn()
        {
            fadeInTimer.Start();
        }

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < DefaultOpacity)
            {
                this.Opacity += FadeInStep;
            }
            else
            {
                fadeInTimer.Stop();
            }
        }

        private void StartFadeOutTimer()
        {
            fadeOutTimer.Start();
        }

        private void StopFadeOutTimer()
        {
            fadeOutTimer.Stop();
        }

        private void FadeOutTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= FadeOutStep;
            }
            else
            {
                this.Hide();
                StopFadeOutTimer();
            }
        }

        private void ResetFadeOutTimer()
        {
            StopFadeOutTimer();
            this.Opacity = (double)DefaultOpacity;
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

                string str = "setTitle(\"" + ProcessName + "\");";
            }
            else
            {
                MessageBox.Show($"Initialization failed : WebView2\nError : {e.InitializationException}");
                Environment.Exit(1);
            }
        }

        private void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            GC.Collect();
            this.Invoke(new Action(() =>
            {
                this.Show();
                timer.Stop();
                ResetFadeOutTimer();
                timer.Start();
            }));
            FadeIn();

            if (PID==0)
            {
                //Get Spotify process information
                foreach (System.Diagnostics.Process p in
                    System.Diagnostics.Process.GetProcessesByName(ProcessName))
                {
                    //Only when the title of the main window
                    if (p.MainWindowTitle.Length != 0)
                    {
                        PID = p.Id;
                    }
                }
                ProcessNameChange = 0;
            }
            
            if (ProcessNameChange==1)
            {
                
                PID = PIDChange;
                ProcessNameChange = 0;
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
                uint gprocessId = session.GetProcessID;
                string processName = ProcessName;

                if (session.GetProcessID == processId)
                {
                    session.SimpleAudioVolume.Volume = volumeLevel;
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

        private void Setting_Click(object sender, EventArgs e)
        {
            if (!form1.Visible)
            {
                form1.ShowDialog();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
