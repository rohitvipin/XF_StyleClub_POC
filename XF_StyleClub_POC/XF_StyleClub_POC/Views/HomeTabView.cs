using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views
{
    public class HomeTabView : TabbedPage, IHomeTabView
    {
        public HomeTabView(IEnumerable<IView> childViews)
        {
            foreach (var childView in childViews)
            {
                Children.Add(childView as Page);
            }
            SelectedItem = Children?.FirstOrDefault();
            BindablePage = this;
            BarBackgroundColor = Color.FromHex("#F9F9F9");
            BarTextColor = Color.FromHex("#BDCBE5");
        }


        public Page BindablePage { get; }

        public async Task Initialize() => await Task.WhenAll(Children.Select(child => (child as IView)?.Initialize()).ToArray());
    }
}