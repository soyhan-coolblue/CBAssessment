using Insurance.Domain.Entities.Product;
using Insurance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Api.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public async Task<decimal> CalculateProductInsuranceValue(long productId)
        {
            var productInsurance = await _insuranceRepository.GetProductInsurance(productId);

            return _insuranceRepository.CalculateProductInsuranceValue(productInsurance);
        }

        public async Task<decimal> CalculateOrderInsuranceValue(IReadOnlyCollection<long> productIds)
        {
            var insuranceValue = 0m;

            var orderInsuranceList = new List<ProductInsurance>();

            foreach (var id in productIds)
                orderInsuranceList.Add(await _insuranceRepository.GetProductInsurance(id));

            insuranceValue = _insuranceRepository.CalculateOrderInsuranceValue(orderInsuranceList);

            return insuranceValue;
        }
    }
}
