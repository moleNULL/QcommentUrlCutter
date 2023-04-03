using System.Diagnostics;
using QcommentUrlCutter.Logger;

namespace QcommentUrlCutter.Helpers
{
    public static class RunFileHelper
    {
        public static void RunFile(ILogger logger, string applicationName, string filePath, string? argument)
        {
            FileHelper.RecreateFileTextIfNotExists(filePath, logger);

            Process.Start(applicationName, (argument ?? string.Empty) + filePath);
        }
    }
}
