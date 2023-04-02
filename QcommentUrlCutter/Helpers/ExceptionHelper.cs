using System.Text.Json;
using QcommentUrlCutter.Logger;

namespace QcommentUrlCutter.Helpers
{
    public static class ExceptionHelper
    {
        public static void HandleException(
            string applicationTitle,
            string methodName,
            Exception ex,
            ILogger logger,
            bool exitApplication)
        {
            string error;
            if (ex is JsonException)
            {
                error = $"Error while deserializing {Constants.AppsettingsJsonFile}: \"{ex.Message}\"" +
                    $"{Environment.NewLine}{Environment.NewLine}" +
                    $"Delete {Constants.AppsettingsJsonFile} and restart the application";
            }
            else
            {
                error = ex.Message;
            }

            MessageBox.Show(
                error,
                $"{applicationTitle} | {methodName} Exception",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            logger.Log($"{methodName} Exception: {ex.Message}");

            if (exitApplication)
            {
                Environment.Exit(0);
            }
        }

        public static void ThrowException()
        {
            throw new Exception($"Debug test exception from {nameof(ExceptionHelper)}.cs");
        }
    }
}
