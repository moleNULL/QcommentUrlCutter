using QcommentUrlCutter.Models;

namespace QcommentUrlCutter.Tabs.Helpers
{
    public class SettingsTabHelper
    {
        public OpenFileDialog GetOpenFileDialog()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "WAV Files (*.wav)|*.wav",
                Title = "Select a WAV file",
                InitialDirectory = ApplicationState.CurrentDirectory
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
    }
}
