using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data.Dtos;
using UpSoluctions.Data.Entities;
using UpSoluctions.Services;


namespace UpSoluctions.API.Controlles
{

    public record AuthRequest(string Email, string Password);

    [ApiController]
    public class AuthController(IEmployeeRepository employeeRepository, TokenService tokenService) : ControllerBase
    {
        private readonly TokenService _tokenService = tokenService;

        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        [HttpPost]
        [Route("api/login")]
        public async Task<ActionResult<TokenService>> Auth(AuthRequest request)
        {
            var (email, password) = request;

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

                return Ok(new
                {
                    tokenString = token.tokenAcess,
                    tokenRefresh = token.tokenRefresh
                });
            }

            return BadRequest($"Senha digitada está incorreta!");
        }

        [HttpPost]
        [Route("api/refresh")]
        public async Task<ActionResult<TokenService>> RefleshToken([FromBody] string refreshToken)
        {
            try
            {
                var tokens = _tokenService.RenewTokens(refreshToken);
                return Ok(new
                {
                    accessToken = tokens.tokenAccess,
                    refreshToken = tokens.tokenRefresh
                });
            }
            catch (SecurityTokenException)
            {
                return Unauthorized("Invalid refresh token");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ReadEmployeeDto>> CreateEmployee()
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
            catch
            {
                return BadRequest($"Email já cadastrado!");
            }
        }
    }
}
