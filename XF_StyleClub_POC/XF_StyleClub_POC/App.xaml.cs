using System.Collections.Generic;
using System.Threading.Tasks;
using XF_StyleClub_POC.Services;
using XF_StyleClub_POC.Services.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using XF_StyleClub_POC.Common;
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
            navigationService.SetRoot(homeTabView, PageTitles.ApplicationTitle);
            Task.Run(async () => await homeTabView.Initialize());
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
            unityContainer.RegisterType<IShopifyWebView, ShopifyWebView>();


            //ViewModels
            unityContainer.RegisterType<IWatchViewModel, WatchViewModel>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IShopViewModel, ShopViewModel>();
            unityContainer.RegisterType<ILoginViewModel, LoginViewModel>();
            unityContainer.RegisterType<IWatchViewModel, WatchViewModel>();
            unityContainer.RegisterType<IDetailVideoViewModel, DetailVideoViewModel>();
            unityContainer.RegisterType<IShopifyWebViewModel, ShopifyWebViewModel>();


            //Services
            unityContainer.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ILoggingService, LoggingService>(new ContainerControlledLifetimeManager());
        }
    }
}
