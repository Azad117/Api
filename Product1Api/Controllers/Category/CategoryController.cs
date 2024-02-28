using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Category;
using Product1Api.Common.Models.Category;

namespace Product1Api.Controllers.Category
{
    [Route("[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        [HttpGet]
        public IActionResult GET()
        {
            List<Category1> Category = new List<Category1>();
            try
            {
                Category = _categoryServices.getcategory();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Category);

        }
        [HttpPost]
        public IActionResult POST([FromForm] CategoryDto categoryDto)
        {
            try
            {
                _categoryServices.createcategory(categoryDto);
            }
             catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PUT(int id, [FromForm] CategoryDto categoryDto) 
        {
            try
            {
                _categoryServices.updatecategory(id,categoryDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GET(int id)
        {
            Category1 category = new Category1();
            try
            {
                category = _categoryServices.idcategory(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(category);
        }
        /*[HttpDelete("{id}")]
        public IActionResult DELETE(int id) 
        {
            try
            {
                _categoryServices.deletecategory(id);
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
