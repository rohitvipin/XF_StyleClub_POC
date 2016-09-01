using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmoMe.Services.Interfaces;
using Microsoft.Practices.Unity;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Enums;
using XF_StyleClub_POC.Services.Interfaces;
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

        public LoginViewModel(IUnityContainer unityContainer, INavigationService navigationService, ILoggingService loggingService, IDialogService dialogService)
        {
            _unityContainer = unityContainer;
            _navigationService = navigationService;
            _loggingService = loggingService;
            _dialogService = dialogService;
            LoginCommand = new AsyncRelayCommand(LoginCommandHandler);
        }

        private async Task LoginCommandHandler()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                var childTabs = new List<IView>
                {
                    _unityContainer.Resolve<IWatchView>(),
                    _unityContainer.Resolve<IShopView>()
                };

                var homeTabView = _unityContainer.Resolve<IHomeTabView>(new ParameterOverride("childViews", childTabs));
                _navigationService.SetRoot(homeTabView,PageTitles.ApplicationTitle);
                await homeTabView.Initialize();
            }
            catch (Exception exception)
            {
                _loggingService.Error(exception);
                _dialogService.ShowToastMessage(PageTitles.ApplicationTitle, Messages.UnExpectedError, ToastNotificationType.Error);
            }
        }

        public override string PageTitle { get; }
        public override Task Initialize()
        {
            throw new NotImplementedException();
        }

        public AsyncRelayCommand LoginCommand { get; }
    }
}
