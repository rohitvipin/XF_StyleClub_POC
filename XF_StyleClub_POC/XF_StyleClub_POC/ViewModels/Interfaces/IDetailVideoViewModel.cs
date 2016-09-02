using System.Threading.Tasks;
using Octane.Xam.VideoPlayer;
using Xamarin.Forms;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Entities;

namespace XF_StyleClub_POC.ViewModels.Interfaces
{
    public interface IDetailVideoViewModel : IViewModel
    {
        string OwnerName { get; set; }

        string Location { get; set; }

        ImageSource OwnerImageSource { get; set; }

        string ProductUrl { get; set; }

        string Description { get; set; }

        int TimeElapsedInMinutes { get; set; }

        VideoSource VideoSource { get; set; }

        AsyncRelayCommand ShopCommand { get; }

        Task Initialize(ProductEntity product);
    }
}