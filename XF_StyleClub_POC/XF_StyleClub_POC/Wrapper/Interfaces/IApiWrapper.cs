using System.Collections.Generic;
using System.Threading.Tasks;
using XF_StyleClub_POC.Entities;

namespace XF_StyleClub_POC.Wrapper.Interfaces
{
    public interface IApiWrapper
    {
        Task<WebResponseEntity> GetAllProducts(string input, IDictionary<string, string> httpRequestHeaders);
    }
}