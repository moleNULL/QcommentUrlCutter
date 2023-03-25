namespace QcommentUrlCutter.Models
{
    public class ApplicationSettings
    {
        public string UrlPrefix { get; set; } = null!;
        public string? RadioButtonChoice { get; set; }
        public bool IsButtonClickedOnLaunch { get; set; }
        public string? SoundPathFirst { get; set; }
        public string? SoundPathSecond { get; set; }
    }
}
