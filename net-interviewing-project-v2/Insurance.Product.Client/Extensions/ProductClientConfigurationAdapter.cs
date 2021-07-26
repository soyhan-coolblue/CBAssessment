using Insurance.Domain.Interfaces;
using Insurance.Product.Configs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace Insurance.Product.Extensions
{
    public static class ProductClientConfigurationAdapter
    {
        public static void AddProductApiClient(this IServiceCollection services, ProductApiConfig _config)
        {
           services.AddHttpClient<IProductClient, Client.ProductClient>(client =>
           {
               client.BaseAddress = new Uri(_config.BaseUrl);
           });
        }
    }
}
