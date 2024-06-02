using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data.Dtos;
using UpSoluctions.Data.Entities;
using UpSoluctions.Services;


namespace UpSoluctions.API.Controlles
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController(IEmployeeRepository employeeRepository, TokenService tokenService) : ControllerBase
    {
        private readonly TokenService _tokenService = tokenService;

        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        [HttpPost]
        public async Task<ActionResult<TokenService>> Auth(string email, string password)
        {
            Employee employee = await _employeeRepository.GetByEmailAsync(email);

            if (employee == null)
            {
                return BadRequest("Email não cadastrado!");
            }

            byte[] key = Convert.FromBase64String(employee.EncryptionKey);
            AesEncryptService aesEncryption = new AesEncryptService(key);

            string decryptedPassword = aesEncryption.Decrypt(employee.Password);

            if (password == decryptedPassword)
            {
                var token = _tokenService.GenerateToken(employee);

                return Ok(token);
            }

            return BadRequest($"Senha digitada está incorreta!");
        }

        [HttpPost]
        [Route("/create")]
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

                string encryptedPassword = aesEncryption.Encrypt("123456");
                string encryptedRePassword = aesEncryption.Encrypt("123456");

                Employee employee = new Employee()
                {
                    Name = "Filipe Paulo",
                    Email = "filipepaulocs@gmail.com",
                    DateBirday = DateTime.Parse("28-11-1988"),
                    Password = encryptedPassword,
                    RePassword = encryptedRePassword,
                    EncryptionKey = Convert.ToBase64String(key),
                    DateCreated = DateTime.UtcNow.Date
                };

                await _employeeRepository.CreateAsync(employee);

                ReadEmployeeDto employeeReturn = new ReadEmployeeDto(employee.Id, employee.Name, employee.Email, employee.Roles);

                return Ok(employeeReturn);
            }
            catch(Exception ex)
            {
                return BadRequest($"Email já cadastrado!\n\n {ex}");
            }
        }

        //[HttpPost]
        //[Route("api/v2")]
        //public async Task<ActionResult<TokenService>> Auth2(string username, string password)
        //{
        //    if (username == "filipe" && password == "123456")
        //    {
        //        var token = _tokenService.GenerateToken(new Employee());
        //        return Ok(token);
        //    }


        //    return BadRequest("username or password invalid");
        //}
    }
}
