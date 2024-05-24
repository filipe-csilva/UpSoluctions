using System.ComponentModel.DataAnnotations;

namespace UpSoluctions.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public DateTime DateBirday { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        public string? RePassword { get; set; }
    }
}
