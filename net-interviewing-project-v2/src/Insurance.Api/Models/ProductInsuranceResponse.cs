using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Api.Models
{
    public class ProductInsuranceResponse
    {
        public long ProductId { get; set; }
        public decimal InsuranceValue { get; set; }
    }
}
