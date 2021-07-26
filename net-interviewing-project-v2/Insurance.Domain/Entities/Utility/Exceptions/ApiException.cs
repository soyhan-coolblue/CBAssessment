using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Entities.Utility.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; } = 500;

        public object Value { get;  set; }
    }
}
