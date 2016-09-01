using System.Threading.Tasks;
using Xamarin.Forms;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views
{
    public partial class ShopView : IShopView
    {
        private readonly IShopViewModel _shopViewModel;

        public ShopView(IShopViewModel shopViewModel)
        {
            InitializeComponent();
            BindingContext = _shopViewModel = shopViewModel;
            BindablePage = this;
        }

        public Page BindablePage { get; }

        public async Task Initialize() => await _shopViewModel.Initialize();

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await Initialize();
		}
    }
}
