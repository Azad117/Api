using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Category;
using Product1Api.Common.Repository.Category;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDb _db;

        public CategoryRepository(IDb db)
        {
            _db = db;
        }
        public List<Category1> GetCategory()
        {
            List<Category1> Category = new List<Category1>();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("AllCategory", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category1 category = new Category1();
                            category.Id = reader.GetInt32(0);
                            category.Name = reader.GetString(1);
                            category.Code = reader.GetString(2);
                            category.Active = reader.GetBoolean(3);
                            Category.Add(category);
                        }
                    }
                }
            }
            return Category;
        }
        public async Task CreateCategory([FromForm] CategoryDto categoryDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("InsertCategory", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", categoryDto.Name);
                    command.Parameters.AddWithValue("@Code", categoryDto.Code);
                    command.Parameters.AddWithValue("@Active", categoryDto.Active);

                    command.ExecuteNonQuery();
                }
            }
        }
        public async Task UpdateCategory(int id, [FromForm] CategoryDto categoryDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("UpdateCategory", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    command.Parameters.AddWithValue("@Name", categoryDto.Name);
                    command.Parameters.AddWithValue("@Code", categoryDto.Code);
                    command.Parameters.AddWithValue("@Active", categoryDto.Active);

                    command.ExecuteNonQuery();

                }
            }
        }
        public Category1 IdCategory(int id)
        {
            Category1 category = new Category1();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("IdCategory", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            category.Id = reader.GetInt32(0);
                            category.Name = reader.GetString(1);
                            category.Code = reader.GetString(2);
                            category.Active = reader.GetBoolean(3);
                        }
                    }
                }
            }
            return category;
        }
        public void DeleteCategory(int id)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteCategory", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
