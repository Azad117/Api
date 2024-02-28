using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Attributes;
using Product1Api.Common.Models.Attributes;
using Product1Api.Common.Repository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.ApplicationServices.ApplicationServices.Attributes
{
    public class AttributeGroupSer : IAttributeGroupSer
    {
        private readonly IAttributeGroupRep _attributegroupRep;

        public AttributeGroupSer(IAttributeGroupRep attributegroupRep)
        {
            _attributegroupRep = attributegroupRep;
        }
        public List<AttributeGroup1> getattributegroup()
        {
            return _attributegroupRep.GetAttributeGroup();
        }
        public async Task createattributegroup([FromForm] AttributeGroupDto attributegroupDto)
        {
            _attributegroupRep.CreateAttributeGroup(attributegroupDto);
        }
        public async Task updateattributegroup(int id, [FromForm] AttributeGroupDto attributegroupDto)
        {
            _attributegroupRep.UpdateAttributeGroup(id,attributegroupDto);

        }
        public void deleteattributegroup(int id)
        {
            _attributegroupRep.DeleteAttributeGroup(id);
        }
        public AttributeGroup1 idattributegroup(int id)
        {
            return _attributegroupRep.IdAttributeGroup(id);
        }
    }
}
