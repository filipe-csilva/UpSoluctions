namespace UpSoluctions.Data.Dtos
{
    public record ReadEmployeeDto(int Id, string Name, string Email, string Password, string[] Roles);
}
