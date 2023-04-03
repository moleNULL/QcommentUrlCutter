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
            _logger = logger;
            _appsettings = SettingsHelper.GetApplicationSettings(_logger);

            _state = state;
            _clipboardTextBox = clipboardTextBox;
            _enableNoneButton = enableNoneButton;
        }

        public async Task RunAsync()
        {
            string oldClipboardData = string.Empty;

            while (_state.MustRun)
            {
                if (Clipboard.ContainsText())
                {
                    string clipboardData = Clipboard.GetText();

                    if (!string.Equals(clipboardData, oldClipboardData))
                    {
                        if (clipboardData.StartsWith(_appsettings.UrlPrefix)
                            && clipboardData != _appsettings.UrlPrefix)
                        {
                            PerformUrlCut(ref clipboardData);
                        }
                        else
                        {
                            HandleClipboardText(ref clipboardData);
                        }

                        oldClipboardData = clipboardData;
                    }
                }

                await Task.Delay(Constants.ClipboardCheckIntervalInMs);
            }
        }

        /*
            ----------------------------------Main utility methods-----------------------------------
        */

        private void PerformUrlCut(ref string clipboardData)
        {
            clipboardData = Uri.UnescapeDataString(clipboardData);

            string formattedUrl = clipboardData[_appsettings.UrlPrefix.Length..];

            Clipboard.SetText(formattedUrl);
            PlaySound(_state.SoundFile);

            string info = $"QcommentUrl: {clipboardData} -> {formattedUrl}";
            PrintText($"{++_state.CountOutput}. {info}", Constants.QcommentText);
            _logger.Log($"{info}\n");
        }

        private void HandleClipboardText(ref string clipboardData)
        {
            string possibleLatestClipboardRecord =
                                $"{_state.CountOutput}. {clipboardData}{Environment.NewLine}";

            if (!_clipboardTextBox.Text.Contains(possibleLatestClipboardRecord))
            {
                if (IsUriEscaped(clipboardData))
                {
                    HandleEscapedUri(ref clipboardData);
                }

                PrintText($"{++_state.CountOutput}. {clipboardData}", Constants.ClipboardText);
            }
        }

        /*
            -------------------------------------Utility methods-------------------------------------
        */

        private void PlaySound(string? fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return;
            }

            try
            {
                SoundHelper.PlayCustomSound(fileName);
            }
            catch (Exception ex)
            {
                SoundHelper.PlayExceptionSound();
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

        private bool IsUriEscaped(string url)
        {
            string decodedUrl = Uri.UnescapeDataString(url);

            return !(url == decodedUrl);
        }

        private void HandleEscapedUri(ref string clipboardData)
        {
            string escapedUri = clipboardData;
            clipboardData = Uri.UnescapeDataString(escapedUri);
            Clipboard.SetText(clipboardData);

            SoundHelper.PlaySuccessSound();
            _logger.Log($"Escaped Uri: {escapedUri} -> {clipboardData}");
        }
    }
}