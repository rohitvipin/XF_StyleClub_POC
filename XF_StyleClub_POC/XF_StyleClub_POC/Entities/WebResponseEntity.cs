namespace XF_StyleClub_POC.Entities
{
    public class WebResponseEntity
    {
        public string WebResponseContent { get; set; }

        public int ResponseCode { get; set; } = 999;

        public bool IsSuccessResponse => ResponseCode == 200;
    }
}