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
                new Claim(JwtRegisteredClaimNames.Iat , DateTime.UtcNow.ToString())
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

            return new TokenResponse() { Token = token };
        }
    }
}
