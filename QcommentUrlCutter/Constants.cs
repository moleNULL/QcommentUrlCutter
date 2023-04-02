namespace QcommentUrlCutter
{
    public static class Constants
    {
        // Program.cs
        public const int MinSoundNameLength = 4;
        public const int MaxSoundNameLength = 21;
        public const int MaxSoundNameWithoutExtension = 17;

        public const string RadioButton1Name = "RadioButton1";
        public const string RadioButton2Name = "RadioButton2";

        // QcommentCutter.cs
        public const int ClipboardCheckIntervalInMs = 500;
        public const string QcommentText = "QcommentText";
        public const string ClipboardText = "ClipboardText";

        public const string AppsettingsJsonFile = "appsettings.json";
        public const string LogFile = "application.log";

        public const string ApplicationToOpenFileDefault = "C:\\Windows\\System32\\notepad.exe";
        public const string ApplicationToOpenFolderDefault = "C:\\Windows\\explorer.exe";
    }
}
