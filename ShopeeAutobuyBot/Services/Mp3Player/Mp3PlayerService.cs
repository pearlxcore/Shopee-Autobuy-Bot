using System;

namespace Shopee_Autobuy_Bot.Services.Mp3Player
{
    public class Mp3PlayerService : IMp3PlayerService
    {
        public Mp3PlayerService() { }

        public void PlaySound()
        {
            Constants.Mp3Player.WaveOut.Play();
            Constants.Mp3Player.WaveOut.PlaybackStopped += OnPlaybackStopped;
        }

        private void OnPlaybackStopped(object sender, EventArgs e/*, WaveOut wave, Mp3FileReader mpefilereader*/)
        {
            Constants.Mp3Player.Mp3FileReader.Position = 0;
        }
    }
}