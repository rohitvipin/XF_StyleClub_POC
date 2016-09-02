using System.Threading.Tasks;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Services.Interfaces;
using XF_StyleClub_POC.ViewModels.Interfaces;

namespace XF_StyleClub_POC.ViewModels
{
    public class ShopViewModel : BaseViewModel, IShopViewModel
    {
        public ShopViewModel(IDialogService dialogService, ILoggingService loggingService) : base(dialogService)
        {
        }

        public override string PageTitle => PageTitles.ShopTab;

        public override async Task Initialize()
        {
        }
    }
}