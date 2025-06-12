using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTO
{
    public class UserEditDto
    {
        [Required(ErrorMessage = "Name field can't be empty")]
        [MinLength(1)]
        public string FullName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Gender field can't be empty")]
        public Gender Gender { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
