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

    namespace MIDI_Volume_Visualizer
    {
    public partial class Form2 : Form
    {
        int prog = 0;
        double stepSize = (double)127 / 100;    //Converts 127 to 100 steps
        int stepIndex;

        public Form2()
        {
            InitializeComponent();
            webView21.EnsureCoreWebView2Async();
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
            stepIndex = (int)((Program.MIDI_MSG_Value) / stepSize);
            string str = "updateProgressBar("+stepIndex+");";
            webView21.ExecuteScriptAsync(str);
        }

        private void webView21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("click");
        }
    }
}
