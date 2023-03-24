using System.Text.Json;
using System.Text.RegularExpressions;
using QcommentUrlCutter.Models;

namespace QcommentUrlCutter.Helpers
{
    public static class SettingsHelper
    {
        public static ApplicationSettings GetApplicationSettings()
        {
            using (var fs = new FileStream(Constants.AppsettingsJson, FileMode.OpenOrCreate))
            {
                var settings = JsonSerializer.Deserialize<ApplicationSettings>(fs);

                if (settings is null)
                {
                    throw new JsonException(
                        $"Failed to deserialize application settings from {Constants.AppsettingsJson}");
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

                File.WriteAllText(Constants.AppsettingsJson, json);
            }
        }
    }
}
