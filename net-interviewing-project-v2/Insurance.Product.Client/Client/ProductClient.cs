using Insurance.Domain.Entities.Product;
using Insurance.Domain.Entities.Utility.Exceptions;
using Insurance.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Insurance.Product.Client
{
    public class ProductClient : IProductClient
    {
        private readonly HttpClient _httpClient;

        public ProductClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductModel> GetProduct(long ProductId)
        {
            var response = await _httpClient.GetAsync(string.Format("/products/{0:G}", ProductId));

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductModel>(stringResponse);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new NotFoundException(nameof(ProductModel), ProductId.ToString());
            else
                throw new ApiException();
        }

        public async Task<IReadOnlyCollection<ProductModel>> GetProducts()
        {
            return await Get<IReadOnlyCollection<ProductModel>>("products");
        }

        public async Task<ProductType> GetProductType(long ProductTypeId)
        {
            var response = await _httpClient.GetAsync(string.Format("/product_types/{0:G}", ProductTypeId));

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductType>(stringResponse);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new NotFoundException(nameof(ProductModel), ProductTypeId.ToString());
            else
                throw new ApiException();
        }

        public async Task<IReadOnlyCollection<ProductType>> GetProductTypes()
        {
            return await Get<IReadOnlyCollection<ProductType>>("product_types");
        }

        private async Task<T> Get<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                var stringResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(stringResponse);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}
