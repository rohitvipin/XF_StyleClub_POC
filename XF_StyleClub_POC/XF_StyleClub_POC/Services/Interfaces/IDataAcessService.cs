using System.Collections.Generic;
using Microsoft.Practices.Unity;
using XF_StyleClub_POC.Entities;

namespace XF_StyleClub_POC.Services.Interfaces
{
    public interface IDataAcessService
    {
        IEnumerable<ProductEntity> GetAllProducts(IUnityContainer unityContainer, INavigationService navigationService, ILoggingService loggingService, IDialogService dialogService);
    }
}