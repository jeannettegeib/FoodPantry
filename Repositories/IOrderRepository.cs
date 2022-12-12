using FoodPantry.Models;
using System.Collections.Generic;

namespace FoodPantry.Repositories
{
    public interface IOrderRepository
    {
        public void OpenEmptyOrder(Order order);
        public Order GetOrderById(int orderId);
        public List<Order> ListAllSubmittedOrders();
    }
}
