using System;
using System.Threading.Tasks;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Enums;
using XF_StyleClub_POC.Services.Interfaces;
using XF_StyleClub_POC.ViewModels.Interfaces;

namespace XF_StyleClub_POC.ViewModels
{
    public class ShopifyWebViewModel : BaseViewModel, IShopifyWebViewModel
    {
        private readonly ILoggingService _loggingService;
        private readonly IDialogService _dialogService;

        private string _url;

        public ShopifyWebViewModel(IDialogService dialogService, ILoggingService loggingService) : base(dialogService)
        {
            _loggingService = loggingService;
            _dialogService = dialogService;
        }

        public override string PageTitle => PageTitles.ShopifyWeb;

        public override Task Initialize()
        {
            throw new NotImplementedException();
        }

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }

        public async Task Initialize(string url)
        {
            try
            {
                BeginBusy();

                Url = url;

                //Time load website
                await Task.Delay(Constants.DefaultLoadTimeInMs);
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
    }
}