using Product1Api.Common.Models.Associations;
using Product1Api.Common.Repository.Associations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Repositories.Associations
{
    public class AssociationsRep : IAssociationsRep
    {
        private readonly IDb _db;
        public AssociationsRep(IDb db)
        { 
            _db = db;
        }
        public List<Associations1> GetAssociations()
        {
            List<Associations1> Asn = new List<Associations1>();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SelectAsn", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Associations1 asn = new Associations1();
                            asn.Id = reader.GetInt32(0);
                            asn.Association = reader.GetString(1);
                            asn.MainProduct = reader.GetString(2);
                            asn.RelatedProduct = reader.GetString(3);
                            asn.SortOrrder = reader.GetInt32(4);

                            Asn.Add(asn);
                        }
                    }
                }
            }
            return Asn;
        }
        public async Task CreateAssociation(AssociationsDto associationsDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("InsertAsn", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Association", associationsDto.Association);
                    command.Parameters.AddWithValue("@MainProduct", associationsDto.MainProduct);
                    command.Parameters.AddWithValue("@RelatedProduct", associationsDto.RelatedProduct);
                    command.Parameters.AddWithValue("@SortOrder", associationsDto.SortOrrder); 

                    command.ExecuteNonQuery();
                }
            }
        }
        public async Task UpdateAssociation(int id, AssociationsDto associationsDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("UpdateAsn", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Association", associationsDto.Association);
                    command.Parameters.AddWithValue("@MainProduct", associationsDto.MainProduct);
                    command.Parameters.AddWithValue("@RelatedProduct", associationsDto.RelatedProduct);
                    command.Parameters.AddWithValue("@SortOrder", associationsDto.SortOrrder);

                    command.ExecuteNonQuery();

                }
            }
        }
        public Associations1 IdAssociation(int id)
        {
            Associations1 asn = new Associations1();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("IdAsn", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            asn.Id = reader.GetInt32(0);
                            asn.Association = reader.GetString(1);
                            asn.MainProduct = reader.GetString(2);
                            asn.RelatedProduct = reader.GetString(3);
                            asn.SortOrrder = reader.GetInt32(4);
                        }
                        return asn;
                    }
                }
            }
        }
        public void DeleteAssociation(int id)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteAsn", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
