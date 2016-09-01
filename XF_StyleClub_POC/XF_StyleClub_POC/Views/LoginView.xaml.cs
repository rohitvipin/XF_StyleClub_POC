using System.Threading.Tasks;

using Xamarin.Forms;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views
{
    public partial class LoginView : ILoginView
    {
        private readonly ILoginViewModel _loginViewModel;
        public LoginView(ILoginViewModel loginViewModel)
        {
            InitializeComponent();
            BindingContext = _loginViewModel = loginViewModel;
            BindablePage = this;
        }

        public Page BindablePage { get; }
        public async Task Initialize() => await _loginViewModel.Initialize();
    }
}
