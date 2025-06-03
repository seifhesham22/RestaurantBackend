using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.DTO;
using Restaurant.Core.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.ServicesContracts
{
    public interface IProfileService
    {
        public Task<ApplicationUser> Login(LoginCredentials? credentials);
        public Task Logout();
        public Task<ApplicationUser> Register(UserRegisterDto? user);
        public Task<UserDto> GetUserProfile();
        public Task EditUserProfile(UserEditDto? user);
    }
}
