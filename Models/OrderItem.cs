using System.ComponentModel.DataAnnotations;

namespace FoodPantry.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int orderId { get; set; }
        public int itemId { get; set; }
    }
}
