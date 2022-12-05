using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodPantry.Repositories;
using FoodPantry.Models;

namespace FoodPantry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet("GetByUNPW")]
        public IActionResult GetByUNPW(string username, string password)
        {
            var user = _userRepository.getUserByUNPW(username, password);
            if (username == null || password == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


    }
}
