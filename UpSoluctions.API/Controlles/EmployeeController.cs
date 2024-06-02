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
            ICollection<Employee> entities = await _employeeRepository.GetAllAsync();
            ICollection<ReadEmployeeDto> dtos = [];

            foreach (Employee entity in entities)
            {
                ReadEmployeeDto dto = new(entity.Id, entity.Name, entity.Email, entity.Roles);

                dtos.Add(dto);
            }

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadEmployeeDto>> GetByIdAsync(int id)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(id);

            if(employee == null) return NotFound();

            ReadEmployeeDto employeeReturn = new ReadEmployeeDto(employee.Id, employee.Name, employee.Email, employee.Roles);

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

                ReadEmployeeDto employeeReturn = new ReadEmployeeDto(employee.Id, employee.Name, employee.Email, employee.Roles);

                return Ok(employeeReturn);
            }
            catch
            {
                return BadRequest($"Email já cadastrado!");
            }
        }

        [HttpPut("id")]
        public async Task<ReadEmployeeDto> UpdateByIdAsync(UpdateEmployeeDto employeeDto, int id)
        {
            Employee currentEmployee = await _employeeRepository.GetByIdAsync(id);

            // Recuperar a chave de criptografia do banco de dados
            byte[] key = Convert.FromBase64String(currentEmployee.EncryptionKey);
            AesEncryptService aesEncryption = new AesEncryptService(key);

            string encryptedPassword = aesEncryption.Encrypt(employeeDto.Password);
            string encryptedRePassword = aesEncryption.Encrypt(employeeDto.RePassword);

            currentEmployee.Name = employeeDto.Name;
            currentEmployee.Email = employeeDto.Email;
            currentEmployee.DateBirday = employeeDto.DateBirday;
            currentEmployee.Password = encryptedPassword;
            currentEmployee.RePassword = encryptedRePassword;
            currentEmployee.EncryptionKey = currentEmployee.EncryptionKey;

            await _employeeRepository.UpdateAsync(currentEmployee, id);

            ReadEmployeeDto employeeReturn = new ReadEmployeeDto(currentEmployee.Id, currentEmployee.Name, currentEmployee.Email, currentEmployee.Roles);

            return employeeReturn;
        }

        [HttpDelete("id")]
        public async Task<Employee> DropUser(int id)
        {
            Employee employee = await _employeeRepository.DeleteAsync(id);
            return employee;
        }
    }
}
