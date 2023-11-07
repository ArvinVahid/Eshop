using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Core.Services.UserServices
{
    public class CategoryToProductServices : ICategoryToProductServices
    {
        private readonly ICategoryToProductRepository _toProductRepository;
        public CategoryToProductServices(ICategoryToProductRepository toProductRepository)
        {
            _toProductRepository = toProductRepository;
        }

        public async Task<List<Product>> GetProductsByGroupId(int id, CancellationToken cancellationToken)
        {
            return await _toProductRepository.GetProductsByGroupId(id, cancellationToken);
        }
    }
}