using System.Threading.Tasks;
using Xamarin.Forms;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views
{
    public partial class WatchView : IWatchView
    {
        private readonly IWatchViewModel _watchViewModel;

        public WatchView(IWatchViewModel watchViewModel)
        {
            InitializeComponent();
            BindingContext = _watchViewModel = watchViewModel;
            BindablePage = this;
        }

        public Page BindablePage { get; }

        public async Task Initialize() => await _watchViewModel.Initialize();

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await Initialize();
		}
	}
}
