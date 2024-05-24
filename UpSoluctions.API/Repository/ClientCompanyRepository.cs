using UpSoluctions.Data;
using UpSoluctions.Data.Entities;
using UpSoluctions.API.Repository.Interfaces;

namespace UpSoluctions.API.Repository
{
    public class ClientCompanyRepository : GenericRepository<ClientCompany>, IClientCompanyRepository
    {
        public ClientCompanyRepository(SystemContext context) : base(context)
        {
        }
    }
}
