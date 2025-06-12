using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string Address { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
