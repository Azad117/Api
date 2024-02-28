using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Attributes;
using Product1Api.Common.Models.Attributes;

namespace Product1Api.Controllers.Attributes
{
    [Route("[controller]")]
    [ApiController]
    public class AttributesController : ControllerBase
    {
        private readonly IAttributesSer _attributesser;

        public AttributesController(IAttributesSer attributesSer)
        {
            _attributesser = attributesSer;
        }

        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpGet("GetAttributes")]
        public IActionResult GET()
        {
            List<Attributes1> Att = new List<Attributes1>();
            try
            {
                Att = _attributesser.getattributes();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Att);
        }
        [HttpPost("CreateAttributes")]
        public async Task<IActionResult> POST([FromForm] AttributesDto attributesDto)
        {
            try
            {
                _attributesser.createattributes(attributesDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpPut("UpdateAttributes/{id}")]
        public async Task<IActionResult> PUT(int id, [FromForm] AttributesDto attributesDto)
        {
            try
            {
                _attributesser.updateattributes(id, attributesDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
       
        [HttpGet("IdAttributes/{id}")]
        public IActionResult GetId(int id)
        {
            Attributes1 Att = new Attributes1();
            try
            {
                Att = _attributesser.idattributes(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Att);
        }
       
        [HttpDelete("DeleteAttributes/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _attributesser.deleteattributes(id);

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
