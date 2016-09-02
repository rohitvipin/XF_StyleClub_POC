namespace XF_StyleClub_POC.Entities
{
    public class ServiceResponseEntity<T>
    {
        public WebResponseEntity WebResponseEntity { get; set; }
        public T ReturnValue { get; set; }
    }
}