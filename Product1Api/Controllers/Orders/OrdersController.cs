using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Orders;
using Product1Api.Common.Models.Orders;

namespace Product1Api.Controllers.Orders
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersSer _ordersSer;
        public OrdersController(IOrdersSer ordersSer)
        {
            _ordersSer = ordersSer;
        }
        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
        [HttpGet("Orders")]
        public IActionResult GET()
        {
            List<Orders1> Orders = new List<Orders1>();
            try
            {
                Orders = _ordersSer.getorders();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("order", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Orders);
        }
        [HttpPost("InsertOrder")]
        public async Task<IActionResult> POST([FromForm]OrdersDto ordersDto)
        {
            try
            {
                _ordersSer.addorder(ordersDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("order", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> PUT(int id, [FromForm]OrdersDto ordersDto)
        {
            try
            {
                _ordersSer.updateorder(id, ordersDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("order", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet("IdOrder/{id}")]
        public IActionResult GETID(int id)
        {
            Orders1 order = new Orders1();
            try
            {
                order = _ordersSer.getorder(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("order", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(order);
        }
        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DELETE(int id)
        {
            try
            {
                _ordersSer.deleteorder(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("order", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
