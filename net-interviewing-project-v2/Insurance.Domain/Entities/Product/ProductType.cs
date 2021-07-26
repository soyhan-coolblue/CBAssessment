using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Entities.Product
{
    public class ProductType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool CanBeInsured { get; set; }
    }
}
