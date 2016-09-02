using System;
using System.Threading.Tasks;
using XF_StyleClub_POC.Services.Interfaces;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Enums;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Entities
{
    public class ProductEntity : BaseEntity
    {
        private readonly IUnityContainer _unityContainer;
        private readonly INavigationService _navigationService;
        private readonly ILoggingService _loggingService;
        private readonly IDialogService _dialogService;
        private string _imageUrl;

        public ProductEntity(IUnityContainer unityContainer, INavigationService navigationService, ILoggingService loggingService, IDialogService dialogService)
        {
            _unityContainer = unityContainer;
            _navigationService = navigationService;
            _loggingService = loggingService;
            _dialogService = dialogService;

            SelectVideoDetailCommand = new AsyncRelayCommand(SelectVideoDetailCommandHandler);
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        public ImageSource ImageSource => ImageSource.FromUri(new Uri(ImageUrl));

        public AsyncRelayCommand SelectVideoDetailCommand { get; }

        private async Task SelectVideoDetailCommandHandler()
        {
            var parentViewModel = _unityContainer.Resolve<IWatchViewModel>();

            try
            {
                if (parentViewModel?.IsBusy != false)
                {
                    return;
                }

                parentViewModel.BeginBusy();

                var detailVideoView = _unityContainer.Resolve<IDetailVideoView>();
                await _navigationService.NavigateToPage(detailVideoView, PageTitles.VideoDetails);
                await detailVideoView.Initialize();
            }
            catch (Exception exception)
            {
                _loggingService.Error(exception);
                _dialogService.ShowToastMessage(PageTitles.ApplicationTitle, Messages.UnExpectedError, ToastNotificationType.Error);
            }
            finally
            {
                parentViewModel?.EndBusy();

            }
        }
    }
}
