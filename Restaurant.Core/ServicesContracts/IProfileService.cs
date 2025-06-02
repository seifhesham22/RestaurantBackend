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
        public Task<TokenResponse> Login(LoginCredentials? credentials);
        public Task Logout();
        public Task<TokenResponse> Register(UserRegisterDto? user);
        public Task<UserDto> GetUserProfile();
        public Task EditUserProfile(UserEditDto? user);
    }
}
