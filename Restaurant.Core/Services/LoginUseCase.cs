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
    public class LoginUseCase
    {
        private readonly ITokenService _tokenService;
        private readonly IProfileService _profileService;

        public LoginUseCase(ITokenService tokenService, IProfileService profileService)
        {
            _tokenService = tokenService;
            _profileService = profileService;
        }

        public async Task<TokenResponse> HandleLoginAsync(LoginCredentials credentials)
        {
            var user = await _profileService.Login(credentials);

            var token = _tokenService.CreateJwtToken(user);
            await _profileService.SaveRefreshToken(user, token.RefreshToken);

            return _tokenService.CreateJwtToken(user);
        }
    }
}
