using XF_StyleClub_POC.Common;

namespace XF_StyleClub_POC.ViewModels.Interfaces
{
    public interface IRegisterViewModel : IViewModel
    {
        AsyncRelayCommand RegisterCommand { get; }
    }
}