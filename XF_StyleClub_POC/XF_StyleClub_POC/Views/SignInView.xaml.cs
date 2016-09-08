using System.Threading.Tasks;
using Xamarin.Forms;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views
{
    public partial class SignInView : ISignInView
    {
        private readonly ISignInViewModel _signInViewModel;
        public SignInView(ISignInViewModel signInViewModel)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = _signInViewModel = signInViewModel;
            BindablePage = this;
        }

        public Page BindablePage { get; }
        public async Task Initialize() => await _signInViewModel.Initialize();
    }
}
