using UpSoluctions.Data;
using UpSoluctions.Models;
using UpSoluctions.Repository.Interfaces;

namespace UpSoluctions.Repository
{
    public class AuthorRepository : GenericRepository<AuthorMd>, IAuthorRepository
    {
        public AuthorRepository(SystemContext context) : base(context)
        {
        }
    }
}
