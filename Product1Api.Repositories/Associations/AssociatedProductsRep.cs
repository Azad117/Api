using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Associations;
using Product1Api.Common.Models.Attributes;
using Product1Api.Common.Repository.Associations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Repositories.Associations
{
    public class AssociatedProductsRep: IAssociatedProductsRep
    {

        private readonly IDb _db;
        public AssociatedProductsRep(IDb db) 
        { 
            _db = db; 
        }  

        public List<AssociatedProducts1> GetAssociatedProducts()
        {
            List<AssociatedProducts1> Asp = new List<AssociatedProducts1>();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SelectAsp", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssociatedProducts1 asp = new AssociatedProducts1();
                            asp.Id = reader.GetInt32(0);
                            asp.Name = reader.GetString(1);
                            asp.Code = reader.GetString(2);
                            asp.Active = reader.GetBoolean(3);
                            
                            Asp.Add(asp);
                        }
                    }
                }
            }
            return Asp;
        }

        public async Task CreateAssociatedProducts([FromForm]AssociatedProductsDto associatedProductsDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("InsertAsp", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", associatedProductsDto.Name);
                    command.Parameters.AddWithValue("@Code", associatedProductsDto.Code);
                    command.Parameters.AddWithValue("@Active", associatedProductsDto.Active);
             
                   
                    command.ExecuteNonQuery();
                }
            }
        }

        public async Task UpdateAssociatedProducts(int id, [FromForm]AssociatedProductsDto associatedProductsDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("UpdateAsp", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", associatedProductsDto.Name);
                    command.Parameters.AddWithValue("@Code", associatedProductsDto.Code);
                    command.Parameters.AddWithValue("@Active", associatedProductsDto.Active);
                   
                    command.ExecuteNonQuery();

                }
            }
        }
        public void DeleteAssociatedProducts(int id)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteAsp", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public AssociatedProducts1 IdAssociatedProducts(int id)
        {
            AssociatedProducts1 asp = new AssociatedProducts1();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("IdAsp", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            asp.Id = reader.GetInt32(0);
                            asp.Name = reader.GetString(1);
                            asp.Code = reader.GetString(2);
                            asp.Active = reader.GetBoolean(3);
                            
                        }
                        return (asp);
                    }
                }
            }
        }
    }
}
