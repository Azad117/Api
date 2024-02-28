using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Product1Api.Common.Models.Products
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public decimal MRP { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Quantity { get; set; } = "";
        [Required]
        public string Description { get; set; } = "None";
        [Required]
        public string Quality { get; set; } = "";
        [Required]
        public string Brand { get; set; } = "";
        [Required]
        public string Category { get; set; } = "";
        [Required]
        public decimal Stock { get; set; }
        [Required]
        public bool isActive { get; set; }
        [Required]
        public bool isVeg { get; set; }
        [Required]
        public IFormFile Img { get; set; }


    }
}
