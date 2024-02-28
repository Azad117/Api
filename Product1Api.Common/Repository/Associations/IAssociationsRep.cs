using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Repository.Associations
{
    public interface IAssociationsRep
    {
         List<Associations1> GetAssociations();
         Task CreateAssociation([FromForm] AssociationsDto associationsDto);
         Task UpdateAssociation(int id, [FromForm] AssociationsDto associationsDto);
         void DeleteAssociation(int id);
         Associations1 IdAssociation(int id);
    }
}
