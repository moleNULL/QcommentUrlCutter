using QcommentUrlCutter.Helpers;
using QcommentUrlCutter.Models;
using QcommentUrlCutter.Tabs.TabHelpers;

namespace QcommentUrlCutter
{
#pragma warning disable SA1205
    partial class MainForm
#pragma warning restore SA1205
    {
        private void SettingsTab_Enter(object? sender, EventArgs e)
        {
            _settingsTabHelper = new SettingsTabHelper(SubmitButton, SubmitButtonStatusLabel);
            _appsettings = SettingsHelper.GetApplicationSettings(_logger);

            UrlPrefixTextBox.Text = _appsettings.UrlPrefix;
            RadioButtonChoiceComboBox.Text = _appsettings.RadioButtonChoice;
            IsButtonClickedOnLaunchComboBox.Text = _appsettings.IsButtonClickedOnLaunch.ToString();

            SoundPathFirstTextBox.Text = _appsettings.SoundPathFirst;
            SoundPathSecondTextBox.Text = _appsettings.SoundPathSecond;

            ApplicationToOpenFilesTextBox.Text = _appsettings.ApplicationToOpenFiles;

            SubmitButton.Enabled = false;
            SubmitButtonStatusLabel.Visible = false;
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

            FileHelper.RecreateFileTextIfNotExists(Constants.AppsettingsJsonFile, _logger);

            try
            {
                SettingsHelper.SaveApplicationSettings(Constants.AppsettingsJsonFile, userSettings);
                _logger.Log($"Edited {Constants.AppsettingsJsonFile} inside Settings tab");
                SettingsTab_Enter(this, EventArgs.Empty);

                SoundHelper.PlaySuccessSound();

                _settingsTabHelper.ShowSubmitButtonStatus(isButtonEnabled: false, "Success", Color.Green);
            }
            catch (Exception ex)
            {
                _logger.Log($"Exception while saving settings to {Constants.AppsettingsJsonFile} inside" +
                    $" Settings tab: {ex.Message}");
                SettingsTab_Enter(this, EventArgs.Empty);

                SoundHelper.PlayExceptionSound();

                _settingsTabHelper.ShowSubmitButtonStatus(isButtonEnabled: true, "Failure", Color.Red);
            }
        }

        private void SoundPathFirstButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = _settingsTabHelper.GetOpenFileDialogWav();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            SoundPathFirstTextBox.Text = _settingsTabHelper.GetSoundFileName(openFileDialog);
        }

        private void SoundPathSecondButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = _settingsTabHelper.GetOpenFileDialogWav();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            SoundPathSecondTextBox.Text = _settingsTabHelper.GetSoundFileName(openFileDialog);
        }

        private void ApplicationToOpenFilesButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = _settingsTabHelper.GetOpenFileDialogExe();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            ApplicationToOpenFilesTextBox.Text = openFileDialog.FileName;
        }

        private void UrlPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            _settingsTabHelper.ToggleButtonEnabledAndHideLabel(UrlPrefixTextBox.Text != _appsettings.UrlPrefix);
        }

        private void RadioButtonChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settingsTabHelper.ToggleButtonEnabledAndHideLabel(
                RadioButtonChoiceComboBox.Text != _appsettings.RadioButtonChoice);
        }

        private void IsButtonClickedOnLaunchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settingsTabHelper.ToggleButtonEnabledAndHideLabel(
                IsButtonClickedOnLaunchComboBox.Text != _appsettings.IsButtonClickedOnLaunch.ToString().ToLower());
        }

        private void SoundPathFirstTextBox_TextChanged(object sender, EventArgs e)
        {
            _settingsTabHelper.ToggleButtonEnabledAndHideLabel(
                SoundPathFirstTextBox.Text != _appsettings.SoundPathFirst);
        }

        private void SoundPathSecondTextBox_TextChanged(object sender, EventArgs e)
        {
            _settingsTabHelper.ToggleButtonEnabledAndHideLabel(
                SoundPathSecondTextBox.Text != _appsettings.SoundPathSecond);
        }

        private void ApplicationToOpenFilesTexTBox_TextChanged(object sender, EventArgs e)
        {
            _settingsTabHelper.ToggleButtonEnabledAndHideLabel(
                ApplicationToOpenFilesTextBox.Text != _appsettings.ApplicationToOpenFiles);
        }

        private void SettingsFolderButton_Click(object sender, EventArgs e)
        {
            string filePath = ApplicationState.CurrentDirectory + "\\" + Constants.AppsettingsJsonFile;
            string argument = $"/select, {filePath}";

            RunFileHelper.RunFile(Constants.ApplicationToOpenFolderDefault, argument, _logger);
        }

        private void SettingsFileButton_Click(object sender, EventArgs e)
        {
            RunFileHelper.RunFile(_appsettings.ApplicationToOpenFiles, Constants.AppsettingsJsonFile, _logger);
        }
    }
}
