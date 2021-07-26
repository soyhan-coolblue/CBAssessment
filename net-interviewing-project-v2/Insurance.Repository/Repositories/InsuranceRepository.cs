using Insurance.Domain.Entities.Product;
using Insurance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Repository.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        public decimal CalculateOrderInsuranceValue(List<ProductInsurance> productInsurances)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateProductInsuranceValue(ProductInsurance productInsurance)
        {
            var insuranceValue = 0;

            if (!productInsurance.CanBeInsured)
                return insuranceValue;

            if (productInsurance.SalesPrice < 500 && productInsurance.ProductTypeName != "Laptops")
                insuranceValue = 0;
            else
            {
                if (productInsurance.SalesPrice >= 500 && productInsurance.SalesPrice < 2000)
                    insuranceValue += 1000;
                if (productInsurance.SalesPrice >= 2000)
                    insuranceValue += 2000;
                if (productInsurance.ProductTypeName == "Laptops" || productInsurance.ProductTypeName == "Smartphones")
                    insuranceValue += 500;
            }

            return insuranceValue;
        }
    }
}
