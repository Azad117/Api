using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.ApplicationServices.Orders
{
    public interface IOrdersSer
    {
        Task addorder([FromForm]OrdersDto ordersDto);
        Task updateorder(int id,[FromForm]OrdersDto ordersDto);
        void deleteorder(int id);
        List<Orders1> getorders();
        Orders1 getorder(int id);
    }
}
