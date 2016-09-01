using System.Collections.Generic;
using System.Threading.Tasks;
using EmoMe.Services;
using EmoMe.Services.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Services;
using XF_StyleClub_POC.Services.Interfaces;
using XF_StyleClub_POC.ViewModels;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var unityContainer = new UnityContainer();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));

            RegisterTypes(unityContainer);

            var navigationService = unityContainer.Resolve<INavigationService>();
            navigationService.AppRoot = this;

            var childTabs = new List<IView>
            {
                unityContainer.Resolve<IWatchView>(),
                unityContainer.Resolve<IShopView>()
            };
            var homeTabView = unityContainer.Resolve<IHomeTabView>(new ParameterOverride("childViews", childTabs));
            Task.Run(async () => await homeTabView.Initialize());
            navigationService.SetRoot(homeTabView, PageTitles.ApplicationTitle);
        }

        private static void RegisterTypes(IUnityContainer unityContainer)
        {
            if (unityContainer == null)
            {
                return;
            }

            //Views
            unityContainer.RegisterType<IHomeTabView, HomeTabView>();
            unityContainer.RegisterType<IWatchView, WatchView>();
            unityContainer.RegisterType<IShopView, ShopView>();
            unityContainer.RegisterType<ILoginView, LoginView>();
            unityContainer.RegisterType<IDetailVideoView, DetailVideoView>();


            //ViewModels
            unityContainer.RegisterType<IWatchViewModel, WatchViewModel>();
            unityContainer.RegisterType<IShopViewModel, ShopViewModel>();
            unityContainer.RegisterType<ILoginViewModel, LoginViewModel>();
            unityContainer.RegisterType<IWatchViewModel, WatchViewModel>();

            //Services
            unityContainer.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ILoggingService, LoggingService>(new ContainerControlledLifetimeManager());
        }
    }
}
