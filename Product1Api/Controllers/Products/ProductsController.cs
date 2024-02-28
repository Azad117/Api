using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Product1Api.ApplicationServices.ApplicationServices.Products;
using Product1Api.Repositories.Products;
using Product1Api.Common.ApplicationServices;
using Product1Api.Common.Models.Products;

namespace Product1Api.Controllers.Products
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productservices;

        public ProductsController(IProductServices productServices)
        {
            _productservices = productServices;
        }

        public static IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
        
        [HttpPost]
        public async Task<IActionResult> POST( [FromForm]ProductDto productDto)
        {
            try
            {
                _productservices.createproduct(productDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "sorry , but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet]
        public IActionResult GET()
        {
            List<Product1> Products = new List<Product1>();
            try
            {
                Products = _productservices.getproducts();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(Products);
        }
        [HttpGet("{id}")]
        public IActionResult GETID(int id)
        {
            Product1 products = new Product1();
            try
            {
                products = _productservices.idproduct(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(products);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PUT(int id, [FromForm] ProductDto productDto)
        {

            try
            {
                _productservices.updateproduct(id, productDto);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("product", "sorry,but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        /*[HttpDelete("{id}")]
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

        }*/

    }
}