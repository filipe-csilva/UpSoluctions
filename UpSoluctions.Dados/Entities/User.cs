﻿using System.ComponentModel.DataAnnotations;

namespace UpSoluctions.Data.Entities
{
    public class User
    {
        public User(int id, string? email, string? password, string[] roles)
        {
            Id = id;
            Email = email;
            Password = password;
            Roles = roles;
        }

        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public DateTime DateBirday { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        public string? RePassword { get; set; }
        [Required]
        public string[] Roles { get; set; }
    }
}
