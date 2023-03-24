using System.Reflection;
using QcommentUrlCutter.Logger;

namespace QcommentUrlCutter.Helpers
{
    public static class FileHelper
    {
        public static void RecreateAppsettingsIfNotExists(ILogger logger)
        {
            RecreateFileTextIfNotExists(Constants.AppsettingsJson, logger);
        }

        public static void RecreateSoundsIfNotExist(ILogger logger)
        {
            string directoryName = "Sounds/";

            string[] soundFiles =
            {
                "dog_barking.wav", "female_gasp.wav", "finished_sound.wav",
                "good_sound.wav", "success_sound.wav"
            };

            foreach (string soundFile in soundFiles)
            {
                RecreateFileBinaryIfNotExists(directoryName + soundFile, logger);
            }
        }

        private static void RecreateFileTextIfNotExists(string file, ILogger logger)
        {
            CreateDirectoryIfNotExists(file, logger);

            if (!File.Exists(file))
            {
                string resourceFullFile = $"QcommentUrlCutter.{file}";
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceFullFile))
                {
                    using (var reader = new StreamReader(stream!))
                    {
                        string content = reader.ReadToEnd();
                        File.WriteAllText(file, content);
                    }
                }

                logger.Log($"Created file {file}");
            }
        }

        private static void RecreateFileBinaryIfNotExists(string file, ILogger logger)
        {
            CreateDirectoryIfNotExists(file, logger);

            if (!File.Exists(file))
            {
                string resourceFile = $"QcommentUrlCutter.Files.Sounds.{Path.GetFileName(file)}";
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceFile))
                {
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        stream!.CopyTo(fileStream);
                    }

                    logger.Log($"Created file {file}");
                }
            }
        }

        private static void CreateDirectoryIfNotExists(string file, ILogger logger)
        {
            string? directoryName = Path.GetDirectoryName(file);

            if (!string.IsNullOrEmpty(directoryName))
            {
                if (!Directory.Exists(Path.GetDirectoryName(file)))
                {
                    Directory.CreateDirectory(directoryName);

                    logger.Log($"Created directory {directoryName}");
                }
            }
        }
    }
}