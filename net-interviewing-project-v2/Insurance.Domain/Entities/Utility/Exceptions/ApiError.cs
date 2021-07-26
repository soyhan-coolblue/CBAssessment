using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Entities.Utility.Exceptions
{
    public class ApiError
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public string Detail { get; set; }
      

        public ApiError(string message)
        {
            this.Message = message;
            IsError = true;
        }
    }
}
