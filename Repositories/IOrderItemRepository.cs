using FoodPantry.Models;

namespace FoodPantry.Repositories
{
    public interface IOrderItemRepository
    {
        public void PostOrderItem(OrderItem orderItem);
        public void UpdateOrderItem(int orderItemId, int newItemId);
    }
}
