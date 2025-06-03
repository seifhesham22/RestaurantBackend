using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.ServicesContracts
{
    public interface ITokenService
    {
        public TokenResponse CreateJwtToken(ApplicationUser user);
    }
}
