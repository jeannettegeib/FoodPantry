using System.ComponentModel.DataAnnotations;

namespace FoodPantry.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int orderId { get; set; }
        public int itemId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Weight { get; set; }
        public int FoodTypeId { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}
