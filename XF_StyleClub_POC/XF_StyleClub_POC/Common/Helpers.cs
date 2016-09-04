using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XF_StyleClub_POC.Entities;
using XF_StyleClub_POC.Enums;

namespace XF_StyleClub_POC.Common
{
    public static class Helpers
    {
        public static async Task<WebResponseEntity> MakeAJsonCallAndGetResult(string serviceUrl, HttpRequestType httpRequestType = HttpRequestType.Get, string input = null,
                                                                              IDictionary<string, string> httpRequestHeaders = null)
        {
            using (var httpMessageHandler = new HttpClientHandler { AllowAutoRedirect = false })
            {
                using (var client = new HttpClient(httpMessageHandler)
                {
                    BaseAddress = new Uri(Constants.BaseUrl),
                })
                {
                    StringContent stringContentInput = null;
                    const string inputContentDataType = "application/json";
                    if (input != null)
                    {
                        stringContentInput = new StringContent(input, Encoding.UTF8, inputContentDataType);
                    }

                    client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
                    if (httpRequestHeaders != null)
                    {
                        foreach (var key in httpRequestHeaders.Keys)
                        {
                            client.DefaultRequestHeaders.Add(key, httpRequestHeaders[key]);
                        }
                    }

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(inputContentDataType));

                    HttpResponseMessage response;
                    var requestUri = new Uri(serviceUrl);

                    switch (httpRequestType)
                    {
                        case HttpRequestType.Get:
                            response = await client.GetAsync(requestUri);
                            break;

                        case HttpRequestType.Post:
                            response = await client.PostAsync(requestUri, stringContentInput);
                            break;

                        case HttpRequestType.Put:
                            response = await client.PutAsync(requestUri, stringContentInput);
                            break;

                        case HttpRequestType.Delete:
                            response = await client.SendAsync(new HttpRequestMessage
                            {
                                Content = stringContentInput,
                                Method = HttpMethod.Delete,
                                RequestUri = requestUri
                            });
                            break;

                        default:
                            throw new Exception("Unexpected http header.");
                    }

                    var responseJson = await response.Content.ReadAsStringAsync();

                    return new WebResponseEntity(response.IsSuccessStatusCode)
                    {
                        WebResponseContent = responseJson,
                        ResponseCode = response.StatusCode
                    };
                }
            }
        }
    }
}