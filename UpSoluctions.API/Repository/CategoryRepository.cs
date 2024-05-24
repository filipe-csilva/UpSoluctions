using UpSoluctions.Data;
using UpSoluctions.Data.Entities;
using UpSoluctions.API.Repository.Interfaces;

namespace UpSoluctions.API.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SystemContext context) : base(context)
        {
        }
    }
}
