using System.Collections.Generic;
using System.Threading.Tasks;
using XF_StyleClub_POC.Common;
using XF_StyleClub_POC.Entities;
using XF_StyleClub_POC.Enums;
using XF_StyleClub_POC.Wrapper.Interfaces;

namespace XF_StyleClub_POC.Wrapper
{
    public class ApiWrapper : IApiWrapper
    {
        public async Task<WebResponseEntity> GetAllProducts(string input, IDictionary<string, string> httpRequestHeaders) =>
            await Helpers.MakeAJsonCallAndGetResult(Constants.GetAllProductsUrl, HttpRequestType.Get, httpRequestHeaders: httpRequestHeaders, input: input);

    }
}