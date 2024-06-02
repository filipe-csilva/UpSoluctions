using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data.Dtos;
using UpSoluctions.Data.Entities;
using UpSoluctions.Services;

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

            ReadEmployeeDto employeeReturn = new ReadEmployeeDto(employee.Id, employee.Name, employee.Email, employee.Password);

            return Ok(employeeReturn);
        }

        [HttpPost]
        public async Task<ActionResult<ReadEmployeeDto>> CreateEmployee(CreateEmployeeDto employeeDto)
        {
            try
            {
                byte[] key;

                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    key = new byte[32];
                    rng.GetBytes(key);
                }

                AesEncryptService aesEncryption = new AesEncryptService(key);

                string encryptedPassword = aesEncryption.Encrypt(employeeDto.Password);
                string encryptedRePassword = aesEncryption.Encrypt(employeeDto.RePassword);

                Employee employee = new Employee()
                {
                    Name = employeeDto.Name,
                    Email = employeeDto.Email,
                    DateBirday = employeeDto.DateBirday,
                    Password = encryptedPassword,
                    RePassword = encryptedRePassword,
                    EncryptionKey = Convert.ToBase64String(key),
                    DateCreated = DateTime.UtcNow.Date
                };

                await _employeeRepository.CreateAsync(employee);

                ReadEmployeeDto employeeReturn = new ReadEmployeeDto(employee.Id, employee.Name, employee.Email, employee.Password);

                return Ok(employeeReturn);
            }
            catch
            {
                return BadRequest($"Email já cadastrado!");
            }
        }
    }
}
