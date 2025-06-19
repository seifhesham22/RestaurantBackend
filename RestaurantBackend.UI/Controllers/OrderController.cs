using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.DTO;
using Restaurant.Core.ServicesContracts;

namespace RestaurantBackend.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly IProfileService _profile;
        private readonly IOrderService _order;

        public OrderController(IProfileService profile, IOrderService order)
        {
            _profile = profile;
            _order = order;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(Guid orderId)
        {
            var order = await _order.GetOrderInfo(orderId);
            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            var user = await _profile.GetUserByAccessToken();
            var orderList = await _order.GetAllOrders(user.Id);
            return Ok(orderList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrder)
        {
            var user = await _profile.GetUserByAccessToken();
            await _order.CreateOrder(user.Id , createOrder);
            return Ok();
        }

        [HttpPost("{orderId}/status")]
        public async Task<IActionResult> Set(Guid orderId)
        {
            await _order.ConfirmOrderDelivery(orderId);
            return Ok();
        }
    }
}
