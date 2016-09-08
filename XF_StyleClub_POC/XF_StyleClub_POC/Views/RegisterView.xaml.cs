using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views
{
    public partial class RegisterView : IRegisterView
    {
        private readonly IRegisterViewModel _registerViewModel;
        public RegisterView(IRegisterViewModel registerViewModel1)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = _registerViewModel = registerViewModel1;
            BindablePage = this;
        }

        public Page BindablePage { get; }
        public async Task Initialize() => await _registerViewModel.Initialize();
    }
}
