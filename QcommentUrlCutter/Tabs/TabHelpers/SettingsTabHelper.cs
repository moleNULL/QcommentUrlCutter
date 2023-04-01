using QcommentUrlCutter.Models;

namespace QcommentUrlCutter.Tabs.TabHelpers
{
    public class SettingsTabHelper
    {
        private readonly Button _submitButton;
        private readonly Label _submitButtonStatusLabel;

        public SettingsTabHelper(Button submitButton, Label submitButtonStatusLabel)
        {
            _submitButton = submitButton;
            _submitButtonStatusLabel = submitButtonStatusLabel;
        }

        public OpenFileDialog GetOpenFileDialogWav()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "WAV Files (*.wav)|*.wav",
                Title = "Select a WAV file",
                InitialDirectory = ApplicationState.CurrentDirectory
            };

            return openFileDialog;
        }

        public OpenFileDialog GetOpenFileDialogExe()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "EXE Files (*.exe)|*,exe",
                Title = "Select application to open text files",
                InitialDirectory = Path.GetPathRoot(Environment.SystemDirectory) // C:\
            };

            return openFileDialog;
        }

        public string GetSoundFileName(OpenFileDialog openFileDialog)
        {
            string fileName = openFileDialog.FileName;
            if (fileName.Contains(ApplicationState.CurrentDirectory))
            {
                fileName = fileName[(ApplicationState.CurrentDirectory.Length + 1) ..];
            }

            return fileName;
        }

        public void ToggleButtonEnabledAndHideLabel(bool isChanged)
        {
            _submitButton.Enabled = isChanged;
            _submitButtonStatusLabel.Visible = false;
        }

        public void ShowSubmitButtonStatus(bool isButtonEnabled, string status, Color color)
        {
            _submitButton.Enabled = isButtonEnabled;
            _submitButtonStatusLabel.Text = status;
            _submitButtonStatusLabel.ForeColor = color;

            _submitButtonStatusLabel.Visible = true;
        }
    }
}
