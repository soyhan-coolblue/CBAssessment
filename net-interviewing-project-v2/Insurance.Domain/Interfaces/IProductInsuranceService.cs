
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces
{
    public interface IInsuranceService
    {
        Task<decimal> CalculateProductInsuranceValue(long productid);
        Task<decimal> CalculateOrderInsuranceValue(IReadOnlyCollection<long> productIds);
    }
}
