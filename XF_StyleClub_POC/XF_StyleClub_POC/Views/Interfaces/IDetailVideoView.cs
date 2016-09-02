using System.Threading.Tasks;
using XF_StyleClub_POC.Entities;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views.Interfaces
{
    public interface IDetailVideoView : IView
    {
        Task Initialize(ProductEntity product);
    }
}