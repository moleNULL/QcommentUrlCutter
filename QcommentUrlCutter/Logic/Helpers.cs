using System.Diagnostics;
using System.Reflection;

namespace QcommentUrlCutter.Logic
{
    public static class Helpers
    {
        public static string? GetAppFileVersion()
        {
            Assembly? assembly = Assembly.GetEntryAssembly();

            if (assembly is null)
            {
                return null;
            }

            string? fileVersionInfo = FileVersionInfo.GetVersionInfo(
                Path.Combine(AppContext.BaseDirectory, $"{assembly.GetName().Name}.dll")).FileVersion;

            return fileVersionInfo is not null ? $" [version {fileVersionInfo}]" : null;
        }
    }
}
