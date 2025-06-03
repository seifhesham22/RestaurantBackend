using Microsoft.AspNetCore.Builder;
using Restaurant.Core.DTO;
using Restaurant.Core.ServicesContracts;
using Restaurant.Core.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public class RegisterUseCase
    {
        private readonly IProfileService _profileService;
        private readonly ITokenService _tokenService;

        public RegisterUseCase(IProfileService profileService, ITokenService tokenService)
        {
            _profileService = profileService;
            _tokenService = tokenService;
        }

        public async Task<TokenResponse> HandleRegisterAsync(UserRegisterDto? user)
        {
            var User = await _profileService.Register(user);
            return _tokenService.CreateJwtToken(User);
        }
    }
}
