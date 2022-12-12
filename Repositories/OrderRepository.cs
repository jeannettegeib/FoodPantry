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

namespace FoodPantry.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration) : base(configuration) { }


        public Order GetOrderById(int orderId)
        {
            using (var conn= Connection)
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
                            order.OderSubmitted = reader.GetDateTime(reader.GetOrdinal("orderSubmitted"));
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

        public List<Order> ListAllSubmittedOrders()
        {
            using (var conn=Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM [Order] WHERE OrderSubmitted = 'true' AND complete = 'false' ORDER BY pickupDate";
                    var reader = cmd.ExecuteReader();
                    List<Order> orders = new List<Order>();
                    while (reader.Read())
                    {
                        var order = new Order()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            ShopperUserId= reader.GetInt32(reader.GetOrdinal("shopperUserId")),
                            OderSubmitted=reader.GetDateTime(reader.GetOrdinal("orderSubmitted")),
                            PickupDate= reader.GetDateTime(reader.GetOrdinal("orderSubmitted"))

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

