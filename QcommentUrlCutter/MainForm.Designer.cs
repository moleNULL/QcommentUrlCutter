using System.Diagnostics;
using System.Reflection;

namespace QcommentUrlCutter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ButtonStart = new Button();
            ButtonStop = new Button();
            clipboardTextBox = new TextBox();
            SuspendLayout();
            // 
            // ButtonStart
            // 
            ButtonStart.Location = new Point(12, 72);
            ButtonStart.Name = "ButtonStart";
            ButtonStart.Size = new Size(75, 23);
            ButtonStart.TabIndex = 0;
            ButtonStart.Text = "Start";
            ButtonStart.UseVisualStyleBackColor = true;
            ButtonStart.Click += ButtonStart_Click;
            // 
            // ButtonStop
            // 
            ButtonStop.Enabled = false;
            ButtonStop.Location = new Point(12, 137);
            ButtonStop.Name = "ButtonStop";
            ButtonStop.Size = new Size(75, 23);
            ButtonStop.TabIndex = 1;
            ButtonStop.Text = "Stop";
            ButtonStop.UseVisualStyleBackColor = true;
            ButtonStop.Click += ButtonStop_Click;
            // 
            // clipboardTextBox
            // 
            clipboardTextBox.Location = new Point(93, 17);
            clipboardTextBox.Multiline = true;
            clipboardTextBox.Name = "clipboardTextBox";
            clipboardTextBox.ScrollBars = ScrollBars.Both;
            clipboardTextBox.Size = new Size(544, 243);
            clipboardTextBox.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 272);
            Controls.Add(clipboardTextBox);
            Controls.Add(ButtonStop);
            Controls.Add(ButtonStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "QcommentUrlCutter by moleNULL";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonStart;
        private Button ButtonStop;
        private TextBox clipboardTextBox;
    }
}