using System.Net;

namespace FinShark.API.Helpers
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; } = true;
        public HttpStatusCode StatusCode { get; set; }
        public object? Result { get; set; }
        public List<string> ErrorMessage { get; set; } = new();
    }
}
