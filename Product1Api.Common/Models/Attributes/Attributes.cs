using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Models.Attributes
{
    public class AttributesDto
    {
        [Required]
        public string AttName { get; set; }
        [Required]
        public string AttType { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string AttGroup { get; set; }
        [Required]
        public string AttTab {  get; set; }
        public string Description { get; set; } = "None";
    }
    public class Attributes1
    {
        public int Id { get; set; }
        public string AttName { get; set; }
        public string AttType { get; set; }
        public string Code { get; set; }
        public string AttGroup { get; set; }
        public string AttTab { get; set; }
        public string Description { get; set; }

    }
}
