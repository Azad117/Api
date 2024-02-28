using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices;
using Product1Api.Common.Models.Products;

namespace Product1Api.Controllers.Products
{
    [Route("[controller]")]
    [ApiController]
    public class DeleteProductController : ControllerBase
    {
        private readonly IProductServices _productservices;
        
        public DeleteProductController(IProductServices productServices)
        {
            _productservices = productServices;
        }
        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpDelete("{id}")]
        public IActionResult DELETE(int id)
        {
            try
            {
                _productservices.deleteproduct(id);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();

        }
    }
}
