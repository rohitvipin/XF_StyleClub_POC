using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views
{
	public class HomeTabView : TabbedPage, IHomeTabView
	{
		public HomeTabView(IEnumerable<IView> childViews)
		{
			foreach (var childView in childViews)
			{
				Children.Add(new NavigationPage(childView as Page) { Title = childView.BindablePage.Title });
			}
			SelectedItem = Children?.FirstOrDefault();
			BindablePage = this;
		}

		public Page BindablePage { get; }

		public async Task Initialize()
		{
		}
	}
}