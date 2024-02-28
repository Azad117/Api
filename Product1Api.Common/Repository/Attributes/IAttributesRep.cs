using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Repository.Attributes
{
    public interface IAttributesRep
    {
        List<Attributes1> GetAttributes();
        Task CreateAttributes([FromForm] AttributesDto attributesDto);
        Task UpdateAttributes(int id,[FromForm] AttributesDto attributesDto);
        Attributes1 IdAttributes(int id);
        void DeleteAttributes(int id);
    }
}
