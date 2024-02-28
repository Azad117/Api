using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Orders;
using Product1Api.Common.Models.Orders;
using Product1Api.Common.Repository.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.ApplicationServices.ApplicationServices.Orders
{
    public class OrdersSer : IOrdersSer
    {
        private readonly IOrdersRep _ordersRep;
        public OrdersSer(IOrdersRep ordersRep)
        {
            _ordersRep = ordersRep;
        }
        public List<Orders1> getorders()
        {
            return _ordersRep.GetOrders();
        }
        public async Task addorder([FromForm] OrdersDto ordersDto)
        {
             _ordersRep.AddOrder(ordersDto);
        }
        public async Task updateorder(int id, [FromForm] OrdersDto ordersDto)
        {
            _ordersRep.UpdateOrder(id, ordersDto);
        }
        public void deleteorder(int id)
        {
            _ordersRep.DeleteOrder(id);
        }
        public Orders1 getorder(int id)
        {
            return _ordersRep.GetOrder(id);
        }
    }
}
