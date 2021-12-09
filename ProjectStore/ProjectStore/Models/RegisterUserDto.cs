using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectStore.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public int RoleId { get; set; }=1;

        public DateTime Birthday { get; set; }
        public int PhoneNumber { get; set; }
    }
}
