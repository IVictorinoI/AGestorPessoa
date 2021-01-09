using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Config.Exceptions
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;

        public int ErrorCode { get; set; }

        public object Value { get; set; }
    }
}
