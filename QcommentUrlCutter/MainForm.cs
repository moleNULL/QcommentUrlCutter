using QcommentUrlCutter.Helpers;
using QcommentUrlCutter.Logger;
using QcommentUrlCutter.Models;
using QcommentUrlCutter.Tabs.Helpers;

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

                FileHelper.RecreateAppsettingsIfNotExists(_logger);
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
1.log if i changed settings via SubmitButton
2.print if successfully submited
3.try-catch everywhere
4.add timer for SubmitButtonStatusLabel
5.combobox bugs with Submit button
 */