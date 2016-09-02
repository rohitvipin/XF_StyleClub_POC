using System;
using System.Collections.ObjectModel;
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
        private ObservableCollection<ImageEntity> _products;
        private readonly IUnityContainer _unityContainer;
        private readonly INavigationService _navigationService;
        private readonly ILoggingService _loggingService;
        private readonly IDialogService _dialogService;

        public WatchViewModel(IUnityContainer unityContainer, INavigationService navigationService, ILoggingService loggingService, IDialogService dialogService) : base(dialogService)
        {
            _dialogService = dialogService;
            _unityContainer = unityContainer;
            _navigationService = navigationService;
            _loggingService = loggingService;
        }

        public ObservableCollection<ImageEntity> Products
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

                Products = new ObservableCollection<ImageEntity>
                {
                    new ImageEntity(_unityContainer, _navigationService, _loggingService, _dialogService)
                    {
                        Title = "Title 1",
                        Description = "Description 1",
                        ImageUrl = "http://keenthemes.com/preview/metronic/theme/assets/global/plugins/jcrop/demos/demo_files/image1.jpg"
                    },
                    new ImageEntity(_unityContainer, _navigationService, _loggingService, _dialogService)
                    {
                        Title = "Title 2",
                        Description = "Description 2",
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIiE4UrM1WYxr5HQQyvouLkG4NGOeezW1U3XwD8PpPdoLf3_M"
                    },
                    new ImageEntity(_unityContainer, _navigationService, _loggingService, _dialogService)
                    {
                        Title = "Title 3",
                        Description = "Description 3",
                        ImageUrl = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg"
                    }
                };

                //Delay to load the image from Url
                await Task.Delay(200);
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
