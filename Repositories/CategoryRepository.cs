using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using FoodPantry.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq;

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
                    cmd.CommandText = @"SELECT c.id AS CategoryID, [name], [1person], [2people], [3_4people], [5_6people], [7_8people], [9people], 
                        i.id AS ItemID, i.item, i.categoryId AS ItemCategory, i.weight, i.foodTypeId, i.image, i.quantity
                        FROM Category c 
                        LEFT JOIN Item i ON i.categoryId = c.id";
                    var reader = cmd.ExecuteReader();
                    //Category category = new Category();
                    Item item = null;
                    List<Category> categories = new List<Category>();
                    List<Item> Items = new List<Item>();
                    while (reader.Read())
                    {
                        if (categories.Any(c=>c.Id == reader.GetInt32(reader.GetOrdinal("CategoryID"))) )
                        {
                            item= new Item()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                Name = reader.GetString(reader.GetOrdinal("item")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("ItemCategory")),};
                         
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
                               

                              
                            categories.Find(c=>c.Id==item.CategoryId).Items.Add(item);
                                                     
                        }else
                        {
                            Category category = new Category()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                OnePerson = reader.GetInt32(reader.GetOrdinal("1person")),
                                TwoPeople = reader.GetInt32(reader.GetOrdinal("2people")),
                                ThreeToFourPeople = reader.GetInt32(reader.GetOrdinal("3_4people")),
                                FiveToSixPeople = reader.GetInt32(reader.GetOrdinal("5_6people")),
                                SevenToEightPeople = reader.GetInt32(reader.GetOrdinal("7_8people")),
                                NinePlusPeople = reader.GetInt32(reader.GetOrdinal("9people")),
                                Items = new List<Item>() 
                                
                                
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("ItemID")))
                            {
                                item = new Item
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                    Name = reader.GetString(reader.GetOrdinal("item")),
                                    CategoryId = reader.GetInt32(reader.GetOrdinal("ItemCategory"))
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
                                category.Items.Add(item);
                            }

                            categories.Add(category);
                        }
                        
                       
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
                    cmd.CommandText = @"SELECT c.id AS CategoryID, [name], [1person], [2people], [3_4people], [5_6people], [7_8people], [9people], 
                        i.id AS ItemID, i.item, i.categoryId AS ItemCategory, i.weight, i.foodTypeId, i.image, i.quantity
                        FROM Category c 
                        LEFT JOIN Item i ON c.id = i.categoryId
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
                                
                            };
                            Item item = new Item
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                Name = reader.GetString(reader.GetOrdinal("item")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("ItemCategory"))
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
                            category.Items.Add(item);


                        }
                        else
                        {
                            Item item = new Item
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                Name = reader.GetString(reader.GetOrdinal("item")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("ItemCategory"))
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
                            category.Items.Add(item);
                        }
                    }
                    reader.Close();
                    return category; 
                }
            }
        }

    }
}
