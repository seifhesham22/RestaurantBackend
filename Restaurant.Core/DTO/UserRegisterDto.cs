using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTO
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Name field can't be empty")]
        public string FullName { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage ="Gender can't be empty")]
        public Gender Gender { get; set; }

        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email field can't be empty")]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password field can't be empty")]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
