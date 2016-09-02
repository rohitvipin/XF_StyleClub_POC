using XF_StyleClub_POC.Common;

namespace XF_StyleClub_POC.ViewModels.Interfaces
{
    public interface IDetailVideoViewModel : IViewModel
    {
        string ProductUrl { get; set; }

        string Description { get; set; }

        AsyncRelayCommand ShopCommand { get; }
    }
}