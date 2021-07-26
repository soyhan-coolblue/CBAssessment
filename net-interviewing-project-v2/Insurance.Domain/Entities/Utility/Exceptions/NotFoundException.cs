using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Entities.Utility.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity,string value):base($"{entity} with {value} could not be found")
        { }

        public int StatusCode { get; set; } = 404;

        public object Value { get; set; }
    }
}
