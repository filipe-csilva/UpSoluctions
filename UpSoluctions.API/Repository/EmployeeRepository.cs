using Microsoft.EntityFrameworkCore;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data;
using UpSoluctions.Data.Entities;

namespace UpSoluctions.API.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SystemContext context) : base(context)
        {
        }

        public async Task<Employee> GetByEmailAsync(string Email)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Email == Email);
        }
    }
}
