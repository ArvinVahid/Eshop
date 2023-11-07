using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.UserServices
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task AddProduct(Product product, CancellationToken cancellationToken)
        {
            await _productRepository.AddProduct(product, cancellationToken);
        }

        public async Task<Product> GetProductByIdIncludeCategoryProducts(int id, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByIdIncludeCategoryProducts(id, cancellationToken);
        }

        public async Task<Product> GetProductById(int id, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductById(id, cancellationToken);
        }

        public async Task<Product> GetAdminProductById(int id, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAdminProductById(id, cancellationToken);

        }
        public async Task<Product> GetProductByIdIncludeItem(int id, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByIdIncludeItem(id, cancellationToken);
        }
        public IQueryable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public async Task RemoveProduct(Product product, CancellationToken cancellationToken)
        {
            await _productRepository.RemoveProduct(product, cancellationToken);
        }
    }
}
