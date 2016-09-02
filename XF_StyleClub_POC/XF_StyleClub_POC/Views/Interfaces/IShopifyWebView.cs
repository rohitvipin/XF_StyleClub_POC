using System.Threading.Tasks;

namespace XF_StyleClub_POC.Views.Interfaces
{
    public interface IShopifyWebView : IView
    {
        Task Initialize(string url);
    }
}