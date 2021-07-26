using Insurance.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces
{
    public interface IProductClient
    {
        Task<ProductType> GetProductType(long ProductTypeId);
        Task<IReadOnlyCollection<ProductType>> GetProductTypes();
        Task<IReadOnlyCollection<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(long ProductId);
    }
}
