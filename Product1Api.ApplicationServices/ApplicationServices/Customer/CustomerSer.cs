using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Customer;
using Product1Api.Common.Models.Customer;
using Product1Api.Common.Repository.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.ApplicationServices.ApplicationServices.Customer
{
    public class CustomerSer : ICustomerSer
    {
        private readonly ICustomerRep _customerRep;
        public CustomerSer(ICustomerRep customerRep)
        {
            _customerRep = customerRep;
        }
        public List<Customer1> getcustomers()
        {
            return _customerRep.GetCustomers();
        }
        public async Task createcustomer([FromForm] CustomerDto customerDto)
        {
             _customerRep.CreateCustomer(customerDto);
        }
        public async Task updatecustomer(int id, [FromForm] CustomerDto customerDto)
        {
             _customerRep.UpdateCustomer(id, customerDto);
        }
        public Customer1 idcustomer(int id)
        {
            return _customerRep.IdCustomer(id);
        }
        public void deletecustomer(int id)
        {
            _customerRep.DeleteCustomer(id);
        }
    }
}
