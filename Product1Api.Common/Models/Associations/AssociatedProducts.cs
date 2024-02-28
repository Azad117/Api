using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Models.Associations
{
    public class AssociatedProductsDto
    {

        [Required]
        public string Name{ get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public bool Active { get; set; }
        
    }
    public class AssociatedProducts1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
    }
}
