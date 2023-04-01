using System.Diagnostics;
using System.Reflection;

namespace QcommentUrlCutter.Helpers
{
    public static class ApplicationHelper
    {
        public static string? GetApplicationFileVersion()
        {
            Assembly? assembly = Assembly.GetEntryAssembly();
            if (assembly is null)
            {
                return null;
            }

            string? applicationFileName = assembly.GetName().Name;
            if (applicationFileName is null)
            {
                return null;
            }

            if (File.Exists(applicationFileName + ".dll"))
            {
                applicationFileName += ".dll";
            }
            else
            {
                // For self-contained version --> it only has *.exe application
                applicationFileName += ".exe";
            }

            string? fileVersionInfo = FileVersionInfo.GetVersionInfo(
                Path.Combine(AppContext.BaseDirectory, applicationFileName)).FileVersion;

            return fileVersionInfo is not null ? $" [version {fileVersionInfo}]" : null;
        }
    }
}
