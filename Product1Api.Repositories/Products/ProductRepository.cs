using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System;
using Product1Api.Common.Models.Products;


namespace Product1Api.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDb _db;

        public ProductRepository(IDb db)
        {
            _db = db;
        } 
        //get
        public List<Product1> GetProducts()
        {
            List<Product1> Product = new List<Product1>();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("AllProducts", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product1 products = new Product1();
                            products.Id = reader.GetInt32(0);
                            products.Name = reader.GetString(1);
                            products.Price = reader.GetDecimal(2);
                            products.Quantity = reader.GetString(3);
                            products.Description = reader.GetString(4);
                            products.Quality = reader.GetString(5);
                            
                            byte[] imageData = (byte[])reader["Img"];
                            string imgdata =  Convert.ToBase64String(imageData);
                            string imgurl = string.Format("data:image/jpg;base64,{0}",imgdata);
                            products.Img = imgurl;

                            products.Brand = reader.GetString(7);
                            products.Category = reader.GetString(8);
                            products.Stock = reader.GetDecimal(9);
                            products.isActive = reader.GetBoolean(10);
                            products.MRP = reader.GetDecimal(11);
                            products.isVeg = reader.GetBoolean(12);
                            
                            Product.Add(products);
                        }
                    }
                }
            }
            return Product;
        }
        //postmethod
        public async Task CreateProduct([FromForm]ProductDto productDto)
        {

            using (var connection = _db.CreateConnection())
            {
                connection.Open();
         
                using (var command = new SqlCommand("AddProduct", (SqlConnection)connection))
                {   
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", productDto.Name);
                    command.Parameters.AddWithValue("@Price", productDto.Price);
                    command.Parameters.AddWithValue("@Quantity", productDto.Quantity);
                    command.Parameters.AddWithValue("@Description", productDto.Description);
                    command.Parameters.AddWithValue("@Quality", productDto.Quality);

                    using(var stream = new MemoryStream())
                    {
                        await productDto.Img.CopyToAsync(stream);
                        command.Parameters.AddWithValue("@Img",stream.ToArray());
                    }
                    command.Parameters.AddWithValue("@Brand",productDto.Brand);
                    command.Parameters.AddWithValue("@Category",productDto.Category);
                    command.Parameters.AddWithValue("@Stock",productDto.Stock);    
                    command.Parameters.AddWithValue("@isActive",productDto.isActive);
                    command.Parameters.AddWithValue("@MRP", productDto.MRP);
                    command.Parameters.AddWithValue("@isVeg", productDto.isVeg);
                    command.ExecuteNonQuery();
                }
            }
        }
        //putmethod
        public async Task UpdateProduct(int id,[FromForm] ProductDto productDto)
        {

            using (var connection = _db.CreateConnection())
            {
                connection.Open();
      
                using (var command = new SqlCommand("UpdateProduct", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    command.Parameters.AddWithValue("@Name", productDto.Name);
                    command.Parameters.AddWithValue("@Price", productDto.Price);
                    command.Parameters.AddWithValue("@Quantity", productDto.Quantity);
                    command.Parameters.AddWithValue("@Description", productDto.Description);
                    command.Parameters.AddWithValue("@Quality", productDto.Quality);
                     using(var stream = new MemoryStream())
                    {
                        await productDto.Img.CopyToAsync(stream);
                        command.Parameters.AddWithValue("@Img",stream.ToArray());
                    }
                    command.Parameters.AddWithValue("@Brand",productDto.Brand);
                    command.Parameters.AddWithValue("@Category",productDto.Category);
                    command.Parameters.AddWithValue("@Stock",productDto.Stock);
                    command.Parameters.AddWithValue("@isActive",productDto.isActive);
                    command.Parameters.AddWithValue("@MRP", productDto.MRP);
                    command.Parameters.AddWithValue("@isVeg",productDto.isVeg);
                    command.ExecuteNonQuery();

                }
            }
        }
        //deletemethod
        public void DeleteProduct(int id)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteProduct", (SqlConnection)connection))
                {   
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

        }


        //GETBYID
        public Product1 IdProduct(int id)
        {
            Product1 products = new Product1();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("IdProduct", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            products.Id = reader.GetInt32(0);
                            products.Name = reader.GetString(1);
                            products.Price = reader.GetDecimal(2);
                            products.Quantity = reader.GetString(3);
                            products.Description = reader.GetString(4);
                            products.Quality = reader.GetString(5);
                            products.Brand = reader.GetString(7);
                            products.Category = reader.GetString(8);
                            products.Stock = reader.GetDecimal(9);
                            byte[] imageData = (byte[])reader["Img"];
                            string imgdata =  Convert.ToBase64String(imageData);
                            string imgurl = string.Format("data:image/jpg;base64,{0}",imgdata);
                            products.Img = imgurl;
                            products.isActive = reader.GetBoolean(10);
                            products.MRP = reader.GetDecimal(11);
                            products.isVeg = reader.GetBoolean(12);                          
                        }
                        return (products);
                    }
                }
            }
        }
    }
}
