using System.Collections.ObjectModel;
using XF_StyleClub_POC.Entities;

namespace XF_StyleClub_POC.ViewModels.Interfaces
{
	public interface IWatchViewModel : IViewModel
	{
		ObservableCollection<ProductEntity> Products { get; set; }
	}
}