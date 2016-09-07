using System;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Enums;
using XF_StyleClub_POC.Services.Interfaces;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.ViewModels
{
    public class RegisterViewModel : BaseViewModel, IRegisterViewModel
    {
        private readonly IUnityContainer _unityContainer;
        private readonly INavigationService _navigationService;
        private readonly ILoggingService _loggingService;
        private readonly IDialogService _dialogService;
        public RegisterViewModel(IDialogService dialogService, IUnityContainer unityContainer, INavigationService navigationService, ILoggingService loggingService, IDialogService dialogService1) : base(dialogService)
        {
            _unityContainer = unityContainer;
            _navigationService = navigationService;
            _loggingService = loggingService;
            _dialogService = dialogService1;
            RegisterCommand = new AsyncRelayCommand(RegisterCommandHandler);
        }

        private async Task RegisterCommandHandler()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                BeginBusy();

                var signInView = _unityContainer.Resolve<ISignInView>();
                await _navigationService.NavigateToPage(signInView, PageTitles.ApplicationTitle);
                await signInView.Initialize();
            }
            catch (Exception exception)
            {
                _loggingService.Error(exception);
                _dialogService.ShowToastMessage(PageTitles.ApplicationTitle, Messages.UnExpectedError, ToastNotificationType.Error);
            }
            finally
            {
                EndBusy();
            }
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

        public AsyncRelayCommand RegisterCommand { get; }
    }
}
