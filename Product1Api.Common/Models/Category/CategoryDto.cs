using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Models.Category
{
    public class CategoryDto
    {

        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Code { get; set; } = "";
        [Required]
        public bool Active { get; set; }
    }
}
