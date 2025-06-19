using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.ServicesContracts;
using Restaurant.Core.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenResponse CreateJwtToken(ApplicationUser user)
        {
            DateTime expirationDate = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));

            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub , user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
          new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),
          ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            SymmetricSecurityKey securityKey = new 
            SymmetricSecurityKey(
                Encoding
                .UTF8
                .GetBytes(_configuration["Jwt:Key"])
                ); 

            SigningCredentials signingCredentials = new
            SigningCredentials(
            securityKey , SecurityAlgorithms.HmacSha256);

            JwtSecurityToken Securitytoken = new
                JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expirationDate,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(Securitytoken);
            string refreshToken = CreateRefreshToken();

            return new TokenResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                RefreshExpiration = DateTime.UtcNow.AddDays(10)
            };
        }

        private string CreateRefreshToken()
        {
            byte[] bytes = new byte[64];

            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        public ClaimsPrincipal ValidatePrincipal(string token)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateLifetime = false,
            };

            var jwtTokenHnadler = new JwtSecurityTokenHandler();

            ClaimsPrincipal claimsPrincipal = jwtTokenHnadler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (claimsPrincipal == null)
                throw new SecurityTokenException($"Invalid jwt access token{nameof(claimsPrincipal)}");

            if(securityToken is not JwtSecurityToken jwtSecurityToken)
                throw new SecurityTokenException($"Invalid token format {nameof(securityToken)}");

            if (!jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException($"Invalid hasing algorithm");

            return claimsPrincipal;
        }
    }
}
