using FoodPantry.Models;
using System.Collections.Generic;

namespace FoodPantry.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();
        public Category GetCategoryByIdWithItems(int categoryId);
    }
}
