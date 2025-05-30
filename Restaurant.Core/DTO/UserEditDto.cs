using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTO
{
    public class UserEditDto
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
