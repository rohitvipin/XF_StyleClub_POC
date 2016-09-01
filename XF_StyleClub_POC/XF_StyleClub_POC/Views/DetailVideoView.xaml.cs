using System;
using System.Threading.Tasks;
using Octane.Xam.VideoPlayer.Constants;
using Octane.Xam.VideoPlayer.Events;
using Xamarin.Forms;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views
{
    public partial class DetailVideoView : IDetailVideoView
    {
        public DetailVideoView()
        {
            InitializeComponent();
        }

        private void PlayButton_OnClicked(object sender, EventArgs e)
        {
            if (VideoPlayer.State == PlayerState.Prepared)
            {
                VideoPlayer.Play();
            }
            else
            {
                VideoPlayer.AutoPlay = true;
            }
            SetPlayerControlVisibility(true);
        }

        private void VideoPlayer_OnPlayerStateChanged(object sender, VideoPlayerStateChangedEventArgs e)
        {
            SetPlayerControlVisibility(e.CurrentState == PlayerState.Playing);
        }

        private void SetPlayerControlVisibility(bool isVideoPlaying)
        {
            VideoPlayer.DisplayControls = isVideoPlaying;
            PlayButton.IsVisible = !isVideoPlaying;
        }

        public Page BindablePage { get; }

		public async Task Initialize()
        {
        }
    }
}
