using UpSoluctions.Data;
using UpSoluctions.Data.Entities;
using UpSoluctions.API.Repository.Interfaces;

namespace UpSoluctions.API.Repository
{
    public class PublishingCompanyRepository : GenericRepository<PublishingCompany>, IPublishingCompany
    {
        public PublishingCompanyRepository(SystemContext context) : base(context)
        {
        }
    }
}
