using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using XF_StyleClub_POC.Services.Interfaces;
using XF_StyleClub_POC.ViewModels.Interfaces;

namespace XF_StyleClub_POC.ViewModels
{
    public class SignInViewModel : BaseViewModel,ISignInViewModel
    {
        private readonly IUnityContainer _unityContainer;
        private readonly INavigationService _navigationService;
        private readonly ILoggingService _loggingService;
        private readonly IDialogService _dialogService;
        public SignInViewModel(IDialogService dialogService, IUnityContainer unityContainer, INavigationService navigationService, IDialogService dialogService1, ILoggingService loggingService) : base(dialogService)
        {
            _unityContainer = unityContainer;
            _navigationService = navigationService;
            _dialogService = dialogService1;
            _loggingService = loggingService;
        }

        public override string PageTitle { get; }
        public override async Task Initialize()
        {
            try
            {
                BeginBusy();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                EndBusy();
            }
        }
    }
}
