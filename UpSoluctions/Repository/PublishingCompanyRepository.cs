using UpSoluctions.Data;
using UpSoluctions.Models;
using UpSoluctions.Repository.Interfaces;

namespace UpSoluctions.Repository
{
    public class PublishingCompanyRepository : GenericRepository<PublishingCompanyMd>, IPublishingCompany
    {
        public PublishingCompanyRepository(SystemContext context) : base(context)
        {
        }
    }
}
