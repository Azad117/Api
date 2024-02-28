using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;
using Product1Api.Common.ApplicationServices.Attributes;
using Product1Api.Common.ApplicationServices;
using Product1Api.ApplicationServices.ApplicationServices.Products;
using Product1Api.Common.Models.Products;

namespace Product1Api.Controllers.Attributes
{
    [Route("[controller]")]
    [ApiController]
    public class AttributeTabController : ControllerBase
    {
        private readonly IAttributeTabSer _attributetabser;

        public AttributeTabController(IAttributeTabSer attributetabSer)
        {
            _attributetabser = attributetabSer;
        }

        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpGet("GetAttributeTab")]
        public IActionResult GET()
        {
            List<AttributeTab1> Tab = new List<AttributeTab1>();
            try
            {
                Tab = _attributetabser.getattributetab();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Tab);
        }
        [HttpPost("CreateAttributeTab")]
        public async Task<IActionResult> POST([FromForm] AttributeTabDto attributetabDto)
        {
            try
            {
                _attributetabser.createattributetab(attributetabDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpPut("UpdateAttributeTab/{id}")]
        public async Task<IActionResult> PUT(int id,[FromForm] AttributeTabDto attributetabDto)
        {
            try
            {
                _attributetabser.updateattributetab(id,attributetabDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet("IdAttributeTab/{id}")]
        public IActionResult GetId(int id)
        {
            AttributeTab1 Tab = new AttributeTab1();
            try
            {
                Tab = _attributetabser.idattributetab(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Tab);
        }
        [HttpDelete("DeleteAttributeTab/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _attributetabser.deleteattributetab(id);

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
