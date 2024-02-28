using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Repository.Orders
{
    public interface IOrdersRep
    {
        Task AddOrder([FromForm]OrdersDto ordersDto);
        Task UpdateOrder(int id, [FromForm]OrdersDto ordersDto);
        void DeleteOrder(int id);
        List<Orders1> GetOrders();
        Orders1 GetOrder(int id);
    }
}
