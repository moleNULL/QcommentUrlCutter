using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using QcommentUrlCutter.Models;

namespace QcommentUrlCutter.Logic
{
    public static class Helpers
    {
        public const string AppsettingsJson = "appsettings.json";

        public static string? GetAppFileVersion()
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

        public static ApplicationSettings GetApplicationSettings()
        {
            if (!File.Exists(AppsettingsJson))
            {
                string resourceFile = $"QcommentUrlCutter.{AppsettingsJson}";
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceFile))
                {
                    using (var reader = new StreamReader(stream!))
                    {
                        string content = reader.ReadToEnd();
                        File.WriteAllText(AppsettingsJson, content);
                    }
                }
            }

            using (var fs = new FileStream(AppsettingsJson, FileMode.OpenOrCreate))
            {
                var settings = JsonSerializer.Deserialize<ApplicationSettings>(fs);

                if (settings is null)
                {
                    throw new JsonException($"Failed to deserialize application settings from {AppsettingsJson}");
                }

                if (string.IsNullOrWhiteSpace(settings.UrlPrefix) ||
                    !Regex.IsMatch(settings.UrlPrefix, @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$"))
                {
                    throw new Exception("UrlPrefix must be URL");
                }

                return settings;
            }
        }

        public static void SaveRadioButtonChoiceToFile(ApplicationSettings appsettings, string radioButtonName)
        {
            if (radioButtonName != appsettings.RadioButtonChoice)
            {
                appsettings.RadioButtonChoice = radioButtonName;

                string json = JsonSerializer.Serialize(
                    appsettings, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(AppsettingsJson, json);
            }
        }
    }
}
