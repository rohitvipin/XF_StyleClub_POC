using System.Collections.ObjectModel;
using XF_StyleClub_POC.Entities;

namespace XF_StyleClub_POC.ViewModels.Interfaces
{
    public interface IDetailVideoViewModel : IViewModel
    {
        ObservableCollection<VideoEntity> Videos { get; set; }
    }
}