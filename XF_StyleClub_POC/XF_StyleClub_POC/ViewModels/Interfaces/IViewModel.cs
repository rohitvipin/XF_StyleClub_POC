using System.ComponentModel;
using System.Threading.Tasks;

namespace XF_StyleClub_POC.ViewModels.Interfaces
{
    public interface IViewModel : INotifyPropertyChanged
    {
        bool IsBusy { get; }

        bool IsActionsAllowed { get; }

        void BeginBusy();

        void EndBusy();

        string PageTitle { get; }

        Task Initialize();
    }
}