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
            RadioButton1 = new RadioButton();
            RadioButton2 = new RadioButton();
            NoneButton = new RadioButton();
            SoundsLabel = new Label();
            SuspendLayout();
            // 
            // ButtonStart
            // 
            ButtonStart.Location = new Point(12, 101);
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
            ButtonStop.Location = new Point(12, 157);
            ButtonStop.Name = "ButtonStop";
            ButtonStop.Size = new Size(75, 23);
            ButtonStop.TabIndex = 1;
            ButtonStop.Text = "Stop";
            ButtonStop.UseVisualStyleBackColor = true;
            ButtonStop.Click += ButtonStop_Click;
            // 
            // clipboardTextBox
            // 
            clipboardTextBox.Location = new Point(93, 33);
            clipboardTextBox.Multiline = true;
            clipboardTextBox.Name = "clipboardTextBox";
            clipboardTextBox.ScrollBars = ScrollBars.Both;
            clipboardTextBox.Size = new Size(544, 243);
            clipboardTextBox.TabIndex = 2;
            // 
            // RadioButton1
            // 
            RadioButton1.AutoSize = true;
            RadioButton1.Checked = true;
            RadioButton1.Location = new Point(227, 6);
            RadioButton1.Name = "RadioButton1";
            RadioButton1.Size = new Size(121, 19);
            RadioButton1.TabIndex = 3;
            RadioButton1.TabStop = true;
            RadioButton1.Text = "RadioButton1.wav";
            RadioButton1.UseVisualStyleBackColor = true;
            RadioButton1.CheckedChanged += RadioButton1_CheckedChanged;
            // 
            // RadioButton2
            // 
            RadioButton2.AutoSize = true;
            RadioButton2.Location = new Point(381, 6);
            RadioButton2.Name = "RadioButton2";
            RadioButton2.Size = new Size(121, 19);
            RadioButton2.TabIndex = 4;
            RadioButton2.Text = "RadioButton2.wav";
            RadioButton2.UseVisualStyleBackColor = true;
            RadioButton2.CheckedChanged += RadioButton2_CheckedChanged;
            // 
            // NoneButton
            // 
            NoneButton.AutoSize = true;
            NoneButton.Location = new Point(535, 6);
            NoneButton.Name = "NoneButton";
            NoneButton.Size = new Size(52, 19);
            NoneButton.TabIndex = 5;
            NoneButton.Text = "none";
            NoneButton.UseVisualStyleBackColor = true;
            NoneButton.CheckedChanged += NoneButton_CheckedChanged;
            // 
            // SoundsLabel
            // 
            SoundsLabel.AutoSize = true;
            SoundsLabel.Font = new Font("Tempus Sans ITC", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            SoundsLabel.ForeColor = Color.Brown;
            SoundsLabel.Location = new Point(141, 6);
            SoundsLabel.Name = "SoundsLabel";
            SoundsLabel.Size = new Size(65, 19);
            SoundsLabel.TabIndex = 6;
            SoundsLabel.Text = "Sounds:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 281);
            Controls.Add(NoneButton);
            Controls.Add(RadioButton1);
            Controls.Add(RadioButton2);
            Controls.Add(SoundsLabel);
            Controls.Add(clipboardTextBox);
            Controls.Add(ButtonStop);
            Controls.Add(ButtonStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QcommentUrlCutter by moleNULL";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonStart;
        private Button ButtonStop;
        private TextBox clipboardTextBox;
        private RadioButton RadioButton1;
        private RadioButton RadioButton2;
        private RadioButton NoneButton;
        private Label SoundsLabel;
    }
}