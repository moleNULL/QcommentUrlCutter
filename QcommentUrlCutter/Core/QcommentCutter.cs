using System.Media;
using QcommentUrlCutter.Helpers;
using QcommentUrlCutter.Logger;
using QcommentUrlCutter.Models;

namespace QcommentUrlCutter.Core
{
    public class QcommentCutter
    {
        private readonly TextBox _clipboardTextBox;
        private readonly ApplicationState _state;
        private readonly ApplicationSettings _appsettings;
        private readonly ILogger _logger;
        private readonly Action _enableNoneButton;

        public QcommentCutter(
            ApplicationState state, TextBox clipboardTextBox, ILogger logger, Action enableNoneButton)
        {
            _appsettings = SettingsHelper.GetApplicationSettings();

            _state = state;
            _clipboardTextBox = clipboardTextBox;
            _logger = logger;
            _enableNoneButton = enableNoneButton;
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
                        if (clipboardData.StartsWith(_appsettings.UrlPrefix))
                        {
                            PerformUrlCut(clipboardData);
                        }
                        else
                        {
                            PrintText($"{++_state.CountOutput}. {clipboardData}", Constants.ClipboardText);
                        }

                        oldClipboardData = clipboardData;
                    }
                }

                await Task.Delay(Constants.ClipboardCheckIntervalInMs);
            }
        }

        private void PerformUrlCut(string clipboardData)
        {
            string encodedUrl = clipboardData[_appsettings.UrlPrefix.Length..];
            string decodedUrl = Uri.UnescapeDataString(encodedUrl);

            Clipboard.SetText(decodedUrl);

            PlaySound(_state.SoundFile);
            PrintText(
                $"{++_state.CountOutput}. Qcomment: {encodedUrl} -> {decodedUrl}", Constants.QcommentText);
        }

        private void PlaySound(string? fileName)
        {
            if (fileName is null)
            {
                return;
            }

            try
            {
                var player = new SoundPlayer(fileName);
                player.Play();
            }
            catch (Exception ex)
            {
                SystemSounds.Hand.Play();
                _enableNoneButton();

                _logger.Log($"[SoundPlayer exception]: {ex.Message} - (File: {fileName})");
            }
        }

        private void PrintText(string text, string textType)
        {
            if (textType == Constants.QcommentText)
            {
                _clipboardTextBox.AppendText(Environment.NewLine);
                _clipboardTextBox.AppendText(text);
                _clipboardTextBox.AppendText(Environment.NewLine);
                _clipboardTextBox.AppendText(Environment.NewLine);
            }
            else if (textType == Constants.ClipboardText)
            {
                _clipboardTextBox.AppendText(text);
                _clipboardTextBox.AppendText(Environment.NewLine);
            }
        }
    }
}