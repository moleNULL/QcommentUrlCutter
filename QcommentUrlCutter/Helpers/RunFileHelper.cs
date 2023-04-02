using System.Diagnostics;
using QcommentUrlCutter.Logger;

namespace QcommentUrlCutter.Helpers
{
    public static class RunFileHelper
    {
        public static void RunFile(string applicationName, string filePath, ILogger logger)
        {
            FileHelper.RecreateFileTextIfNotExists(filePath, logger);

            Process.Start(applicationName, filePath);
        }
    }
}
