using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using FoodPantry.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq;
using Microsoft.AspNetCore.Connections;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace FoodPantry.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration) : base(configuration) { }



        public Order GetOrderById(int orderId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id, shopperUserId, orderSubmitted, pickupDate, employeeUserId, inStore, complete FROM [Order] WHERE id = @ID";
                    cmd.Parameters.AddWithValue("@ID", orderId);
                    var reader = cmd.ExecuteReader();

                    Order order = null;
                    if (reader.Read())
                    {
                        order = new Order()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            ShopperUserId = reader.GetInt32(reader.GetOrdinal("shopperUserId"))
                        };
                        if (!reader.IsDBNull(reader.GetOrdinal("orderSubmitted")))
                        {
                            order.OrderSubmitted = reader.GetDateTime(reader.GetOrdinal("orderSubmitted"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("pickupDate")))
                        {
                            order.PickupDate = reader.GetDateTime(reader.GetOrdinal("pickupDate"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("employeeUserId")))
                        {
                            order.EmployeeUserId = reader.GetInt32(reader.GetOrdinal("employeeUserId"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("employeeUserId")))
                        {
                            order.EmployeeUserId = reader.GetInt32(reader.GetOrdinal("employeeUserId"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("inStore")))
                        {
                            order.InStore = reader.GetBoolean(reader.GetOrdinal("inStore"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("complete")))
                        {
                            order.Complete = reader.GetBoolean(reader.GetOrdinal("complete"));
                        }
                    }
                    reader.Close();
                    return order;
                }
            }
        }


        public Order GetOrderByIdWithItems(int orderId)
        {
            using (var conn= Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT o.id AS OrderID, o.shopperUserId, o.orderSubmitted, o.pickupDate, o.employeeUserId, o.inStore, o.complete, oi.id AS OrderItemID, oi.orderId, oi.itemId, i.id AS ItemID, i.item, i.categoryId, i.[weight], i.foodTypeId, i.[image], i.quantity  
                                    FROM [Order] o
                                    LEFT JOIN OrderItem oi ON oi.orderId = o.id
                                    LEFT JOIN Item i ON oi.itemId = i.id
                                    WHERE o.id = @ID
                                    ORDER BY i.categoryId;";
                    cmd.Parameters.AddWithValue("@ID", orderId);
                    var reader = cmd.ExecuteReader();

                    Order order = null;
                    List<OrderItem> Items = new List<OrderItem>();
                    OrderItem item = null;
                    while (reader.Read())
                    {
                        if(order == null)
                        { 
                            order = new Order()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("OrderID")),
                                ShopperUserId = reader.GetInt32(reader.GetOrdinal("shopperUserId")),
                                
                            };
                            if (!reader.IsDBNull(reader.GetOrdinal("orderSubmitted")))
                            {
                                order.OrderSubmitted = reader.GetDateTime(reader.GetOrdinal("orderSubmitted"));
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("pickupDate")))
                            {
                                order.PickupDate = reader.GetDateTime(reader.GetOrdinal("pickupDate"));
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("employeeUserId")))
                            {
                                order.EmployeeUserId = reader.GetInt32(reader.GetOrdinal("employeeUserId"));
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("employeeUserId")))
                            {
                                order.EmployeeUserId = reader.GetInt32(reader.GetOrdinal("employeeUserId"));
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("inStore")))
                            {
                                order.InStore = reader.GetBoolean(reader.GetOrdinal("inStore"));
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("complete")))
                            {
                                order.Complete = reader.GetBoolean(reader.GetOrdinal("complete"));
                            }
                            
                            if (!reader.IsDBNull(reader.GetOrdinal("ItemID")))
                            { 
                               
                            }
                            item = new OrderItem
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("OrderItemID")),
                                orderId = reader.GetInt32(reader.GetOrdinal("orderId")),
                                itemId = reader.GetInt32(reader.GetOrdinal("itemId")),
                                Name = reader.GetString(reader.GetOrdinal("item")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("categoryId"))
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("weight"))) { item.Weight = reader.GetDouble(reader.GetOrdinal("weight")); }

                            if (!reader.IsDBNull(reader.GetOrdinal("foodTypeId")))
                            {
                                item.FoodTypeId = reader.GetInt32(reader.GetOrdinal("foodTypeId"));
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("image")))
                            {
                                item.Image = reader.GetString(reader.GetOrdinal("image"));
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("quantity")))
                            {
                                item.Quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                            }
                            order.Items.Add(item);

                        }
                        else
                        {
                            item = new OrderItem
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("OrderItemID")),
                                orderId = reader.GetInt32(reader.GetOrdinal("orderId")),
                                itemId = reader.GetInt32(reader.GetOrdinal("itemId")),
                                Name = reader.GetString(reader.GetOrdinal("item")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("categoryId"))
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("weight"))) { item.Weight = reader.GetDouble(reader.GetOrdinal("weight")); }

                            if (!reader.IsDBNull(reader.GetOrdinal("foodTypeId")))
                            {
                                item.FoodTypeId = reader.GetInt32(reader.GetOrdinal("foodTypeId"));
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("image")))
                            {
                                item.Image = reader.GetString(reader.GetOrdinal("image"));
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("quantity")))
                            {
                                item.Quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                            }
                            order.Items.Add(item);
                        }

                    }
                    reader.Close();
                    return order;
                }
            }
        }


        public void OpenEmptyOrder(Order order)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [Order] (shopperUserId, pickupDate) OUTPUT INSERTED.ID  
                                        VALUES (@shopperId, @pickupDate)";
                    cmd.Parameters.AddWithValue("@shopperId", order.ShopperUserId);
                    cmd.Parameters.AddWithValue("@pickupDate", order.PickupDate);
                    order.Id = (int)cmd.ExecuteScalar();                    
                }
            }
        }


        public void SubmitOrder(Order order)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    DateTime now = DateTime.Now;

                    cmd.CommandText = @"UPDATE [Order] SET orderSubmitted = @orderSubmitted, complete=@complete,  pickupDate=@pickupDate,  inStore=@inStore WHERE id = @orderId";
                    cmd.Parameters.AddWithValue("@orderId", order.Id);
                    cmd.Parameters.AddWithValue("@orderSubmitted", now);
                    cmd.Parameters.AddWithValue("@complete", order.Complete);
                    cmd.Parameters.AddWithValue("@pickupDate", order.PickupDate);
                    
                    cmd.Parameters.AddWithValue("@inStore", order.InStore);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void CompleteOrder(Order order)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Order] SET complete=1 WHERE id = @orderId";
                    cmd.Parameters.AddWithValue("@orderId", order.Id);
                    
                    cmd.ExecuteNonQuery();
                }

            }
        }


        public List<Order> ListAllSubmittedOrders()
        {
            using (var conn=Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM [Order] WHERE orderSubmitted IS NOT null AND complete IS null ORDER BY pickupDate";
                    var reader = cmd.ExecuteReader();
                    List<Order> orders = new List<Order>();
                    while (reader.Read())
                    {
                        var order = new Order()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            ShopperUserId= reader.GetInt32(reader.GetOrdinal("shopperUserId")),
                            OrderSubmitted=reader.GetDateTime(reader.GetOrdinal("orderSubmitted")),
                            PickupDate= reader.GetDateTime(reader.GetOrdinal("pickupDate"))

                        };
                        if (!reader.IsDBNull(reader.GetOrdinal("employeeUserId")))
                        {
                            order.EmployeeUserId = reader.GetInt32(reader.GetOrdinal("employeeUserId"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("employeeUserId")))
                        {
                            order.EmployeeUserId = reader.GetInt32(reader.GetOrdinal("employeeUserId"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("inStore")))
                        {
                            order.InStore = reader.GetBoolean(reader.GetOrdinal("inStore"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("complete")))
                        {
                            order.Complete = reader.GetBoolean(reader.GetOrdinal("complete"));
                        }
                      orders.Add(order);  
                    }
                    reader.Close();
                    return orders;
                }


                }

            }

        public List<Order> GetOrdersByUserId(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id, shopperUserId, orderSubmitted, pickupDate, employeeUserId, inStore, complete FROM [Order] 
                                        WHERE shopperUserId =@UserId AND orderSubmitted IS NOT Null
                                        ORDER BY orderSubmitted DESC;";     
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    var reader=cmd.ExecuteReader();

                    List<Order> orders = new List<Order>();
                    Order order = null;

                    while(reader.Read())
                    {
                        order = new Order()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            ShopperUserId = reader.GetInt32(reader.GetOrdinal("shopperUserId")),
                            OrderSubmitted = reader.GetDateTime(reader.GetOrdinal("orderSubmitted")),
                            PickupDate = reader.GetDateTime(reader.GetOrdinal("pickupDate"))
                        };
                        if (!reader.IsDBNull(reader.GetOrdinal("employeeUserId")))
                        {
                            order.EmployeeUserId = reader.GetInt32(reader.GetOrdinal("employeeUserId"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("employeeUserId")))
                        {
                            order.EmployeeUserId = reader.GetInt32(reader.GetOrdinal("employeeUserId"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("inStore")))
                        {
                            order.InStore = reader.GetBoolean(reader.GetOrdinal("inStore"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("complete")))
                        {
                            order.Complete = reader.GetBoolean(reader.GetOrdinal("complete"));
                        }
                        orders.Add(order);
                    }
                    reader.Close();
                    return orders;
                }
            }
        }


    }
    }

