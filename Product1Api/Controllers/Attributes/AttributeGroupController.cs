using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Attributes;
using Product1Api.Common.Models.Attributes;

namespace Product1Api.Controllers.Attributes
{
    [Route("[controller]")]
    [ApiController]
    public class AttributeGroupController : ControllerBase
    {
        private readonly IAttributeGroupSer _attributegroupser;

        public AttributeGroupController(IAttributeGroupSer attributegroupSer)
        {
            _attributegroupser = attributegroupSer;
        }

        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpGet("GetAttributeGroup")]
        public IActionResult GET()
        {
            List<AttributeGroup1> Group = new List<AttributeGroup1>();
            try
            {
                Group = _attributegroupser.getattributegroup();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Group);
        }
        [HttpPost("CreateAttributeGroup")]
        public async Task<IActionResult> POST([FromForm] AttributeGroupDto attributegroupDto)
        {
            try
            {
                _attributegroupser.createattributegroup(attributegroupDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpPut("UpdateAttributeGroup/{id}")]
        public async Task<IActionResult> PUT(int id, [FromForm] AttributeGroupDto attributegroupDto)
        {
            try
            {
                _attributegroupser.updateattributegroup(id, attributegroupDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet("IdAttributeGroup/{id}")]
        public IActionResult GetId(int id)
        {
            AttributeGroup1 Group = new AttributeGroup1();
            try
            {
                Group = _attributegroupser.idattributegroup(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Group);
        }
        [HttpDelete("DeleteAttributeGroup/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _attributegroupser.deleteattributegroup(id);

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
