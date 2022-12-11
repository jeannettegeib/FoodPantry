using FoodPantry.Models;

namespace FoodPantry.Repositories
{
    public interface IOrderRepository
    {
        public void OpenEmptyOrder(Order order);
        public Order GetOrderById(int orderId);
    }
}
