namespace QcommentUrlCutter.Models
{
    public class ApplicationSettings
    {
        public string UrlPrefix { get; init; } = null!;
        public string? RadioButtonChoice { get; set; }
        public bool IsButtonClickedOnLaunch { get; init; }
        public string? SoundPathFirst { get; init; }
        public string? SoundPathSecond { get; init; }
    }
}
