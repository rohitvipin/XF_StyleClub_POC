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
    }
}