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

                if (_appsettings.IsStartButtonClickedOnLaunch)
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
                _appsettings.IsStartButtonClickedOnLaunch = true;
                SettingsHelper.SaveApplicationSettings(Constants.AppsettingsJsonFile, _appsettings);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(
                    _applicationTitle, nameof(ButtonStart_ClickAsync), ex, _logger, exitApplication: false);
            }

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

            try
            {
                _appsettings.IsStartButtonClickedOnLaunch = false;
                SettingsHelper.SaveApplicationSettings(Constants.AppsettingsJsonFile, _appsettings);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(
                    _applicationTitle, nameof(ButtonStop_Click), ex, _logger, exitApplication: false);
            }
        }

        private void ApplicationFolderButton_Click(object sender, EventArgs e)
        {
            string filePath = ApplicationState.CurrentDirectory
                + "\\" + AppDomain.CurrentDomain.FriendlyName + ".exe";
            string argument = $"/select, ";

            try
            {
                RunFileHelper.RunFile(_logger, Constants.ApplicationToOpenFolderDefault, filePath, argument);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(
                    _applicationTitle, nameof(ApplicationFolderButton_Click), ex, _logger, exitApplication: false);
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                if (!_applicationTabHelper.IsAppliedNoneButtonIfSoundMissing(RadioButton1))
                {
                    _state.SoundFile = _appsettings.SoundPathFirst;
                }

                try
                {
                    SettingsHelper.SaveRadioButtonChoiceToFile(_appsettings, RadioButton1.Name);
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException(
                        _applicationTitle, nameof(RadioButton1_CheckedChanged), ex, _logger, exitApplication: false);
                }
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

                try
                {
                    SettingsHelper.SaveRadioButtonChoiceToFile(_appsettings, RadioButton2.Name);
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException(
                        _applicationTitle, nameof(RadioButton2_CheckedChanged), ex, _logger, exitApplication: false);
                }
            }
        }

        private void NoneButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NoneButton.Checked)
            {
                _state.SoundFile = null;

                try
                {
                    SettingsHelper.SaveRadioButtonChoiceToFile(_appsettings, NoneButton.Name);
                }
                catch (Exception ex)
                {
                    ExceptionHelper.HandleException(
                        _applicationTitle, nameof(NoneButton_CheckedChanged), ex, _logger, exitApplication: false);
                }
            }
        }
    }
}