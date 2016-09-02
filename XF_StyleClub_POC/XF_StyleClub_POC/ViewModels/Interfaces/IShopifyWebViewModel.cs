using System.Threading.Tasks;

namespace XF_StyleClub_POC.ViewModels.Interfaces
{
    public interface IShopifyWebViewModel : IViewModel
    {
        string Url { get; set; }

        Task Initialize(string url);
    }
}