using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Products;
using Product1Api.Common.Repository.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using Product1Api.Common.Models.Brands;
using System.Data.SqlClient;

namespace Product1Api.Repositories.Brands
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly IDb _db;

        public BrandsRepository(IDb db)
        {
            _db = db;
        }
        public List<Brands1> GetBrands()
        {
            List<Brands1> Brands = new List<Brands1>();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("AllBrands", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Brands1 brands = new Brands1();
                            brands.Id = reader.GetInt32(0);
                            brands.Name = reader.GetString(1);
                            brands.Code = reader.GetString(2);
                            brands.Active = reader.GetBoolean(3);
                            byte[] imageData = (byte[])reader["Img"];
                            string imgdata = Convert.ToBase64String(imageData);
                            string imgurl = string.Format("data:image/jpg;base64,{0}", imgdata);
                            brands.Img = imgurl;
         
                            Brands.Add(brands);
                        }
                    }
                }
            }
            return Brands;
        }
        public async Task CreateBrand([FromForm] BrandsDto brandsDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("InsertBrand", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", brandsDto.Name);
                    command.Parameters.AddWithValue("@Code", brandsDto.Code);
                    command.Parameters.AddWithValue("@Active", brandsDto.Active);

                    using (var stream = new MemoryStream())
                    {
                        await brandsDto.Img.CopyToAsync(stream);
                        command.Parameters.AddWithValue("@Img", stream.ToArray());
                    }
                    command.ExecuteNonQuery();
                }
            }
        }
        public async Task UpdateBrand(int id, [FromForm] BrandsDto brandsDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("UpdateBrand", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    command.Parameters.AddWithValue("@Name", brandsDto.Name);
                    command.Parameters.AddWithValue("@Code", brandsDto.Code);
                    command.Parameters.AddWithValue("@Active", brandsDto.Active);

                    using (var stream = new MemoryStream())
                    {
                        await brandsDto.Img.CopyToAsync(stream);
                        command.Parameters.AddWithValue("@Img", stream.ToArray());
                    }

                    command.ExecuteNonQuery();

                }
            }
        }
        public void DeleteBrand(int id)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteBrand", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public Brands1 IdBrand(int id)
        {
            Brands1 brands = new Brands1();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("IdBrand", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            brands.Id = reader.GetInt32(0);
                            brands.Name = reader.GetString(1);
                            brands.Code = reader.GetString(2);
                            brands.Active = reader.GetBoolean(3);
                            brands.Img = reader.GetString(4);
                        }
                        return (brands);
                    }
                }
            }
        }
    }
}