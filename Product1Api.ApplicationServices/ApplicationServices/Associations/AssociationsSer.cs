using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Associations;
using Product1Api.Common.Models.Associations;
using Product1Api.Common.Repository.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.ApplicationServices.ApplicationServices.Associations
{
    public class AssociationsSer: IAssociationsSer
    {

        private readonly IAssociationsRep _associationsRep;

        public AssociationsSer(IAssociationsRep associationsRep)
        {
            _associationsRep = associationsRep;
        }
        public List<Associations1> getassociations()
        {
            return _associationsRep.GetAssociations();
        }
        public async Task createassociation([FromForm] AssociationsDto associationsDto)
        {
            _associationsRep.CreateAssociation(associationsDto);
        }
        public async Task updateassociation(int id, [FromForm] AssociationsDto associationsDto)
        {
            _associationsRep.UpdateAssociation(id, associationsDto);

        }
        public void deleteassociation(int id)
        {
            _associationsRep.DeleteAssociation(id);
        }
        public Associations1 idassociation(int id)
        {
            return _associationsRep.IdAssociation(id);
        }
    }
}
