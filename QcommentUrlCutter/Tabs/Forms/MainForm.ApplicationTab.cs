using System.Diagnostics;
using QcommentUrlCutter.Core;
using QcommentUrlCutter.Helpers;
using QcommentUrlCutter.Models;
using QcommentUrlCutter.Tabs.TabHelpers;

namespace QcommentUrlCutter
{
#pragma warning disable SA1205
    partial class MainForm
#pragma warning restore SA1205
    {
        private void ApplicationTab_Enter(object sender, EventArgs e)
        {
            try
            {
                FileHelper.RecreateFileTextIfNotExists(Constants.AppsettingsJsonFile, _logger);
                FileHelper.RecreateFileTextIfNotExists(Constants.LogFile, _logger);

                _appsettings = SettingsHelper.GetApplicationSettings(_logger);

                _applicationTabHelper = new ApplicationTabHelper()
                {
                    RadioButton1 = RadioButton1,
                    RadioButton2 = RadioButton2,
                    NoneButton = NoneButton,
                    ApplicationSettings = _appsettings,
                    ApplicationState = _state
                };

                _applicationTabHelper.AssingRadioButtonSoundNames();
                _applicationTabHelper.CheckRadioButton(_appsettings.RadioButtonChoice);

                if (_appsettings.IsButtonClickedOnLaunch)
                {
                    ButtonStart_ClickAsync(this, EventArgs.Empty);
                }
                else
                {
                    ButtonStop_Click(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(
                    _applicationTitle, nameof(ApplicationTab_Enter), ex, _logger, exitApplication: true);
            }
        }

        private async void ButtonStart_ClickAsync(object sender, EventArgs e)
        {
            _state.MustRun = true;
            ButtonStart.Enabled = false;
            ButtonStop.Enabled = true;

            try
            {
                var qCutter = new QcommentCutter(
                    _state, clipboardTextBox, _logger, _applicationTabHelper.CheckNoneButton);
                await qCutter.RunAsync();
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(
                    _applicationTitle, nameof(ButtonStart_ClickAsync), ex, _logger, exitApplication: true);
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            _state.MustRun = false;

            ButtonStart.Enabled = true;
            ButtonStop.Enabled = false;
        }

        private void ApplicationFolderButton_Click(object sender, EventArgs e)
        {
            string filePath = ApplicationState.CurrentDirectory
                + "\\" + AppDomain.CurrentDomain.FriendlyName + ".exe";
            string argument = $"/select, {filePath}";

            Process.Start(Constants.ApplicationToOpenFolderDefault, argument);
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                if (!_applicationTabHelper.IsAppliedNoneButtonIfSoundMissing(RadioButton1))
                {
                    _state.SoundFile = _appsettings.SoundPathFirst;
                }

                SettingsHelper.SaveRadioButtonChoiceToFile(_appsettings, RadioButton1.Name);
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked)
            {
                if (!_applicationTabHelper.IsAppliedNoneButtonIfSoundMissing(RadioButton2))
                {
                    _state.SoundFile = _appsettings.SoundPathSecond;
                }

                SettingsHelper.SaveRadioButtonChoiceToFile(_appsettings, RadioButton2.Name);
            }
        }

        private void NoneButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NoneButton.Checked)
            {
                _state.SoundFile = null;
                SettingsHelper.SaveRadioButtonChoiceToFile(_appsettings, NoneButton.Name);
            }
        }
    }
}