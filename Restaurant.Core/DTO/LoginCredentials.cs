using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTO
{
    public class LoginCredentials
    {
        [Required(ErrorMessage ="Email field can't be empty")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password field can't be empty")]
        public string Password { get; set; } = string.Empty;
    }
}
