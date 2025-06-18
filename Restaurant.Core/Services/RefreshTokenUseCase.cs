using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.ServicesContracts;
using Restaurant.Core.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public class RefreshTokenUseCase
    {
        private readonly IProfileService _profileService;
        private readonly ITokenService _tokenService;

        public RefreshTokenUseCase(IProfileService profileService, ITokenService tokenService)
        {
            _profileService = profileService;
            _tokenService = tokenService;
        }

        public async Task<TokenResponse> HandleRefresh(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentNullException(nameof(refreshToken));

            ApplicationUser? user = await _profileService.GetUserByRefreshToken(refreshToken);

            if (user == null || !await _profileService.IsRefreshTokenValid(user , refreshToken))
            {
                throw new UnauthorizedAccessException("Invalid or expired refresh token");
            }

            var newToken = _tokenService.CreateJwtToken(user);
            await _profileService.SaveRefreshToken(user, newToken.RefreshToken);

            return newToken;
        }
    }
}
