using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.DTO;
using Restaurant.Core.ServicesContracts;
using Restaurant.Core.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public ProfileService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor contextAccessor,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task EditUserProfile(UserEditDto? userEdit)
        {
            ApplicationUser User = await GetUserByAccessToken();
            _mapper.Map(userEdit , User);
            
            var result = await _userManager.UpdateAsync(User);
            if (!result.Succeeded)
                throw new ApplicationException(string.Join(","  , result.Errors.Select(x => x.Description)));
        }

        public async Task<UserDto> GetUserProfile()
        {
            ApplicationUser user = await GetUserByAccessToken();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<ApplicationUser> Login(LoginCredentials credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var result = await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, false);
            if (!result.Succeeded)
                throw new UnauthorizedAccessException("invalid credentials");
 
            return user;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync(); 
        }

        public async Task<ApplicationUser> Register(UserRegisterDto user)
        {
            var User = _mapper.Map<ApplicationUser>(user);
            User.Id = Guid.NewGuid();
            User.UserName = user.Email;

            var result = await _userManager.CreateAsync(User , user.Password);
            if (!result.Succeeded)
                throw new ApplicationException(string.Join("," , result.Errors.Select(x => x.Description)));

            return User;   
        }

        public async Task<ApplicationUser> GetUserByAccessToken()
        {
            var userId = _contextAccessor
               .HttpContext
               .User
               .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                throw new UnauthorizedAccessException("User is not logged in");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new ArgumentNullException("User not found");

            return user;
        }

        public async Task SaveRefreshToken(ApplicationUser user , string refreshToken)
        {
            user.RefreshToken = refreshToken;
            user.RefreshExpiration = DateTime.UtcNow.AddDays(10);

            await _userManager.UpdateAsync(user);
        }

        public async Task<ApplicationUser> GetUserByRefreshToken(string refreshToken)
        {
            return await _userManager.Users
                .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken.Trim());
        }

        public async Task<bool> IsRefreshTokenValid(ApplicationUser user , string refreshToken)
        {
            return user.RefreshToken == refreshToken &&
                   user.RefreshExpiration > DateTime.UtcNow;
        }
    }
}
