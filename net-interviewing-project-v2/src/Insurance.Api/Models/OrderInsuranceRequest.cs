using Insurance.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Insurance.Api.Models
{
    public class OrderInsuranceRequest
    {
        [Required]
        public long OrderId { get; set; }

        [Required]
        public List<long> ProductIds { get; set; }
    }
}
