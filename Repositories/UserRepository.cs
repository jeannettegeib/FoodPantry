using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using FoodPantry.Models;
using Microsoft.AspNetCore.Routing;
using Azure.Identity;

namespace FoodPantry.Repositories
{
    public class usersRepository
    {
        private readonly string _connectionString;
        public usersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<User> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id, userType, email, username, password, phone, firstName, lasteName, familySize, foodTypeId, frequency FROM User";
                    var reader = cmd.ExecuteReader();
                    var users = new List<User>();
                    while (reader.Read())
                    {
                        var user = new User()
                        {
                            id = reader.GetInt32(reader.GetOrdinal("id")),
                            userType = reader.GetInt32(reader.GetOrdinal("userType")),
                            username = reader.GetString(reader.GetOrdinal("username")),
                            password = reader.GetString(reader.GetOrdinal("password")),
                            firstName = reader.GetString(reader.GetOrdinal("firstName")),
                            lastName = reader.GetString(reader.GetOrdinal("lastName")),
                        };
                        if (!reader.IsDBNull(reader.GetOrdinal("email")))
                        {
                            user.email = reader.GetString(reader.GetOrdinal("email"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("phone")))
                        {
                            user.phone = reader.GetString(reader.GetOrdinal("phone"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("familySize")))
                        {
                            user.familySize = reader.GetInt32(reader.GetOrdinal("familySize"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("foodTypeId")))
                        {
                            user.foodTypeId = reader.GetInt32(reader.GetOrdinal("foodTypeId"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("frequency")))
                        {
                            user.frequency = reader.GetInt32(reader.GetOrdinal("frequency"));
                        }

                        users.Add(user);
                    }
                    reader.Close();
                    return users;
                }
            }
        }


        public User getUserByUNPW(string username, string password)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id, userType, email, username, password, phone, firstName, lasteName, familySize, foodTypeId, frequency FROM User WHERE username = @UserName AND password = @PassWord";
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@PassWord", password);
                    var reader = cmd.ExecuteReader();

                    User user = null;
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            id = reader.GetInt32(reader.GetOrdinal("id")),
                            userType = reader.GetInt32(reader.GetOrdinal("userType")),
                            username = reader.GetString(reader.GetOrdinal("username")),
                            password = reader.GetString(reader.GetOrdinal("password")),
                            firstName = reader.GetString(reader.GetOrdinal("firstName")),
                            lastName = reader.GetString(reader.GetOrdinal("lastName")),
                        };
                        if (!reader.IsDBNull(reader.GetOrdinal("email")))
                        {
                            user.email = reader.GetString(reader.GetOrdinal("email"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("phone")))
                        {
                            user.phone = reader.GetString(reader.GetOrdinal("phone"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("familySize")))
                        {
                            user.familySize = reader.GetInt32(reader.GetOrdinal("familySize"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("foodTypeId")))
                        {
                            user.foodTypeId = reader.GetInt32(reader.GetOrdinal("foodTypeId"));
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("frequency")))
                        {
                            user.frequency = reader.GetInt32(reader.GetOrdinal("frequency"));
                        }

                    }
                    reader.Close();
                    return user;
                }
            }

        }

        public void Add(User user)
        {
           using (var conn=Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO User (userType, email, username, password, phone, firstName, lasteName, familySize, foodTypeId, frequency) OUTPUT INSERTED.ID 
                                        VALUES (@userType, @email, @username, @password, @phone, @firstName, @lasteName, @familySize, @foodTypeId, @frequency)";
                    cmd.Parameters.AddWithValue("@userType", user.userType);
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@password", user.password);
                    cmd.Parameters.AddWithValue("@phone", user.phone);
                    cmd.Parameters.AddWithValue("@firstName", user.firstName);
                    cmd.Parameters.AddWithValue("@lastName", user.lastName);
                    cmd.Parameters.AddWithValue("@familySize", user.familySize);
                    cmd.Parameters.AddWithValue("@foodTypeId", user.foodTypeId);
                    cmd.Parameters.AddWithValue("@frequency", user.frequency);

                    user.id = (int)cmd.ExecuteScalar();
                }
            }
        }



    }
}

