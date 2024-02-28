using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Models.Brands
{
    public class BrandsDto
    {
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Code { get; set; } = "";
        [Required]
        public bool Active { get; set; }
        [Required]
        public IFormFile Img { get; set; }

    }
}
