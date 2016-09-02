using System.Threading.Tasks;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Services.Interfaces
{
    public interface INavigationService
    {
        App AppRoot { get; set; }
        void SetRoot(IView view, string pageTitle);
        Task NavigateToPage(IView view, string pageTitle);
        Task GoBack(bool isModal);
    }
}