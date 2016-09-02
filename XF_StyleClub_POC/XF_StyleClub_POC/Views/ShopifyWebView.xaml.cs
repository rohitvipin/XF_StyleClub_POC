using System.Threading.Tasks;
using Xamarin.Forms;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views
{
    public partial class ShopifyWebView : IShopifyWebView
    {
        private readonly IShopifyWebViewModel _shopifyWebViewModel;

        public ShopifyWebView(IShopifyWebViewModel shopifyWebViewModel)
        {
            InitializeComponent();
            BindingContext = _shopifyWebViewModel = shopifyWebViewModel;
            BindablePage = this;
        }

        public Page BindablePage { get; }

        public Task Initialize()
        {
            throw new System.NotImplementedException();
        }

        public Task Initialize(string url) => _shopifyWebViewModel.Initialize(url);
    }
}
