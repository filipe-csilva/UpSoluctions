using UpSoluctions.Data;
using UpSoluctions.Models;
using UpSoluctions.Repository.Interfaces;

namespace UpSoluctions.Repository
{
    public class ClientCompanyRepository : GenericRepository<ClientCompanyMd>, IClientCompanyRepository
    {
        public ClientCompanyRepository(SystemContext context) : base(context)
        {
        }
    }
}
