using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.DTO;
using Restaurant.Core.Services;
using Restaurant.Core.ServicesContracts;

namespace RestaurantBackend.API.Controllers
{
    
    [Route("api/account")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly LoginUseCase _loginUseCase;
        private readonly RegisterUseCase _registerUseCase;

        public ProfileController(IProfileService profileService, LoginUseCase loginUseCase, RegisterUseCase registerUseCase)
        {
            _profileService = profileService;
            _loginUseCase = loginUseCase;
            _registerUseCase = registerUseCase;
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> register([FromBody] UserRegisterDto user)
        {
            var token = await _registerUseCase.HandleRegisterAsync(user);
            return Ok(token);
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> login([FromBody] LoginCredentials login)
        {
            var token = await _loginUseCase.HandleLoginAsync(login);
            return Ok(token);
        }

        [HttpPost]
        [Route("[Action]")]
        [Authorize]
        public async Task<IActionResult> logout()
        {
            await _profileService.Logout();
            return Ok();
        }

        [HttpGet]
        [Route("[Action]")]
        [Authorize]
        public async Task<IActionResult> profile()
        {
            var user = await _profileService.GetUserProfile();
            return Ok(user);
        }

        [HttpPost]
        [Route("[Action]")]
        [Authorize]
        public async Task<IActionResult> profile(UserEditDto user)
        {
            await _profileService.EditUserProfile(user);
            return NoContent();
        }
    }
}
