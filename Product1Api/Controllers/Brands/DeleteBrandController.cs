using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Brands;

namespace Product1Api.Controllers.Brands
{

    [Route("[controller]")]
    [ApiController]
    public class DeleteBrandController : ControllerBase
    {
        private readonly IBrandsServices _brandsservices;

        public DeleteBrandController(IBrandsServices brandsServices)
        {
            _brandsservices = brandsServices;
        }
        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpDelete("{id}")]
        public IActionResult DELETE(int id)
        {
            try
            {
                _brandsservices.deletebrand(id);

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
