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
        public Form2()
        {
            InitializeComponent();
            webView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;
        }

        //private void webView21_Click(object sender, EventArgs e)
        //{
        //    if (webView21 != null && webView21.CoreWebView2 != null)
        //    {
        //        webView21.CoreWebView2.Navigate("https://assets.view/index.html");
        //        webView21.CoreWebView2.Navigate("https://www.apple.com/jp/?afid=p238%7CZUkI5bsT-dc_mtid_18707vxu38484&cid=aos-jp-kwyh-brand");
        //    }
        //}
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
            }
        }
    }
}
