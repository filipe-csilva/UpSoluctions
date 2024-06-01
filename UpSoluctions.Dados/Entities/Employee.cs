using System.ComponentModel.DataAnnotations;

namespace UpSoluctions.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateBirday { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        public string? RePassword { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow.Date;
        [Required]
        public string[] Roles { get; set; }
    }
}
