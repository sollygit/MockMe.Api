using Microsoft.Extensions.Logging;
using MockMe.Common;
using MockMe.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MockMe.Api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(int id);
    }

    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = new List<Product>();

            try
            {
                products = MockUtil.Products(10);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductService GetAll Error", ex);
            }

            return await Task.FromResult(products);
        }

        public Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
