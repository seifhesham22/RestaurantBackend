using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.ServicesContracts;

namespace RestaurantBackend.UI.Controllers
{
    [ApiController]
    [Route("api/dish")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;
        private readonly IRatingService _ratingService;
        private readonly IProfileService _profileService;
        private readonly IRatingService _rating;

        public DishController(
            IDishService dishService,
            IRatingService ratingService,
            IProfileService profileService,
            IRatingService rating)
        {
            _dishService = dishService;
            _ratingService = ratingService;
            _profileService = profileService;
            _rating = rating;
        }

        [HttpGet]
        public async Task<IActionResult> FilterDishes([FromQuery] DishFilterParams parameters)
        {
            var dishes = await _dishService.GetDishPagedList(parameters);
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<IActionResult> GetDish(Guid dishId)
        {
            var dish = await _dishService.GetDishInfo(dishId);
            return Ok(dish);
        }

        [Authorize]
        [HttpGet]
        [Route("{dishId}/rating/[Action]")]
        public async Task<IActionResult> check(Guid dishId)
        {
            ApplicationUser user = await _profileService.GetUserByAccessToken();
            bool canRate = await _ratingService.CanUserRate(user.Id , dishId);
            return Ok(canRate);
        }

        [Authorize]
        [HttpPost]
        [Route("{dishId}/rating")]
        public async Task<IActionResult> SetRating(Guid dishId , int score) 
        {
            var user = await GetCurrentUser();
            bool canRate = await CanUserRateDish(user.Id , dishId);

            if (!canRate)
                return Conflict("Need to order the dish before reting it");
                
            await _rating.AddRating(user.Id, dishId, score);
            await _dishService.UpdateDishAvgRating(dishId);

            return NoContent();
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _profileService.GetUserByAccessToken();
        }

        private async Task<bool> CanUserRateDish(Guid userId, Guid dishId)
        {
            return await _ratingService.CanUserRate(userId, dishId);
        }
    }
}
