using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.ApplicationServices.Attributes
{
    public interface IAttributesSer
    {
        List<Attributes1> getattributes();
        Task createattributes([FromForm] AttributesDto attributesDto);
        Task updateattributes(int id,[FromForm] AttributesDto attributesDto);
        Attributes1 idattributes(int id);
        void deleteattributes(int id);
    }
}
