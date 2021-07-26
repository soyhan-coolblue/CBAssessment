using Insurance.Api.Services;
using Insurance.Domain.Entities.Product;
using Insurance.Domain.Insurance;
using Insurance.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Insurance.Api.Tests
{
    public class ProductInsuranceServiceUnitTests
    {
        private readonly Mock<IProductClient> ProductClientMock = new Mock<IProductClient>();
        private readonly Mock<IInsuranceRepository> InsuranceRepositoryMock = new Mock<IInsuranceRepository>();


        [Fact]
        public void CalculateInsurance_GivenSalesPrice_LessThanFiveHundred_ShouldNotAddToInsuranceCost()
        {
            const decimal expectedInsuranceValue = 0;
            var productId = 1;

            var testProduct = new ProductModel()
            {
                Id = productId,
                Name = "Test Product",
                ProductTypeId = 1,
                SalesPrice = 350
            };

            var testProductType = new ProductType()
            {
                Id = 1,
                Name = "Washing Machines",
                CanBeInsured = true
            };

            var testProductInsurance = new ProductInsurance()
            {
                ProductTypeName = testProductType.Name,
                CanBeInsured = testProductType.CanBeInsured,
                SalesPrice = testProduct.SalesPrice
            };

            ProductClientMock.Setup(x => x.GetProduct(productId)).ReturnsAsync(testProduct);
            ProductClientMock.Setup(x => x.GetProductType(testProduct.ProductTypeId)).ReturnsAsync(testProductType);



            var insuranceService = new InsuranceRepository(ProductClientMock.Object);

            var insuranceValue = insuranceService.CalculateProductInsuranceValue(testProductInsurance);

            Assert.Equal(
                expected: expectedInsuranceValue,
                        actual: insuranceValue
                    );
        }


        [Fact]
        public void CalculateInsurance_GivenSalesPriceBetween500And2000Euros_ShouldAddThousandEurosToInsuranceCost()
        {

            const decimal expectedInsuranceValue = 1000;
            var productId = 1;

            var testProduct = new ProductModel()
            {
                Id = productId,
                Name = "Test Product",
                ProductTypeId = 1,
                SalesPrice = 750
            };

            var testProductType = new ProductType()
            {
                Id = 1,
                Name = "Test type",
                CanBeInsured = true
            };

            var testProductInsurance = new ProductInsurance()
            {
                ProductTypeName = testProductType.Name,
                CanBeInsured = testProductType.CanBeInsured,
                SalesPrice = testProduct.SalesPrice
            };

            //ProductClientMock.Setup(x => x.GetProduct(productId)).ReturnsAsync(testProduct);
            //ProductClientMock.Setup(x => x.GetProductType(testProduct.ProductTypeId)).ReturnsAsync(testProductType);


            var insuranceService = new InsuranceRepository(ProductClientMock.Object);

            var insuranceValue = insuranceService.CalculateProductInsuranceValue(testProductInsurance);

            Assert.Equal(
                expected: expectedInsuranceValue,
                    actual: insuranceValue
                );
        }

        [Fact]
        public void CalculateInsurance_GivenSalesPrice350_LaptopProductType_ShouldAddFiveHundredToInsuranceCost()
        {
            const decimal expectedInsuranceValue = 500;
            var productId = 1;

            var testProduct = new ProductModel()
            {
                Id = productId,
                Name = "Test Product",
                ProductTypeId = 1,
                SalesPrice = 350
            };

            var testProductType = new ProductType()
            {
                Id = 1,
                Name = "Laptops",
                CanBeInsured = true
            };

            var testProductInsurance = new ProductInsurance()
            {
                ProductTypeName = testProductType.Name,
                CanBeInsured = testProductType.CanBeInsured,
                SalesPrice = testProduct.SalesPrice
            };

            ProductClientMock.Setup(x => x.GetProduct(productId)).ReturnsAsync(testProduct);
            ProductClientMock.Setup(x => x.GetProductType(testProduct.ProductTypeId)).ReturnsAsync(testProductType);


            var insuranceService = new InsuranceRepository(ProductClientMock.Object);

            var insuranceValue = insuranceService.CalculateProductInsuranceValue(testProductInsurance);

            Assert.Equal(
                expected: expectedInsuranceValue,
                        actual: insuranceValue
                    );
        }


        [Fact]
        public void CalculateInsurance_GivenSalesPrice2000_ShouldAddTwoThousandToInsuranceCost()
        {
            const decimal expectedInsuranceValue = 2000;
            var productId = 1;

            var testProduct = new ProductModel()
            {
                Id = productId,
                Name = "Test Product",
                ProductTypeId = 1,
                SalesPrice = 2000
            };

            var testProductType = new ProductType()
            {
                Id = 1,
                Name = "Washing Machines",
                CanBeInsured = true
            };

            var testProductInsurance = new ProductInsurance()
            {
                ProductTypeName = testProductType.Name,
                CanBeInsured = testProductType.CanBeInsured,
                SalesPrice = testProduct.SalesPrice
            };

            ProductClientMock.Setup(x => x.GetProduct(productId)).ReturnsAsync(testProduct);
            ProductClientMock.Setup(x => x.GetProductType(testProduct.ProductTypeId)).ReturnsAsync(testProductType);

            var insuranceService = new InsuranceRepository(ProductClientMock.Object);
            var insuranceValue = insuranceService.CalculateProductInsuranceValue(testProductInsurance);

            Assert.Equal(
                expected: expectedInsuranceValue,
                        actual: insuranceValue
                    );
        }
    }
}
