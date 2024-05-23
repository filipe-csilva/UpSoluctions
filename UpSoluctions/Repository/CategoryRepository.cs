using UpSoluctions.Data;
using UpSoluctions.Models;
using UpSoluctions.Repository.Interfaces;

namespace UpSoluctions.Repository
{
    public class CategoryRepository : GenericRepository<CategoryMd>, ICategoryRepository
    {
        public CategoryRepository(SystemContext context) : base(context)
        {
        }
    }
}
