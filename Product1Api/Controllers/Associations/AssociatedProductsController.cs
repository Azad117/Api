using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Associations;
using Product1Api.Common.Models.Associations;
using Product1Api.Common.Models.Attributes;

namespace Product1Api.Controllers.Associations
{
    public class AssociatedProductsController : ControllerBase
    {
        private readonly IAssociatedProductsSer _associatedproductsser;

        public AssociatedProductsController(IAssociatedProductsSer associatedproductSer)
        {
            _associatedproductsser = associatedproductSer;
        }

        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpGet("GetAssociatedProducts")]
        public IActionResult Get()
        {
            List<AssociatedProducts1> associatedproducts = new List<AssociatedProducts1>();
            try
            {
                associatedproducts = _associatedproductsser.getassociatedproducts();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(associatedproducts);
        }
        [HttpPost("CreateAssociatedProducts")]
        public IActionResult Post([FromForm] AssociatedProductsDto associatedproductsDto)
        {
            try
            {
                _associatedproductsser.createassociatedproduct(associatedproductsDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpPut("UpdateAssociatedProducts/{id}")]
        public IActionResult Put(int id, [FromForm] AssociatedProductsDto associatedproductsDto)
        {
            try
            {
                _associatedproductsser.updateassociatedproduct(id,associatedproductsDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet("IdAssociatedProducts/{id}")]
        public IActionResult GetId(int id)
        {
            AssociatedProducts1 associatedproducts = new AssociatedProducts1();
            try
            {
                associatedproducts = _associatedproductsser.idassociatedproduct(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(associatedproducts);
        }

        [HttpDelete("DeleteAssociatedProducts/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _associatedproductsser.deleteassociatedproduct(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }

    }
}
