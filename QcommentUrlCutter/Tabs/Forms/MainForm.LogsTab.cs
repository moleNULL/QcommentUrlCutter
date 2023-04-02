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
            try
            {
                if (!File.Exists(Constants.LogFile))
                {
                    File.Create(Constants.LogFile);
                }

                string? logs = FileHelper.GetTextFromFile(Constants.LogFile);
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
            string argument = $"/select, {filePath}";

            RunFileHelper.RunFile(Constants.ApplicationToOpenFolderDefault, argument, _logger);
        }

        private void LogsFileButton_Click(object sender, EventArgs e)
        {
            RunFileHelper.RunFile(_appsettings.ApplicationToOpenFiles, Constants.LogFile, _logger);
        }
    }
}
