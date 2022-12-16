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

        [HttpGet]
        public IActionResult Get()
        {
            return NoContent(); 
        }
        

        [HttpPost]
        public IActionResult Post(OrderItem orderItem)
        {
            _orderItemRepository.PostOrderItem(orderItem);
            //return CreatedAtAction("Get", new { id = orderItem.Id }, orderItem);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(int orderItemId, int newItemId)
        {
            _orderItemRepository.UpdateOrderItem(orderItemId, newItemId);
            return NoContent();

        }

            
    }
}
