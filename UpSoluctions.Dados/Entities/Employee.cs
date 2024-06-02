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
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateBirday { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        public string EncryptionKey { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow.Date;
    }
}
