using QcommentUrlCutter.Helpers;
using QcommentUrlCutter.Models;

namespace QcommentUrlCutter
{
#pragma warning disable SA1205
    partial class MainForm
#pragma warning restore SA1205
    {
        private void LogsTab_Enter(object sender, EventArgs e)
        {
            LogsTimer_Tick(nameof(LogsTab_Enter), EventArgs.Empty);
            LogsTimer.Start();
        }

        private void LogsTimer_Tick(object? sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Constants.LogFile))
                {
                    File.Create(Constants.LogFile);
                }

                string? logs = FileHelper.GetTextFromFile(Constants.LogFile);

                bool isLogTabSender = sender?.ToString()?.Equals(nameof(LogsTab_Enter)) ?? false;

                if (logs != LogsTextBox.Text || isLogTabSender)
                {
                    if (string.IsNullOrWhiteSpace(logs))
                    {
                        ClearLogsButton.Enabled = false;
                        LogsTextBox.Text = "(no logs)";
                    }
                    else
                    {
                        ClearLogsButton.Enabled = true;
                        LogsTextBox.Text = logs;

                        LogsTextBox.BeginInvoke(() =>
                        {
                            LogsTextBox.SelectionStart = LogsTextBox.Text.Length;
                            LogsTextBox.ScrollToCaret();
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(
                    _applicationTitle, nameof(LogsTab_Enter), ex, _logger, exitApplication: false);
            }
        }

        private void ClearLogsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Constants.LogFile))
                {
                    FileHelper.ClearFile(Constants.LogFile);

                    LogsTab_Enter(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(
                    _applicationTitle, nameof(ClearLogsButton_Click), ex, _logger, exitApplication: false);
            }
        }

        private void LogsFolderButton_Click(object sender, EventArgs e)
        {
            string filePath = ApplicationState.CurrentDirectory + "\\" + Constants.LogFile;
            string argument = $"/select, ";

            try
            {
                RunFileHelper.RunFile(_logger, Constants.ApplicationToOpenFolderDefault, filePath, argument);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(
                    _applicationTitle, nameof(LogsFolderButton_Click), ex, _logger, exitApplication: false);
            }
        }

        private void LogsFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                RunFileHelper.RunFile(_logger, _appsettings.ApplicationToOpenFiles, Constants.LogFile, null);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(
                    _applicationTitle, nameof(LogsFileButton_Click), ex, _logger, exitApplication: false);
            }
        }
    }
}
