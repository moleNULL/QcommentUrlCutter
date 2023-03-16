using QcommentUrlCutter.Logic;

namespace QcommentUrlCutter
{
    public partial class MainForm : Form
    {
        private readonly ApplicationState _state;
        public MainForm()
        {
            InitializeComponent();
            Text += Helpers.GetAppFileVersion();

            _state = new ApplicationState();
        }

        private async void ButtonStart_Click(object sender, EventArgs e)
        {
            _state.MustRun = true;
            ButtonStart.Enabled = false;
            ButtonStop.Enabled = true;

            try
            {
                var qCutter = new QcommentCutter(_state, clipboardTextBox);
                await qCutter.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            _state.MustRun = false;

            ButtonStart.Enabled = true;
            ButtonStop.Enabled = false;
        }
    }
}

/*
     TODO:
1. Add RadioButton to switch between sounds (bark, gasp and none) with memory
2. Press startbutton on launch
3. No icon for the process in Task Manager
 */