using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Entities.Product
{
    public class ProductInsurance
    {
        public string ProductTypeName { get; set; }
        public bool CanBeInsured { get; set; }
        public decimal SalesPrice { get; set; }
    }
}
