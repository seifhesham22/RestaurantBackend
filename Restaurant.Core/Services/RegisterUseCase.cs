using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters;
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

        public async Task<TokenResponse> HandleRegisterAsync(UserRegisterDto user)
        {
            var User = await _profileService.Register(user);

            var token = _tokenService.CreateJwtToken(User);
            await _profileService.SaveRefreshToken(User, token.RefreshToken);
            
            return token;
        }
    }

    
}
