using System.Text.Json;
using System.Text.RegularExpressions;
using QcommentUrlCutter.Logger;
using QcommentUrlCutter.Models;

namespace QcommentUrlCutter.Helpers
{
    public static class SettingsHelper
    {
        public static ApplicationSettings GetApplicationSettings(ILogger logger)
        {
            string settingsFile = Constants.AppsettingsJsonFile;

            RecreateSettingsFileIfEmpty(settingsFile, logger);

            ApplicationSettings? settings;

            using (var fs = new FileStream(settingsFile, FileMode.OpenOrCreate))
            {
                settings = JsonSerializer.Deserialize<ApplicationSettings>(fs);
            }

            if (settings is null)
            {
                throw new JsonException(
                    $"Failed to deserialize application settings from {settingsFile}");
            }

            ValidateApplicationSettings(settings);

            return settings;
        }

        public static void SaveRadioButtonChoiceToFile(ApplicationSettings appsettings, string radioButtonName)
        {
            if (radioButtonName != appsettings.RadioButtonChoice)
            {
                appsettings.RadioButtonChoice = radioButtonName;
                SaveApplicationSettings(Constants.AppsettingsJsonFile, appsettings);
            }
        }

        public static void SaveApplicationSettings(string path, ApplicationSettings appsettings)
        {
            string json = JsonSerializer.Serialize(
                    appsettings, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(path, json);
        }

        /*
            -------------------------------------Utility methods-------------------------------------
        */

        private static void RecreateSettingsFileIfEmpty(string settingsFile, ILogger logger)
        {
            if (new FileInfo(settingsFile).Length == 0)
            {
                File.Delete(settingsFile);
                FileHelper.RecreateFileTextIfNotExists(settingsFile, logger);
            }
        }

        private static void ValidateApplicationSettings(ApplicationSettings settings)
        {
            ValidateUrlPrefix(settings);

            bool needToSaveFile = SetDefaultRadioButtonChoiceIfInvalid(settings)
                || SetDefaultApplicationToOpenFileIfInvalid(settings);

            if (needToSaveFile)
            {
                SaveApplicationSettings(Constants.AppsettingsJsonFile, settings);
            }
        }

        private static void ValidateUrlPrefix(ApplicationSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings.UrlPrefix) ||
                !Regex.IsMatch(settings.UrlPrefix, @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$"))
            {
                throw new Exception("UrlPrefix must be URL");
            }
        }

        private static bool SetDefaultRadioButtonChoiceIfInvalid(ApplicationSettings settings)
        {
            string[] radioButtonNames = { "RadioButton1", "RadioButton2", "NoneButton" };
            string radioButtonDefaultIfWrong = "NoneButton";

            if (string.IsNullOrWhiteSpace(settings.RadioButtonChoice)
                || !radioButtonNames.Contains(settings.RadioButtonChoice))
            {
                settings.RadioButtonChoice = radioButtonDefaultIfWrong;
                return true;
            }

            return false;
        }

        private static bool SetDefaultApplicationToOpenFileIfInvalid(ApplicationSettings settings)
        {
            if (!File.Exists(settings.ApplicationToOpenFiles))
            {
                settings.ApplicationToOpenFiles = Constants.ApplicationToOpenFileDefault;
                return true;
            }

            return false;
        }
    }
}
