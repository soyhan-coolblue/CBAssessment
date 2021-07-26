using Insurance.Domain.Entities.Product;
using Insurance.Domain.Insurance;
using Insurance.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Insurance.Api.Tests
{
    public class OrderInsuranceServiceUnitTests
    {
        private readonly Mock<IProductClient> ProductClientMock = new Mock<IProductClient>();

        [Fact]
        public void CalculateOrderInsurance_GivenTwoDigitalCamerasInOrder_ShouldAddTwoThousandToInsuranceCost()
        {
            const decimal expectedInsuranceValue = 2500;

            var productInsuranceList = new List<ProductInsurance>()
            {
                new ProductInsurance()
                {
                    CanBeInsured = true,
                    ProductTypeName = "Digital Cameras",
                    SalesPrice = 600
                },
                 new ProductInsurance()
                {
                    CanBeInsured = true,
                    ProductTypeName = "Digital Cameras",
                    SalesPrice = 250
                },
                 new ProductInsurance()
                {
                    CanBeInsured = true,
                    ProductTypeName = "Washing Machines",
                    SalesPrice = 1100
                }
            };

            var insuranceService = new InsuranceRepository(ProductClientMock.Object);

            var insuranceValue = insuranceService.CalculateOrderInsuranceValue(productInsuranceList);

            Assert.Equal(
                expected: expectedInsuranceValue,
                        actual: insuranceValue
                    );
        }

        [Fact]
        public void CalculateOrderInsurance_GivenThreeItems_ShouldAddTwoThousandEurosToInsuranceValue()
        {
            const decimal expectedInsuranceValue = 2000;

            var productInsuranceList = new List<ProductInsurance>()
            {
                new ProductInsurance()
                {
                    CanBeInsured = true,
                    ProductTypeName = "Laptops",
                    SalesPrice = 400
                },
                 new ProductInsurance()
                {
                    CanBeInsured = true,
                    ProductTypeName = "Digital Cameras",
                    SalesPrice = 250
                },
                 new ProductInsurance()
                {
                    CanBeInsured = true,
                    ProductTypeName = "Washing Machines",
                    SalesPrice = 500
                }
            };

            var insuranceService = new InsuranceRepository(ProductClientMock.Object);

            var insuranceValue = insuranceService.CalculateOrderInsuranceValue(productInsuranceList);

            Assert.Equal(
                expected: expectedInsuranceValue,
                        actual: insuranceValue
                    );
        }

    }
}
