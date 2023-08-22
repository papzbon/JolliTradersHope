using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolliTradersHope.Shared.Models
{
    public sealed class ApiResponse<TData>
    {
        public ApiResponse(TData data = default!) => Data = data;

        public bool Status { get; set; } = true;
        public IEnumerable<string>? Errors { get; set; }
        public int StatusCode { get; set; } = 200;
        public TData Data { get; set; }

        public static ApiResponse<TData> Success(int statusCode, TData data = default!) =>
            new(data)
            {
                StatusCode = statusCode,
                Status = true
            };

        //public static ApiResponse<TData> Success(TData data = default!, HttpStatusCode statusCode = HttpStatusCode);
    }
}
