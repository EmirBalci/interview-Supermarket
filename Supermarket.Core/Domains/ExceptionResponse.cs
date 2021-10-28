using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Domains
{
    public class ExceptionResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ExceptionResponse(string message, int statusCode = 500)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
