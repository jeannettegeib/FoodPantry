using Microsoft.AspNetCore.Mvc;
using FoodPantry.Repositories;
using FoodPantry.Models;

namespace FoodPantry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]   
        public IActionResult Get()
        {
            return Ok(_orderRepository.ListAllSubmittedOrders());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null) { return NotFound(); }
            return Ok (order);
        }

        [HttpGet("GetWithItems/{id}")]
        public IActionResult GetWithItems(int id)
        {
            var order = _orderRepository.GetOrderByIdWithItems(id);
            if (order == null) { return NotFound(); }
            return Ok(order);
        }


        [HttpPost]
        public IActionResult Post(Order order)
        {
            _orderRepository.OpenEmptyOrder(order);
            return CreatedAtAction("Get", new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult SubmitOrder(Order order)
        {
            _orderRepository.SubmitOrder(order);
            return Ok(order);
        }


    }
}
