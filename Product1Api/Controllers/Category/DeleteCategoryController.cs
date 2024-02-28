using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Category;

namespace Product1Api.Controllers.Category
{
    [Route("[controller]")]
    [ApiController]
    public class DeleteCategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryservices;

        public DeleteCategoryController(ICategoryServices categoryServices)
        {
            _categoryservices = categoryServices;
        }
        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpDelete("{id}")]
        public IActionResult DELETE(int id)
        {
            try
            {
                _categoryservices.deletecategory(id);
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
