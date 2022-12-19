using FoodPantry.Models;
using System.Collections.Generic;

namespace FoodPantry.Repositories
{
    public interface IOrderRepository
    {
        public void OpenEmptyOrder(Order order);
        public Order GetOrderByIdWithItems(int orderId);
        public Order GetOrderById(int orderId);
        public void SubmitOrder(Order order);
        public void CompleteOrder(Order order);
        public List<Order> ListAllSubmittedOrders();
        public List<Order> GetOrdersByUserId(int userId);



    }
}
