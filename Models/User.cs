using System.ComponentModel.DataAnnotations;

namespace FoodPantry.Models
{
    public class User
    {
        public int id { get; set; }
        public int userType { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }    
        public string phone { get; set; }   
        public string firstName { get; set; }
        public string lastName { get; set; }    
        public int familySize { get; set; } 
        public int foodTypeId { get; set; }
        public int frequency { get; set; }
    }
}
