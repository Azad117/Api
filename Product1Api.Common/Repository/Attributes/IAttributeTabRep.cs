using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Repository.Attributes
{
    public interface IAttributeTabRep
    {
        List<AttributeTab1> GetAttributeTab();
        Task CreateAttributeTab([FromForm] AttributeTabDto attributetabDto);
        Task UpdateAttributeTab(int id,[FromForm] AttributeTabDto attributetabDto);
        AttributeTab1 IdAttributeTab(int id);
        void DeleteAttributeTab(int id);
    }
}
