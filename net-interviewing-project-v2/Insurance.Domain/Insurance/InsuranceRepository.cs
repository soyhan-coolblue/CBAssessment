using Insurance.Domain.Entities.Product;
using Insurance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Insurance.Domain.Insurance
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly IProductClient _productClient;

        //Read this from appsettings to make it more configurable
        private readonly IEnumerable<string> ExtraInsuranceProductTypes = new List<string>() { "Laptops", "Smartphones" };

        public InsuranceRepository(IProductClient productClient)
        {
            _productClient = productClient;
        }

        public async Task<ProductInsurance> GetProductInsurance(long productId)
        {
            var product = await _productClient.GetProduct(productId);

            var productType = await _productClient.GetProductType(product.ProductTypeId);

            return BuildProductInsurance(productType.Name, product.SalesPrice, productType.CanBeInsured);
        }

        public decimal CalculateProductInsuranceValue(ProductInsurance productInsurance)
        {
            var insuranceValue = 0m;

            if (!productInsurance.CanBeInsured)
                return insuranceValue;

            if (productInsurance.SalesPrice < 500 && productInsurance.ProductTypeName != "Laptops")
                return insuranceValue;

            insuranceValue += CalculateSalesPriceInsuranceValue(productInsurance.SalesPrice);
            insuranceValue += CalculateProductTypeInsuranceValue(productInsurance.ProductTypeName);

            return insuranceValue;
        }

        public decimal CalculateOrderInsuranceValue(List<ProductInsurance> productInsurances)
        {
            var insuranceValue = 0m;

            foreach (var productInsurance in productInsurances)
                insuranceValue += CalculateProductInsuranceValue(productInsurance);

            if (productInsurances.Any(x => string.Equals(x.ProductTypeName, "Digital Cameras", StringComparison.OrdinalIgnoreCase)))
                insuranceValue += 500;

            return insuranceValue;
        }

        private ProductInsurance BuildProductInsurance(string productTypeName, decimal salesPrice, bool canBeInsured)
        {
            return new ProductInsurance()
            {
                CanBeInsured = canBeInsured,
                SalesPrice = salesPrice,
                ProductTypeName = productTypeName
            };
        }

        private decimal CalculateProductTypeInsuranceValue(string productTypeName)
        {
            var insuranceValue = 0m;

            if (ExtraInsuranceProductTypes.Contains(productTypeName))
                insuranceValue += 500;

            return insuranceValue;
        }

        private decimal CalculateSalesPriceInsuranceValue(decimal salesPrice)
        {
            var insuranceValue = 0m;

            if (salesPrice < 500)
                return insuranceValue;

            if (salesPrice >= 500 && salesPrice < 2000)
                insuranceValue += 1000;
            if (salesPrice >= 2000)
                insuranceValue += 2000;

            return insuranceValue;
        }
    }
}
