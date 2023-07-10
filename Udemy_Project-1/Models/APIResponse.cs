using System.Net;

namespace Udemy_Project_1.Models
{
    public class APIResponse
    {
         public APIResponse() {
            ErrorsMsg = new List<string>();
                }
		public HttpStatusCode statusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorsMsg { get; set; }
        public object Result { get; set; }
    }
}
