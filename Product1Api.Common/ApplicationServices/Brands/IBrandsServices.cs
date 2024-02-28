using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.ApplicationServices.Brands
{
    public interface IBrandsServices
    {
        List<Brands1> getbrands();

        Task createbrand([FromForm] BrandsDto brandsdto);

        Task updatebrand(int id, [FromForm] BrandsDto brandsdto);

        void deletebrand(int id);

        Brands1 idbrand(int id);
    }
}
