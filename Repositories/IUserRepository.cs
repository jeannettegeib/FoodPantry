using FoodPantry.Models;
using System.Collections.Generic;

namespace FoodPantry.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User getUserByUNPW(string username, string password);
        public User GetUserById(int id);
    }
}
