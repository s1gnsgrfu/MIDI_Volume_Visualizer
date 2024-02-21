namespace MIDI_Volume_Visualizer
{
    partial class Form1
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
            label2 = new Label();
            comboBox1 = new ComboBox();
            trackBar1 = new TrackBar();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(71, 26);
            label2.Name = "label2";
            label2.Size = new Size(146, 30);
            label2.TabIndex = 2;
            label2.Text = "Procces Name";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(242, 33);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(230, 23);
            comboBox1.TabIndex = 4;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(242, 89);
            trackBar1.Maximum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(230, 45);
            trackBar1.TabIndex = 6;
            trackBar1.TickFrequency = 0;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(71, 77);
            label5.Name = "label5";
            label5.Size = new Size(84, 30);
            label5.TabIndex = 2;
            label5.Text = "Opacity";
            // 
            // label6
            // 
            label6.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(481, 86);
            label6.Name = "label6";
            label6.Size = new Size(75, 23);
            label6.TabIndex = 7;
            label6.Text = "Percent";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(432, 315);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(513, 315);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 350);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(trackBar1);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Settings";
            Activated += Form1_Load;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private ComboBox comboBox1;
        private TrackBar trackBar1;
        private Label label5;
        private Label label6;
        private Button button1;
        private Button button2;
    }
}