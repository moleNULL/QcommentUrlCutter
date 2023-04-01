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
            MessageBox.Show(
                ex.Message,
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
