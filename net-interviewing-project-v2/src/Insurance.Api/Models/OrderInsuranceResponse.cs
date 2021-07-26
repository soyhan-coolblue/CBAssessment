using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Api.Models
{
    public class OrderInsuranceResponse
    {
        public long OrderId { get; set; }
        public decimal OrderInsuranceValue { get; set; }
    }
}
