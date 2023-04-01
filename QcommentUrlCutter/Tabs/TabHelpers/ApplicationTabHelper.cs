using QcommentUrlCutter.Models;

namespace QcommentUrlCutter.Tabs.TabHelpers
{
    public class ApplicationTabHelper
    {
        public RadioButton RadioButton1 { get; set; } = null!;
        public RadioButton RadioButton2 { get; set; } = null!;
        public RadioButton NoneButton { get; set; } = null!;
        public ApplicationSettings ApplicationSettings { get; set; } = null!;
        public ApplicationState ApplicationState { get; set; } = null!;

        public void AssingRadioButtonSoundNames()
        {
            RadioButton1.Text = GetSoundName(ApplicationSettings.SoundPathFirst);
            RadioButton2.Text = GetSoundName(ApplicationSettings.SoundPathSecond);
        }

        public void CheckRadioButton(string? radioButtonName)
        {
            if (radioButtonName == Constants.RadioButton1Name)
            {
                if (!IsAppliedNoneButtonIfSoundMissing(RadioButton1))
                {
                    RadioButton1.Checked = true;
                    ApplicationState.SoundFile = ApplicationSettings.SoundPathFirst;
                }
            }
            else if (radioButtonName == Constants.RadioButton2Name)
            {
                if (!IsAppliedNoneButtonIfSoundMissing(RadioButton2))
                {
                    RadioButton2.Checked = true;
                    ApplicationState.SoundFile = ApplicationSettings.SoundPathSecond;
                }
            }
            else
            {
                CheckNoneButton();
            }
        }

        public bool IsAppliedNoneButtonIfSoundMissing(RadioButton radioButton)
        {
            if (radioButton.Text == "?")
            {
                CheckNoneButton();

                return true;
            }

            return false;
        }

        public void CheckNoneButton()
        {
            NoneButton.Checked = true;
            ApplicationState.SoundFile = null;
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
