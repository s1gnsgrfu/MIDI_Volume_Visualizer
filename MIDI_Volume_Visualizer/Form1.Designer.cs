﻿namespace MIDI_Volume_Visualizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Button = new Button();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // Button
            // 
            Button.Location = new Point(0, 0);
            Button.Name = "Button";
            Button.Size = new Size(75, 23);
            Button.TabIndex = 0;
            Button.Text = "EXIT";
            Button.UseVisualStyleBackColor = true;
            Button.Click += Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 68);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 1;
            // 
            // Form1
            // 
            ClientSize = new Size(350, 150);
            Controls.Add(label1);
            Controls.Add(Button);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Location = new Point(1550, 850);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            TopMost = true;
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Button;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}
