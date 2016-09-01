﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_StyleClub_POC.Services.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Services
{
    public class NavigationService : INavigationService
    {
        public App AppRoot { get; set; }

        public void SetRoot(IView view, string pageTitle)
        {
            var page = view as Page;
            if (page == null)
            {
                return;
            }
            page.Title = pageTitle;

            AppRoot.MainPage = page;
        }

        public async Task NavigateFromRootPage(IView view, string pageTitle)
        {
            var page = view as Page;
            if (page == null)
            {
                return;
            }
            page.Title = pageTitle;
            await AppRoot.MainPage.Navigation.PushAsync(page, true);
        }

        public async Task GoBack(bool isModal)
        {
            if (isModal)
            {
                await AppRoot.MainPage.Navigation.PopModalAsync();
            }
            else
            {
                await AppRoot.MainPage.Navigation.PopAsync();
            }
        }

		public async Task NavigateFromTabPage(IView view, string pageTitle)
		{
			var page = view as Page;
			if (page == null)
			{
				return;
			}
			page.Title = pageTitle;
			await ((AppRoot.MainPage as TabbedPage)?.SelectedItem as NavigationPage)?.Navigation.PushAsync(page, true);
		}
	}
}