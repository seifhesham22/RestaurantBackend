using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.ServicesContracts;

namespace RestaurantBackend.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly IProfileService _profile;
        private readonly ICartService _cart;

        public CartController(ICartService cart, IProfileService profile)
        {
            _profile = profile;
            _cart = cart;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var user = await _profile.GetUser();
            var cartItems = await _cart.GetUserCartItems(user.Id);

            return Ok(cartItems);
        }

        [HttpPost]
        [Route("dish/{dishId}")]
        public async Task<IActionResult> Add(Guid dishId)
        {
            var user = await _profile.GetUser();
            await _cart.AddDishToCart(dishId , user.Id);

            return Ok();
        }

        [HttpDelete]
        [Route("dish/{dishId}")]
        public async Task<IActionResult> Delete(Guid dishId)
        {
            var user = await _profile.GetUser();
            await _cart.RemoveDishFromCart(dishId , user.Id);

            return Ok();
        }
    }
}
