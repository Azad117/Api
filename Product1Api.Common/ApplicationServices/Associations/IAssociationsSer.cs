using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.ApplicationServices.Associations
{
    public interface IAssociationsSer
    {
        List<Associations1> getassociations();
        Task createassociation([FromForm] AssociationsDto associationsDto);
        Task updateassociation(int id, [FromForm] AssociationsDto associationsDto);
        void deleteassociation(int id);
        Associations1 idassociation(int id);
    }
    
    
}
