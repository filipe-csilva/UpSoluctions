using System.ComponentModel.DataAnnotations;

namespace UpSoluctions.Data.Dtos
{
    public record UpdateEmployeeDto(string Name, string Email, DateTime DateBirday, string Password, [DataType(DataType.Password)] string RePassword, string[]? Roles) { 
    }
}
