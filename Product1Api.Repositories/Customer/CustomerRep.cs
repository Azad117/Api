using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Customer;
using Product1Api.Common.Models.Products;
using Product1Api.Common.Repository.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Repositories.Customer
{
    public class CustomerRep : ICustomerRep
    {
        private readonly IDb _db;
        public CustomerRep(IDb db)
        {
            _db = db;
        }
        public List<Customer1> GetCustomers()
        {
            List<Customer1> Cust = new List<Customer1>();

            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("AllCustomers", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer1 cust = new Customer1();
                            cust.Id = reader.GetInt32(0);
                            cust.Name = reader.GetString(1);
                            cust.Email = reader.GetString(2);
                            cust.Phone = reader.GetString(3);
                            cust.Dob = reader.GetString(4);
                            cust.Gender = reader.GetString(5);
                            cust.Street = reader.GetString(6);
                            cust.City = reader.GetString(7);
                            cust.State = reader.GetString(8);
                            cust.Zip = reader.GetString(9);

                            byte[] imageData = (byte[])reader["Img"];
                            string imgdata = Convert.ToBase64String(imageData);
                            string imgurl = string.Format("data:image/jpg;base64,{0}", imgdata);
                            cust.Img = imgurl;
                            cust.Active = reader.GetBoolean(11);

                            Cust.Add(cust);
                        }
                    }
                }
            }
            return Cust;
        }
        public async Task CreateCustomer([FromForm] CustomerDto customerDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("InsertCustomer", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", customerDto.Name);
                    command.Parameters.AddWithValue("@Email", customerDto.Email);
                    command.Parameters.AddWithValue("@Phone", customerDto.Phone);
                    command.Parameters.AddWithValue("@Dob", customerDto.Dob);
                    command.Parameters.AddWithValue("@Gender", customerDto.Gender);
                    command.Parameters.AddWithValue("@Street", customerDto.Street);
                    command.Parameters.AddWithValue("@City", customerDto.City);
                    command.Parameters.AddWithValue("@State", customerDto.State);
                    command.Parameters.AddWithValue("@Zip", customerDto.Zip);
                    using (var stream = new MemoryStream())
                    {
                        await customerDto.Img.CopyToAsync(stream);
                        command.Parameters.AddWithValue("@Img", stream.ToArray());
                    }
                    command.Parameters.AddWithValue("@Active", customerDto.Active);
                    
                    command.ExecuteNonQuery();
                }
            }
        }
        public async Task UpdateCustomer(int id, [FromForm] CustomerDto customerDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("UpdateCustomer", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    command.Parameters.AddWithValue("@Name", customerDto.Name);
                    command.Parameters.AddWithValue("@Email", customerDto.Email);
                    command.Parameters.AddWithValue("@Phone", customerDto.Phone);
                    command.Parameters.AddWithValue("@Dob", customerDto.Dob);
                    command.Parameters.AddWithValue("@Gender", customerDto.Gender);
                    command.Parameters.AddWithValue("@Street", customerDto.Street);
                    command.Parameters.AddWithValue("@City", customerDto.City);
                    command.Parameters.AddWithValue("@State", customerDto.State);
                    command.Parameters.AddWithValue("@Zip", customerDto.Zip);
                    using (var stream = new MemoryStream())
                    {
                        await customerDto.Img.CopyToAsync(stream);
                        command.Parameters.AddWithValue("@Img", stream.ToArray());
                    }
                    command.Parameters.AddWithValue("@Active", customerDto.Active);

                    command.ExecuteNonQuery();
                }
            }
        }
        public Customer1 IdCustomer(int id)
        {
            Customer1 cust = new Customer1();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("IdCustomer", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cust.Id = reader.GetInt32(0);
                            cust.Name = reader.GetString(1);
                            cust.Email = reader.GetString(2);
                            cust.Phone = reader.GetString(3);
                            cust.Dob = reader.GetString(4);
                            cust.Gender = reader.GetString(5);
                            cust.Street = reader.GetString(6);
                            cust.City = reader.GetString(7);
                            cust.State = reader.GetString(8);
                            cust.Zip = reader.GetString(9);

                            byte[] imageData = (byte[])reader["Img"];
                            string imgdata = Convert.ToBase64String(imageData);
                            string imgurl = string.Format("data:image/jpg;base64,{0}", imgdata);
                            cust.Img = imgurl;
                            cust.Active = reader.GetBoolean(11);
                            
                        }
                        return (cust);
                    }
                }
            }
        }
        public void DeleteCustomer(int id)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteCustomer", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
