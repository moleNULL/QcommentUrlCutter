using System.Media;
using System.Reflection;

namespace QcommentUrlCutter.Logic
{
    public class QcommentCutter
    {
        private const string SoundDogBarking = "dog_barking.wav";
        private const string SoundFemaleGasp = "female_gasp.wav";
        private const int ClipboardCheckIntervalInMs = 500;

        private readonly string _prefix;
        private readonly TextBox _clipboardTextBox;
        private readonly ApplicationState _state;

        public QcommentCutter(ApplicationState state, TextBox clipboardTextBox)
        {
            _prefix = "https://qcomment.ru/site/go?url=";

            _state = state;
            _clipboardTextBox = clipboardTextBox;
        }

        public async Task Run()
        {
            string oldClipboardData = string.Empty;

            while (_state.MustRun)
            {
                if (Clipboard.ContainsText())
                {
                    string clipboardData = Clipboard.GetText();

                    if (!string.Equals(clipboardData, oldClipboardData))
                    {
                        if (clipboardData.StartsWith(_prefix))
                        {
                            string encodedUrl = clipboardData[_prefix.Length..];
                            string decodedUrl = Uri.UnescapeDataString(encodedUrl);

                            Clipboard.SetText(decodedUrl);

                            PlaySound(SoundDogBarking);
                            PrintQcommentText($"{++_state.CountOutput}. Qcomment: {encodedUrl} -> {decodedUrl}");
                        }
                        else
                        {
                            PrintClipboardText($"{++_state.CountOutput}. Clipboard: {clipboardData}");
                        }

                        oldClipboardData = clipboardData;
                    }
                }

                await Task.Delay(ClipboardCheckIntervalInMs);
            }
        }

        private void PlaySound(string fileName)
        {
            using (Stream? stream = Assembly.GetExecutingAssembly()
                                .GetManifestResourceStream($"QcommentUrlCutter.Files.{fileName}"))
            {
                if (stream is not null)
                {
                    var player = new SoundPlayer(stream);
                    player.Play();
                }
            }
        }

        private void PrintQcommentText(string text)
        {
            _clipboardTextBox.AppendText(Environment.NewLine);

            _clipboardTextBox.AppendText(text);

            _clipboardTextBox.AppendText(Environment.NewLine);
            _clipboardTextBox.AppendText(Environment.NewLine);
        }

        private void PrintClipboardText(string text)
        {
            _clipboardTextBox.AppendText(text);

            _clipboardTextBox.AppendText(Environment.NewLine);
        }
    }
}
