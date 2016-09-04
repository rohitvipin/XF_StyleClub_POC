using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XF_StyleClub_POC.Entities;
using XF_StyleClub_POC.Models;
using XF_StyleClub_POC.Services.Interfaces;
using XF_StyleClub_POC.Wrapper.Interfaces;

namespace XF_StyleClub_POC.Services
{
    public class DataAcessService : IDataAcessService
    {
        private readonly IApiWrapper _apiWrapper;

        public DataAcessService(IApiWrapper apiWrapper)
        {
            _apiWrapper = apiWrapper;
        }

        public async Task<ServiceResponseEntity<List<Product>>> GetAllProducts()
        {
            var response = await _apiWrapper.GetAllProducts(null, null);

            if (response == null)
            {
                return new ServiceResponseEntity<List<Product>>
                {
                    ReturnValue = null,
                    WebResponseEntity = null
                };
            }

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponseEntity<List<Product>>
                {
                    ReturnValue = null,
                    WebResponseEntity = response
                };
            }

            return new ServiceResponseEntity<List<Product>>
            {
                ReturnValue = JsonConvert.DeserializeObject<List<Product>>(response.WebResponseContent) ?? new List<Product>(),
                WebResponseEntity = response
            };
        }
    }
}