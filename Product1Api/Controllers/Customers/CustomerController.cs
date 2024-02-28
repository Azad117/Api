using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Customer;
using Product1Api.Common.Models.Customer;

namespace Product1Api.Controllers.Customers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerSer _customerser;

        public CustomerController(ICustomerSer customerSer)
        {
            _customerser = customerSer;
        }
        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpGet("Customers")]
        public IActionResult GET()
        {
            List<Customer1> Customers = new List<Customer1>();
            try
            {
                Customers = _customerser.getcustomers();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("customer", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Customers);
        }
        [HttpPost("InsertCustomer")]
        public async Task<IActionResult> POST([FromForm]CustomerDto customerDto)
        {
            try
            {
                _customerser.createcustomer(customerDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("customer", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> PUT(int id, [FromForm]CustomerDto customerDto)
        {
            try
            {
                _customerser.updatecustomer(id, customerDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("customer", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpDelete("DeleteCustomer/{id}")]
        public IActionResult DELETE(int id)
        {
            try
            {
                _customerser.deletecustomer(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("customer", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet("Customerby/{id}")]
        public IActionResult GETID(int id)
        {
            Customer1 customer = new Customer1();
            try
            {
                customer = _customerser.idcustomer(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("customer", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }
    }
}
