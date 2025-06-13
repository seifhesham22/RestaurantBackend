using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Token
{
    public class TokenResponse
    {
        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
