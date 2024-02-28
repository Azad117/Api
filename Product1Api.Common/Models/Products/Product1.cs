using System.ComponentModel.DataAnnotations;

namespace Product1Api.Common.Models.Products
{
    public class Product1
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public decimal MRP { get; set; }

        public decimal Price { get; set; }

        public string Quantity { get; set; } = "";

        public string Description { get; set; } = "";

        public string Quality { get; set; } = "";

        public string Brand { get; set; } = "";

        public string Category { get; set; } = "";

        public decimal Stock { get; set; }

        public bool isVeg { get; set; }

        public bool isActive { get; set; }

        public string Img { get; set; } = "";


    }
}
