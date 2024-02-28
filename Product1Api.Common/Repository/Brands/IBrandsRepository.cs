using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Brands;

namespace Product1Api.Common.Repository.Brands
{
    public interface IBrandsRepository
    {
        List<Brands1> GetBrands();

        Task CreateBrand([FromForm] BrandsDto brandsdto);

        Task UpdateBrand(int id, [FromForm]  BrandsDto brandsdto);

        void DeleteBrand(int id);

        Brands1 IdBrand(int id);

    }
}
