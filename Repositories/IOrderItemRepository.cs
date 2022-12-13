using FoodPantry.Models;

namespace FoodPantry.Repositories
{
    public interface IOrderItemRepository
    {
        public void PostOrderItem(OrderItem orderItem);
    }
}
