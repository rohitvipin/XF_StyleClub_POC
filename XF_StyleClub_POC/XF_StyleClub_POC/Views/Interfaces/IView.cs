using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_StyleClub_POC.Views.Interfaces
{
    public interface IView
    {
        Page BindablePage { get; }

        Task Initialize();
    }
}