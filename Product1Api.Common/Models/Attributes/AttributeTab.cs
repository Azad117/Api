using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Models.Attributes
{
    public class AttributeTabDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; } = "";
    }
    public class AttributeTab1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
