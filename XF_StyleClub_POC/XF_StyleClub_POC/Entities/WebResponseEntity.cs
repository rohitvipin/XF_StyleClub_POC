using System.Net;

namespace XF_StyleClub_POC.Entities
{
    public class WebResponseEntity
    {
        public WebResponseEntity(bool isSuccessResponse)
        {
            IsSuccessStatusCode = isSuccessResponse;
        }

        public string WebResponseContent { get; set; }

        public HttpStatusCode ResponseCode { get; set; }

        public bool IsSuccessStatusCode { get; }
    }
}