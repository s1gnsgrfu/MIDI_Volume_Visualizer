using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace MIDI_Volume_Visualizer
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webView21 = new WebView2();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(0, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(350, 100);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            webView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;
            // 
            // Form2
            // 
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(350, 100);
            Controls.Add(webView21);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Location = new Point(1550, 900);
            Name = "Form2";
            StartPosition = FormStartPosition.Manual;
            Text = "Form2";
            TransparencyKey = Color.FromArgb(255, 192, 192);
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            ShowInTaskbar = false;
            TopMost = true;

            this.BackColor = Color.Black;
            this.Opacity = 0.9;
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
        }


        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}