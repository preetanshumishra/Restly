namespace Restly.Core.Models
{
    public class RestlyResponseModel<T> : BindableBase
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public object Message { get; set; }
    }
}