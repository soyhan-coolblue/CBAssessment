using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Insurance.Domain.Entities.Product
{
    public class ProductModel
    { 
        public long Id { get; set; }

        public string Name { get; set; }

        public long ProductTypeId { get; set; }

        public decimal SalesPrice { get; set; }
    }
}
