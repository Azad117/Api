using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Models.Associations
{
    public class AssociationsDto
    {
        [Required]
        public string Association { get; set; }
        [Required]
        public string MainProduct { get; set; }
        [Required]
        public string RelatedProduct { get; set; }
        [Required]
        public int SortOrrder { get; set; }
    }
    public class Associations1
    {
        public int Id { get; set; }
        public string Association { get; set; }
        public string MainProduct { get; set; }
        public string RelatedProduct { get; set; }
        public int SortOrrder { get; set; }
    }
}
