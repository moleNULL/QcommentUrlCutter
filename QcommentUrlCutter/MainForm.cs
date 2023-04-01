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
1.try-catch everywhere
2.exceptions if removed appsettings and logs while app is already running
3. QcommentUrl -> UrlCutter
4. Application helper Exception sound method
--5. \r\n in WinForms
--6. WinForms architecture + best practice
--7. IClonable
8. Exception thrown if invalid json 0 bytes
9. отделить комментариями утилитарные методы везде
10. exception https://qcomment.ru/site/go?url=
11. WinAPI clipboard event
12. Make sound for escaped urls
13. Log if: unescaped string, qcomment cut
 */