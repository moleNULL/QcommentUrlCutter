using System.Diagnostics;
using QcommentUrlCutter.Helpers;
using QcommentUrlCutter.Models;
using QcommentUrlCutter.Tabs.Helpers;

namespace QcommentUrlCutter
{
#pragma warning disable SA1205
    partial class MainForm
#pragma warning restore SA1205
    {
        private void SettingsTab_Enter(object sender, EventArgs e)
        {
            _settingsTabHelper = new SettingsTabHelper();
            var currentSettings = SettingsHelper.GetApplicationSettings();

            UrlPrefixTextBox.Text = currentSettings.UrlPrefix;
            RadioButtonChoiceComboBox.Text = currentSettings.RadioButtonChoice;
            IsButtonClickedOnLaunchComboBox.Text = currentSettings.IsButtonClickedOnLaunch.ToString();

            SoundPathFirstTextBox.Text = currentSettings.SoundPathFirst;
            SoundPathSecondTextBox.Text = currentSettings.SoundPathSecond;

            SubmitButton.Enabled = false;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var userSettings = new ApplicationSettings()
            {
                UrlPrefix = UrlPrefixTextBox.Text,
                RadioButtonChoice = RadioButtonChoiceComboBox.Text,
                IsButtonClickedOnLaunch = Convert.ToBoolean(IsButtonClickedOnLaunchComboBox.Text),

                SoundPathFirst = SoundPathFirstTextBox.Text,
                SoundPathSecond = SoundPathSecondTextBox.Text
            };

            SettingsHelper.SaveApplicationSettings(Constants.AppsettingsJsonFile, userSettings);
            _logger.Log($"Edited {Constants.AppsettingsJsonFile} inside Settings tab");

            SubmitButton.Enabled = false;
            SubmitButtonStatusLabel.Text = "Success";
            SubmitButtonStatusLabel.ForeColor = Color.Green;
            SubmitButtonStatusLabel.Visible = true;
        }

        private void SoundPathFirstButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = _settingsTabHelper.GetOpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            SoundPathFirstTextBox.Text = _settingsTabHelper.GetSoundFileName(openFileDialog);
        }

        private void SoundPathSecondButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = _settingsTabHelper.GetOpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            SoundPathSecondTextBox.Text = _settingsTabHelper.GetSoundFileName(openFileDialog);
        }

        private void UrlPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            SubmitButton.Enabled = UrlPrefixTextBox.Text != _appsettings.UrlPrefix;
        }

        private void RadioButtonChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubmitButton.Enabled = RadioButtonChoiceComboBox.Text != _appsettings.RadioButtonChoice;
        }

        private void IsButtonClickedOnLaunchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubmitButton.Enabled =
                IsButtonClickedOnLaunchComboBox.Text != _appsettings.IsButtonClickedOnLaunch.ToString().ToLower();
        }

        private void SoundPathFirstTextBox_TextChanged(object sender, EventArgs e)
        {
            SubmitButton.Enabled = SoundPathFirstTextBox.Text != _appsettings.SoundPathFirst;
        }

        private void SettingsFolderButton_Click(object sender, EventArgs e)
        {
            string filePath = ApplicationState.CurrentDirectory + "\\" + Constants.AppsettingsJsonFile;
            string argument = $"/select, {filePath}";

            Process.Start("explorer.exe", argument);
        }

        private void SettingsFileButton_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", Constants.AppsettingsJsonFile);
        }
    }
}
