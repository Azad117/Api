using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;
using Product1Api.Common.Models.Products;
using Product1Api.Common.Repository.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Repositories.Attributes
{
    public class AttributesRep : IAttributesRep
    {
        private readonly IDb _db;

        public AttributesRep(IDb db)
        {
            _db = db;
        }
        public List<Attributes1> GetAttributes()
        {
            List<Attributes1> Att = new List<Attributes1>();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SelectAtt", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Attributes1 att = new Attributes1();
                            att.Id = reader.GetInt32(0);
                            att.AttName = reader.GetString(1);
                            att.AttType = reader.GetString(2);
                            att.Code = reader.GetString(3);
                            att.AttGroup = reader.GetString(4);
                            att.AttTab = reader.GetString(5);
                            att.Description = reader.GetString(6);

                            Att.Add(att);
                        }
                    }
                }
            }
            return Att;
        }
        public async Task CreateAttributes([FromForm] AttributesDto attributesDto)
        {

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("InsertAtt", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AttName", attributesDto.AttName);
                    command.Parameters.AddWithValue("@AttType", attributesDto.AttType);
                    command.Parameters.AddWithValue("@Code", attributesDto.Code);
                    command.Parameters.AddWithValue("@AttGroup", attributesDto.AttGroup);
                    command.Parameters.AddWithValue("@AttTab", attributesDto.AttTab);
                    command.Parameters.AddWithValue("@Description", attributesDto.Description);

                    command.ExecuteNonQuery();
                }
            }

        }
        public async Task UpdateAttributes(int id,[FromForm] AttributesDto attributesDto)
        {

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("UpdateAtt", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@AttName", attributesDto.AttName);
                    command.Parameters.AddWithValue("@AttType", attributesDto.AttType);
                    command.Parameters.AddWithValue("@Code", attributesDto.Code);
                    command.Parameters.AddWithValue("@AttGroup", attributesDto.AttGroup);
                    command.Parameters.AddWithValue("@AttTab", attributesDto.AttTab);
                    command.Parameters.AddWithValue("@Description", attributesDto.Description);

                    command.ExecuteNonQuery();

                }
            }
        }
        public void DeleteAttributes(int id)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteAtt", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

        }
        public Attributes1 IdAttributes(int id)
        {
            Attributes1 att = new Attributes1();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("IdAtt", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            att.Id = reader.GetInt32(0);
                            att.AttName = reader.GetString(1);
                            att.AttType = reader.GetString(2);
                            att.Code = reader.GetString(3);
                            att.AttGroup = reader.GetString(4);
                            att.AttTab = reader.GetString(5);
                            att.Description = reader.GetString(6);
                        }
                        return (att);
                    }
                }
            }
        }
    }
}