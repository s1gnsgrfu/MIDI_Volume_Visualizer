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
            //MessageBox.Show("down");
            string str = "updateProgressBar("+prog+");";
            webView21.ExecuteScriptAsync(str);
            prog+=10;
            if (prog >= 100)
            {
                prog = 0;
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("click");
        }

        //private void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        //{
        //    webView21.KeyDown += Form2_KeyDown;
        //}
    }
}
