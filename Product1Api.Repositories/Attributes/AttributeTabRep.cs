using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;
using Product1Api.Common.Repository.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Repositories.Attributes
{
    public class AttributeTabRep : IAttributeTabRep
    {
        private readonly IDb _db;

        public AttributeTabRep(IDb db)
        {
            _db = db;
        }

        public List<AttributeTab1> GetAttributeTab()
        {
            List<AttributeTab1> Tab = new List<AttributeTab1>();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SelectTab", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AttributeTab1 tab = new AttributeTab1();
                            tab.Id = reader.GetInt32(0);
                            tab.Name = reader.GetString(1);
                            tab.Description = reader.GetString(2);

                            Tab.Add(tab);
                        }
                    }
                }
            }
            return Tab;
        }
        public async Task CreateAttributeTab([FromForm] AttributeTabDto attributetabDto)
        {

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("InsertTab", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TabName", attributetabDto.Name);
                    command.Parameters.AddWithValue("@Description", attributetabDto.Description);
                   
                    command.ExecuteNonQuery();
                }
            }

        }
        public async Task UpdateAttributeTab(int id, [FromForm] AttributeTabDto attributetabDto)
        {

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("UpdateTab", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    command.Parameters.AddWithValue("@TabName", attributetabDto.Name);
                    command.Parameters.AddWithValue("@Description", attributetabDto.Description);
                    
                    command.ExecuteNonQuery();

                }
            }
        }
        public void DeleteAttributeTab(int id)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteTab", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

        }
        public AttributeTab1 IdAttributeTab(int id)
        {
            AttributeTab1 Tab = new AttributeTab1();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("IdTab", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Tab.Id = reader.GetInt32(0);
                            Tab.Name = reader.GetString(1);
                            Tab.Description = reader.GetString(2);
                        }
                        return (Tab);
                    }
                }
            }
        }
    }
}
