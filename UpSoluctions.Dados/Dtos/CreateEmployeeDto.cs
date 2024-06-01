using System.ComponentModel.DataAnnotations;

namespace UpSoluctions.Data.Dtos
{
    public class CreateEmployeeDto([Required] string Name, [Required] string Email, DateTime DateBirday, [Required] string Password, [Required][DataType(DataType.Password)] string RePassword);
}
