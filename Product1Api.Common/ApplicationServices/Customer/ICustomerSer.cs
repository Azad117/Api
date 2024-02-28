using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.ApplicationServices.Customer
{
    public interface ICustomerSer
    {
        List<Customer1> getcustomers();
        Task createcustomer([FromForm]CustomerDto customerDto);
        Task updatecustomer(int id, [FromForm]CustomerDto customerDto);
        void deletecustomer(int id);
        Customer1 idcustomer(int id);
    }
}
