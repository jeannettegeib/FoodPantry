using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodPantry.Repositories;
using FoodPantry.Models;
using System.Security.Permissions;

namespace FoodPantry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user=_userRepository.GetUserById(id);
            if (user==null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //[HttpPost] IActionResult Post(User user)
        //{
        //    _userRepository.Add(user);
        //    return CreatedAtAction("Get", new { id = user.id }, user);
        //}



    }
}
