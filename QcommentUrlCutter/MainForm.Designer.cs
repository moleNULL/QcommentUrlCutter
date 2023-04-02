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
            TabControl = new TabControl();
            ApplicationTab = new TabPage();
            ApplicationFolderButton = new Button();
            SettingsTab = new TabPage();
            ApplicationToOpenFilesButton = new Button();
            ApplicationToOpenFilesTextBox = new TextBox();
            ApplicationToOpenFilesLabel = new Label();
            SubmitButtonStatusLabel = new Label();
            SettingsFolderButton = new Button();
            SettingsFileButton = new Button();
            SubmitButton = new Button();
            SoundPathSecondButton = new Button();
            SoundPathSecondTextBox = new TextBox();
            SoundPathSecondLabel = new Label();
            SoundPathFirstTextBox = new TextBox();
            SoundPathFirstButton = new Button();
            SoundPathFirstLabel = new Label();
            RadioButtonChoiceComboBox = new ComboBox();
            IsButtonClickedOnLaunchComboBox = new ComboBox();
            IsButtonClickedOnLaunchLabel = new Label();
            RadioButtonChoiceLabel = new Label();
            UrlPrefixTextBox = new TextBox();
            UrlPrefixLabel = new Label();
            LogsTab = new TabPage();
            LogsFolderButton = new Button();
            LogsFileButton = new Button();
            ClearLogsButton = new Button();
            LogsTextBox = new TextBox();
            TabControl.SuspendLayout();
            ApplicationTab.SuspendLayout();
            SettingsTab.SuspendLayout();
            LogsTab.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonStart
            // 
            ButtonStart.Location = new Point(3, 96);
            ButtonStart.Name = "ButtonStart";
            ButtonStart.Size = new Size(75, 23);
            ButtonStart.TabIndex = 0;
            ButtonStart.Text = "Start";
            ButtonStart.UseVisualStyleBackColor = true;
            ButtonStart.Click += ButtonStart_ClickAsync;
            // 
            // ButtonStop
            // 
            ButtonStop.Enabled = false;
            ButtonStop.Location = new Point(3, 152);
            ButtonStop.Name = "ButtonStop";
            ButtonStop.Size = new Size(75, 23);
            ButtonStop.TabIndex = 1;
            ButtonStop.Text = "Stop";
            ButtonStop.UseVisualStyleBackColor = true;
            ButtonStop.Click += ButtonStop_Click;
            // 
            // clipboardTextBox
            // 
            clipboardTextBox.Location = new Point(84, 31);
            clipboardTextBox.Multiline = true;
            clipboardTextBox.Name = "clipboardTextBox";
            clipboardTextBox.ScrollBars = ScrollBars.Vertical;
            clipboardTextBox.Size = new Size(546, 254);
            clipboardTextBox.TabIndex = 2;
            // 
            // RadioButton1
            // 
            RadioButton1.AutoSize = true;
            RadioButton1.Checked = true;
            RadioButton1.Location = new Point(196, 6);
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
            RadioButton2.Location = new Point(372, 6);
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
            NoneButton.Location = new Point(549, 6);
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
            SoundsLabel.Location = new Point(97, 6);
            SoundsLabel.Name = "SoundsLabel";
            SoundsLabel.Size = new Size(65, 19);
            SoundsLabel.TabIndex = 6;
            SoundsLabel.Text = "Sounds:";
            // 
            // TabControl
            // 
            TabControl.Controls.Add(ApplicationTab);
            TabControl.Controls.Add(SettingsTab);
            TabControl.Controls.Add(LogsTab);
            TabControl.Location = new Point(3, 0);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(641, 320);
            TabControl.TabIndex = 7;
            // 
            // ApplicationTab
            // 
            ApplicationTab.Controls.Add(ApplicationFolderButton);
            ApplicationTab.Controls.Add(ButtonStart);
            ApplicationTab.Controls.Add(NoneButton);
            ApplicationTab.Controls.Add(ButtonStop);
            ApplicationTab.Controls.Add(RadioButton2);
            ApplicationTab.Controls.Add(RadioButton1);
            ApplicationTab.Controls.Add(clipboardTextBox);
            ApplicationTab.Controls.Add(SoundsLabel);
            ApplicationTab.Location = new Point(4, 24);
            ApplicationTab.Name = "ApplicationTab";
            ApplicationTab.Padding = new Padding(3);
            ApplicationTab.Size = new Size(633, 292);
            ApplicationTab.TabIndex = 0;
            ApplicationTab.Text = "Application";
            ApplicationTab.UseVisualStyleBackColor = true;
            ApplicationTab.Enter += ApplicationTab_Enter;
            // 
            // ApplicationFolderButton
            // 
            ApplicationFolderButton.Location = new Point(3, 269);
            ApplicationFolderButton.Name = "ApplicationFolderButton";
            ApplicationFolderButton.Size = new Size(75, 23);
            ApplicationFolderButton.TabIndex = 7;
            ApplicationFolderButton.Text = "Folder";
            ApplicationFolderButton.UseVisualStyleBackColor = true;
            ApplicationFolderButton.Click += ApplicationFolderButton_Click;
            // 
            // SettingsTab
            // 
            SettingsTab.Controls.Add(ApplicationToOpenFilesButton);
            SettingsTab.Controls.Add(ApplicationToOpenFilesTextBox);
            SettingsTab.Controls.Add(ApplicationToOpenFilesLabel);
            SettingsTab.Controls.Add(SubmitButtonStatusLabel);
            SettingsTab.Controls.Add(SettingsFolderButton);
            SettingsTab.Controls.Add(SettingsFileButton);
            SettingsTab.Controls.Add(SubmitButton);
            SettingsTab.Controls.Add(SoundPathSecondButton);
            SettingsTab.Controls.Add(SoundPathSecondTextBox);
            SettingsTab.Controls.Add(SoundPathSecondLabel);
            SettingsTab.Controls.Add(SoundPathFirstTextBox);
            SettingsTab.Controls.Add(SoundPathFirstButton);
            SettingsTab.Controls.Add(SoundPathFirstLabel);
            SettingsTab.Controls.Add(RadioButtonChoiceComboBox);
            SettingsTab.Controls.Add(IsButtonClickedOnLaunchComboBox);
            SettingsTab.Controls.Add(IsButtonClickedOnLaunchLabel);
            SettingsTab.Controls.Add(RadioButtonChoiceLabel);
            SettingsTab.Controls.Add(UrlPrefixTextBox);
            SettingsTab.Controls.Add(UrlPrefixLabel);
            SettingsTab.Location = new Point(4, 24);
            SettingsTab.Name = "SettingsTab";
            SettingsTab.Padding = new Padding(3);
            SettingsTab.Size = new Size(633, 292);
            SettingsTab.TabIndex = 1;
            SettingsTab.Text = "Settings";
            SettingsTab.UseVisualStyleBackColor = true;
            SettingsTab.Enter += SettingsTab_Enter;
            // 
            // ApplicationToOpenFilesButton
            // 
            ApplicationToOpenFilesButton.Location = new Point(482, 216);
            ApplicationToOpenFilesButton.Name = "ApplicationToOpenFilesButton";
            ApplicationToOpenFilesButton.Size = new Size(31, 23);
            ApplicationToOpenFilesButton.TabIndex = 23;
            ApplicationToOpenFilesButton.Text = "...";
            ApplicationToOpenFilesButton.UseVisualStyleBackColor = true;
            ApplicationToOpenFilesButton.Click += ApplicationToOpenFilesButton_Click;
            // 
            // ApplicationToOpenFilesTextBox
            // 
            ApplicationToOpenFilesTextBox.Location = new Point(178, 216);
            ApplicationToOpenFilesTextBox.Name = "ApplicationToOpenFilesTextBox";
            ApplicationToOpenFilesTextBox.Size = new Size(298, 23);
            ApplicationToOpenFilesTextBox.TabIndex = 21;
            ApplicationToOpenFilesTextBox.TextChanged += ApplicationToOpenFilesTexTBox_TextChanged;
            // 
            // ApplicationToOpenFilesLabel
            // 
            ApplicationToOpenFilesLabel.AutoSize = true;
            ApplicationToOpenFilesLabel.Location = new Point(18, 221);
            ApplicationToOpenFilesLabel.Name = "ApplicationToOpenFilesLabel";
            ApplicationToOpenFilesLabel.Size = new Size(135, 15);
            ApplicationToOpenFilesLabel.TabIndex = 20;
            ApplicationToOpenFilesLabel.Text = "ApplicationToOpenFiles:";
            // 
            // SubmitButtonStatusLabel
            // 
            SubmitButtonStatusLabel.AutoSize = true;
            SubmitButtonStatusLabel.Font = new Font("Algerian", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            SubmitButtonStatusLabel.Location = new Point(281, 245);
            SubmitButtonStatusLabel.Name = "SubmitButtonStatusLabel";
            SubmitButtonStatusLabel.Size = new Size(80, 21);
            SubmitButtonStatusLabel.TabIndex = 19;
            SubmitButtonStatusLabel.Text = "Status";
            SubmitButtonStatusLabel.Visible = false;
            // 
            // SettingsFolderButton
            // 
            SettingsFolderButton.Location = new Point(3, 269);
            SettingsFolderButton.Name = "SettingsFolderButton";
            SettingsFolderButton.Size = new Size(75, 23);
            SettingsFolderButton.TabIndex = 18;
            SettingsFolderButton.Text = "Folder";
            SettingsFolderButton.UseVisualStyleBackColor = true;
            SettingsFolderButton.Click += SettingsFolderButton_Click;
            // 
            // SettingsFileButton
            // 
            SettingsFileButton.Location = new Point(555, 269);
            SettingsFileButton.Name = "SettingsFileButton";
            SettingsFileButton.Size = new Size(75, 23);
            SettingsFileButton.TabIndex = 17;
            SettingsFileButton.Text = "SettingsFile";
            SettingsFileButton.UseVisualStyleBackColor = true;
            SettingsFileButton.Click += SettingsFileButton_Click;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(281, 269);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 16;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // SoundPathSecondButton
            // 
            SoundPathSecondButton.Location = new Point(482, 174);
            SoundPathSecondButton.Name = "SoundPathSecondButton";
            SoundPathSecondButton.Size = new Size(31, 23);
            SoundPathSecondButton.TabIndex = 15;
            SoundPathSecondButton.Text = "...";
            SoundPathSecondButton.UseVisualStyleBackColor = true;
            SoundPathSecondButton.Click += SoundPathSecondButton_Click;
            // 
            // SoundPathSecondTextBox
            // 
            SoundPathSecondTextBox.Location = new Point(178, 174);
            SoundPathSecondTextBox.Name = "SoundPathSecondTextBox";
            SoundPathSecondTextBox.Size = new Size(298, 23);
            SoundPathSecondTextBox.TabIndex = 14;
            SoundPathSecondTextBox.TextChanged += SoundPathSecondTextBox_TextChanged;
            // 
            // SoundPathSecondLabel
            // 
            SoundPathSecondLabel.AutoSize = true;
            SoundPathSecondLabel.Location = new Point(18, 179);
            SoundPathSecondLabel.Name = "SoundPathSecondLabel";
            SoundPathSecondLabel.Size = new Size(107, 15);
            SoundPathSecondLabel.TabIndex = 13;
            SoundPathSecondLabel.Text = "SoundPathSecond:";
            // 
            // SoundPathFirstTextBox
            // 
            SoundPathFirstTextBox.Location = new Point(178, 134);
            SoundPathFirstTextBox.Name = "SoundPathFirstTextBox";
            SoundPathFirstTextBox.Size = new Size(298, 23);
            SoundPathFirstTextBox.TabIndex = 12;
            SoundPathFirstTextBox.TextChanged += SoundPathFirstTextBox_TextChanged;
            // 
            // SoundPathFirstButton
            // 
            SoundPathFirstButton.Location = new Point(482, 134);
            SoundPathFirstButton.Name = "SoundPathFirstButton";
            SoundPathFirstButton.Size = new Size(31, 23);
            SoundPathFirstButton.TabIndex = 11;
            SoundPathFirstButton.Text = "...";
            SoundPathFirstButton.UseVisualStyleBackColor = true;
            SoundPathFirstButton.Click += SoundPathFirstButton_Click;
            // 
            // SoundPathFirstLabel
            // 
            SoundPathFirstLabel.AutoSize = true;
            SoundPathFirstLabel.Location = new Point(18, 140);
            SoundPathFirstLabel.Name = "SoundPathFirstLabel";
            SoundPathFirstLabel.Size = new Size(90, 15);
            SoundPathFirstLabel.TabIndex = 10;
            SoundPathFirstLabel.Text = "SoundPathFirst:";
            // 
            // RadioButtonChoiceComboBox
            // 
            RadioButtonChoiceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RadioButtonChoiceComboBox.FormattingEnabled = true;
            RadioButtonChoiceComboBox.Items.AddRange(new object[] { "RadioButton1", "RadioButton2", "NoneButton" });
            RadioButtonChoiceComboBox.Location = new Point(178, 54);
            RadioButtonChoiceComboBox.Name = "RadioButtonChoiceComboBox";
            RadioButtonChoiceComboBox.Size = new Size(104, 23);
            RadioButtonChoiceComboBox.TabIndex = 9;
            RadioButtonChoiceComboBox.SelectedIndexChanged += RadioButtonChoiceComboBox_SelectedIndexChanged;
            // 
            // IsButtonClickedOnLaunchComboBox
            // 
            IsButtonClickedOnLaunchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            IsButtonClickedOnLaunchComboBox.FormattingEnabled = true;
            IsButtonClickedOnLaunchComboBox.Items.AddRange(new object[] { "true", "false" });
            IsButtonClickedOnLaunchComboBox.Location = new Point(178, 95);
            IsButtonClickedOnLaunchComboBox.Name = "IsButtonClickedOnLaunchComboBox";
            IsButtonClickedOnLaunchComboBox.Size = new Size(62, 23);
            IsButtonClickedOnLaunchComboBox.TabIndex = 8;
            IsButtonClickedOnLaunchComboBox.SelectedIndexChanged += IsButtonClickedOnLaunchComboBox_SelectedIndexChanged;
            // 
            // IsButtonClickedOnLaunchLabel
            // 
            IsButtonClickedOnLaunchLabel.AutoSize = true;
            IsButtonClickedOnLaunchLabel.Location = new Point(18, 99);
            IsButtonClickedOnLaunchLabel.Name = "IsButtonClickedOnLaunchLabel";
            IsButtonClickedOnLaunchLabel.Size = new Size(148, 15);
            IsButtonClickedOnLaunchLabel.TabIndex = 6;
            IsButtonClickedOnLaunchLabel.Text = "IsButtonClickedOnLaunch:";
            // 
            // RadioButtonChoiceLabel
            // 
            RadioButtonChoiceLabel.AutoSize = true;
            RadioButtonChoiceLabel.Location = new Point(16, 59);
            RadioButtonChoiceLabel.Name = "RadioButtonChoiceLabel";
            RadioButtonChoiceLabel.Size = new Size(113, 15);
            RadioButtonChoiceLabel.TabIndex = 2;
            RadioButtonChoiceLabel.Text = "RadioButtonChoice:";
            // 
            // UrlPrefixTextBox
            // 
            UrlPrefixTextBox.Location = new Point(178, 12);
            UrlPrefixTextBox.Name = "UrlPrefixTextBox";
            UrlPrefixTextBox.Size = new Size(298, 23);
            UrlPrefixTextBox.TabIndex = 1;
            UrlPrefixTextBox.TextChanged += UrlPrefixTextBox_TextChanged;
            // 
            // UrlPrefixLabel
            // 
            UrlPrefixLabel.AutoSize = true;
            UrlPrefixLabel.Location = new Point(18, 18);
            UrlPrefixLabel.Name = "UrlPrefixLabel";
            UrlPrefixLabel.Size = new Size(55, 15);
            UrlPrefixLabel.TabIndex = 0;
            UrlPrefixLabel.Text = "UrlPrefix:";
            // 
            // LogsTab
            // 
            LogsTab.Controls.Add(LogsFolderButton);
            LogsTab.Controls.Add(LogsFileButton);
            LogsTab.Controls.Add(ClearLogsButton);
            LogsTab.Controls.Add(LogsTextBox);
            LogsTab.Location = new Point(4, 24);
            LogsTab.Name = "LogsTab";
            LogsTab.Padding = new Padding(3);
            LogsTab.Size = new Size(633, 292);
            LogsTab.TabIndex = 2;
            LogsTab.Text = "Logs";
            LogsTab.UseVisualStyleBackColor = true;
            LogsTab.Enter += LogsTab_Enter;
            // 
            // LogsFolderButton
            // 
            LogsFolderButton.Location = new Point(3, 269);
            LogsFolderButton.Name = "LogsFolderButton";
            LogsFolderButton.Size = new Size(75, 23);
            LogsFolderButton.TabIndex = 3;
            LogsFolderButton.Text = "Folder";
            LogsFolderButton.UseVisualStyleBackColor = true;
            LogsFolderButton.Click += LogsFolderButton_Click;
            // 
            // LogsFileButton
            // 
            LogsFileButton.Location = new Point(555, 269);
            LogsFileButton.Name = "LogsFileButton";
            LogsFileButton.Size = new Size(75, 23);
            LogsFileButton.TabIndex = 2;
            LogsFileButton.Text = "LogFile";
            LogsFileButton.UseVisualStyleBackColor = true;
            LogsFileButton.Click += LogsFileButton_Click;
            // 
            // ClearLogsButton
            // 
            ClearLogsButton.Location = new Point(281, 269);
            ClearLogsButton.Name = "ClearLogsButton";
            ClearLogsButton.Size = new Size(75, 23);
            ClearLogsButton.TabIndex = 1;
            ClearLogsButton.Text = "Clear logs";
            ClearLogsButton.UseVisualStyleBackColor = true;
            ClearLogsButton.Click += ClearLogsButton_Click;
            // 
            // LogsTextBox
            // 
            LogsTextBox.Location = new Point(-4, 0);
            LogsTextBox.Multiline = true;
            LogsTextBox.Name = "LogsTextBox";
            LogsTextBox.ReadOnly = true;
            LogsTextBox.ScrollBars = ScrollBars.Vertical;
            LogsTextBox.Size = new Size(641, 265);
            LogsTextBox.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 321);
            Controls.Add(TabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QcommentUrlCutter by moleNULL";
            TabControl.ResumeLayout(false);
            ApplicationTab.ResumeLayout(false);
            ApplicationTab.PerformLayout();
            SettingsTab.ResumeLayout(false);
            SettingsTab.PerformLayout();
            LogsTab.ResumeLayout(false);
            LogsTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonStart;
        private Button ButtonStop;
        private TextBox clipboardTextBox;
        private RadioButton RadioButton1;
        private RadioButton RadioButton2;
        private RadioButton NoneButton;
        private Label SoundsLabel;
        private TabControl TabControl;
        private TabPage ApplicationTab;
        private TabPage SettingsTab;
        private TabPage LogsTab;
        private Label UrlPrefixLabel;
        private TextBox UrlPrefixTextBox;
        private Label RadioButtonChoiceLabel;
        private ComboBox IsButtonClickedOnLaunchComboBox;
        private Label IsButtonClickedOnLaunchLabel;
        private ComboBox RadioButtonChoiceComboBox;
        private Label SoundPathFirstLabel;
        private TextBox SoundPathFirstTextBox;
        private Button SoundPathFirstButton;
        private Label SoundPathSecondLabel;
        private Button SubmitButton;
        private Button SoundPathSecondButton;
        private TextBox SoundPathSecondTextBox;
        private TextBox LogsTextBox;
        private Button ClearLogsButton;
        private Button LogsFileButton;
        private Button LogsFolderButton;
        private Button SettingsFolderButton;
        private Button SettingsFileButton;
        private Button ApplicationFolderButton;
        private Label SubmitButtonStatusLabel;
        private Button ApplicationToOpenFilesButton;
        private TextBox ApplicationToOpenFilesTextBox;
        private Label ApplicationToOpenFilesLabel;
    }
}