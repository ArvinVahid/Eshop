using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;

namespace Eshop.Core.Services.UserServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategories(CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAllCategories(cancellationToken);
        }
    }
}