using Microsoft.AspNetCore.Mvc;
using FoodPantry.Repositories;
using System.Security.Permissions;

namespace FoodPantry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryRepository.GetAll());    
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryRepository.GetCategoryByIdWithItems(id);
            if (category==null)
            { return NotFound(); }
            return Ok(category);
        }
    }
}
