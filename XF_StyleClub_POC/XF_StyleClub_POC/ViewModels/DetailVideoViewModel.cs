using System;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Octane.Xam.VideoPlayer;
using Xamarin.Forms;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Entities;
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
        private VideoSource _videoSource;
        private string _ownerName;
        private string _location;
        private int _timeElapsedInMinutes;
        private ImageSource _ownerImageSource;

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

        public override Task Initialize()
        {
            throw new NotImplementedException();
        }

        public async Task Initialize(ProductEntity product)
        {
            try
            {
                BeginBusy();

                Description = product.Description;
                ProductUrl = product.WebsiteUrl;
                VideoSource = product.VideoSource;
                OwnerImageSource = product.OwnerImageSource;
                OwnerName = product.OwnerName;
                TimeElapsedInMinutes = (int)product.TimeElapsed.TotalMinutes;
                Location = product.Location;

                await Task.Delay(Constants.VideoLoadTimeInMs);
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

        public string OwnerName
        {
            get { return _ownerName; }
            set
            {
                _ownerName = value;
                OnPropertyChanged();
            }
        }

        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public ImageSource OwnerImageSource
        {
            get { return _ownerImageSource; }
            set
            {
                _ownerImageSource = value;
                OnPropertyChanged();
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

        public int TimeElapsedInMinutes
        {
            get { return _timeElapsedInMinutes; }
            set
            {
                _timeElapsedInMinutes = value;
                OnPropertyChanged();
            }
        }

        public VideoSource VideoSource
        {
            get { return _videoSource; }
            set
            {
                _videoSource = value;
                OnPropertyChanged();
            }
        }

        public AsyncRelayCommand ShopCommand { get; }
    }
}