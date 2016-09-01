using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XF_StyleClub_POC.Services.Interfaces;
using Microsoft.Practices.Unity;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Entities;
using XF_StyleClub_POC.Services.Interfaces;
using XF_StyleClub_POC.ViewModels.Interfaces;

namespace XF_StyleClub_POC.ViewModels
{
	public partial class WatchViewModel : BaseViewModel, IWatchViewModel
	{
		private ObservableCollection<ImageEntity> _styleClub;
		private readonly IUnityContainer _unityContainer;
		private readonly INavigationService _navigationService;
		private readonly ILoggingService _loggingService;
		private readonly IDialogService _dialogService;

		public WatchViewModel(IUnityContainer unityContainer, INavigationService navigationService, ILoggingService loggingService, IDialogService dialogService)
		{
			_unityContainer = unityContainer;
			_navigationService = navigationService;
			_loggingService = loggingService;
			_dialogService = dialogService;
		}

		//TODO : WHY DO YOU NAME A PROPERTY StyleClub????
		public ObservableCollection<ImageEntity> StyleClub
		{
			get { return _styleClub; }
			set
			{
				_styleClub = value;
				OnPropertyChanged();
			}
		}

		public override string PageTitle => PageTitles.WatchTab;

		public override async Task Initialize()
		{
			try
			{
				StyleClub = new ObservableCollection<ImageEntity>
				{
					new ImageEntity(_unityContainer, _navigationService,_loggingService,_dialogService)
					{
					  Title  = "Title 1",
					  Description = "Description 1",
					  ImageSource = "http://keenthemes.com/preview/metronic/theme/assets/global/plugins/jcrop/demos/demo_files/image1.jpg"
					},
					 new ImageEntity(_unityContainer, _navigationService,_loggingService,_dialogService)
					{
					  Title  = "Title 2",
					  Description = "Description 2",
					  ImageSource = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIiE4UrM1WYxr5HQQyvouLkG4NGOeezW1U3XwD8PpPdoLf3_M"
					},
					  new ImageEntity(_unityContainer, _navigationService,_loggingService,_dialogService)
					{
					  Title  = "Title 3",
					  Description = "Description 3",
					  ImageSource = "https://s.yimg.com/ge/default/691231/carousel3lg.jpg"
					}
				};
			}
			catch (Exception)
			{
				//TODO : DO NOT THROW FROM VM, Handle error and use user friendly error messages. 
				throw;
			}
		}
	}
}
