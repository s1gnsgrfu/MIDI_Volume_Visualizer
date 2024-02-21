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
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            trackBar1 = new TrackBar();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(34, 23);
            label1.Name = "label1";
            label1.Size = new Size(149, 47);
            label1.TabIndex = 0;
            label1.Text = "Settings";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(71, 87);
            label2.Name = "label2";
            label2.Size = new Size(146, 30);
            label2.TabIndex = 2;
            label2.Text = "Procces Name";
            // 
            // button1
            // 
            button1.Location = new Point(481, 93);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Set";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(242, 94);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(230, 23);
            comboBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(97, 134);
            label3.Name = "label3";
            label3.Size = new Size(120, 21);
            label3.TabIndex = 5;
            label3.Text = "Current Process";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(242, 134);
            label4.Name = "label4";
            label4.Size = new Size(120, 21);
            label4.TabIndex = 5;
            label4.Text = "Current Process";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(242, 190);
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
            label5.Location = new Point(71, 178);
            label5.Name = "label5";
            label5.Size = new Size(84, 30);
            label5.TabIndex = 2;
            label5.Text = "Opacity";
            // 
            // label6
            // 
            label6.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(481, 187);
            label6.Name = "label6";
            label6.Size = new Size(75, 23);
            label6.TabIndex = 7;
            label6.Text = "Percent";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 350);
            Controls.Add(label6);
            Controls.Add(trackBar1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Settings";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private TrackBar trackBar1;
        private Label label5;
        private Label label6;
    }
}