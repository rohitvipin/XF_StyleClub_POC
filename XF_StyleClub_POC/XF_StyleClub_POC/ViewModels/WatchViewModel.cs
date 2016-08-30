using System.Threading.Tasks;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.ViewModels.Interfaces;

namespace XF_StyleClub_POC.ViewModels
{
    public class WatchViewModel : BaseViewModel, IWatchViewModel
    {
        public override string PageTitle => PageTitles.WatchTab;
        public override Task Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}