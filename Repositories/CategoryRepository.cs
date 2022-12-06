using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using FoodPantry.Models;


namespace FoodPantry.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration) { }

        public List<Category> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id, [name], [1person], [2people], [3_4people], [5_6people], [7_8people], [9people] FROM Category";
                    var reader = cmd.ExecuteReader();
                    var categories = new List<Category>();
                    while (reader.Read())
                    {
                        var category = new Category()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            OnePerson = reader.GetInt32(reader.GetOrdinal("1person")),
                            TwoPeople = reader.GetInt32(reader.GetOrdinal("2people")),
                            ThreeToFourPeople = reader.GetInt32(reader.GetOrdinal("3_4people")),
                            FiveToSixPeople = reader.GetInt32(reader.GetOrdinal("5_6people")),
                            SevenToEightPeople = reader.GetInt32(reader.GetOrdinal("7_8people")),
                            NinePlusPeople = reader.GetInt32(reader.GetOrdinal("9people"))

                        };
                        categories.Add(category);
                    }
                    reader.Close();
                    return categories;
                }
            }
        }

        public Category GetCategoryByIdWithItems(int categoryId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id AS CategoryID, [name], [1person], [2people], [3_4people], [5_6people], [7_8people], [9people], 
                        i.id AS ItemID, i.item, i.categoryId AS ItemCategory, i.weight, i.foodTypeId, i.image, i.quantity
                        FROM Category c 
                        LEFT JOIN Item i ON p.CategoryID = i.CategoryId
                        WHERE CategoryID = @categoryId";
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    var reader = cmd.ExecuteReader();

                    Category category = null;
                    List<Item> Items = new List<Item>();
                    while (reader.Read())
                    {
                        if (category==null)
                        {
                            category = new Category()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                OnePerson = reader.GetInt32(reader.GetOrdinal("1person")),
                                TwoPeople = reader.GetInt32(reader.GetOrdinal("2people")),
                                ThreeToFourPeople = reader.GetInt32(reader.GetOrdinal("3_4people")),
                                FiveToSixPeople = reader.GetInt32(reader.GetOrdinal("5_6people")),
                                SevenToEightPeople = reader.GetInt32(reader.GetOrdinal("7_8people")),
                                NinePlusPeople = reader.GetInt32(reader.GetOrdinal("9people")),
                                Items = Items
                            };

                            
                        }
                        else
                        {
                            Items.Add(new Item()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                Name = reader.GetString(reader.GetOrdinal("item")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("ItemCategory")),
                                Weight = reader.GetFloat(reader.GetOrdinal("weight")),
                                FoodTypeId = reader.GetInt32(reader.GetOrdinal("foodTypeId")),
                                Image = reader.GetString(reader.GetOrdinal("image")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("quantity"))

                            });
                        }
                    }
                    reader.Close();
                    return category; 
                }
            }
        }

    }
}
