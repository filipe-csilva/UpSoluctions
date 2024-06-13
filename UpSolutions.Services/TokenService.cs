using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UpSoluctions.Data.Entities;

namespace UpSoluctions.Services
{
    public class TokenService(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly Config _config = new ();

        public (string tokenAcess, string tokenRefresh) GenerateToken(Employee employee)
        {
            var Secret = _configuration["Secret"];
            var SubSecret = _configuration["SubSecret"];

            var tokenString = CreateToken(employee, Secret, _config.TimeTokenSecret);

            var tokenRefresh = CreateToken(employee, SubSecret, _config.TimeRefreshTokenSecret);

            return  (tokenString, tokenRefresh);
        }

        private string CreateToken(Employee employee, string Secret, int expiresInHours)
        {
            var key = Encoding.ASCII.GetBytes(Secret);

            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("employeeId", employee.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(expiresInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenConfig);

            var tokengerado = tokenHandler.WriteToken(token);

            return tokengerado;
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token, string secret)
        {
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public (string tokenAccess, string tokenRefresh) RenewTokens(string refreshToken)
        {
            var SubSecret = _configuration["SubSecret"];
            var principal = GetPrincipalFromExpiredToken(refreshToken, SubSecret);
            var employeeIdClaim = principal.Claims.FirstOrDefault(c => c.Type == "employeeId");
            if (employeeIdClaim == null)
                throw new SecurityTokenException("Invalid refresh token");

            // Aqui você deve verificar se o token de refresh é válido e não foi revogado
            // Esta implementação assume que é válido para simplificar

            var employeeId = int.Parse(employeeIdClaim.Value);
            var employee = new Employee { Id = employeeId };

            return GenerateToken(employee);
        }
    }
}
