using QcommentUrlCutter.Logic;

namespace QcommentUrlCutter
{
    public partial class MainForm : Form
    {
        private readonly ApplicationState _state;
        public MainForm()
        {
            _state = new ApplicationState();

            InitializeComponent();
            Text += Helpers.GetAppFileVersion();

            DogBarkingButton_CheckedChanged(this, EventArgs.Empty);
            ButtonStart_Click(this, EventArgs.Empty);
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

        private void DogBarkingButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DogBarkingButton.Checked)
            {
                _state.SoundFile = DogBarkingButton.Text;
            }
        }

        private void FemaleGaspButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FemaleGaspButton.Checked)
            {
                _state.SoundFile = FemaleGaspButton.Text;
            }
        }

        private void NoneButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NoneButton.Checked)
            {
                _state.SoundFile = null;
            }
        }
    }
}

/*
     TODO:
1. Remember selected RadioButton -> settings in %appdata%
 */