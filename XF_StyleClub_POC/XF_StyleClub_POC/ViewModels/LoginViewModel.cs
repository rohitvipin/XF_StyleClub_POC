using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XF_StyleClub_POC.Services.Interfaces;
using Microsoft.Practices.Unity;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Enums;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.ViewModels
{
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {
        private readonly IUnityContainer _unityContainer;
        private readonly INavigationService _navigationService;
        private readonly ILoggingService _loggingService;
        private readonly IDialogService _dialogService;

        public LoginViewModel(IUnityContainer unityContainer, INavigationService navigationService, ILoggingService loggingService, IDialogService dialogService) : base(dialogService)
        {
            _unityContainer = unityContainer;
            _navigationService = navigationService;
            _loggingService = loggingService;
            _dialogService = dialogService;
            SignInCommand = new AsyncRelayCommand(SignInCommandHandler);
            LoginCommand = new AsyncRelayCommand(LoginCommandHandler);
            RegisterCommand = new AsyncRelayCommand(RegisterCommandHandler);
        }

        private async Task SignInCommandHandler()
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

        private async Task RegisterCommandHandler()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                BeginBusy();

                var registerView = _unityContainer.Resolve<IRegisterView>();
                await _navigationService.NavigateToPage(registerView, PageTitles.ApplicationTitle);
                await registerView.Initialize();
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

        private async Task LoginCommandHandler()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                BeginBusy();

                var childTabs = new List<IView>
                {
                    _unityContainer.Resolve<IWatchView>(),
                    _unityContainer.Resolve<IShopView>()
                };

                var homeTabView = _unityContainer.Resolve<IHomeTabView>(new ParameterOverride("childViews", childTabs));
                _navigationService.SetRoot(homeTabView, PageTitles.ApplicationTitle);
                await homeTabView.Initialize();
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

        public async override Task Initialize()
        {
        }

        public AsyncRelayCommand LoginCommand { get; }
        public AsyncRelayCommand RegisterCommand { get; }
        public AsyncRelayCommand SignInCommand { get; }
    }
}
