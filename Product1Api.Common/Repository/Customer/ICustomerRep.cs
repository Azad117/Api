using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Repository.Customer
{
    public interface ICustomerRep
    {
        List<Customer1> GetCustomers();
        Task CreateCustomer([FromForm]CustomerDto customerDto);
        Task UpdateCustomer(int id, [FromForm]CustomerDto customerDto);
        void DeleteCustomer(int id);
        Customer1 IdCustomer(int id);
    }
}
