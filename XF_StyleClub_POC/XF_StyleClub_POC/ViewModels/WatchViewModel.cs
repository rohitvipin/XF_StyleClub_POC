using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Entities;
using XF_StyleClub_POC.ViewModels.Interfaces;

namespace XF_StyleClub_POC.ViewModels
{
    public class WatchViewModel : BaseViewModel, IWatchViewModel
    {
        public override string PageTitle => PageTitles.WatchTab;
        public override async Task Initialize()
        {
            var videos = new List<VideoEntity>();
            for (var i = 0; i < 10; i++)
            {
                videos.Add(new VideoEntity());
            }
            Videos = new ObservableCollection<VideoEntity>(videos);
        }

        public ObservableCollection<VideoEntity> Videos { get; set; }
    }
}