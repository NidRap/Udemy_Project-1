using System.Net;

namespace ConsumingApiSection.Models
{
    public class APIResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorsMsg { get; set; }
        public object Result { get; set; }
    }
}
