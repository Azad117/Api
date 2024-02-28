using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;

namespace Product1Api.Common.ApplicationServices.Attributes
{
    public interface IAttributeTabSer
    {
        List<AttributeTab1> getattributetab();
        Task createattributetab([FromForm] AttributeTabDto attributetabDto);
        Task updateattributetab(int id,[FromForm] AttributeTabDto attributetabDto);
        AttributeTab1 idattributetab(int id);
        void deleteattributetab(int id);
    }
}
