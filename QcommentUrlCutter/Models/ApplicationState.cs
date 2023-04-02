namespace QcommentUrlCutter.Models
{
    public class ApplicationState
    {
        private static string? _currentDirectory;

        public bool MustRun { get; set; }
        public int CountOutput { get; set; }
        public string? SoundFile { get; set; }
        public static string CurrentDirectory => _currentDirectory ??= Directory.GetCurrentDirectory();
    }
}
