using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Models.Attributes
{
    public class AttributeGroupDto
    {
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int SortOrder { get; set; } = 0;
        public string Description { get; set; } = "None";
    }
    public class AttributeGroup1
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Code { get; set; }
        public int SortOrder { get; set; }
        public string Description { get; set; }

    }
}

