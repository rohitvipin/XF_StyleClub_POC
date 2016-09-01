using System.Collections.ObjectModel;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Entities;

namespace XF_StyleClub_POC.ViewModels.Interfaces
{
    public interface IWatchViewModel : IViewModel
    {
        ObservableCollection<StyleClubEntity> StyleClub { get; set; }

        AsyncRelayCommand SelectVideoDetailCommand { get; set; }
    }
}