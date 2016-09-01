using XF_StyleClub_POC.Common;

namespace XF_StyleClub_POC.ViewModels.Interfaces
{
    public interface ILoginViewModel : IViewModel
    {
        AsyncRelayCommand LoginCommand { get; }
    }
}