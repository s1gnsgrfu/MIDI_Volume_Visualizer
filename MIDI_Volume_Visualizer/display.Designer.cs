/*
display.Designer.cs

Copyright (c) 2024 S'(s1gnsgrfu)

This software is released under the MIT License.
see https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/blob/master/LICENSE
*/

using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace MIDI_Volume_Visualizer
{
    partial class display
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(display));
            webView21 = new WebView2();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(0, 0);
            webView21.Name = "webView21";
            //webView21.Size = new Size(330, 100); //FHD
            webView21.Size = new Size(330 * 2-80, 100*2-40); //4K
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            webView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "MIDI Volume Visualizer";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += Setting_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(117, 48);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(116, 22);
            toolStripMenuItem1.Text = "Settings";
            toolStripMenuItem1.Click += Setting_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(116, 22);
            toolStripMenuItem2.Text = "Exit";
            toolStripMenuItem2.Click += ToolStripMenuItem2_Click;
            // 
            // Form2
            // 
            BackColor = Color.Black;
            //ClientSize = new Size(330, 100); //FHD
            ClientSize = new Size(330*2-80, 100*2-40); //4K
            Controls.Add(webView21);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            //Location = new Point(1570, 920); //FHD
            Location = new Point(1570*2+70, 920*2+50); //4K
            Name = "Form2";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Form2";
            TopMost = true;
            TransparencyKey = Color.FromArgb(255, 192, 192);
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
    }
}