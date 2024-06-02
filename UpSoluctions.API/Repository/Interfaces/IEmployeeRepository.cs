using UpSoluctions.Data.Entities;

namespace UpSoluctions.API.Repository.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByEmailAsync(string email);
    }
}
