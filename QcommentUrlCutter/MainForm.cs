using QcommentUrlCutter.Helpers;
using QcommentUrlCutter.Logger;
using QcommentUrlCutter.Models;

namespace QcommentUrlCutter
{
    public partial class MainForm : Form
    {
        private readonly ApplicationState _state;
        private readonly ApplicationSettings _appsettings = null!;
        private readonly ILogger _logger;
        private readonly string _applicationTitle = null!;
        public MainForm()
        {
            InitializeComponent();

            _logger = new FileLogger();
            _state = new ApplicationState();

            try
            {
                _applicationTitle = Text + ApplicationHelper.GetApplicationFileVersion();
                Text = _applicationTitle;

                FileHelper.RecreateAppsettingsIfNotExists(_logger);
                FileHelper.RecreateSoundsIfNotExist(_logger);
                _appsettings = SettingsHelper.GetApplicationSettings();

                AssingRadioButtonFileNames();
                EnableRadioButton(_appsettings.RadioButtonChoice);

                if (_appsettings.IsButtonClickedOnLaunch)
                {
                    ButtonStart_Click(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                ProcessException(nameof(MainForm), ex.Message);
            }
        }

        private async void ButtonStart_Click(object sender, EventArgs e)
        {
            _state.MustRun = true;
            ButtonStart.Enabled = false;
            ButtonStop.Enabled = true;

            try
            {
                var qCutter = new QcommentCutter(_state, clipboardTextBox, _logger, EnableNoneButton);
                await qCutter.Run();
            }
            catch (Exception ex)
            {
                ProcessException(nameof(ButtonStart_Click), ex.Message);
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            _state.MustRun = false;
            _state.CountOutput--; // when switching between Start/Stop the CountOutput won't be incremented

            ButtonStart.Enabled = true;
            ButtonStop.Enabled = false;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                if (!IsAppliedNoneButtonIfSoundMissing(RadioButton1))
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
                if (!IsAppliedNoneButtonIfSoundMissing(RadioButton2))
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

        private void ProcessException(string methodName, string exceptionMessage)
        {
            MessageBox.Show(
                exceptionMessage,
                $"{_applicationTitle} | {methodName} Exception",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            _logger.Log($"{methodName} Exception: {exceptionMessage}");

            Environment.Exit(0);
        }

        private void AssingRadioButtonFileNames()
        {
            RadioButton1.Text = GetSoundName(_appsettings.SoundPathFirst);
            RadioButton2.Text = GetSoundName(_appsettings.SoundPathSecond);
        }

        private void EnableRadioButton(string? radioButtonName)
        {
            if (radioButtonName == Constants.RadioButton1Name)
            {
                if (!IsAppliedNoneButtonIfSoundMissing(RadioButton1))
                {
                    RadioButton1.Checked = true;
                    _state.SoundFile = _appsettings.SoundPathFirst;
                }
            }
            else if (radioButtonName == Constants.RadioButton2Name)
            {
                if (!IsAppliedNoneButtonIfSoundMissing(RadioButton2))
                {
                    RadioButton2.Checked = true;
                    _state.SoundFile = _appsettings.SoundPathSecond;
                }
            }
            else
            {
                EnableNoneButton();
            }
        }

        private bool IsAppliedNoneButtonIfSoundMissing(RadioButton radioButton)
        {
            if (radioButton.Text == "?")
            {
                EnableNoneButton();

                return true;
            }

            return false;
        }

        private void EnableNoneButton()
        {
            NoneButton.Checked = true;
            _state.SoundFile = null;
        }

        private string GetSoundName(string? soundPath)
        {
            string? soundName = Path.GetFileName(soundPath);
            if (string.IsNullOrWhiteSpace(soundName) || soundName.Length < Constants.MinSoundNameLength)
            {
                return "?";
            }

            if (soundName.Length < Constants.MaxSoundNameLength)
            {
                return soundName;
            }
            else
            {
                string soundNameWithoutExtension = Path.GetFileNameWithoutExtension(soundName);

                return soundNameWithoutExtension[..Constants.MaxSoundNameWithoutExtension]
                    + ".." + Path.GetExtension(soundName);
            }
        }
    }
}

/*
    TODO:
1. Apply SOLID principles to the MainForm

v3.0
    -settings: different form to change appsettings through it
    -settings: ability to choose any *.wav file on disk
 */