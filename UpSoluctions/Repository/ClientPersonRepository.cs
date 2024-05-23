using UpSoluctions.Data;
using UpSoluctions.Models;
using UpSoluctions.Repository.Interfaces;

namespace UpSoluctions.Repository
{
    public class ClientPersonRepository : GenericRepository<ClientPersonMd>, IClientPersonRepository
    {
        public ClientPersonRepository(SystemContext context) : base(context)
        {
        }
    }
}
