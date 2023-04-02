using QcommentUrlCutter.Helpers;
using QcommentUrlCutter.Logger;
using QcommentUrlCutter.Models;
using QcommentUrlCutter.Tabs.TabHelpers;

namespace QcommentUrlCutter
{
    public partial class MainForm : Form
    {
        private readonly ApplicationState _state = null!;
        private readonly ILogger _logger = null!;
        private readonly string _applicationTitle = null!;

        private ApplicationSettings _appsettings = null!;
        private ApplicationTabHelper _applicationTabHelper = null!;
        private SettingsTabHelper _settingsTabHelper = null!;
        public MainForm()
        {
            InitializeComponent();
            try
            {
                _logger = new FileLogger();
                _state = new ApplicationState();

                Text += ApplicationHelper.GetApplicationFileVersion();
                _applicationTitle = Text;

                FileHelper.RecreateFileTextIfNotExists(Constants.AppsettingsJsonFile, _logger);
                FileHelper.RecreateFileTextIfNotExists(Constants.LogFile, _logger);
                FileHelper.RecreateSoundsIfNotExist(_logger);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(
                    _applicationTitle, nameof(MainForm), ex, _logger, exitApplication: true);
            }
        }
    }
}

/*
    TODO:
 */