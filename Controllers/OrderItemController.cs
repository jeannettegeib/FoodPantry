using Microsoft.AspNetCore.Mvc;
using FoodPantry.Repositories;
using FoodPantry.Models;

namespace FoodPantry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderItemController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        
        //[HttpGet]

        [HttpPost]
        public IActionResult Post(OrderItem orderItem)
        {
            _orderItemRepository.PostOrderItem(orderItem);
            return CreatedAtAction("Get", new { id = orderItem.Id }, orderItem);
        }

            
    }
}
