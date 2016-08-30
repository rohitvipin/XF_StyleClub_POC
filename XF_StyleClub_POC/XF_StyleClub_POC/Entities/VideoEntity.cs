namespace XF_StyleClub_POC.Entities
{
    public class VideoEntity : BaseEntity
    {
        private bool _isPlayButtonVisible;

        private bool IsPlayButtonVisible
        {
            get { return _isPlayButtonVisible; }
            set
            {
                _isPlayButtonVisible = value;
                OnPropertyChanged();
            }
        }

        //private void PlayButton_OnClicked(object sender, EventArgs e)
        //{
        //    if (VideoPlayer.State == PlayerState.Prepared)
        //    {
        //        VideoPlayer.Play();
        //    }
        //    else
        //    {
        //        VideoPlayer.AutoPlay = true;
        //    }
        //    SetPlayerControlVisibility(true);
        //}

        //private void VideoPlayer_OnPlayerStateChanged(object sender, VideoPlayerStateChangedEventArgs e) => SetPlayerControlVisibility(e.CurrentState == PlayerState.Playing);

        //private void SetPlayerControlVisibility(bool isVideoPlaying)
        //{
        //    VideoPlayer.DisplayControls = isVideoPlaying;
        //    PlayButton.IsVisible = !isVideoPlaying;
        //}
    }
}