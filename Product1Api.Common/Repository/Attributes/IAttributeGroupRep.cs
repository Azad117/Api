using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Repository.Attributes
{
    public interface IAttributeGroupRep
    {
        List<AttributeGroup1> GetAttributeGroup();
        Task CreateAttributeGroup([FromForm] AttributeGroupDto attributegroupDto);
        Task UpdateAttributeGroup(int id,[FromForm] AttributeGroupDto attributegroupDto);
        AttributeGroup1 IdAttributeGroup(int id);
        void DeleteAttributeGroup(int id);
    }
}
