using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using XF_StyleClub_POC.Services.Interfaces;
using Microsoft.Practices.Unity;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Entities;
using XF_StyleClub_POC.Enums;
using XF_StyleClub_POC.ViewModels.Interfaces;

namespace XF_StyleClub_POC.ViewModels
{
    public class WatchViewModel : BaseViewModel, IWatchViewModel
    {
        private ObservableCollection<ProductEntity> _products;
        private readonly IUnityContainer _unityContainer;
        private readonly INavigationService _navigationService;
        private readonly ILoggingService _loggingService;
        private readonly IDialogService _dialogService;
        private readonly IDataAcessService _dataAcessService;

        public WatchViewModel(IUnityContainer unityContainer, INavigationService navigationService, ILoggingService loggingService, IDialogService dialogService, IDataAcessService dataAcessService) : base(dialogService)
        {
            _dialogService = dialogService;
            _dataAcessService = dataAcessService;
            _unityContainer = unityContainer;
            _navigationService = navigationService;
            _loggingService = loggingService;
        }

        public ObservableCollection<ProductEntity> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public override string PageTitle => PageTitles.WatchTab;

        public override async Task Initialize()
        {
            try
            {
                BeginBusy();

                var allProductsServiceResponse = await _dataAcessService.GetAllProducts();

                if (allProductsServiceResponse?.WebResponseEntity?.IsSuccessStatusCode != true || allProductsServiceResponse?.ReturnValue == null)
                {
                    _dialogService.ShowToastMessage(PageTitle, Messages.NoDataReceivedFromServer, ToastNotificationType.Error);
                    return;
                }

                Products = new ObservableCollection<ProductEntity>(allProductsServiceResponse.ReturnValue
                                                                   ?.Select(x => new ProductEntity(_unityContainer, _navigationService, _loggingService, _dialogService)
                                                                   {
                                                                       CreatedDateTime = x.CreatedDateTime,
                                                                       Description = x.Description,
                                                                       ImageUrl = x.ImageUrl,
                                                                       Location = x.Location,
                                                                       OwnerImageUrl = x.OwnerImageUrl,
                                                                       OwnerName = x.OwnerName,
                                                                       Title = x.Title,
                                                                       VideoUrl = x.VideoUrl,
                                                                       WebsiteUrl = x.WebsiteUrl
                                                                   }));

                //Delay to load the image from Url
                await Task.Delay(Constants.DefaultLoadTimeInMs);
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
    }
}
