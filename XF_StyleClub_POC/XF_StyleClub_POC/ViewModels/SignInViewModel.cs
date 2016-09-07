using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Enums;
using XF_StyleClub_POC.Services.Interfaces;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

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
            SignInCommand = new AsyncRelayCommand(SignInCommandHandler);
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

        public AsyncRelayCommand SignInCommand { get; }
    }
}
