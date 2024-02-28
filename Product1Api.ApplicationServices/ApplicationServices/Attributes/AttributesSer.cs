using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;
using Product1Api.Common.Repository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product1Api.Common.ApplicationServices.Attributes;

namespace Product1Api.ApplicationServices.ApplicationServices.Attributes
{
    public class AttributesSer : IAttributesSer
    {
        private readonly IAttributesRep _attributesRep;

        public AttributesSer(IAttributesRep attributesRep)
        {
            _attributesRep = attributesRep;
        }
        public List<Attributes1> getattributes()
        {
            return _attributesRep.GetAttributes();
        }
        public async Task createattributes([FromForm] AttributesDto attributesDto)
        {
            _attributesRep.CreateAttributes(attributesDto);
        }
        public async Task updateattributes(int id, [FromForm] AttributesDto attributesDto)
        {
            _attributesRep.UpdateAttributes(id,attributesDto);
        }
        public void deleteattributes(int id)
        {
            _attributesRep.DeleteAttributes(id);
        }
        public Attributes1 idattributes(int id)
        {
            return _attributesRep.IdAttributes(id);
        }
    }
}
