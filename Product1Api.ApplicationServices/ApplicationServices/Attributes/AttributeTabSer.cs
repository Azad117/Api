using Product1Api.Common.ApplicationServices.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product1Api.Common.Repository.Attributes;
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;

namespace Product1Api.ApplicationServices.ApplicationServices.Attributes
{
    public class AttributeTabSer : IAttributeTabSer
    {
        private readonly IAttributeTabRep _attributetabRep;

        public AttributeTabSer(IAttributeTabRep attributetabRep)
        {
            _attributetabRep = attributetabRep;
        }
        public List<AttributeTab1> getattributetab()
        {
            return _attributetabRep.GetAttributeTab();
        }
        public async Task createattributetab([FromForm] AttributeTabDto attributetabDto)
        {
            _attributetabRep.CreateAttributeTab(attributetabDto);
        }
        public async Task updateattributetab(int id, [FromForm] AttributeTabDto attributetabDto)
        {
            _attributetabRep.UpdateAttributeTab(id,attributetabDto);

        }
        public void deleteattributetab(int id)
        {
            _attributetabRep.DeleteAttributeTab(id);
        }
        public AttributeTab1 idattributetab(int id)
        {
            return _attributetabRep.IdAttributeTab(id);
        }
    }
}
