using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.ServicesContracts;

namespace RestaurantBackend.UI.Controllers
{
    [ApiController]
    [Route("api")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;
        private readonly IRatingService _ratingService;
        private readonly IProfileService _profileService;
        private readonly IRatingService _rating;

        public DishController(IDishService dishService , IRatingService ratingService , IProfileService profileService , IRatingService rating)
        {
            _dishService = dishService;
            _ratingService = ratingService;
            _profileService = profileService;
            _rating = rating;
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> Dish([FromQuery] DishFilterParams parameters)
        {
            var dishes = await _dishService.GetDishPagedList(parameters);
            return Ok(dishes);
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public async Task<IActionResult> Dish(Guid Id)
        {
            var dish = await _dishService.GetDishInfo(Id);
            return Ok(dish);
        }

        [Authorize]
        [HttpGet]
        [Route("[Action]/{id}/rating")]
        public async Task<IActionResult> Check(Guid dishId)
        {
            ApplicationUser user = await _profileService.GetUser();
            bool canRate = await _ratingService.CanUserRate(user.Id , dishId);
            return Ok(canRate);
        }

        [Authorize]
        [HttpPost]
        [Route("[Action]/{id}/rating")]
        public async Task<IActionResult> Set(Guid dishId , int score) 
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
            return await _profileService.GetUser();
        }

        private async Task<bool> CanUserRateDish(Guid userId, Guid dishId)
        {
            return await _ratingService.CanUserRate(userId, dishId);
        }
    }
}
