using System.Media;

namespace QcommentUrlCutter.Helpers
{
    public static class SoundHelper
    {
        public static void PlayCustomSound(string fileName)
        {
            var player = new SoundPlayer(fileName);
            player.Play();
        }

        public static void PlayExceptionSound()
        {
            SystemSounds.Hand.Play();
        }

        public static void PlaySuccessSound()
        {
            SystemSounds.Exclamation.Play();
        }
    }
}
