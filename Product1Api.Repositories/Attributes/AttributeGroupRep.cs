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
    public class AttributeGroupRep : IAttributeGroupRep
    {
        private readonly IDb _db;

        public AttributeGroupRep(IDb db)
        {
            _db = db;
        }
        public List<AttributeGroup1> GetAttributeGroup()
        {
            List<AttributeGroup1> Group = new List<AttributeGroup1>();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SelectGroup", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AttributeGroup1 group = new AttributeGroup1();
                            group.Id = reader.GetInt32(0);
                            group.GroupName = reader.GetString(1);
                            group.Code = reader.GetString(2);
                            group.SortOrder = reader.GetInt32(3);
                            group.Description = reader.GetString(4);

                            Group.Add(group);
                        }
                    }
                }
            }
            return Group;
        }
        public async Task CreateAttributeGroup([FromForm] AttributeGroupDto attributegroupDto)
        {

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("InsertGroup", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupName", attributegroupDto.GroupName);
                    command.Parameters.AddWithValue("@Code", attributegroupDto.Code);
                    command.Parameters.AddWithValue("@SortOrder", attributegroupDto.SortOrder);
                    command.Parameters.AddWithValue("@Description", attributegroupDto.Description);

                    command.ExecuteNonQuery();
                }
            }

        }
        public async Task UpdateAttributeGroup(int id, [FromForm] AttributeGroupDto attributegroupDto)
        {

            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("UpdateGroup", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@GroupName", attributegroupDto.GroupName);
                    command.Parameters.AddWithValue("@Code", attributegroupDto.Code);
                    command.Parameters.AddWithValue("@SortOrder", attributegroupDto.SortOrder);
                    command.Parameters.AddWithValue("@Description", attributegroupDto.Description);

                    command.ExecuteNonQuery();

                }
            }
        }
        public void DeleteAttributeGroup(int id)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteGroup", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

        }
        public AttributeGroup1 IdAttributeGroup(int id)
        {
            AttributeGroup1 group = new AttributeGroup1();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("IdGroup", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            group.Id = reader.GetInt32(0);
                            group.GroupName = reader.GetString(1);
                            group.Code = reader.GetString(2);
                            group.SortOrder = reader.GetInt32(3);
                            group.Description = reader.GetString(4);
                        }
                        return (group);
                    }
                }
            }
        }

    }
}
