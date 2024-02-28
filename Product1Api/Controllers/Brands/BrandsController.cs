using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Brands;
using Product1Api.Common.Models.Brands;
using Product1Api.Common.Models.Products;

namespace Product1Api.Controllers.Brands
{
    [Route("[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        private readonly IBrandsServices _brandsServices;
        public BrandsController(IBrandsServices brandsServices)
        {
            _brandsServices = brandsServices;
        }
        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpGet]
        public IActionResult GET()
        {
            List<Brands1> Brands = new List<Brands1>();
            try
            {
                Brands = _brandsServices.getbrands();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Brands);
        }
        [HttpPost]
        public IActionResult POST([FromForm] BrandsDto brandsDto)
        {
            try
            {
                _brandsServices.createbrand(brandsDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PUT(int id, [FromForm] BrandsDto brandsDto)
        {
            try
            {
                _brandsServices.updatebrand(id,brandsDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            Brands1 brands = new Brands1();
            try
            {
                brands = _brandsServices.idbrand(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(brands);
        }
        /*[HttpDelete("{id}")]
        public IActionResult DELETE(int id)
        {
            try
            {
                _brandsServices.deletebrand(id);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }*/
    }
}
