namespace QcommentUrlCutter.Models
{
    public class ApplicationSettings
    {
        private string? _applicationToOpenFiles;

        public string UrlPrefix { get; set; } = null!;
        public string? RadioButtonChoice { get; set; }
        public bool IsStartButtonClickedOnLaunch { get; set; }
        public string? SoundPathFirst { get; set; }
        public string? SoundPathSecond { get; set; }
        public string ApplicationToOpenFiles
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_applicationToOpenFiles))
                {
                    _applicationToOpenFiles = Constants.ApplicationToOpenFileDefault;
                }

                return _applicationToOpenFiles;
            }

            set
            {
                _applicationToOpenFiles = value;
            }
        }
    }
}
