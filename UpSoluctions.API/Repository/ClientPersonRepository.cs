using UpSoluctions.Data;
using UpSoluctions.Data.Entities;
using UpSoluctions.API.Repository.Interfaces;

namespace UpSoluctions.API.Repository
{
    public class ClientPersonRepository : GenericRepository<ClientPerson>, IClientPersonRepository
    {
        public ClientPersonRepository(SystemContext context) : base(context)
        {
        }
    }
}
