using UpSoluctions.Data;
using UpSoluctions.Data.Entities;
using UpSoluctions.API.Repository.Interfaces;

namespace UpSoluctions.API.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(SystemContext context) : base(context)
        {
        }
    }
}
