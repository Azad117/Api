using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;

namespace Product1Api.Common.ApplicationServices.Attributes
{
    public interface IAttributeGroupSer
    {
        List<AttributeGroup1> getattributegroup();
        Task createattributegroup([FromForm] AttributeGroupDto attributegroupDto);
        Task updateattributegroup(int id,[FromForm] AttributeGroupDto attributegroupDto);
        AttributeGroup1 idattributegroup(int id);
        void deleteattributegroup(int id);

    }
}
