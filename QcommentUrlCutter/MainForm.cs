using QcommentUrlCutter.Logger;
using QcommentUrlCutter.Logic;
using QcommentUrlCutter.Models;

namespace QcommentUrlCutter
{
    public partial class MainForm : Form
    {
        private const string RadioButton1Name = "RadioButton1";
        private const string RadioButton2Name = "RadioButton2";

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
                _applicationTitle = Text + Helpers.GetAppFileVersion();
                Text = _applicationTitle;

                _appsettings = Helpers.GetApplicationSettings();

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

                Helpers.SaveRadioButtonChoiceToFile(_appsettings, RadioButton1.Name);
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

                Helpers.SaveRadioButtonChoiceToFile(_appsettings, RadioButton2.Name);
            }
        }

        private void NoneButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NoneButton.Checked)
            {
                _state.SoundFile = null;
                Helpers.SaveRadioButtonChoiceToFile(_appsettings, NoneButton.Name);
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
            string? sound1 = Path.GetFileName(_appsettings.SoundPathFirst);
            if (string.IsNullOrWhiteSpace(sound1))
            {
                RadioButton1.Text = "?";
            }
            else
            {
                RadioButton1.Text = sound1;
            }

            string? sound2 = Path.GetFileName(_appsettings.SoundPathSecond);
            if (string.IsNullOrWhiteSpace(sound2))
            {
                RadioButton2.Text = "?";
            }
            else
            {
                RadioButton2.Text = sound2;
            }
        }

        private void EnableRadioButton(string? radioButtonName)
        {
            if (radioButtonName == RadioButton1Name)
            {
                if (!IsAppliedNoneButtonIfSoundMissing(RadioButton1))
                {
                    RadioButton1.Checked = true;
                    _state.SoundFile = _appsettings.SoundPathFirst;
                }
            }
            else if (radioButtonName == RadioButton2Name)
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
    }
}

/*
    TODO:
1. count when stop/start -> need count to be fixed
2. check if Files/*.wav exist and if not - recreate them

v3.0
    -settings: different form to change appsettings through it
    -settings: ability to choose any *.wav file on disk
 */