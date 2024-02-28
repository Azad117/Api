using Microsoft.AspNetCore.Mvc;
using Product1Api.ApplicationServices.ApplicationServices.Attributes;
using Product1Api.Common.ApplicationServices.Associations;
using Product1Api.Common.ApplicationServices.Attributes;
using Product1Api.Common.Models.Associations;
using Product1Api.Common.Models.Attributes;

namespace Product1Api.Controllers.Associations
{
    [Route("[controller]")]
    [ApiController]
    public class AssociationsController : ControllerBase
    {
        private readonly IAssociationsSer _associationsser;

        public AssociationsController(IAssociationsSer associationsSer)
        {
            _associationsser = associationsSer;
        }

        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpGet("GetAssociations")]
        public IActionResult Get()
        {
            List<Associations1> associations = new List<Associations1>();
            try
            {
                associations = _associationsser.getassociations();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(associations);
        }
        [HttpPost("CreateAssociations")]
        public IActionResult Post([FromForm]AssociationsDto associationsDto)
        {
            try
            {
                _associationsser.createassociation(associationsDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpPut("UpdateAssociations/{id}")]
        public IActionResult Put(int id, [FromForm]AssociationsDto associationsDto)
        {
            try
            {
                _associationsser.updateassociation(id,associationsDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet("IdAssociations/{id}")]
        public IActionResult GetId(int id)
        {
            Associations1 associations = new Associations1();
            try
            {
                associations = _associationsser.idassociation(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(associations);
        }

        [HttpDelete("DeleteAssociations/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _associationsser.deleteassociation(id);
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
