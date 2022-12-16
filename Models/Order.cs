using System;
using System.Collections.Generic;

namespace FoodPantry.Models
{
    public class Order
    {
        public int Id { get; set; } 
        public int ShopperUserId { get; set; }  
        public DateTime OrderSubmitted { get; set; } 
        public DateTime PickupDate { get; set; }
        public int EmployeeUserId { get; set; }
        public bool InStore { get; set; } = false;
        public bool Complete { get; set; } = false;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public User Shopper { get; set; }
    }
    
}
