using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Orders;
using Product1Api.Common.Repository.Orders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Repositories.Orders
{
    public class OrdersRep : IOrdersRep
    {
        private readonly IDb _db;
        public OrdersRep(IDb db)
        {
            _db = db;
        }
        public List<Orders1> GetOrders()
        {
            List<Orders1> Orders = new List<Orders1>();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("AllOrders", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Orders1 orders = new Orders1();
                            orders.OrderId = reader.GetInt32(0);
                            orders.CustomerId = reader.GetInt32(1);
                            orders.ProductId = reader.GetInt32(2);
                            orders.Price = reader.GetDecimal(3);
                            orders.Quantity = reader.GetInt32(4);
                            orders.TotalPrice = reader.GetDecimal(5);
                            orders.OrderMethod = reader.GetString(6);
                            orders.PaymentMethod = reader.GetString(7);
                            orders.PaymentStatus = reader.GetBoolean(8);
                            orders.OrderDate = reader.GetDateTime(9);
                            orders.DeliveryDate = reader.GetDateTime(10);
                            orders.Status = reader.GetString(11);

                            Orders.Add(orders);
                        }
                    }
                }
            }
            return Orders;
        }
        public Orders1 GetOrder(int id)
        {
            Orders1 orders = new Orders1();
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("IdOrder", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.OrderId = reader.GetInt32(0);
                            orders.CustomerId = reader.GetInt32(1);
                            orders.ProductId = reader.GetInt32(2);
                            orders.Price = reader.GetDecimal(3);
                            orders.Quantity = reader.GetInt32(4);
                            orders.TotalPrice = reader.GetDecimal(5);
                            orders.OrderMethod = reader.GetString(6);
                            orders.PaymentMethod = reader.GetString(7);
                            orders.PaymentStatus = reader.GetBoolean(8);
                            orders.OrderDate = reader.GetDateTime(9);
                            orders.DeliveryDate = reader.GetDateTime(10);
                            orders.Status = reader.GetString(11);
                        }
                    }
                }
            }
            return orders;
        }
        public async Task AddOrder([FromForm]OrdersDto ordersDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("CreateOrder", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerId", ordersDto.CustomerId);
                    command.Parameters.AddWithValue("@ProductId", ordersDto.ProductId);
                    command.Parameters.AddWithValue("@Price", ordersDto.Price);
                    command.Parameters.AddWithValue("@Quantity", ordersDto.Quantity);
                    command.Parameters.AddWithValue("@TotalPrice", ordersDto.TotalPrice);
                    command.Parameters.AddWithValue("@OrderMethod", ordersDto.OrderMethod);
                    command.Parameters.AddWithValue("@PaymentMethod", ordersDto.PaymentMethod);
                    command.Parameters.AddWithValue("@PaymentStatus", ordersDto.PaymentStatus);
                    command.Parameters.AddWithValue("@DeliveryDate", ordersDto.DeliveryDate);
                    command.Parameters.AddWithValue("@Status", ordersDto.Status);

                    command.ExecuteNonQuery();
                }
            }
        }
        public async Task UpdateOrder(int id, [FromForm]OrdersDto ordersDto)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("OrdersUpdate", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@CustomerId", ordersDto.CustomerId);
                    command.Parameters.AddWithValue("@ProductId", ordersDto.ProductId);
                    command.Parameters.AddWithValue("@Price", ordersDto.Price);
                    command.Parameters.AddWithValue("@Quantity", ordersDto.Quantity);
                    command.Parameters.AddWithValue("@TotalPrice", ordersDto.TotalPrice);
                    command.Parameters.AddWithValue("@OrderMethod", ordersDto.OrderMethod);
                    command.Parameters.AddWithValue("@PaymentMethod", ordersDto.PaymentMethod);
                    command.Parameters.AddWithValue("@PaymentStatus", ordersDto.PaymentStatus);
                    command.Parameters.AddWithValue("@DeliveryDate", ordersDto.DeliveryDate);
                    command.Parameters.AddWithValue("@Status", ordersDto.Status);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteOrder(int id)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteOrders", (SqlConnection)connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
