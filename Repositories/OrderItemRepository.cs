using FoodPantry.Models;
using Microsoft.Extensions.Configuration;

namespace FoodPantry.Repositories
{
    public class OrderItemRepository : BaseRepository,IOrderItemRepository
    {
        public OrderItemRepository(IConfiguration configuration) : base(configuration) { }
        public void PostOrderItem(OrderItem orderItem)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO OrderItem (orderId, itemId)
                                    OUTPUT INSERTED.ID 
                                    VALUES (@OrderId,@ItemId)";
                    cmd.Parameters.AddWithValue("@OrderId", orderItem.OrderId);
                    cmd.Parameters.AddWithValue("@ItemId", orderItem.ItemId);
                    orderItem.Id=(int)cmd.ExecuteScalar();

                }
            }
        }
    }
}
