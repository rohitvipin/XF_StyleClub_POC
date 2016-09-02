using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using XF_StyleClub_POC.Entities;
using XF_StyleClub_POC.Models;

namespace XF_StyleClub_POC.Services.Interfaces
{
    public interface IDataAcessService
    {
        Task<ServiceResponseEntity<List<Product>>> GetAllProducts();
    }
}