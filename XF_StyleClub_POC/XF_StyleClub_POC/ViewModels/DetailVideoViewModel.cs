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
    public class DetailVideoViewModel : BaseViewModel, IDetailVideoViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly ILoggingService _loggingService;
        private readonly IUnityContainer _unityContainer;
        private readonly INavigationService _navigationService;

        private string _productUrl;
        private string _description;

        public DetailVideoViewModel(IDialogService dialogService, ILoggingService loggingService, IUnityContainer unityContainer, INavigationService navigationService) : base(dialogService)
        {
            _dialogService = dialogService;
            _loggingService = loggingService;
            _unityContainer = unityContainer;
            _navigationService = navigationService;
            ShopCommand = new AsyncRelayCommand(ShopCommandHandler);
        }

        private async Task ShopCommandHandler()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                BeginBusy();

                var shopifyWebView = _unityContainer.Resolve<IShopifyWebView>();
                await _navigationService.NavigateToPage(shopifyWebView, PageTitles.ShopifyWeb);
                await shopifyWebView.Initialize(ProductUrl);
            }
            catch (Exception exception)
            {
                _loggingService.Error(exception);
                _dialogService.ShowToastMessage(PageTitle, exception.Message, ToastNotificationType.Error);
            }
            finally
            {
                EndBusy();
            }
        }

        public override string PageTitle => PageTitles.VideoDetails;

        public override async Task Initialize()
        {
            try
            {
                BeginBusy();

                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc commodo sodales augue quis vehicula. Quisque eget neque in nisl cursus cursus at ut sem. Integer lacus nisl, malesuada in mollis at, aliquam in sem. Aliquam semper lacus nec lectus tincidunt, ut elementum orci iaculis. Duis aliquet interdum odio vel rutrum. Vivamus tincidunt tellus sit amet nulla efficitur rutrum. Sed aliquet enim at scelerisque vestibulum. Quisque at tincidunt tortor. Vestibulum sed tincidunt velit, eget pellentesque neque. Nulla facilisi.";
                ProductUrl = "http://thestyleclub.com/";
            }
            catch (Exception exception)
            {
                _loggingService.Error(exception);
                _dialogService.ShowToastMessage(PageTitle, exception.Message, ToastNotificationType.Error);
            }
            finally
            {
                EndBusy();
            }
        }

        public string ProductUrl
        {
            get { return _productUrl; }
            set
            {
                _productUrl = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public AsyncRelayCommand ShopCommand { get; }
    }
}