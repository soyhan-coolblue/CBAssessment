using Insurance.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces
{
    public interface IInsuranceRepository
    {
        Task<ProductInsurance> GetProductInsurance(long productId);
        decimal CalculateProductInsuranceValue(ProductInsurance productInsurance);
        decimal CalculateOrderInsuranceValue(List<ProductInsurance> productInsurances);
    }
}
