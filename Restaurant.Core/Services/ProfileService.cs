using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            if (userEdit == null)
                throw new ArgumentNullException(nameof(userEdit));

            ApplicationUser User = await FindUser();
            _mapper.Map(userEdit , User);
            
            var result = await _userManager.UpdateAsync(User);
            if (!result.Succeeded)
                throw new ApplicationException(string.Join(","  , result.Errors.Select(x => x.Description)));
        }

        public async Task<UserDto> GetUserProfile()
        {
            ApplicationUser user = await FindUser();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<TokenResponse> Login(LoginCredentials? credentials)
        {
            if(credentials == null)
                throw new ArgumentNullException($"Login Credentials required{nameof(credentials)}");

            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var result = await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, false);
            if (!result.Succeeded)
                throw new UnauthorizedAccessException("invalid credentials");
            // token should be here. 
            return new TokenResponse
            {
                Token = "abc"
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<TokenResponse> Register(UserRegisterDto? user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var User = _mapper.Map<ApplicationUser>(user);
            User.Id = Guid.NewGuid();

            var result = await _userManager.CreateAsync(User);
            if (!result.Succeeded)
                throw new ApplicationException(string.Join("," , result.Errors.Select(x => x.Description)));

            //handleing token here
            return new TokenResponse
            {
                Token = "abc"
            };   
        }

        private async Task<ApplicationUser> FindUser()
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
    }
}
