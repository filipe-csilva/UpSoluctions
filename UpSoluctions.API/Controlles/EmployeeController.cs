using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data.Dtos;
using UpSoluctions.Data.Entities;

namespace UpSoluctions.API.Controlles
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ReadEmployeeDto>>> SearchAllAsync()
        {
            ICollection<Employee> employees = await _employeeRepository.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadEmployeeDto>> GetByIdAsync(int id)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(id);

            if(employee == null) return NotFound();

            ReadEmployeeDto employeeReturn = new ReadEmployeeDto(employee.Id, employee.Name, employee.Email, employee.Password, employee.Roles);

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(CreateEmployeeDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
